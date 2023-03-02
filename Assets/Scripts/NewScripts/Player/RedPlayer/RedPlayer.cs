
using System;
using UnityEngine;

public class RedPlayer : Player
{
    private float helth = 40f;
    private float _velocity = 20f;

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
