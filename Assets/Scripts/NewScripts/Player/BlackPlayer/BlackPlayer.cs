using System;
using System.Collections.Generic;
using UnityEngine;

public class BlackPlayer : Player
{
    private float helth = 20f;
    private float _velocity = 25f;

    void OnEnable()
    {
        PlayerSwap.SetActivePos(transform);
    }

    void OnDisable()
    {
        PlayerSwap.TakeTransformPos(transform);
    }

    public override float SetVelocity()
    {
        return _velocity;
    }
}
