using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] TimeBody timeBody;

    List<PointInTime> enemyPoints;
    List<PointInTime> enemyPoints_1;

    public GameObject enemy;
    public EnemyRewind enemyRewind;
    public int levelNow = 0;
    GameObject _enemy;
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
        //enemyPoints = new List<PointInTime>(timeBody.pointsInTime);


        //_enemy = Instantiate(enemy, enemyPoints[enemyPoints.Count - 1].position, Quaternion.identity);
    }

    IEnumerator InstanEnemy()
    {
        Debug.Log("instanPos:" + enemyPoints[enemyPoints.Count - 1].position);
        Debug.Log("instanING!");
        _enemy = Instantiate(enemy, enemyPoints[enemyPoints.Count - 1].position, Quaternion.identity);
        Debug.Log("instanCOM!");

        yield return new WaitForSeconds(3f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            levelNow++;

            if (levelNow == 1)
            {
                enemyPoints = new List<PointInTime>(timeBody.pointsInTime);
                timeBody.SaveRewind(1);
            }
            if (levelNow == 2)
            {
                enemyPoints = new List<PointInTime>(timeBody.pointsInTime);
                timeBody.SaveRewind(2);
            }
            if (levelNow == 3)
            {
                enemyPoints = new List<PointInTime>(timeBody.pointsInTime);
                timeBody.SaveRewind(3);
            }
            if (levelNow == 4)
            {
                enemyPoints = new List<PointInTime>(timeBody.pointsInTime);
                timeBody.SaveRewind(4);
            }

            
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
