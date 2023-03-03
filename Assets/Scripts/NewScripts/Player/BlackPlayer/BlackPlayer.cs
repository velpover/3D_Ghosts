using System;
using System.Collections.Generic;
using UnityEngine;

namespace NewScene
{
    public class BlackPlayer : Player
    {
        private float _health = 21f;
        private float _maxHealth = 21f;

        [SerializeField] HealthBar _healthBar;
        private float _convertHpBar = 0.05f;
        public override float Health
        {
            get => _health;

            set
            {
                if (_health <= _maxHealth)
                {
                    _health = value;
                }
                else
                {
                    _health = _maxHealth;
                    _healthBar.ChangeBar(_health * _convertHpBar);
                }
            }
        }

        private float _velocity = 20f;

        private void Awake()
        {
            healthSystem.OnDiead += Dead;
        }

        private void OnDestroy()
        {
            healthSystem.OnDiead -= Dead;
        }

        void OnEnable()
        {
            PlayerSwap.SetActivePos(transform);

            _healthBar.ChangeBar(_health * _convertHpBar);
        }

        void OnDisable()
        {
            PlayerSwap.TakeTransformPos(transform);
        }

        public override float SetVelocity()
        {
            return _velocity;
        }

        protected override void Dead()
        {
            gameObject.SetActive(false);
        }
    }

}
