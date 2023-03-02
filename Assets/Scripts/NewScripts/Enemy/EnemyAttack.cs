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
            Debug.Log("contact");
            if (collision.gameObject.layer == _layerPlayer)
            {
                _player = collision.gameObject.GetComponent<Player>();
                if (_player != null)
                {
                    Debug.Log(_player.name);
                    StartCoroutine(InvokePerSec(_player));
                }
                
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            Debug.Log("leave");
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

                _player.Health = health;

                OnAttack?.Invoke();

                yield return new WaitForSeconds(1f);
            }
        }
    }

}
