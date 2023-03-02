using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAttack : MonoBehaviour
{
    public event Action OnAttack;


    private int _layerPlayer = 6;
    private bool _play= false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == _layerPlayer)
        {
            StartCoroutine(InvokePerSec());
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.layer == _layerPlayer)
        {
            _play = false;
        }
    }

    IEnumerator InvokePerSec()
    {   
        _play=true;

        while (_play)
        {
            OnAttack?.Invoke();
            yield return new WaitForSeconds(1f);
        }
    }
}
