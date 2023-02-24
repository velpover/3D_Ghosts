using System;
using UnityEngine;

public class YellowPlayer : MonoBehaviour
{
    public float helth = 100f;
    public float _velocity = 0.7f;

    void OnEnable()
    {
        PlayerSwap.SetActivePos(transform);
    }

    void OnDisable()
    {
        PlayerSwap.TakeTransformPos(transform);
    }
}
