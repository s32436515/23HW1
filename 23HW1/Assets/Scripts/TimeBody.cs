using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    bool isRewinding = false;
    public List<PointInTime> pointsInTime;
    public List<PointInTime> savePoint1, savePoint2, savePoint3, savePoint4;
    public float recordTime = 10f;
    [SerializeField] GameObject player;
    [SerializeField] SpriteRenderer spRender;
    playerController playerCtrl = new();
    //int indexCounter = 0;

    void Start()
    {
        pointsInTime = new List<PointInTime>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            StartRewind();
        if (Input.GetKeyUp(KeyCode.Return))
            StopRewind();
    }

    void FixedUpdate()
    {
        if (isRewinding)
            Rewind();
        else
            Record();
    }

    public void Initiate()
    {
        pointsInTime = new List<PointInTime>();
    }

    void Rewind()
    {
        if (pointsInTime.Count > 0)
        {
            PointInTime pointInTime = pointsInTime[0];
            player.transform.position = pointInTime.position;
            player.transform.rotation = pointInTime.rotation;
            player.GetComponent<SpriteRenderer>().flipX = pointInTime.isFlip;
            pointsInTime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }

    }

    void Record()
    {
        if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }

        pointsInTime.Insert(0, new PointInTime(player.transform.position, player.transform.rotation, spRender.flipX));
    }

    public void StartRewind()
    {
        isRewinding = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
    }

    public void SaveRewind(int indexCounter)
    {
        switch (indexCounter)
        {
            case 1:
                savePoint1 = new List<PointInTime>(pointsInTime);
                break;
            case 2:
                savePoint2 = new List<PointInTime>(pointsInTime);
                break;
            case 3:
                savePoint3 = new List<PointInTime>(pointsInTime);
                break;
            case 4:
                savePoint4 = new List<PointInTime>(pointsInTime);
                break;
        }
        //pointsInTime.Clear();
        if (indexCounter >= 5)
            print("indexCounter >= 5, cannot save any more.");
    }

    public List<PointInTime> GetRewind(int index)
    {
        switch (index)
        {
            case 1:
                return savePoint1;
            case 2:
                return savePoint2;
            case 3:
                return savePoint3;
            case 4:
                return savePoint4;
            default:
                return null;
        }
    }
}
