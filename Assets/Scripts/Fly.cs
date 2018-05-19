using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField]
    public GameObject hunter;
    [SerializeField]
    public GameObject OutOfScreenSpot;
    [SerializeField]
    public SpriteRenderer mySpriteRenderer;
    [SerializeField]
    public Animator myAnimator;
    [SerializeField]
    public Rigidbody2D myRigit;

    public BalloonHealth BalloonHealth;
    public Balloon Balloon;

    public float speed;
    public float Score = 1;
    public GameObject destination;
    public bool alive = true;

    // Use this for initialization
    void Start()
    {
        destination = hunter;
    }

    // Update is called once per frame
    void Update()
    {
        FlyToSpot(destination);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject == Balloon.gameObject && alive)
        {
            destination = OutOfScreenSpot;
            myAnimator.Play("FlyDown");
            Destroy(gameObject, 10);
            speed++;
            BalloonHealth.MinusBag();
        }
    }

    public void FlyToSpot( GameObject spot)
    {
        var delta = transform.position - spot.transform.position;
        delta.Normalize();
        float moveSpeed = speed * Time.deltaTime;
        transform.position = transform.position - (delta* moveSpeed);
        if (transform.position.x > spot.transform.position.x)
        {
            mySpriteRenderer.flipX = true;
        }
        if (transform.position.x<spot.transform.position.x)
        {
            mySpriteRenderer.flipX = false;
        }
     }
}
