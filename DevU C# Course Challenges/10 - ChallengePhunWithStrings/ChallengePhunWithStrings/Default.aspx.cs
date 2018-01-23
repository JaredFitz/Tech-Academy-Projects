using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengePhunWithStrings
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 1.  Reverse your name
            string name = "Jared Fitzpatrick";
            // In my case, the result would be:
            // robaT boB
            string reverseName = "";
            for (int i = name.Length-1; i >=0; i--)
            {
                reverseName += name[i];
            }

            // 2.  Reverse this sequence:
            string names = "Luke,Leia,Han,Chewbacca";
            // When you're finished it should look like this:
            // Chewbacca,Han,Leia,Luke

            string[] namesArray = names.Split(',');
            string reverseNames = "";
            for (int i = namesArray.Length - 1; i >= 0; i--)
            {
                reverseNames += namesArray[i] + ",";
            }

            // 3. Use the sequence to create ascii art:
            // *****luke*****
            // *****leia*****
            // *****han******
            // **Chewbacca***

            string[] asciiArray = names.Split(',');
            string asciiString = "";
            
            for (int i = 0; i < asciiArray.Length; i++)
            {
                asciiString += asciiArray[i].PadLeft((7 + asciiArray[i].Length / 2), '*').PadRight(14, '*') + "<br/>";   
            }

            // 4. Solve this puzzle:

            string puzzle = "NOW IS ZHEremove-me ZIME FOR ALL GOOD MEN ZO COME ZO ZHE AID OF ZHEIR COUNZRY.";

            // Once you fix it with string helper methods, it should read:
            // Now is the time for all good men to come to the aid of their country.
            puzzle = puzzle.ToLower().Replace("remove-me", "").Replace('z', 't');
            puzzle = puzzle[0].ToString().ToUpper() + puzzle.Substring(1);

            resultLabel1.Text = "Challenge 1:<br/>" + reverseName +
                "<br/><br/>Challenge 2:<br/>" + reverseNames.Remove(reverseNames.Length - 1) +
                "<br/><br/>Challenge 3:<br/>" + asciiString +
                "<br/><br/>Challenge 4:<br/>" + puzzle;
        }
    }
}