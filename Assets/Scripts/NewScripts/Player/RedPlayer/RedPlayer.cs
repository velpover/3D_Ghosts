
using System;
using UnityEngine;

public class RedPlayer : MonoBehaviour
{
    public float helth = 50f;
    public float _velocity = 1f;

    void OnEnable()
    {   
        PlayerSwap.SetActivePos(transform);
    }

    void OnDisable()
    {
        PlayerSwap.TakeTransformPos(transform);
    }

}
