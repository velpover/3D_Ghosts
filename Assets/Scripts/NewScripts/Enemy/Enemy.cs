using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewScene
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private HealthSystem _healthSystem;
        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private EnemyMoveTo _enemyMoveTo;


        private float _lightHealth = 100f;
        private float _collisonHealth = 100f;

        private void Awake()
        {
            _healthSystem.OnDiead += _enemyAnimator.Died;
            _healthSystem.OnDiead += _enemyMoveTo.StopMove;

        }

        private void OnDestroy()
        {
            _healthSystem.OnDiead -= _enemyAnimator.Died;
            _healthSystem.OnDiead -= _enemyMoveTo.StopMove;
        }

        public void TakeHit(float damage, bool type)
        {
            if (type)
            {
                _healthSystem.TakeDamage(ref _lightHealth, damage);

            }
            else
            {
                _healthSystem.TakeDamage(ref _collisonHealth, damage);
            }

            _enemyAnimator.TakeHit();

        }

        public void MoveTo(Transform target)
        {
            _enemyMoveTo.GoToPlayer(target);
        }

    }

}