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
        [SerializeField] private ParticleSystem _vfxBlood;

        private  float _health=100f;

        private void Awake()
        {
            _healthSystem.OnDiead += _enemyAnimator.Died;
            _healthSystem.OnDiead += _enemyMoveTo.StopMove;
            _healthSystem.OnDiead += Diead;

        }

        private void OnDestroy()
        {
            _healthSystem.OnDiead -= _enemyAnimator.Died;
            _healthSystem.OnDiead -= _enemyMoveTo.StopMove;
            _healthSystem.OnDiead -= Diead;
        }

        public void TakeHit(float damage, bool type)
        {
            
            _healthSystem.TakeDamage(ref _health, damage);
       
            _enemyAnimator.TakeHit();

            _vfxBlood.Play();

        }

        public void MoveTo(Transform target)
        {
            _enemyAnimator.Walk();
            _enemyMoveTo.GoToPlayer(target);
        }

        public void Diead()
        {
            _enemyAnimator.Died();
            Destroy(gameObject,2f);
        }

    }

}