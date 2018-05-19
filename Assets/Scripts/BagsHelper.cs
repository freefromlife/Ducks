using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagsHelper : MonoBehaviour
{
    public GameObject Bag;

    // Use this for initialization
    void Start()
    {
        Instantiate(Bag, transform.position, Quaternion.identity);

    }


}