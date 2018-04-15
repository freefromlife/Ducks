using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallonHealth : MonoBehaviour {
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




    // Use this for initialization
    void Start() {
        gameoverflag = false;
        StartTime = Time.time;

    }

    // Update is called once per frame
    void Update() {
        if (AmountOfBags <1)
        {
            GameIsOver();
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
    public void GameIsOver()
    {
        gameoverflag = true;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = -0.2f;
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Spawner"))
        { Destroy(item); }
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Duck"))
        { Destroy(item, 4); }
        Destroy(gameObject, 5);
        gameover.SetActive(true);
        dataControl.SubmitNewPlayerTime(Seconds);
        dataControl.SubmitNewPlayerScore(SC.GetComponent<ScoreCounter>().PlayerScore);
        dataControl.SubmitNewPlayerKilles(SC.GetComponent<ScoreCounter>().killed);
        ResultScore.text ="Score: "+ SC.GetComponent<ScoreCounter>().PlayerScore.ToString();
        ResultKills.text ="Killed: "+ SC.GetComponent<ScoreCounter>().killed.ToString() + " ducks";
        ResultTime.text = "Time: "+ Seconds.ToString() + " s";
        BestScore.text ="Best score: "+ dataControl.GetHighestScore().ToString();
        BestKills.text ="Best Ducks killed: "+ dataControl.GetBestKilled().ToString() + " ducks";
        BestTime.text = "Best time: "+ dataControl.GetBestTime().ToString() + " s";

    }

}
