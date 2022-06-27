using System;
using System.Collections.Generic;
using System.Text;

namespace Invsion.Engine.Components
{
    public class HealthComponent : IHealthComponent
    {
        private int _maxHealth;
        private int _minHealth;
        private int _currentHealth;

        public HealthComponent (int maxHealth)
        {
            _maxHealth = maxHealth;
            _minHealth = 0;
            _currentHealth = maxHealth;
        }

        public HealthComponent (int maxHealth, int minHealth)
        {
            _maxHealth = maxHealth;
            _minHealth = minHealth;
            _currentHealth = maxHealth;
        }



        public void IncreaseHealth (int healthIncrease)
        {
            _currentHealth = Math.Clamp(_currentHealth + healthIncrease, _minHealth, _maxHealth);
        }



        public void DecreaseHealth (int healthIncrease)
        {
            _currentHealth = Math.Clamp(_currentHealth - healthIncrease, _minHealth, _maxHealth);
        }



        public int GetHealth ()
        {
            return _currentHealth;
        }



        public int GetMaxHealth ()
        {
            return _maxHealth;
        }


        public bool IsDead ()
        {
            return _currentHealth <= _minHealth;
        }
    }
}
