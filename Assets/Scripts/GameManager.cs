using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName = string.Empty;
    public string highScoreName = string.Empty;
    public int highScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        LoadScores();
    }

    public void StartGame()
    {
        if (playerName == null || playerName.Length < 1) return;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private void LoadScores()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Highscore data = JsonUtility.FromJson<Highscore>(json);

            highScore = data.score;
            highScoreName = data.name;
        }
    }

    public void SaveScores()
    {
        Highscore newTemp = new Highscore { name = highScoreName, score = highScore};
        var toJson = JsonUtility.ToJson(newTemp);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", toJson);
    }

    public void SaveHighScore(int points)
    {
        highScore = points;
        highScoreName = playerName;
        SaveScores();
    }

    [Serializable]
    public class Highscore
    {
        public string name;
        public int score;
    }
}
