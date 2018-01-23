using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts
{
    public class Dart
    {
        public int Score { get; set; }
        public int Multiplier { get; set; }

        private Random _random;
        public Dart(Random random)
        {
            _random = random;
        }

        public void Throw()
        {
            Score = _random.Next(0, 21); // 0 will be a bullseye (actually worth 25)
            Multiplier = _random.Next(1, 21);

            if (Multiplier == 19) Multiplier = 2; // 5% chance there's a double
            else if (Multiplier == 20) Multiplier = 3; // 5% chance there's a triple
            else Multiplier = 1; // Every other throw is a single value

            if (Score == 0) Score = 25;
            if (Score == 25 && Multiplier == 3) Multiplier = 1; // There's no triple for bullseyes
        }

    }
}
