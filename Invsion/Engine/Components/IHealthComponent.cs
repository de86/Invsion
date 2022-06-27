using System;
using System.Collections.Generic;
using System.Text;

namespace Invsion.Engine.Components
{
    interface IHealthComponent
    {
        public void IncreaseHealth (int healthIncrease);
        public void DecreaseHealth (int healthIncrease);
        public int GetHealth ();
        public int GetMaxHealth ();
        public bool IsDead ();
    }
}
