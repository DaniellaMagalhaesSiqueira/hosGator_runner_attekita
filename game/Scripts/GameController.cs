using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    private bool isGameRunning;
    public int score;
    public Generator generator;
    public GameConfiguration config;
    public TextMeshProUGUI scoreLabel;
    public GameUI gameStartUI;
    public GameUI gameOverUI;
    public Player player;
    public LevelConfiguration[] levels;
    private int currentLevelIndex;

    public void Start()
    {
        config.speed = 0f;
        isGameRunning = false;
        gameStartUI.Show();
        
    }

    private void Update()
    {
        scoreLabel.text = score.ToString("00000000.##");
        if (!isGameRunning) return;
        score++;
        CheckLevelUpdate();
    }

    private void CheckLevelUpdate()
    {
        if (currentLevelIndex >= levels.Length - 1) return;
        if (score < levels[currentLevelIndex + 1].minScore) return;
        currentLevelIndex++;
        print(currentLevelIndex);
        SetCurrentLevelConfiguration();
    }
    private void SetCurrentLevelConfiguration()
    {
        
        LevelConfiguration level = levels[currentLevelIndex];
        config.speed = level.speed;
        config.minRangeObstaclesGenarator = level.minRangeObstaclesGenarator;
        config.maxRangeObstaclesGenarator = level.maxRangeObstaclesGenarator;
    }

    public void GameStart()
    {
        currentLevelIndex = 0;
        SetCurrentLevelConfiguration();
        isGameRunning = true;

        generator.GeneratedObstacles();
        score = 0;
        gameStartUI.Hide();
        player.SetActive();
    }

    public void GameOver()
    {
        print("O jogo acabou!");
        isGameRunning = false;
        config.speed = 0f;
        generator.StopGenerator();
        gameOverUI.Show();
    }

    public void GameRestart()
    {
        gameOverUI.Hide();
        generator.ResetGenerator();
        GameStart();
    }
}
