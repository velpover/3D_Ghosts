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
        [SerializeField] private EnemyAttack _enemyAttack;

        private Collider _col;

        private  float _health=100f;
        protected virtual float Amount { get => 5f;}

        private void Awake()
        {
            _healthSystem.OnDiead += _enemyAnimator.Died;
            _healthSystem.OnDiead += _enemyMoveTo.StopMove;
            _healthSystem.OnDiead += Diead;

            _enemyAttack.OnAttack += Attack;

            _col = GetComponent<Collider>();
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

        public void Attack()
        {
            _enemyAnimator.Attack();
        }
        public void MoveTo(Transform target)
        {
            _enemyAnimator.Walk();

            _enemyMoveTo.GoToPlayer(target);
        }

        private void Diead()
        {
            Score.PlusScore(Amount);

            _enemyAnimator.Died();

            Destroy(_col);
            Destroy(gameObject,2f);
        }

    }

}