using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewScene
{
    public class EnemyAnimator : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void TakeHit()
        {
            StartCoroutine(StartAnimation("Hit"));
        }

        public void Walk()
        {
            _animator.SetBool("Go", true);
        }

        public void Attack()
        {
            StartCoroutine(StartAnimation("Attack"));
        }

        public void Died()
        {
            _animator.SetBool("Go", false);
            _animator.SetBool("Died", true);
        }

        IEnumerator StartAnimation(string name)
        {
            _animator.SetBool(name, true);
            yield return new WaitForSeconds(0.5f);
            _animator.SetBool(name, false);
        }
    }
}

