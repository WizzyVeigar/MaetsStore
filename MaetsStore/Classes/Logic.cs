using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;


namespace MaetsStore.Classes
{
    public class Logic
    {
        Sql sql = new Sql();

        public Logic()
        {
        }

        internal bool Login(string username, string password)
        {
            if(sql.GetUserIdByNameAndPass(username,password))
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
            sql.AddUser(username, password);
        }

        internal string[] GetGameImages(DataTable dt)
        {
            string path = @"C:\Users\pete168s\source\repos\ZbcGuideApp\ZbcGuideApp\ZbcGuideApp.Android\Resources\drawable";
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
            return sql.GetDb();
        }
    }
}
