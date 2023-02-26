using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewScene
{
    [RequireComponent(typeof(KeyInput))]
    public class Scythe : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private KeyInput _keyinput;

        private float _damage = 20f;
        private bool _isAttack = false;


        private void Awake()
        {

            _keyinput.KeyEDown += Attack;
            _keyinput.KeyEUP += EndAttack;

        }

        private void OnDestroy()
        {
            _keyinput.KeyEDown -= Attack;
            _keyinput.KeyEUP -= EndAttack;
        }           
        private void Attack()
        {
            _animator.SetBool("Attack", true);
            _isAttack = true;
        }

        private void EndAttack()
        {
            _animator.SetBool("Attack", false);
            _isAttack = false;
        }


        private void OnCollisionEnter(Collision collisionInfo)
        {
            if (_isAttack) TakeDamage(collisionInfo.gameObject, 20f);
        }

        private void TakeDamage(GameObject obj, float damage)
        {
            Enemy enemy = obj.GetComponent<Enemy>();

            if (enemy != null)
            {
                Debug.Log("Hit");
                enemy?.TakeHit(damage);
            }
        }
    }
}

