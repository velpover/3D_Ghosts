using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NewScene
{
    public abstract class Player : MonoBehaviour
    {
        [SerializeField] protected HealthSystem healthSystem;

        protected bool isActive;
        public abstract float Health { get; set; }
        public abstract float SetVelocity();

        protected abstract void Dead();


    }

}
