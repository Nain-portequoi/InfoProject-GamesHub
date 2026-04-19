using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace InfoProject_GamesHub.Modèle
{
    public class DataBaseConfig
    {
        private bool CreateTable(string tableName, string columns)
        {
            using (var connection = new SqliteConnection("Data Source=GamesHub.db"))
            {
                connection.Open();
                var command = connection.CreateCommand();

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
        #region TableCreation

        public bool CreatePlayersTable()
        {
            string columns = "PlayerId INTEGER PRIMARY KEY AUTOINCREMENT, Pseudo TEXT NOT NULL, FirstName TEXT, LastName TEXT, ScoreTot INTEGER, Results TEXT, FOREIGN KEY(GameID) REFERENCES Game(GameID)";
            return CreateTable("Players", columns);
        }
        public bool CreateGameTable()
        {
            string columns = "GameID INTEGER PRIMARY KEY AUTOINCREMENT, GameName TEXT NOT NULL";
            return CreateTable("Game", columns);
        }
        public bool CreateRoundTable()
        {
            string columns = "RoundID INTEGER PRIMARY KEY AUTOINCREMENT, FOREIGN KEY(GameID) REFERENCES Game(GameID), WinnerPlayerId INTEGER REFERENCES Players(PlayerId)";
            return CreateTable("Round", columns);
        }
        #endregion

        #region DataInsertion
        public bool InsertPlayer(string pseudo, string firstName, string lastName, int scoreTot, string results)
        {
            using (var connection = new SqliteConnection("Data Source=GamesHub.db"))
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
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting player: {ex.Message}");
                    return false;
                }
            }
        }
        #endregion
    }
}
