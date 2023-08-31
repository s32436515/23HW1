using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class repeatRoad : MonoBehaviour
{
    float speed = 0.8f;
    void Update()
    {
        float roadX = GetComponent<Renderer>().material.GetTextureOffset("_MainTex").x;
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(roadX + speed * Time.deltaTime, 0));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
