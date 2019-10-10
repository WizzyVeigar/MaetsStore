using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;

namespace MaetsStore.Classes
{
    public class Sql
    {
        const string connectionstring = @"Server = ZBC-EMA-23111; Database=MaetsStore; Integrated Security=true";


        SqlConnection conn;
        SqlCommand command;
        SqlDataReader dataReader;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();

        public Sql()
        {
            conn = new SqlConnection(connectionstring);
        }

        internal bool GetUserIdByNameAndPass(string username, string password)
        {
            // this is the value we will return
                       
            using (SqlCommand cmd = new SqlCommand("SELECT UserName, UserPassword, UserGuid FROM MaetsStore_User WHERE UserName=@UserName", conn))
            {
                cmd.Parameters.AddWithValue("@UserName", username);
                conn.Open();
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    // dataReader.Read() = we found user(s) with matching username!

                    string dbUserName = dataReader["UserName"].ToString();
                    string dbPassword = dataReader["UserPassword"].ToString();
                    string dbUserGuid = dataReader["UserGuid"].ToString().ToLower();
                    // Hash the UserGuid from the database with the password we want to check
                    // Same way as when we saved it to the database in the first place. (see AddUser() function)
                    string hashedPassword = Encryption.EncryptPass(password + dbUserGuid).ToString();

                    if (dbPassword == hashedPassword)
                    {
                        // The password is correct
                        username = dbUserName;
                        return true;
                    }
                }
                conn.Close();
            }
            // userId is 0 if no user was found
            return false;
        }
        //Adds a user to the database
        public bool AddUser(string username, string password)
        {
            //Create a unique Guid for the user.
            Guid userGuid = System.Guid.NewGuid();

            string nonQuery = "INSERT INTO MaetsStore_User VALUES (@UserName, @UserPassword, @UserGuid)";

            using (command = new SqlCommand(nonQuery, conn))
            {
                command.Parameters.AddWithValue("@UserName", username);
                command.Parameters.AddWithValue("@UserPassword", Encryption.EncryptPass(password + userGuid).ToString()); // store the hashed value
                command.Parameters.AddWithValue("@UserGuid", userGuid); // store the Guid

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            return true;
        }


        public DataTable GetDb()
        {
            command = new SqlCommand("Select * From MaetsStore_Games", conn);
            conn.Open();
            da.SelectCommand = command;
            dataReader = command.ExecuteReader();
            dataReader.Close();
            da.Fill(dt);
            conn.Close();
            da.Dispose();
            return dt;
        }
    }
}
