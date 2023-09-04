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
    public int levelNow = 0, enemyCounter = 0;
    GameObject _enemy;
    int finishedTimes;
    Vector3 instanPos;
    bool rewindswitcher = false;

    void Start()
    {
        //InvokeRepeating("SpawnEnemy", 1, 1);  //生成怪物(每秒一次)
        enemyPoints = new List<PointInTime>();
        timeBody.Initiate();
        enemyCounter = 1;
    }

    void Update()
    {
        if (finishedTimes >= 5) Debug.Log("GGGGGGG");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            levelNow++;
            rewindswitcher = true;

            timeBody.SaveRewind(levelNow);

            StartCoroutine(SpawnAlot());

            finishedTimes++;
        }
    }

    IEnumerator SpawnAlot()
    {
        while (rewindswitcher)
        {
            if (enemyCounter <= 5)
            {
                for (int i = 1; i <= levelNow; i++)
                {
                    SpawnEnemy();
                }
                enemyCounter++;
                yield return new WaitForSeconds(2.5f);
            }
            else
                rewindswitcher = false;
        }
    }

    void SpawnEnemy()
    {
        _enemy = Instantiate(enemy, new Vector3(6.86f, 5.89f, 0), Quaternion.identity);
    }

    IEnumerator InstanEnemy(int levelNum)
    {
        timeBody.GetRewind(levelNum);
        enemyPoints = timeBody.savePoint1;
        //Debug.Log("enemyPoints[0]=" + enemyPoints[0].position + ", enemyPoints.Count-1=" + enemyPoints[enemyPoints.Count - 1].position);
        //Debug.Log("instanPos:" + enemyPoints[0].position);
        //Debug.Log("instanING!");
        //_enemy = Instantiate(enemy, new Vector3(6.86f,5.89f,0), Quaternion.identity);
        //Debug.Log("instanCOM!");

        yield return null;
        //yield return StartCoroutine(InstanEnemy(levelNum));
    }
}
