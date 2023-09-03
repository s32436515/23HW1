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
    int finishedTimes;

    void Start()
    {
        //InvokeRepeating("SpawnEnemy", 1, 1);  //�ͦ��Ǫ�(�C��@��)
        enemyPoints = new List<PointInTime>();
        timeBody.Initiate();
    }

    void Update()
    {
        if (finishedTimes >= 5) Debug.Log("GGGGGGG");
    }

    void SpawnEnemy()
    {
        enemyPoints = new List<PointInTime>(timeBody.pointsInTime);

        _enemy = Instantiate(enemy, enemyPoints[enemyPoints.Count - 1].position, Quaternion.identity);
    }

    /*IEnumerator moveAnim()
    {
        while ((enemyPoints_A.Count != enemyPoints_A.Count - 1) && enemyPoints_A.Count > 0)
        {
            PointInTime pointInTime = enemyPoints_A[0];

            _enemy.transform.position = pointInTime.position; Debug.Log("enemyPoints_A.Count - 1:" + (pointInTime.position));
            _enemy.transform.rotation = pointInTime.rotation;

            _enemy.GetComponent<SpriteRenderer>().flipX = !pointInTime.isFlip;


            enemyPoints_A.RemoveAt(0);

            yield return new WaitForSeconds(.018f);
        }

        Destroy(_enemy);
        print("rewind finished");
    }*/

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            SpawnEnemy();

            finishedTimes++;
        }
    }
}
