using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewScene
{
    public class CallEnemy : MonoBehaviour
    {
        private Vector3 _cube = new Vector3(10, 0.1f, 10);
        private Vector3 _correct = new Vector3(0, 3f, 0);
        private RaycastHit[] hits = new RaycastHit[8];

        private float _maxDistance = 4f;
        private LayerMask _layerEnemyMask = 1 << 7;


        void Start()
        {
            StartCoroutine(CallEnemyPerSec());
            
        }

        IEnumerator CallEnemyPerSec()
        {
            while (true)
            {
                BoxRayCasts();
                yield return new WaitForSeconds(1f);
            }
        }

        private void BoxRayCasts()
        {

            int j = Physics.BoxCastNonAlloc(transform.position+_correct, _cube, Vector3.down, hits, Quaternion.identity, _maxDistance, _layerEnemyMask);

            for (int i = 0; i < j ; i++)
            {
                GoToPlayer(hits[i].collider.gameObject);
            }

        }

        private void GoToPlayer(GameObject obj)
        {
            Enemy enemy = obj.GetComponent<Enemy>();

            if(enemy != null)
            {
                enemy?.MoveTo(transform);
            }
        }
      
    }

}
