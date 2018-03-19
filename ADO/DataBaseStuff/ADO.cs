using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DataBaseStuff
{
    class ADO
    {
        Stopwatch timer = new Stopwatch();
        Random rnd = new Random();
        
        public void createDB()
        {
            string connectionString = @"Server=.\SQLExpress;Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionString);
            String query = "CREATE DATABASE Netflix;";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("done");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }

        public void createTable()
        {
            string connectionString = @"Server=.\SQLExpress;Initial Catalog=Netflix; Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionString);
            String query = "CREATE TABLE movieList(moviekey int NOT NULL IDENTITY, MovieName varchar(60)  NOT NULL, MinAge int, Rating int, PRIMARY KEY(movieKey))";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("done creating table");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }
        public void insertData()
        {
            string connectionString = @"Server=.\SQLExpress;Initial Catalog=Netflix; Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionString);
            String query = "INSERT INTO movieList(MovieName, MinAge, Rating) VALUES (@name, 14, 5)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", "movie");
            try
            {
                connection.Open();
                timer.Start();
                for (int i = 0; i < 100; i++)
                {
                    command.ExecuteNonQuery();
                }
                timer.Stop();
                Console.WriteLine("done inserting in {0}", timer.ElapsedMilliseconds);
                timer.Reset();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public void updateTable()
        {
            string connectionString = @"Server=.\SQLExpress;Initial Catalog=Netflix; Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionString);
            String query = "UPDATE movieList SET MovieName = @name, MinAge = 19";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", "newMovie");
            try
            {
                connection.Open();
                timer.Start();
                command.ExecuteNonQuery();
                timer.Stop();
                Console.WriteLine("done updating all rows in {0}", timer.ElapsedMilliseconds);
                timer.Reset();
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
 
            }
        }
        public void deleteFromTable()
        {
            string connectionString = @"Server=.\SQLExpress;Initial Catalog=Netflix; Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionString);
            String query = "DELETE FROM movieList";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                timer.Start();
                command.ExecuteNonQuery();
                timer.Stop();
                Console.WriteLine("deleted all rows in {0}", timer.ElapsedMilliseconds);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }

            }
        }
    }
}
