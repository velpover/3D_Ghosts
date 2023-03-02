using System;
using UnityEngine;

namespace NewScene
{
    public class YellowPlayer : Player
    {
        private float _health = 100f;
        public override float Health { get =>_health; set=>_health=value; }

        private float _velocity = 15f;

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
            isActive = true;
            PlayerSwap.SetActivePos(transform);
        }

        void OnDisable()
        {
            isActive = false;
            PlayerSwap.TakeTransformPos(transform);
        }

        public override float SetVelocity()
        {
            return _velocity;
        }

        private void UpVelocity()
        {
            _velocity = 25f;
            _playerMove.SetVelocity();
        }

        private void DownVelocity()
        {
            _velocity = 15f;
            _playerMove.SetVelocity();
        }

        protected override void Dead()
        {
            gameObject.SetActive(false);
        }
    } 
}

