using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRewind : MonoBehaviour
{
    [SerializeField] TimeBody timeBody;

    List<PointInTime> enemyPoints;
    List<PointInTime> enemyPoints_1;
    int enemyCount;

    void Start()
    {
        timeBody = GameObject.Find("Player").GetComponent<TimeBody>();

        enemyPoints_1 = new List<PointInTime>(timeBody.pointsInTime);

        StartCoroutine(RewindEnemy());
    }

    void Update()
    {

    }

    public IEnumerator RewindEnemy()
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

        while ((enemyPoints_1.Count != enemyPoints_1.Count - 1) && enemyPoints_1.Count > 0)
        {
            for (int i = 0; i < enemyPoints_1.Count - 1; i++)
            {
                PointInTime pointInTime = enemyPoints_1[i];

                if (i == 0)
                    transform.position = enemyPoints_1[0].position;
                else
                    transform.position = pointInTime.position; //Debug.Log("enemyPoints_A.Count - 1:" + (pointInTime.position));

                transform.rotation = pointInTime.rotation;
                GetComponent<SpriteRenderer>().flipX = !pointInTime.isFlip;

                yield return new WaitForSeconds(.018f);
            }
        }
        if (enemyPoints_1.Count == 0)
            Destroy(this.gameObject);
        print("rewind finished");
    }

    //IEnumerator Wait3s()
    //{
    //    yield return new WaitForSeconds(3f);
    //    yield return StartCoroutine(RewindEnemy());
    //}

}
