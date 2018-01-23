using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeEpicSpiesAssetTracker
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string[] evilNames = new string[0];
                ViewState.Add("Names", evilNames);

                double[] evilElections = new double[0];
                ViewState.Add("Elections", evilElections);

                double[] evilSub = new double[0];
                ViewState.Add("Subterfuge", evilSub);
            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            string[] evilNames = (string[])ViewState["Names"];
            double[] evilElections = (double[])ViewState["Elections"];
            double[] evilSub = (double[])ViewState["Subterfuge"];

            if (nameTextBox.Text == "" || electionTextBox.Text == "" || subTextBox.Text == "")
            {
                int lastName = evilNames.GetUpperBound(0);
                if (evilNames.Length == 0)
                {
                    resultLabel.Text = "Please input data into all fields.";
                    return;
                }

                resultLabel.Text = String.Format("Please input data into all fields.<br />Total Elections Rigged: {0}<br />Average Acts of Subterfuge per Asset: {1:N2}<br />(Last Asset you Added: {2})",
                    evilElections.Sum(),
                    evilSub.Average(),
                    evilNames[lastName].ToString());

                return;
            }

            Array.Resize(ref evilNames, evilNames.Length + 1);
            Array.Resize(ref evilElections, evilElections.Length + 1);
            Array.Resize(ref evilSub, evilSub.Length + 1);

            int lastIndex = evilNames.GetUpperBound(0);

            evilNames[lastIndex] = nameTextBox.Text;
            evilElections[lastIndex] = double.Parse(electionTextBox.Text);
            evilSub[lastIndex] = double.Parse(subTextBox.Text);

            ViewState["Names"] = evilNames;
            ViewState["Elections"] = evilElections;
            ViewState["Subterfuge"] = evilSub;

            resultLabel.Text = String.Format("Total Elections Rigged: {0}<br />Average Acts of Subterfuge per Asset: {1:N2}<br />(Last Asset you Added: {2})",
                    evilElections.Sum(),
                    evilSub.Average(),
                    evilNames[lastIndex].ToString());

            nameTextBox.Text = "";
            electionTextBox.Text = "";
            subTextBox.Text = "";
        }
    }
}