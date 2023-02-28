using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewScene
{
    public class SphereRotate : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private ParticleSystem _vfxAttack;

        private readonly float _rotateVelocity = 4f;
        private readonly float _damage = 5f;

        void FixedUpdate()
        {
            transform.RotateAround(_player.position, Vector3.up, _rotateVelocity);
        }

        private void OnTriggerEnter(Collider other)
        {
            TakeDamage(other.gameObject, _damage);
        }

        private void TakeDamage(GameObject obj, float damage)
        {
            ColliderEnemy enemy = obj.GetComponent<ColliderEnemy>();

            if (enemy != null)
            {
                _vfxAttack.Play();
                enemy.TakeHit(damage, false);
            }
        }
    }

}
