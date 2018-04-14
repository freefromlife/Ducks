using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour {

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
    }
}
