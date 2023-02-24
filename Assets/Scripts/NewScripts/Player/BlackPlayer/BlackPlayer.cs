using System;
using System.Collections.Generic;
using UnityEngine;

public class BlackPlayer : MonoBehaviour
{
    public float health = 20f;
    public float velocity = 1.5f;

    void OnEnable()
    {
        PlayerSwap.SetActivePos(transform);
    }

    void OnDisable()
    {
        PlayerSwap.TakeTransformPos(transform);
    }
}
