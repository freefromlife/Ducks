using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    public BalloonHealth BalloonHealth;

    public BulletDestroy bullet; // префаб нашей пули
    private float cooldown;
    public Transform gunPoint; // точка рождения
    public Slider GunSelection;
    public GameObject gunSelectionImage;
    public GunsLib gunsLib;
    public GameObject SC;
    public SpriteRenderer WeaponRenderer;
    public GunAngle GunAngle;

    public bool IsGameover
    {
        get { return BalloonHealth.gameoverflag; }
    }

    private void Start()
    {
        WeaponRenderer.sprite = gunsLib.Images[Mathf.RoundToInt(GunSelection.value)];
        GunSelection.maxValue = gunsLib.Images.Length - 1;
    }


    private void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            if (Input.GetMouseButton(0) && !IsGameover) CreateBullet(Mathf.RoundToInt(GunSelection.value));
        }
    }

    private void CreateBullet(int index)
    {
        cooldown = gunsLib.fireRate[index];
        var clone = Instantiate(bullet, gunPoint.position, GunAngle.WeaponRoot.rotation);
        clone.Rigidbody2D.velocity =
            GunAngle.WeaponRoot.TransformDirection(Vector3.right*gunsLib.speed[index]);
       clone.CircleCollider2D.radius = gunsLib.cal[index];
        clone.SC = SC;
    }

    public void Slide()
    {
        WeaponRenderer.sprite = gunsLib.Images[Mathf.RoundToInt(GunSelection.value)];
    }
}