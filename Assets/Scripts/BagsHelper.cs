using UnityEngine;

public class BagsHelper : MonoBehaviour
{
    public GameObject Bag;

    // Use this for initialization
    void Start()
    {
        Instantiate(Bag, transform, false);
    }
}