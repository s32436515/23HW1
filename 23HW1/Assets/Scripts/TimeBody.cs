using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        savePoint1 = new List<PointInTime>();
        savePoint2 = new List<PointInTime>();
        savePoint3 = new List<PointInTime>();
        savePoint4 = new List<PointInTime>();
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
            PointInTime pointInTime = pointsInTime[pointsInTime.Count - 1];
            player.transform.position = pointInTime.position;
            player.transform.rotation = pointInTime.rotation;
            player.GetComponent<SpriteRenderer>().flipX = pointInTime.isFlip;
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
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
            pointsInTime.RemoveAt(0);
        }

        pointsInTime.Add(new PointInTime(player.transform.position, player.transform.rotation, spRender.flipX));
    }

    void StartRewind()
    {
        isRewinding = true;
    }

    void StopRewind()
    {
        isRewinding = false;
    }

    public void SaveRewind(int indexCounter)
    {
        switch (indexCounter)
        {
            case 1:
                savePoint1 = pointsInTime.ToList();
                break;
            case 2:
                savePoint2 = pointsInTime.ToList();
                break;
            case 3:
                savePoint3 = pointsInTime.ToList();
                break;
            case 4:
                savePoint4 = pointsInTime.ToList();
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
