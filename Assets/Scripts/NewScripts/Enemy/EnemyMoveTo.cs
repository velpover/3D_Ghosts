using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace NewScene
{
    public class EnemyMoveTo:MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;

        private Transform _target;

        private bool _isMove = false;
        public void GoToPlayer(Transform target)
        {
            if (!_isMove)
            {
                this._target = target;

                StartCoroutine(MoveTo());
            }
           
            _isMove = true;
            
        }

        public void StopMove()
        {
            _agent.isStopped = true;
        }

        IEnumerator MoveTo()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                _agent.destination = _target.position;
            }
        }
    }

}
