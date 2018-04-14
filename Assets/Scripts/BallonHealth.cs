using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonHealth : MonoBehaviour {
    public int AmountOfBags = 3;

    // Use this for initialization
    void Start() {


    }

    // Update is called once per frame
    void Update() {
        if (AmountOfBags <1)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;
            Destroy(gameObject, 5);
        }

    }
    public void MinusBag()
    {
        AmountOfBags--;
        GameObject.FindGameObjectWithTag("Bag").GetComponent<Rigidbody2D>().gravityScale = 3;
        Destroy(GameObject.FindGameObjectWithTag("Bag"), 5);
    }

}
