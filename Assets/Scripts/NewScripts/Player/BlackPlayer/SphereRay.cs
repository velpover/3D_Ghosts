using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewScene
{
    public class SphereRay : MonoBehaviour
    {

        [SerializeField] private Transform _player;
        [SerializeField] private Transform _staff;

        [SerializeField] private KeyInput _keyInput;

        private float _velocity = 12f;
        private Transform _cube;

        private bool _isKeyEDown=false;
        private void Awake()
        {
            _keyInput.KeyEDown += StartCor;

            _keyInput.KeyEUP +=StopCor;

        }

        private void OnDisable()
        {
            _keyInput.KeyEDown -=StartCor;

            _keyInput.KeyEUP -= StopCor;
        }

        public void StartCor()
        {
            StartCoroutine(SkullMove());
        }
        public void StopCor()
        {
            _isKeyEDown = false;
        }
        IEnumerator SkullMove()
        {
            _isKeyEDown = true;
            while (_isKeyEDown)
            { 
                transform.position = transform.position + _player.forward * Time.deltaTime *_velocity; 
                yield return null;
            }

            while (!_isKeyEDown)
            {
                transform.position = Vector3.Lerp(transform.position, _staff.position, 0.1f);
                yield return null;
            }
        }
        private void OnTriggerEnter(Collider other)
        {

            Debug.Log("hit");
        }
    }

}
