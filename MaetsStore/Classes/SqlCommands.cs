using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MaetsStore.Classes;

namespace MaetsStore
{
    public class SqlCommands
    {
        SqlController sqlController = new SqlController();
        SqlCommand command;
        SqlDataReader dataReader;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        internal delegate bool SqlDoubleString(string input1, string input2);
        internal delegate bool SqlStringNInt(string sqlColumn, int newNumber);

        internal int GetGameAmount(Game gameToCheck)
        {
            int gameAmount = 0;
            using (command = new SqlCommand("USE MaetsStore Select GameAmount FROM MaetsStore_Games WHERE GameId=@GameId", sqlController.conn))
            {
                command.Parameters.AddWithValue("@GameId", gameToCheck.GameId);
                sqlController.OpenSqlConn();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    gameAmount = Convert.ToInt32(dataReader["GameAmount"]);
                }
                return gameAmount;
            }
        }
        //Takes a method that uses 2 strings as parameters, returning a true/false
        internal bool SqlReturnsBoolDoubleString(SqlDoubleString userMethod, string input1, string input2)
        {
            sqlController.OpenSqlConn();
            bool result = userMethod(input1, input2);
            sqlController.CloseSqlConn();
            return result;
        }
        //For use when a value in the database needs to be updated
        internal bool SqlReturnsBoolStrNInt(SqlStringNInt userMethod, string strInput, int IntInput)
        {
            sqlController.OpenSqlConn();
            bool result = userMethod(strInput, IntInput);
            sqlController.CloseSqlConn();
            return result;
        }


        internal bool GetUserIdByNameAndPass(string username, string password)
        {

            using (command = new SqlCommand("SELECT UserName, UserPassword, UserGuid FROM MaetsStore_User WHERE UserName=@UserName", sqlController.conn))
            {
                command.Parameters.AddWithValue("@UserName", username);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    // dataReader.Read() = we found user(s) with matching username!

                    string dbUserName = dataReader["UserName"].ToString();
                    string dbPassword = dataReader["UserPassword"].ToString();
                    string dbUserGuid = dataReader["UserGuid"].ToString().ToLower();
                    // Hash the UserGuid from the database with the password we want to check
                    // Same way as when we saved it to the database in the first place. (see AddUser() function)
                    string hashedPassword = Encryption.EncryptPass(password + dbUserGuid);

                    if (dbPassword == hashedPassword)
                    {
                        // The password is correct
                        username = dbUserName;
                        return true;
                    }
                }
            }
            // userId is 0 if no user was found
            return false;
        }

        //Adds a user to the database
        internal bool AddUser(string username, string password)
        {
            //Create a unique Guid for the user.
            Guid userGuid = System.Guid.NewGuid();

            string nonQuery = "INSERT INTO MaetsStore_User VALUES (@UserName, @UserPassword, @UserGuid)";

            using (command = new SqlCommand(nonQuery, sqlController.conn))
            {
                command.Parameters.AddWithValue("@UserName", username);
                command.Parameters.AddWithValue("@UserPassword", Encryption.EncryptPass(password + userGuid)); // store the hashed value
                command.Parameters.AddWithValue("@UserGuid", userGuid); // store the Guid


                command.ExecuteNonQuery();
            }
            return true;
        }

        internal DataTable GetDb()
        {
            command = new SqlCommand("Select * From MaetsStore_Games", sqlController.conn);
            sqlController.OpenSqlConn();
            da.SelectCommand = command;
            dataReader = command.ExecuteReader();
            dataReader.Close();
            da.Fill(dt);
            sqlController.CloseSqlConn();
            da.Dispose();
            return dt;
        }
    }
}