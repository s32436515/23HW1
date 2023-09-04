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
        goat1.SetActive(false);
        goat2.SetActive(false);
        goat3.SetActive(false);
        goat4.SetActive(false);
        goat5.SetActive(false);
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
                goat1.SetActive(true);
                break;
            case 2:
                goat2.SetActive(true);
                break;
            case 3:
                goat3.SetActive(true);
                break;
            case 4:
                goat4.SetActive(true);
                break;
            case 5:
                goat5.SetActive(true);
                SceneManager.LoadScene("EndScene");
                break;
        }
    }
}
