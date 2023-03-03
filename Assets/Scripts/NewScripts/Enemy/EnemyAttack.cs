using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace NewScene
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private Enemy attacker;

        public event Action OnAttack;

        private Player _player;

        private int _layerPlayer = 6;
        private bool _play = false;

        private void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.layer == _layerPlayer)
            {

                _player = collision.gameObject.GetComponent<Player>();

                if (_player != null)
                {

                    StartCoroutine(InvokePerSec(_player));
                }
                
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            
            if (collision.gameObject.layer == _layerPlayer)
            {
                _play = false;
            }
        }

        IEnumerator InvokePerSec(Player _player)
        {
            _play = true;

            while (_play)
            {
                float health = _player.Health;

                _player.GetComponent<HealthSystem>()?.TakeDamage(ref health, attacker._attackDamage);

                OnAttack?.Invoke();

                yield return new WaitForSeconds(0.5f);

                _player.Health = health;
            }
        }
    }

}
