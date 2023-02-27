using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace NewScene
{
    public class LightAttack : MonoBehaviour
    {
        [SerializeField] Transform _target;

        private Vector3 _cubeSpotAttack = new Vector3(5, 0.1f, 5);
        private Vector3 _cubeAroundAttack = new Vector3(7.5f, 0.1f, 7.5f);
        private Vector3 _correct = new Vector3(0, 3, 0);

        private LayerMask _layerMaskEnemy = 1 << 7;
        private RaycastHit[] _hitsInfo = new RaycastHit[4];

        private float _spotDamage = 4f;
        private float _aroundDamage = 2f;
        private float _maxDistance = 4f;

        private bool _spot = false;
        private bool _around = false;


        private void OnEnable()
        {
            StartCoroutine(ILightAttack());
        }



        private void SpotAttack()
        {
            int j = Physics.BoxCastNonAlloc(_target.position, _cubeSpotAttack, Vector3.down, _hitsInfo, Quaternion.identity, _maxDistance, _layerMaskEnemy);

            for (int i = 0; i < j; i++)
            {
                TakeDamage(_hitsInfo[i].collider.gameObject, _spotDamage);

            }
        }


        private void AroundAttack()
        {
            int j = Physics.BoxCastNonAlloc(transform.position + _correct, _cubeAroundAttack, Vector3.down, _hitsInfo, Quaternion.identity, _maxDistance, _layerMaskEnemy);

            for (int i = 0; i < j; i++)
            {
                TakeDamage(_hitsInfo[i].collider.gameObject, _aroundDamage);
            }
        }



        private void TakeDamage(GameObject obj, float damage)
        {
            Enemy enemy = obj.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy?.TakeHit(damage, true);
            }
        }


        public void LightSpotAttack()
        {
            _spot = true;
        }

        public void LightAroundAttack()
        {
            _around = true;
        }

        public void StopAttack()
        {
            _spot = false;
            _around = false;
        }


        IEnumerator ILightAttack()
        {

            while (true)
            {

                if (_spot)
                {
                    SpotAttack();
                }
                else if (_around)
                {
                    AroundAttack();
                }

                yield return new WaitForSeconds(0.5f);
            }
        }

    }
}

