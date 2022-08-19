using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    public bool isEndGame;
    public int endGameUI = 0;
    public LevelData[] allLevel;
    public LevelData currentLevel;
    public string currentLevelText;
    public float currentEnemySpeed;
    public GameObject[] enemyPrefabs;
    public GameObject[] enemies;
    public SpawnerHolder[] spawnerHolders;
    public Player player;

    private int levelIndex;
    private List<Step> activatedStep = new List<Step>();

    private void OnInit()
    {
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            enemies[i] = GameObject.Instantiate(enemyPrefabs[i]);
        }
    }

    private void Awake()
    {
        levelIndex = 0;
        currentLevel = allLevel[levelIndex];
        currentLevelText = currentLevel.level;
        currentEnemySpeed = currentLevel.enemySpeed;
    }

    public void NextLevel()
    {
        isEndGame = false;
        endGameUI = 0;

        if (levelIndex < 2) levelIndex++;
        currentLevel = allLevel[levelIndex];
        currentLevelText = currentLevel.level;
        currentEnemySpeed = currentLevel.enemySpeed;

        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            GameObject.Destroy(enemies[i]);
        }

        for (int i = 0; i < spawnerHolders.Length; i++)
        {
            spawnerHolders[i].Reset();
        }

        while (activatedStep.Count > 0)
        {
            activatedStep[0].Reset();
            activatedStep.RemoveAt(0);
        }

        player.Reset();
        SimplePool.ReleaseAll();

        OnInit();
    }

    public void StepRegister(Step step)
    {
        activatedStep.Add(step);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SimplePool.ReleaseAll();
    }
}
