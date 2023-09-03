using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRewind : MonoBehaviour
{
    [SerializeField] TimeBody timeBody;

    List<PointInTime> enemyPoints;
    List<PointInTime> enemyPoints_1;

    void Start()
    {
        timeBody = GameObject.Find("Player").GetComponent<TimeBody>();

        enemyPoints_1 = new List<PointInTime>(timeBody.pointsInTime);

        StartCoroutine(RewindEnemy());
    }

    public IEnumerator RewindEnemy()
    {
        Debug.Log(enemyPoints_1.Count);
        while ((enemyPoints_1.Count != enemyPoints_1.Count - 1) && enemyPoints_1.Count > 0)
        {
            PointInTime pointInTime = enemyPoints_1[0];

            transform.position = pointInTime.position; Debug.Log("enemyPoints_A.Count - 1:" + (pointInTime.position));
            transform.rotation = pointInTime.rotation;
            GetComponent<SpriteRenderer>().flipX = !pointInTime.isFlip;

            enemyPoints_1.RemoveAt(0);

            yield return new WaitForSeconds(.018f);
        }

        Destroy(this.gameObject);
        print("rewind finished");
    }
}
