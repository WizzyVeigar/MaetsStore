﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;


namespace MaetsStore.Classes
{
    //TODO Should split my logic classes into multiple pages: Gameslogic, LoginLogic...
    public class Logic
    {
        SqlCommands sqlCommands = new SqlCommands();

        internal bool Login(string username, string password)
        {
            if(sqlCommands.SqlReturnsBoolDoubleString(sqlCommands.GetUserIdByNameAndPass,username,password))
            {
                System.Diagnostics.Debug.WriteLine("Successful login");
                return true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong!");
                return false;
            }
        }

        internal void AddUser(string username, string password)
        {
            sqlCommands.SqlReturnsBoolDoubleString(sqlCommands.AddUser,username, password);
        }

        internal string[] GetGameImages(DataTable dt)
        {
            string path = @"C:\Users\Kenn5073\source\repos\MaetsStore\MaetsStore\Images";
            return Directory.GetFiles(path);
            //foreach (DataRow row in dt.Rows)
            //{
            //    //if(File.Exists(@"\images\" + row[1].ToString().ToLower()))
            //    //{

            //    //}
            //}
            //foreach (string s in Directory.GetFiles(path, "*.png").Select(Path.GetFileName))
            //    System.Diagnostics.Debug.WriteLine(s);

            //string[] a = Directory.GetFiles(path);
            

        }

        public DataTable GetDb()
        {
            return sqlCommands.GetDb();
        }
    }
}
