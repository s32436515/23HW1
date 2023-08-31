using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatBg : MonoBehaviour
{
    float speed = 0.1f;
    void Update()
    {
        float bgX = GetComponent<Renderer>().material.GetTextureOffset("_MainTex").x;
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(bgX + speed * Time.deltaTime, 0));
    }
}
