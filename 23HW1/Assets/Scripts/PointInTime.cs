using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInTime : MonoBehaviour
{
    public Vector3 position;
    public Quaternion rotation;
    public bool isFlip;

    public PointInTime(Vector3 _position, Quaternion _rotation, bool _isFlip)
    {
        position = _position;
        rotation = _rotation;
        isFlip = _isFlip;
    }
}
