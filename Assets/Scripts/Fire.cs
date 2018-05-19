using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    public bool gameoverflag;
    public GameObject bullet; // префаб нашей пули
    public Transform gunPoint; // точка рождения
    private float curTimeout;
    public GameObject SC;
    public Slider GunSelection;
    public GameObject gunSelectionImage;
    public GunsLib gunsLib;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = gunsLib.Images[Mathf.RoundToInt(GunSelection.value)];
        GunSelection.maxValue = gunsLib.Images.Length - 1;
    }

 

    void Update()
    {
        gameoverflag = FindObjectOfType<BallonHealth>().gameoverflag;
        if (Input.GetMouseButton(0) && gameoverflag==false)
        {
            CreateBullet(Mathf.RoundToInt( GunSelection.value));
        }
        else
        {
            curTimeout = 100;
        }
        

    }

    void CreateBullet(int index)
    {
        
        curTimeout += Time.deltaTime;
        if (curTimeout > gunsLib.fireRate[index])
        {
            curTimeout = 0;
            GameObject clone = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            clone.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(gunPoint.right * gunsLib.speed[index]);
            clone.transform.right = gunPoint.right;
            clone.GetComponent<CircleCollider2D>().radius = gunsLib.cal[index];
            clone.GetComponent<BulletDestroy>().SC = SC;
        }
    }
    public void Slide()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = gunsLib.Images[Mathf.RoundToInt(GunSelection.value)];
       // gunSelectionImage.GetComponent<Image>().sprite = gunsLib.Images[Mathf.RoundToInt(GunSelection.value)];
       // gunSelectionImage.SetActive(true);
    }
}