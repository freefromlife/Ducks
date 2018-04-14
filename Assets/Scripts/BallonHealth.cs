using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonHealth : MonoBehaviour {
    public int AmountOfBags = 3;
    public GameObject gameover;
    public bool gameoverflag;

    // Use this for initialization
    void Start() {
        gameoverflag = false;


    }

    // Update is called once per frame
    void Update() {
        if (AmountOfBags <1)
        {
            gameoverflag = true;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = -0.2f;
            foreach (GameObject item in GameObject.FindGameObjectsWithTag("Spawner"))
            { Destroy(item); }
            foreach (GameObject item in GameObject.FindGameObjectsWithTag("Duck"))
            { Destroy(item, 4); }
            Destroy(gameObject, 5);
            gameover.SetActive(true);
            
            
        }

    }
    public void MinusBag()
    {
        AmountOfBags--;
        GameObject.FindGameObjectWithTag("Bag").GetComponent<Rigidbody2D>().gravityScale = 3;
        Destroy(GameObject.FindGameObjectWithTag("Bag"), 5);
    }

}
