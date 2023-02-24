using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _animator.SetBool("Attack", true);
        }
        else _animator.SetBool("Attack", false);
        
    }
}
