using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeDaysBetweenDates
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            DateTime firstDate = firstCalendar.SelectedDate;
            DateTime secondDate = secondCalendar.SelectedDate;

            TimeSpan dateDifference = (firstDate > secondDate) ? 
                (firstDate - secondDate) : (secondDate - firstDate);

            resultLabel.Text = dateDifference.TotalDays.ToString();
        }
    }
}