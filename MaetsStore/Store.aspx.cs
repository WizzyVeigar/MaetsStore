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
        Logic logic = new Logic();
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

        public List<Game> GetGames()
        {
            List<Game> games = new List<Game>();
            DataTable dt = logic.GetDb();
            string rowName;
            int rowAmount;
            float rowPrice;
            string rowImage = "";
            string[] gameImages = logic.GetGameImages(dt);

            foreach (DataRow row in dt.Rows)
            {
                rowName = row[1].ToString().ToLower();
                rowAmount = Convert.ToInt32(row[2]);
                rowPrice = float.Parse(row[3].ToString());
                foreach (string path in gameImages)
                {
                    path.ToLower();
                    if (path.Contains(rowName))
                    {
                        rowImage = rowName + ".png";
                        gameImages = gameImages.Where(s => s != path).ToArray();
                        break;
                    }
                }
                games.Add(new Game(rowName, rowAmount, rowPrice, rowImage));
            }
            return games;
        }


        private void ShowImgs()
        {
            DataTable tb = new DataTable();
            tb.Columns.Add("imgurl");

            string[] filesindirectory = Directory.GetFiles(Server.MapPath("~/Images/"));


            foreach (string item in filesindirectory)
            {
                string ImagePath = String.Format("~/Images/{0}", System.IO.Path.GetFileName(item));
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
