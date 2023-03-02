using System;
using System.Collections.Generic;
using UnityEngine;

namespace NewScene
{
    public class BlackPlayer : Player
    {
        private float _health = 20f;
        public override float Health { get => _health; set => _health = value; }

        private float _velocity = 25f;

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
