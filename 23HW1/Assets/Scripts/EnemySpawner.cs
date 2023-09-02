using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField] TimeBody timeBody;
    List<PointInTime> enemyPoints;
    List<PointInTime> enemyPoints_A;
    int finishedTimes;

    void Start()

    {
        //InvokeRepeating("SpawnEnemy", 1, 1);  //生成怪物(每秒一次)
        enemyPoints = new List<PointInTime>();
        //timeBody = new TimeBody();

        timeBody.Initiate();
    }

    void FixedUpdate()
    {
        
    }

    void Update()
    {
        if (finishedTimes >= 5) Debug.Log("GGGGGGG");
    }

    void SpawnEnemy()
    {
        enemyPoints = new List<PointInTime>(timeBody.pointsInTime);
        Instantiate(enemy, enemyPoints[enemyPoints.Count-1].position, Quaternion.identity);

        enemyPoints_A = new List<PointInTime>(enemyPoints);
        while (enemyPoints.Count == 0)
        {
            PointInTime pointInTime = enemyPoints_A[enemyPoints.Count];

            enemy.transform.position = pointInTime.position;
            enemy.transform.rotation = pointInTime.rotation;
            enemy.GetComponent<SpriteRenderer>().flipX = pointInTime.isFlip;

            enemyPoints.RemoveAt(enemyPoints.Count);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            SpawnEnemy();

            finishedTimes++;
        }
    }
}
