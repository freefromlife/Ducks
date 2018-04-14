using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

    public void PlayAgainPressed()
    {
        SceneManager.LoadScene("Duck's Revenge");
        Debug.Log("play pressed");
    }
    public void MenuPressed()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("menu pressed");
    }
}
