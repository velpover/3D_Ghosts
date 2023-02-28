using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject _spider;
    [SerializeField] GameObject _Chest;

    private Vector3 _correct = new Vector3(4f, 0, 5f);
    private void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    IEnumerator CreateEnemy()
    {   

        while (true)
        {
            PlayerSwap.SetActivePos(transform);

            Instantiate(_spider, transform.position+_correct, Quaternion.identity);

            yield return new WaitForSeconds(10f);

            Instantiate(_Chest, transform.position+_correct, Quaternion.identity);

            yield return new WaitForSeconds(10f);

        }
    }
}
