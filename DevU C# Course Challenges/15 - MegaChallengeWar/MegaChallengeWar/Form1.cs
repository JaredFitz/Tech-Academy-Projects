using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaChallengeWar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void warButton_Click(object sender, EventArgs e)
        {
            Game game = new Game(player1TextBox.Text, player2TextBox.Text);

            game.PlayGame(out string summary, out Player player1, out Player player2);

            DisplayGameResults(summary, player1, player2);
        }

        private void DisplayGameResults(string summary, Player player1, Player player2)
        {
            outputTextBox.Text = summary;
            player1ScoreLabel.Text = player1.Name + ": " + player1.Score.ToString();
            player2ScoreLabel.Text = player2.Name + ": " + player2.Score.ToString();
            
            if (player1.Score > player2.Score)
            { winnerLabel.Text = player1.Name + " wins!"; winnerLabel.ForeColor = Color.Red; }
            else if (player2.Score > player1.Score)
            { winnerLabel.Text = player2.Name + " wins!"; winnerLabel.ForeColor = Color.Blue; }
            else
            { winnerLabel.Text = player1.Name + " and " + player2.Name + " tied!"; winnerLabel.ForeColor = Color.Purple; }
        }
    }
}
