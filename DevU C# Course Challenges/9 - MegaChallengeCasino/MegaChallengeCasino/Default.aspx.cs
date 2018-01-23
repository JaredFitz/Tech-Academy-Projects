using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeCasino
{
    public partial class Default : System.Web.UI.Page
    {
        Random random = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            // First time page load put three random images at the top 
            // and set the starting Money to $100

            if (!Page.IsPostBack)
            {
                double wallet = 100.00;
                ViewState.Add("Wallet", wallet);
                moneyLabel.Text = String.Format("Player's Money: {0:C}", wallet);
                int[] visibleSlotIndexes = randomSlots();
                slotPictures(visibleSlotIndexes);
            }
        }

        protected void leverButton_Click(object sender, EventArgs e)
        {
            // First check cash on hand to see if the bet is higher than the wallet, 
            // not a number, or a negative/0 bet.  Different error messages depending on result of check.
            if (!walletCheck(out double bet)) { return; };

            // If the bet can happen, do the random spin & change pictures
            int[] visibleSlotIndexes = randomSlots();
            slotPictures(visibleSlotIndexes);

            // Check to see if the combination is a winner - cherries, bars, and 7s 
            // are all that matters (indexes of 3, 1, and 9 in the picture array).  
            // Return if it's a winner and the multiplier
            int winningMultiplier = checkWinner(visibleSlotIndexes);


            // Take money out of wallet from bet & add in if any was won.  Display the winner/loser message
            settleUp(winningMultiplier, bet);
            
        }

        private bool walletCheck(out double bet)
        {
            // Check Parsability and >0
            if (!Double.TryParse(betTextBox.Text.Trim(), out bet)) { resultLabel.Text = "Come on, enter a real number please"; return false; }

            if ((double)ViewState["Wallet"] == 0) { resultLabel.Text = "Looks like you're out of money - better luck next time!"; return false; }

            if (bet <= 0) { resultLabel.Text = "Don't try to cheat!  Enter an actual bet!"; return false; }

            if ((double)ViewState["Wallet"] < bet) { resultLabel.Text = "You don't have that kind of money!"; return false; }

            return true;
        }

        private int[] randomSlots()
        {
            int[] slotArray = new int[3];
            for (int i = 0; i < 3; i++)
            { slotArray[i] = random.Next(0, 11); }
            return slotArray;
        }

        private void slotPictures(int[] slotIndexes)
        {
            string[] slotPictureValues = new string[12] { "Bar.png", "Bell.png", "Cherry.png", "Clover.png", "Diamond.png", "HorseShoe.png", "Lemon.png", "Orange.png", "Plum.png", "Seven.png", "Strawberry.png", "Watermelon.png" };

            firstSlotImage.ImageUrl = "~/Images/" + slotPictureValues[slotIndexes[0]];
            secondSlotImage.ImageUrl = "~/Images/" + slotPictureValues[slotIndexes[1]];
            thirdSlotImage.ImageUrl = "~/Images/" + slotPictureValues[slotIndexes[2]];
        }

        private int checkWinner(int[] slotIndexes)
        {
            // index 0 is bar, index 2 is cherry, index 9 is 7s
            // count cherries
            int cherries = 0;
            for (int i = 0; i < slotIndexes.Length; i++) { if (slotIndexes[i] == 2) { cherries++; } }

            // if any of the slots are bar, it is not a winner
            if (slotIndexes[0] == 0 || slotIndexes[1] == 0 || slotIndexes[2] == 0) { return 0; } // checks for any bars
            else if (slotIndexes[0] == 9 && slotIndexes[1] == 9 && slotIndexes[2] == 9) { return 100; } // checks for 3 7s
            else if (cherries > 0) { return cherries + 1; }
            else { return 0; }
        }

        private void settleUp(int winningMultiplier, double bet)
        {
            double wallet = (double)ViewState["Wallet"];
            if (winningMultiplier == 0) { resultLabel.Text = String.Format("Sorry, you lost {0:C}.  Better luck next time.", bet); wallet -= bet; }
            else { resultLabel.Text = String.Format("You bet {0:C} and won {1:C}!", bet, bet * winningMultiplier); wallet -= bet; wallet += winningMultiplier * bet; }

            moneyLabel.Text = String.Format("Player's Money: {0:C}", wallet);
            ViewState["Wallet"] = wallet;
        }
        
        protected void resetButton_Click(object sender, EventArgs e)
        {
            double wallet = 100.00;
            ViewState["Wallet"] = wallet;
            moneyLabel.Text = String.Format("Player's Money: {0:C}", wallet);
            resultLabel.Text = "You must have had a rough go, let's start over!";
        }
    }
}