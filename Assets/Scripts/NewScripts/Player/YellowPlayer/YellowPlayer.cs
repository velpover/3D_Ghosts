using System;
using UnityEngine;

namespace NewScene
{
    public class YellowPlayer : Player
    {
        private float _maxHealth = 100f;

        private float _health = 100f;

        [SerializeField] HealthBar _healthBar;
        private float _convertHpBar = 0.01f;
        public override float Health
        {
            get => _health;

            set
            {
                if (_health <= _maxHealth)
                {
                    _health = value;
                    _healthBar.ChangeBar(_health * _convertHpBar);
                }
                else
                {
                    _health = _maxHealth;
                    _healthBar.ChangeBar(_health * _convertHpBar);
                }
            }
        }

        private float _velocity = 10f;

        [SerializeField] private KeyInput _keyInput;
        [SerializeField] private PlayerMove _playerMove;

        private void Awake()
        {
            _keyInput.KeyQDown += UpVelocity;
            _keyInput.KeyQUP += DownVelocity;

            healthSystem.OnDiead += Dead;

        }

        private void OnDestroy()
        {
            _keyInput.KeyQDown -= UpVelocity;
            _keyInput.KeyQUP -= DownVelocity;

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

        private void UpVelocity()
        {
            _velocity = 20f;
            _playerMove.SetVelocity();
        }

        private void DownVelocity()
        {
            _velocity = 10f;
            _playerMove.SetVelocity();
        }

        protected override void Dead()
        {
            gameObject.SetActive(false);
        }
    } 
}

