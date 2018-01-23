using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeHeroMonsterClassesPart2
{
    public partial class Default : System.Web.UI.Page
    {
        Random random = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
            Character hero = new Character();
            Character monster = new Character();
            Dice diceRoll = new Dice();

            hero.Name = "Vulcoran the Hero";
            hero.Health = 50;
            hero.DamageMaximum = 20;
            hero.AttackBonus = false;

            monster.Name = "Demigorgon the Monster";
            monster.Health = 40;
            monster.DamageMaximum = 25;
            monster.AttackBonus = true;

            // Bonus round at the beginning if either opponent gets a free extra round
            if (hero.AttackBonus)
                monster.Defend(hero.Attack(diceRoll));
            if (monster.AttackBonus)
                hero.Defend(monster.Attack(diceRoll));

            while (hero.Health > 0 && monster.Health > 0)
            {
                hero.Defend(monster.Attack(diceRoll));
                monster.Defend(hero.Attack(diceRoll));

                printStats(hero);
                printStats(monster);
                resultLabel.Text += "<br/>";
            }

            displayResult(hero, monster);
        }

        private void printStats(Character character)
        {
            resultLabel.Text += String.Format("Name: {0} - Health: {1} - DamageMaximum: {2} - AttackBonus: {3}<br/>",
                character.Name,
                character.Health,
                character.DamageMaximum,
                character.AttackBonus);
        }

        private void displayResult(Character opponent1, Character opponent2)
        {
            if (opponent1.Health <= 0 && opponent2.Health <= 0)
                resultLabel.Text += String.Format("Both {0} and {1} were vanquished in the battle.", opponent1.Name, opponent2.Name);
            else if (opponent1.Health <= 0)
                resultLabel.Text += String.Format("{0} defeats {1}", opponent2.Name, opponent1.Name);
            else
                resultLabel.Text += String.Format("{0} defeats {1}", opponent1.Name, opponent2.Name);
        }
    }
    
    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }

        Random random = new Random();
        public int Attack(Dice diceRoll)
        {
            diceRoll.Sides = this.DamageMaximum; //Sets the sides of the dice to the damage maximum

            return diceRoll.Roll();
        }

        public void Defend(int damage)
        {
            this.Health -= damage;
        }
    }

    class Dice
    {
        public int Sides { get; set; }

        Random random = new Random();
        public int Roll()
        {
            return random.Next(Sides + 1); //assumes there's a 0 side to the dice as well - missed attacks should happen sometimes
        }
    }
}