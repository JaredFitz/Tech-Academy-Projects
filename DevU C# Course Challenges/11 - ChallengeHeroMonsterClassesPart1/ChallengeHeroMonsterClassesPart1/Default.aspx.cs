using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeHeroMonsterClassesPart1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Character hero = new Character();
            Character monster = new Character();

            hero.Name = "Vulcoran";
            hero.Health = 100;
            hero.DamageMaximum = 25;
            hero.AttackBonus = true;

            monster.Name = "Demigorgon";
            monster.Health = 200;
            monster.DamageMaximum = 15;
            monster.AttackBonus = false;

            int damage = hero.Attack();
            monster.Defend(damage);

            damage = monster.Attack();
            hero.Defend(damage);

            printStats(hero);
            printStats(monster);
            

        }
        private void printStats(Character character)
        {
            resultLabel.Text += String.Format("Name: {0} - Health: {1} - DamageMaximum: {2} - AttackBonus: {3}<br/>",
                character.Name,
                character.Health,
                character.DamageMaximum,
                character.AttackBonus);
        }
    }

    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }

        Random random = new Random();

        public int Attack()
        {
            int damage = random.Next(0, this.DamageMaximum);
            
            return damage;
        }

        public void Defend(int damage)
        {
            this.Health -= damage;
        }
    }
}