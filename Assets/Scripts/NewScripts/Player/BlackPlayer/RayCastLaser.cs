using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastLaser : MonoBehaviour
{
    [SerializeField] LineRenderer _lineRender;
    [SerializeField] Transform _target;
    Vector3 _pos = Vector3.forward;
    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {   
            RaycastHit hit;
            if(Physics.Raycast(transform.position, _target.forward,out hit, 200f, 1 << 8))
            {
                _lineRender.SetPosition(0,transform.position);
                _lineRender.SetPosition(1,hit.point);
            }
            else
            {
                _lineRender.SetPosition(0, transform.position);
                _lineRender.SetPosition(1, _target.forward * 200f);
            }
        }
    }
}
