using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    void Start()

    {
        InvokeRepeating("SpawnEnemy", 1, 1);  //�ͦ��Ǫ�(�C��@��)
    }

    public void SpawnEnemy()
    {
        Instantiate(enemy, new Vector3(5.75f, 5.8f, 0), Quaternion.identity);
    }
}
