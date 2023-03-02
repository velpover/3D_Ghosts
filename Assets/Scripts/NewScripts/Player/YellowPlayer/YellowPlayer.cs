using System;
using UnityEngine;

namespace NewScene
{
    public class YellowPlayer : Player
    {
        private float helth = 100f;
        private float _velocity = 15f;

        [SerializeField] private KeyInput _keyInput;
        [SerializeField] private PlayerMove _playerMove;

        private void Awake()
        {
            _keyInput.KeyQDown += UpVelocity;
            _keyInput.KeyQUP += DownVelocity;

        }

        private void OnDestroy()
        {
            _keyInput.KeyQDown -= UpVelocity;
            _keyInput.KeyQUP -= DownVelocity;
        }
        void OnEnable()
        {
            PlayerSwap.SetActivePos(transform);
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
            _velocity = 25f;
            _playerMove.SetVelocity();
        }

        private void DownVelocity()
        {
            _velocity = 15f;
            _playerMove.SetVelocity();
        }
    } 
}

