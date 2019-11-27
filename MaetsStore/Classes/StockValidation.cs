using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MaetsStore.Classes;

namespace MaetsStore
{
    public class StockValidation
    {
        SqlCommands sqlCommands = new SqlCommands();

        public bool IsThereStock(Game gameToCheck)
        {
            System.Diagnostics.Debug.WriteLine("Game has: " + gameToCheck.TempGameAmount);
            int stockAmount = sqlCommands.GetGameAmount(gameToCheck);
            if (gameToCheck.TempGameAmount >= 1)
            {
                gameToCheck.TempGameAmount--;
                System.Diagnostics.Debug.WriteLine(gameToCheck.TempGameAmount);
                return true;
            }
            return false; //just for now
        }
    }
}