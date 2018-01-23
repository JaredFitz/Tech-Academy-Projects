using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengePostalCalculatorHelperMethods
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void changeSomething(object sender, EventArgs e)
        {
            // Do values exist in TextBoxes?
            if (!checkValues()) { return; }

            // Determining the Shipping Volume
            double volume;
            if (!checkVolume(out volume)) { return; }

            // Determine the multiplier based on the shipping method
            double shipMethodMultiplier = shipMethod();

            // Determine the cost
            double totalCost = volume * shipMethodMultiplier;

            // Final display
            resultLabel.Text = String.Format("Your parcel will cost {0:C} to ship", totalCost);
        }

        private bool checkValues()
        {
            if (!groundRadioButton.Checked
                && !airRadioButton.Checked
                && !nextDayRadioButton.Checked)
            { return false; }

            if (widthTextBox.Text.Trim().Length == 0
                || heightTextBox.Text.Trim().Length == 0)
            { return false; }

            return true;
        }

        private bool checkVolume(out double volume)
        {
            volume = 0;
            double width, height, length = 0;

            if (!Double.TryParse(widthTextBox.Text.Trim(), out width))
            { resultLabel.Text = "Width Text Box is incorrect"; return false; }

            if (!Double.TryParse(heightTextBox.Text.Trim(), out height))
            { resultLabel.Text = "Height Text Box is incorrect"; return false; }

            if (lengthTextBox.Text.Trim().Length == 0) { length = 1; }
            else if (!Double.TryParse(lengthTextBox.Text.Trim(), out length))
            { resultLabel.Text = "Length Text Box is incorrect"; return false; }

            volume = width * height * length;
            return true;
        }
        private double shipMethod()
        {
            //determining the multiplier based on the shipping method

            if (groundRadioButton.Checked) { return 0.15; }
            else if (airRadioButton.Checked) { return 0.25; }
            else if (nextDayRadioButton.Checked) { return 0.45; }
            else { return 0; }
        }
    }
}


/* Did with only one method in attemptToShip:
double shipMethodMultiplier;
if (groundRadioButton.Checked) { shipMethodMultiplier = 0.15; }
else if (airRadioButton.Checked) { shipMethodMultiplier = 0.25; }
else { shipMethodMultiplier = 0.45; }

double width, height = 0, length = 1.0;
if (!Double.TryParse(widthTextBox.Text, out width))
    { resultLabel.Text = "Width Text Box is incorrect"; return; }
if (!Double.TryParse(heightTextBox.Text, out height))
    { resultLabel.Text = "Height Text Box is incorrect"; return; }
if (!Double.TryParse(lengthTextBox.Text, out length)) {
    if (lengthTextBox.Text.Trim().Length == 0) { length = 10; }
    else { resultLabel.Text = "Length Text Box is incorrect"; return; }
}

double totalCost = width * height * length * shipMethodMultiplier;
            
resultLabel.Text = String.Format("Your parcel will cost {0:C} to ship", totalCost);
*/
