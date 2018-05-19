using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunangle : MonoBehaviour {
    [SerializeField]
    private SpriteRenderer mySpriteRenderer;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //положение мыши из экранных в мировые координаты
        var angle = Vector2.Angle(Vector2.right, mousePosition - transform.position);//угол между вектором от объекта к мыше и осью х
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePosition.y ? angle : -angle);//немного магии на последок
        if (mousePosition.x - transform.position.x > 0)
        {
            mySpriteRenderer.flipY = false;
        }
        if (mousePosition.x - transform.position.x < 0)
        {
            mySpriteRenderer.flipY = true;
        }
    }
}
