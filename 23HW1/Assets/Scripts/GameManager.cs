using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject goat1, goat2, goat3, goat4, goat5;
    [SerializeField] EnemySpawner enemySpawner;

    void Awake()
    {
        goat1.GetComponent<Image>().enabled = false;
        goat2.GetComponent<Image>().enabled = false;
        goat3.GetComponent<Image>().enabled = false;
        goat4.GetComponent<Image>().enabled = false;
        goat5.GetComponent<Image>().enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("MenuScene");
        }

        switch (enemySpawner.levelNow)
        {
            case 1:
                goat1.GetComponent<Image>().enabled = true;
                break;
            case 2:
                goat2.GetComponent<Image>().enabled = true;
                break;
            case 3:
                goat3.GetComponent<Image>().enabled = true;
                break;
            case 4:
                goat4.GetComponent<Image>().enabled = true;
                break;
            case 5:
                goat5.GetComponent<Image>().enabled = true;
                SceneManager.LoadScene("EndScene");
                break;
        }
    }
}
