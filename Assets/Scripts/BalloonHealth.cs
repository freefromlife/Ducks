using UnityEngine;
using UnityEngine.UI;

public class BalloonHealth : MonoBehaviour
{
    public int AmountOfBags = 3;
    public GameObject gameover;
    public bool gameoverflag;
    public float StartTime;
    public Text GameTime;
    public int Seconds;
    public Text ResultScore;
    public Text ResultTime;
    public Text ResultKills;
    public Text BestScore;
    public Text BestTime;
    public Text BestKills;
    public GameObject SC;
    public DataControl dataControl;
    public float GetBestScore;
    public int GetBestTime;
    public int GetBestKills;

    public Balloon Balloon;

    // Use this for initialization
    void Start()
    {
        gameoverflag = false;
        StartTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if (AmountOfBags < 1)
        {
            ShowGameOver();
        }

        if (gameoverflag == false)
        {
            Seconds = Mathf.RoundToInt(Time.time - StartTime);
            GameTime.text = Seconds.ToString() + " s";
        }
    }

    public void MinusBag()
    {
        AmountOfBags--;
        GameObject.FindGameObjectWithTag("Bag").GetComponent<Rigidbody2D>().gravityScale = 3;
        Destroy(GameObject.FindGameObjectWithTag("Bag"), 5);
    }

    public void ShowGameOver()
    {
        gameoverflag = true;

        SaveProgress();
        ShowUI();
        PlayDeathAnimation();
    }

    private void SaveProgress()
    {
        dataControl.SubmitNewPlayerTime(Seconds);
        dataControl.SubmitNewPlayerScore(SC.GetComponent<ScoreCounter>().PlayerScore);
        dataControl.SubmitNewPlayerKilles(SC.GetComponent<ScoreCounter>().killed);
    }

    private void PlayDeathAnimation()
    {
        Balloon.FlyTop();

        foreach (var item in GameObject.FindGameObjectsWithTag("Spawner"))
        {
            Destroy(item);
        }

        foreach (var item in GameObject.FindGameObjectsWithTag("Duck"))
        {
            Destroy(item, 4);
        }
    }

    private void ShowUI()
    {
        gameover.SetActive(true);
        ResultScore.text = "Score: " + SC.GetComponent<ScoreCounter>().PlayerScore.ToString();
        ResultKills.text = "Killed: " + SC.GetComponent<ScoreCounter>().killed.ToString() + " ducks";
        ResultTime.text = "Time: " + Seconds.ToString() + " s";
        BestScore.text = "Best score: " + dataControl.GetHighestScore().ToString();
        BestKills.text = "Best Ducks killed: " + dataControl.GetBestKilled().ToString() + " ducks";
        BestTime.text = "Best time: " + dataControl.GetBestTime().ToString() + " s";
    }
}