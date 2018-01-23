using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeFirstPapaBobsPizza
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void purchaseButton_Click(object sender, EventArgs e)
        {
            double totalPrice = 0;

            //Finding size
            if (babySizeRadioButton.Checked)
            {
                totalPrice += 10;
            }
            else if (mamaSizeRadioButton.Checked)
            {
                totalPrice += 13;
            }
            else
            {
                totalPrice += 16;
            }

            //Crust
            totalPrice += ((deepDishRadioButton.Checked) ? 2 : 0);

            //Toppings
            totalPrice += ((pepperoniCheckBox.Checked) ? 1.5 : 0);
            totalPrice += ((onionCheckBox.Checked) ? .75 : 0);
            totalPrice += ((greenPepperCheckBox.Checked) ? .5 : 0);
            totalPrice += ((redPepperCheckBox.Checked) ? .75 : 0);
            totalPrice += ((anchoviesCheckBox.Checked) ? 2 : 0);

            //Special Deal
            if ((pepperoniCheckBox.Checked && greenPepperCheckBox.Checked && anchoviesCheckBox.Checked) 
                || (pepperoniCheckBox.Checked && redPepperCheckBox.Checked && onionCheckBox.Checked))
            {
                totalPrice -= 2;
            }

            finalPriceLabel.Text = totalPrice.ToString();
        }
    }
}