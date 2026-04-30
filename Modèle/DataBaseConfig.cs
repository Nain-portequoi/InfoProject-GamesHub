using PlayerInformation;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    public class DataBaseConfig
    {
        public List<Player> ListPlayersPseudo(string fileName)
        {
            List<Player> playersPseudo = new List<Player>();
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName); // Chemin vers la base de données
            bool ok = CreatePlayersTable(fileName);
            using (var connection = new SQLiteConnection($"Data Source={dbPath};"))             // Crée une connexion à la base de données SQLite
            {
                connection.Open();                                                              // Ouvre la connexion à la base de données (même principe qu'en C où l'on ouvrait le fichier avec fopen)
                var command = connection.CreateCommand();                                       // Crée une commande SQL pour interagir avec la base de données. C'est grâce à cette variable que l'on va pouvoir exécuter des requêtes SQL sur la base de données
                command.CommandText = "SELECT Pseudo FROM Players";                             // Sélectionne uniquement la colonne Pseudo de la table Players
                using (var reader = command.ExecuteReader())                                    // Exécute la requête et lit les résultats
                {
                    while (reader.Read())                                                       // Parcourt chaque ligne du résultat
                    {
                        Player player = new Player
                        (
                            reader.GetString(0)                                                 // Récupère la valeur de la colonne Pseudo (index 0) et l'assigne à la propriété Pseudo du joueur
                        );
                        playersPseudo.Add(player);                                              // Ajoute le joueur à la liste des pseudos (/!\ Attention, on ne récupère que les pseudos ! - Sera utilisé pour l'affichage des pseudos dans l'interface utilisateur)
                    }
                }
            }
            return playersPseudo;
        }
        public Player GetPlayersPseudo(int playerId, string fileName) ////// JSP si tu l'utilisais mais en fait elle récupere que le pseudo moi j'ai besoin de recuper l'id donc j'ai fait un GetPlayerAllInformations
        {
            Player player;
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName); // Chemin vers la base de données

            using (var connection = new SQLiteConnection($"Data Source={dbPath};"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Pseudo FROM Players WHERE PlayerId = @playerId";
                command.Parameters.AddWithValue("@playerId", playerId);                         // Ajoute un paramètre à la requête SQL pour éviter les injections SQL. Le paramètre @playerId est remplacé par la valeur de playerId lors de l'exécution de la requête.
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return player = new Player(reader.GetString(0));
                    }
                }
            }
            return null;
        }
        public Player GetPlayersAllInformations(int playerId, string fileName) 
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName); // Chemin vers la base de données

            using (var connection = new SQLiteConnection($"Data Source={dbPath};"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT PlayerId, Pseudo, FirstName, LastName FROM Players WHERE PlayerId = @playerId";
                command.Parameters.AddWithValue("@playerId", playerId);                         // Ajoute un paramètre à la requête SQL pour éviter les injections SQL. Le paramètre @playerId est remplacé par la valeur de playerId lors de l'exécution de la requête.
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // On récupère chaque colonne avec le bon type
                        int id = reader.GetInt32(0);       // Index 0 : PlayerId (int)
                        string pseudo = reader.GetString(1); // Index 1 : Pseudo (string)

                        // On récupère le prénom et nom (en gérant les valeurs potentiellement vides/nulles)
                        string prenom = reader.IsDBNull(2) ? "" : reader.GetString(2);
                        string nom = reader.IsDBNull(3) ? "" : reader.GetString(3);

                        // On crée l'objet complet
                        return new Player(pseudo, prenom, nom, id);
                    }
                }
                return null;
            }
        }

        public int GetPlayerID(string pseudo, string fileName)
        {
            int playerID;
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName); // Chemin vers la base de données

            using (var connection = new SQLiteConnection($"Data Source={dbPath};"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT PlayerId FROM Players WHERE Pseudo = @pseudo";
                command.Parameters.AddWithValue("@pseudo", pseudo);                         // Ajoute un paramètre à la requête SQL pour éviter les injections SQL. Le paramètre @pseudo est remplacé par la valeur de playerId lors de l'exécution de la requête.
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return playerID = reader.GetInt32(0);
                    }
                }
            }
            return -1;
        }

        public int GetNumberOfPlayers(string fileName)
        {
            int numberOfPlayers = 0;
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName); // Chemin vers la base de données
            using (var connection = new SQLiteConnection($"Data Source={dbPath};"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(PlayerId) FROM Players;";
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read()) // Lit la première ligne du résultat (il n'y en aura qu'une car COUNT() retourne une seule valeur)
                    {
                        numberOfPlayers = reader.GetInt32(0); // Récupère la valeur de la première colonne (index 0) qui contient le nombre de joueurs et l'assigne à la variable numberOfPlayers
                    }
                }
            }

            return numberOfPlayers;
        }
        public int GetGameID(string gameName, string fileName)
        {
            int gameID;
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName); // Chemin vers la base de données
            using (var connection = new SQLiteConnection($"Data Source={dbPath};"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT GameID FROM Games WHERE GameName = @gameName";
                command.Parameters.AddWithValue("@gameName",gameName);                         // Ajoute un paramètre à la requête SQL pour éviter les injections SQL. Le paramètre @playerId est remplacé par la valeur de playerId lors de l'exécution de la requête.
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return gameID = reader.GetInt32(0);
                    }
                }
            }
            return -1;
        }

        #region DataRetrieval
        public List<string> GetAllInfos(string fileName, string commandText)
        {
            List<string> infos = new List<string>();
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName); // Chemin vers la base de données
            using (var connection = new SQLiteConnection($"Data Source={dbPath};"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                try
                {
                    command.CommandText = commandText;                  // "SELECT * FROM Players"
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string info = reader[0].ToString();
                            for (int i = 1; i < reader.FieldCount; i++)
                            {
                                info += "\t\t" + reader[i].ToString();

                            }
                            infos.Add(info);
                        }
                    }
                }
                catch (Exception ex) 
                { 
                    throw new Exception($"Error executing query: {ex.Message}");
                }
            return infos;
            }
        }


        #endregion


        #region TableCreation
        private bool CreateTable(string tableName, string columns, string fileName)
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName); // Même commentaire que pour la méthode GetPlayersPseudo()
            using (var connection = new SQLiteConnection($"Data Source={dbPath}"))
            {
                connection.Open();                                                              // Même commentaire que pour la méthode GetPlayersPseudo()
                var command = connection.CreateCommand();                                       // Même commentaire que pour la méthode GetPlayersPseudo()
                command.CommandText = $"CREATE TABLE IF NOT EXISTS {tableName} ({columns})"; 
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating table {tableName}: {ex.Message}");
                    return false;
                }
            }
        }
        public bool CreatePlayersTable(string fileName)
        {
            string columns = "PlayerId INTEGER PRIMARY KEY AUTOINCREMENT, Pseudo TEXT NOT NULL, FirstName TEXT, LastName TEXT, ScoreTot INTEGER, Results TEXT, UNIQUE(Pseudo)";
            return CreateTable("Players", columns, fileName);
        }
        public bool CreateGameTable(string fileName)
        {
            string columns = "GameID INTEGER PRIMARY KEY AUTOINCREMENT, GameName TEXT NOT NULL, UNIQUE(GameName)";
            return CreateTable("Games", columns, fileName);
        }
        public bool CreateRoundTable(string fileName)
        {
            string columns = "RoundID INTEGER PRIMARY KEY AUTOINCREMENT, WinnerPlayerId INTEGER REFERENCES Players(PlayerId),GameID INTEGER REFERENCES Games(GameID)"; // J'ai modifié cette ligne là car il y avait un problème avec le foreign KEY avant c'etait ça : "RoundID INTEGER PRIMARY KEY AUTOINCREMENT, FOREIGN KEY(GameID) REFERENCES Game(GameID), WinnerPlayerId INTEGER ..."
            return CreateTable("Rounds", columns, fileName);
        }
        #endregion

        #region DataInsertion
        public void InsertPlayer(string pseudo, string firstName, string lastName, int scoreTot, string results, string fileName)
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            using (var connection = new SQLiteConnection($"Data Source={dbPath};"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Players (Pseudo, FirstName, LastName, ScoreTot, Results) VALUES (@pseudo, @firstName, @lastName, @scoreTot, @results)";
                command.Parameters.AddWithValue("@pseudo", pseudo);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@scoreTot", scoreTot);
                command.Parameters.AddWithValue("@results", results);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting player: {ex.Message}");
                    throw ex;
                }
            }
        }
        public void InsertGame(string gameName, string fileName)
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            using (var connection = new SQLiteConnection($"Data Source={dbPath};"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT OR IGNORE INTO Games (GameName) VALUES (@gameName)"; // J'ai mis un "OR IGNORE" Car si le jeu est déjà dans la base de donnée je pouvais plus jouer au jeux car il essaye de creeer un nouveau jeu qui est sencé etre etre unique mais il existe deja donc ca plante
                command.Parameters.AddWithValue("@gameName", gameName);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting game: {ex.Message}");
                    throw ex;
                }
            }
        }
        public void InsertRound(int winnerPlayerID, int gameID, string fileName)
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            using (var connection = new SQLiteConnection($"Data Source={dbPath};"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Rounds (winnerPlayerID , gameID) VALUES (@winnerPlayerId,@gameID)";
                command.Parameters.AddWithValue("@winnerPlayerId", winnerPlayerID);
                command.Parameters.AddWithValue("@gameID", gameID);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting game: {ex.Message}");
                    throw ex;
                }
            }
        }
        #endregion

        #region DataDeletion
        public bool DeletePlayer(int playerId, string fileName)
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            using (var connection = new SQLiteConnection($"Data Source={dbPath};"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Players WHERE PlayerId = @playerId";
                command.Parameters.AddWithValue("@playerId", playerId);
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting player: {ex.Message}");
                    return false;
                }
            }
        }

        public bool DeleteAllPlayers(string fileName)
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            using (var connection = new SQLiteConnection($"Data Source={dbPath};"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DROP TABLE IF EXISTS Players";
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting player: {ex.Message}");
                    return false;
                }
            }
        }

        #endregion
    }
}
