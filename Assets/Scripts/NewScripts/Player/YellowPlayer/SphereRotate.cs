using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRotate : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private ParticleSystem _vfxAttack;
    private float _rotateVelocity = 4f;
    private float _damage = 5f;
    void FixedUpdate()
    {
        transform.RotateAround(_player.position,Vector3.up,_rotateVelocity );
    }

    private void OnTriggerEnter(Collider other)
    {
        TakeDamage(other.gameObject, _damage);
    }

    private void TakeDamage(GameObject obj, float damage)
    {
        Enemy enemy = obj.GetComponent<Enemy>();

        if (enemy != null)
        {
            _vfxAttack.Play();
            enemy?.TakeHit(damage);
        }
    }
}
