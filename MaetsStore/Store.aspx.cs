using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaetsStore.Classes;

namespace MaetsStore
{
    public partial class Store : System.Web.UI.Page
    {
        GameFactory gameFactory = new GameFactory();

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowImgs();
           
            //if (!IsPostBack)
            //{
            //    if ((string)Session["uname"] != null)
            //    { if(lit == true)
            //         Debug.WriteLine("👌");

            //    }

            //    else
            //    {
            //        Response.Redirect("Login.aspx");
            //    }
            //}
        }

        //int id = 0;
        //THIS METHOD DOES TOO MUCH, maybe make a StoreLogic class?
        public List<Game> GetGames()
        {
            if (GameFactory.games.Count == 0)
                return gameFactory.MakeGames();
            else
                return GameFactory.games;
        }

        private void ShowImgs()
        {
            DataTable tb = new DataTable();
            tb.Columns.Add("imgurl");

            string[] filesindirectory = Directory.GetFiles(Server.MapPath("~/Images/"));


            foreach (string item in filesindirectory)
            {
                string ImagePath = String.Format("~/Images/{0}", Path.GetFileName(item));
                tb.Rows.Add(ImagePath);
            }

            //lVStaffPhotoList.DataSource = tb;
            //lVStaffPhotoList.DataBind();

        }
        //public void ResizeImages(System.Drawing.Image image, out List<System.Drawing.Image> resizedImages)
        //{
        //    resizedImages = null;
        //    const int maxResizedDimension = 200;
        //    //Resizes the image to suitable size
        //    Size resizedSize;
        //    if (image.Width > image.Height)
        //    {
        //        resizedSize = new Size(maxResizedDimension, (int)Math.Floor((image.Height / (image.Width * 1.0f)) * maxResizedDimension));
        //    }
        //    else
        //    {
        //        //If height > width = 200px,200px
        //        resizedSize = new Size((int)Math.Floor((image.Width / (image.Width * 1.0f)) * maxResizedDimension), maxResizedDimension);
        //    }
        //    Bitmap resizedBitMapImage = new Bitmap(image, resizedSize);
        //    resizedImages.Add((System.Drawing.Image)resizedBitMapImage);
        //}
    }

}
