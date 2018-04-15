using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{
    public bool gameoverflag;
    public float speed = 10; // скорость пули
    public GameObject bullet; // префаб нашей пули
    public Transform gunPoint; // точка рождения
    public float fireRate = 1; // скорострельность
    private float curTimeout;
    public GameObject SC;


    void Start()
    {

    }

 

    void Update()
    {
        gameoverflag = FindObjectOfType<BallonHealth>().gameoverflag;
        if (Input.GetMouseButton(0) && gameoverflag==false)
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
            GameObject clone = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            clone.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(gunPoint.right * speed);
            clone.transform.right = gunPoint.right;
            clone.GetComponent<BulletDestroy>().SC = SC;
        }
    }
}