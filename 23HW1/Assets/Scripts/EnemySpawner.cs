using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] TimeBody timeBody;

    List<PointInTime> enemyPoints;
    List<PointInTime> enemyPoints_1;

    public GameObject enemy;
    GameObject _enemy;
    public EnemyRewind enemyRewind;
    int finishedTimes, o;
    Vector3 instanPos;

    void Start()
    {
        //InvokeRepeating("SpawnEnemy", 1, 1);  //生成怪物(每秒一次)
        enemyPoints = new List<PointInTime>();
        timeBody.Initiate();
        o = 0;
    }

    void Update()
    {
        if (finishedTimes >= 5) Debug.Log("GGGGGGG");
    }

    void SpawnEnemy()
    {
        enemyPoints = new List<PointInTime>(timeBody.pointsInTime);

        if (o < 1)
        {
            instanPos = enemyPoints[enemyPoints.Count - 1].position;
            o++;
        }


        //_enemy = Instantiate(enemy, enemyPoints[enemyPoints.Count - 1].position, Quaternion.identity);
    }

    IEnumerator InstanEnemy()
    {
        Debug.Log("instanPos:" + instanPos);
        Debug.Log("instanING!");
        _enemy = Instantiate(enemy, instanPos, Quaternion.identity);
        Debug.Log("instanCOM!");

        yield return new WaitForSeconds(3f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            SpawnEnemy();
            StartCoroutine(InstanEnemy());

            finishedTimes++;
        }
    }

    //IEnumerator SpawnAlot()
    //{
    //    while (isGamePlaying)
    //    {
    //        for (int i = 0; i < nowLevel; i++)
    //        {
    //            SpawnEnemy(i);
    //        }
    //        yield return new WaitForSeconds(3f);
    //    }

    //}
}
