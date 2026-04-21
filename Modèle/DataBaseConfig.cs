using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerInformation;
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
        public Player GetPlayersPseudo(int playerId, string fileName)
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
            return CreateTable("Game", columns, fileName);
        }
        public bool CreateRoundTable(string fileName)
        {
            string columns = "RoundID INTEGER PRIMARY KEY AUTOINCREMENT, FOREIGN KEY(GameID) REFERENCES Game(GameID), WinnerPlayerId INTEGER REFERENCES Players(PlayerId)";
            return CreateTable("Round", columns, fileName);
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
