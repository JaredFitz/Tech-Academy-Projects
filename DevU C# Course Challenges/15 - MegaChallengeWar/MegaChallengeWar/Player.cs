using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaChallengeWar
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public List<Card> PlayerCards { get; set; }
    }
}
