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
        SqlConnection connection;


        private void connect()

        { 
             string connectionString = @"Server=.\SQLExpress;Integrated Security=true";

            connection = new SqlConnection(connectionString);
        }

        /** 
           Create the Ado.Net database if not existent
        */

        public void createDB()
        {

            connect();
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
        /** 
            A Method to add a new table to the database
        */
        public void createTable()
        {
            connect();
            String query = "CREATE TABLE MovieList(MovieKey int NOT NULL IDENTITY, MovieName varchar(60)  NOT NULL, MinAge int, Rating int, PRIMARY KEY(movieKey))";
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

        /** 
            A Method to Insert random rows in the table
        */
        public void insertData()
        {
            connect();
            String query = "INSERT INTO movieList(MovieName, MinAge, Rating) VALUES (@name, 14, 5)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", "movie");
            try
            {
                connection.Open();
                timer.Start();
                for (int i = 0; i < 1000; i++)
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

        /** 
            A Method to Update all the rows in the table
        */
        public void updateTable()
        {
            connect();
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

        /** 
            A Method to delete all the rows in the table
        */
        public void deleteFromTable()
        {
            connect();
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
