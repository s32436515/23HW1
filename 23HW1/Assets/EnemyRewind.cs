using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRewind : MonoBehaviour
{
    [SerializeField] TimeBody timeBody;
    [SerializeField] EnemySpawner enemySpawner;

    List<PointInTime> enemyPoints;
    List<PointInTime> enemyPoints_1, enemyPoints_2, enemyPoints_3, enemyPoints_4;
    int enemyCount;

    void Start()
    {
        timeBody = GameObject.Find("Player").GetComponent<TimeBody>();
        enemySpawner = GameObject.Find("Froggg").GetComponent<EnemySpawner>();


        if (enemySpawner.levelNow == 1)
        {
            timeBody.GetRewind(1);
            enemyPoints_1 = new List<PointInTime>(timeBody.pointsInTime);
            StartCoroutine(RewindEnemy(enemyPoints_1));
        }

        if (enemySpawner.levelNow == 2)
        {
            timeBody.GetRewind(2);
            enemyPoints_2 = new List<PointInTime>(timeBody.pointsInTime);
            StartCoroutine(RewindEnemy(enemyPoints_2));
        }

        if (enemySpawner.levelNow == 3)
        {
            timeBody.GetRewind(3);
            enemyPoints_3 = new List<PointInTime>(timeBody.pointsInTime);
            StartCoroutine(RewindEnemy(enemyPoints_3));
        }

        if (enemySpawner.levelNow == 4)
        {
            timeBody.GetRewind(4);
            enemyPoints_4 = new List<PointInTime>(timeBody.pointsInTime);
            StartCoroutine(RewindEnemy(enemyPoints_4));
        }


    }

    void Update()
    {

    }

    public IEnumerator RewindEnemy(List<PointInTime> levelList)
    {
        //Debug.Log(enemyPoints_1.Count);

        //for(int i= enemyPoints_1.Count - 1; i > 0; i--)
        //{
        //    PointInTime pointInTime = enemyPoints_1[0];

        //    transform.position = pointInTime.position; Debug.Log("enemyPoints_A.Count - 1:" + (pointInTime.position));
        //    transform.rotation = pointInTime.rotation;
        //    GetComponent<SpriteRenderer>().flipX = !pointInTime.isFlip;

        //    yield return new WaitForSeconds(.018f);
        //    break;
        //}

        while ((levelList.Count != levelList.Count - 1) && levelList.Count > 0)
        {
            for (int i = 0; i < levelList.Count - 1; i++)
            {
                PointInTime pointInTime = levelList[i];

                if (i == 0)
                    transform.position = levelList[0].position;
                else
                    transform.position = pointInTime.position; //Debug.Log("enemyPoints_A.Count - 1:" + (pointInTime.position));
                transform.rotation = pointInTime.rotation;
                GetComponent<SpriteRenderer>().flipX = !pointInTime.isFlip;

                yield return new WaitForSeconds(.018f);
            }
        }
        if (levelList.Count == 0)
            Destroy(this.gameObject);
        print("rewind finished");
    }

    //IEnumerator Wait3s()
    //{
    //    yield return new WaitForSeconds(3f);
    //    yield return StartCoroutine(RewindEnemy());
    //}

}
