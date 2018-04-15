using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {
    public Text PlayerScoreUI;
    public float PlayerScore;
    public int killed;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PlayerScoreUI.text = PlayerScore.ToString();
    }
    public void TakeScore(float score, int amountofkills)
    {
        PlayerScore = PlayerScore + score * amountofkills;
        killed++;
     }
}
