using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRay : MonoBehaviour
{

    [SerializeField] private Transform _player;
    [SerializeField] private Transform _target;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.position = transform.position + _player.forward*Time.deltaTime*12f;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, _target.position, 0.1f);
        }
    }
}
