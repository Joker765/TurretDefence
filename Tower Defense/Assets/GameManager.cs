using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject endUI;
    public Text endMessage;

    public static GameManager Instance;
    private EnemySpawn enemySpawn;

    private void Awake()
    {
        Instance = this;
        enemySpawn = GetComponent<EnemySpawn>();
    }

    public void Win()
    {
        endUI.SetActive(true);
        endMessage.text = "You Win!";

    }

    public void Failed()
    {
        enemySpawn.Stop();
        endUI.SetActive(true);
        endMessage.text = "Game Over";
    }

}
