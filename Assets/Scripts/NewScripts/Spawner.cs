using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject _spider;
    [SerializeField] GameObject _Chest;

    private Vector3 _correctSpider = new Vector3(4f, 0, 5f);
    private Vector3 _correctChest = new Vector3(-4f, 0, -5f);
    private void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    IEnumerator CreateEnemy()
    {   

        while (true)
        {
            PlayerSwap.SetActivePos(transform);

            Instantiate(_spider, transform.position+_correctSpider, Quaternion.identity);

            yield return new WaitForSeconds(6f);

            Instantiate(_Chest, transform.position+_correctChest, Quaternion.identity);

            yield return new WaitForSeconds(6f);

        }
    }
}
