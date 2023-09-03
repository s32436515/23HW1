using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] TimeBody timeBody;

    List<PointInTime> enemyPoints;
    List<PointInTime> enemyPoints_A;

    public GameObject enemy;
    GameObject _enemy;
    int finishedTimes;

    void Start()

    {
        //InvokeRepeating("SpawnEnemy", 1, 1);  //�ͦ��Ǫ�(�C��@��)
        enemyPoints = new List<PointInTime>();
        //timeBody = new TimeBody();
        timeBody.Initiate();
    }

    void Update()
    {
        if (finishedTimes >= 5) Debug.Log("GGGGGGG");

        if (Input.GetKeyDown(KeyCode.J))
        {
            enemyPoints = new List<PointInTime>(timeBody.pointsInTime);
            _enemy = Instantiate(enemy, enemyPoints[enemyPoints.Count - 1].position, Quaternion.identity);

            enemyPoints_A = new List<PointInTime>(enemyPoints);
            StartCoroutine(moveAnim());
        }
    }

    void SpawnEnemy()
    {




    }

    IEnumerator moveAnim()
    {
        while (enemyPoints_A.Count != 0)
        {
            PointInTime pointInTime = enemyPoints_A[enemyPoints_A.Count - 1];

            _enemy.transform.position = pointInTime.position;
            _enemy.transform.rotation = pointInTime.rotation;
            _enemy.GetComponent<SpriteRenderer>().flipX = pointInTime.isFlip;

            enemyPoints_A.RemoveAt(enemyPoints_A.Count - 1);

            yield return null;
        }
        print("rewind finished");
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
