using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeEpicSpiesAssignment
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                oldAssignmentEndCalendar.SelectedDate = DateTime.Now.Date;

                newAssignmentStartCalendar.SelectedDate = DateTime.Now.Date.AddDays(14);
                newAssignmentStartCalendar.VisibleDate = newAssignmentStartCalendar.SelectedDate;

                newAssignmentEndCalendar.SelectedDate = DateTime.Now.Date.AddDays(21);
                newAssignmentEndCalendar.VisibleDate = newAssignmentStartCalendar.SelectedDate;
            }
        }

        protected void assignButton_Click(object sender, EventArgs e)
        {
            string spyName = spyNameTextBox.Text;
            string assignmentName = assignmentNameTextBox.Text;

            DateTime oldDate = oldAssignmentEndCalendar.SelectedDate;
            DateTime newStart = newAssignmentStartCalendar.SelectedDate;
            DateTime newEnd = newAssignmentEndCalendar.SelectedDate;

            TimeSpan vacation = newStart.Subtract(oldDate);
            double vacationDays = vacation.TotalDays;

            TimeSpan assignmentTime = newEnd.Subtract(newStart);
            double assignmentDays = assignmentTime.TotalDays;

            double totalCost = 500;

            if (vacationDays < 14)
            {
                resultLabel.Text = "Error: Must allow at least two weeks between previous assignment and new assignment.";
                newAssignmentStartCalendar.SelectedDate = oldAssignmentEndCalendar.SelectedDate.AddDays(14);
                newAssignmentEndCalendar.SelectedDate = oldAssignmentEndCalendar.SelectedDate.AddDays(21);
            }
            else
            {
                totalCost += (500 * (assignmentDays-((assignmentDays == 0) ? 0:1))) + ((assignmentDays > 21) ? 1000 : 0);

                resultLabel.Text = String.Format("Assignment of {0} to assignment " +
                "Project: {1} is authorized.  Budget total: {2:C}",
                spyName, assignmentName, totalCost);
            }
        }

        protected void oldAssignmentEndCalendar_SelectionChanged(object sender, EventArgs e)
        {
            newAssignmentStartCalendar.SelectedDate = oldAssignmentEndCalendar.SelectedDate.AddDays(14);
            newAssignmentEndCalendar.SelectedDate = newAssignmentStartCalendar.SelectedDate.AddDays(7);
        }

        protected void newAssignmentStartCalendar_SelectionChanged(object sender, EventArgs e)
        {
            if (newAssignmentEndCalendar.SelectedDate < newAssignmentStartCalendar.SelectedDate)
            {
                newAssignmentEndCalendar.SelectedDate = newAssignmentStartCalendar.SelectedDate;
            }
        }

        protected void newAssignmentEndCalendar_SelectionChanged(object sender, EventArgs e)
        {
            if (newAssignmentEndCalendar.SelectedDate < newAssignmentStartCalendar.SelectedDate)
            {
                newAssignmentStartCalendar.SelectedDate = newAssignmentEndCalendar.SelectedDate;
            }
        }
    }
}