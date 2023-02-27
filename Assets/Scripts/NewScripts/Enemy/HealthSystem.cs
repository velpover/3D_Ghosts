using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace NewScene
{
    public class HealthSystem : MonoBehaviour
    {
        public event Action OnDiead;
        public void TakeDamage(ref float health, float damage)
        {
            health -= damage;

            if (health <= 0)
            {
                OnDiead?.Invoke();
            }
        }
    }

}
