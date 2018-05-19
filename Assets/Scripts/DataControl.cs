using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataControl : MonoBehaviour {
    private PlayerProgress playerProgress;
    // Use this for initialization
    void Start() {
        LoadPlayerProgress();
    }

    public void SubmitNewPlayerScore(float newScore)
    {
        if (newScore > playerProgress.HighestScore)
        { playerProgress.HighestScore = newScore;
            SavePlayerProgress();
        }
    }
    public void SubmitNewPlayerTime(int newTime)
    {
        if (newTime > playerProgress.BestTime)
        {
            playerProgress.BestTime = newTime;
            SavePlayerProgress();
        }
    }
            public void SubmitNewPlayerKilles(int newKills)
    {
        if (newKills> playerProgress.BestKilled)
        { playerProgress.BestKilled = newKills;
            SavePlayerProgress();
        }

    }
    public float GetHighestScore()
    {
        return playerProgress.HighestScore;
    }
    public int GetBestTime()
    {
        return playerProgress.BestTime;
    }
    public int GetBestKilled()
    {
        return playerProgress.BestKilled;
    }
    private void LoadPlayerProgress()
    { playerProgress = new PlayerProgress();
        if (PlayerPrefs.HasKey("HighestScore"))
        {
            playerProgress.HighestScore = PlayerPrefs.GetFloat("HighestScore");
        }
        if (PlayerPrefs.HasKey("BestTime"))
        {
            playerProgress.BestTime = PlayerPrefs.GetInt("BestTime");
        }
        if (PlayerPrefs.HasKey("BestKilled"))
        {
            playerProgress.BestKilled = PlayerPrefs.GetInt("BestKilled");
        }
    }
    private void SavePlayerProgress()
    {
        PlayerPrefs.SetFloat("HighestScore", playerProgress.HighestScore);
        PlayerPrefs.SetInt("BestTime", playerProgress.BestTime);
        PlayerPrefs.SetInt("BestKilled", playerProgress.BestKilled);
    }
}
