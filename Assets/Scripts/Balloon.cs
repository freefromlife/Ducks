using System.Diagnostics;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;

    [Conditional("UNITY_EDITOR")]
    private void OnValidate()
    {
        if (!Rigidbody2D)
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }

    public void FlyTop()
    {
        //describe all animation here
        Rigidbody2D.gravityScale = -0.2f;
        Destroy(gameObject, 5);
    }
}