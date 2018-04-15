using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour {
    [SerializeField]
    public GameObject SC;
    public int KillCounter;
    // Use this for initialization
    void Start () {
        Destroy(gameObject, 5);
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (!coll.isTrigger) // чтобы пуля не реагировала на триггер
        {
            Destroy(gameObject);
        }
        if (coll.tag == "Duck")
        {
            KillCounter++;
            coll.GetComponent <Fly>().alive = false;
            coll.GetComponent<Fly>().myAnimator.Play("Die");
            coll.GetComponent<Fly>().myRigit.gravityScale = 2;
            Destroy(coll, 5);
            SC.GetComponent<ScoreCounter>().TakeScore(coll.GetComponent<Fly>().Score * Mathf.RoundToInt(coll.GetComponent<Fly>().speed), KillCounter);
        }
    }
}
