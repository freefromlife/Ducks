using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{

    public float speed = 10; // скорость пули
    public Rigidbody2D bullet; // префаб нашей пули
    public Transform gunPoint; // точка рождения
    public float fireRate = 1; // скорострельность
    private float curTimeout;

    void Start()
    {
    }

 

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            CreateBullet();
        }
        else
        {
            curTimeout = 100;
        }

        
    }

    void CreateBullet()
    {
        curTimeout += Time.deltaTime;
        if (curTimeout > fireRate)
        {
            curTimeout = 0;
            Rigidbody2D clone = Instantiate(bullet, transform.position, Quaternion.identity) as Rigidbody2D;
            clone.velocity = transform.TransformDirection(gunPoint.right * speed);
            clone.transform.right = gunPoint.right;
        }
    }
}