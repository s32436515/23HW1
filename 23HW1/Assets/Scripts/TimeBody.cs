using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    bool isRewinding = false;
    public List<PointInTime> pointsInTime;
    public float recordTime = 10f;
    [SerializeField] GameObject player;
    [SerializeField] SpriteRenderer spRender;
    playerController playerCtrl = new();

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
}
