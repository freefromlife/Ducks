using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


public class GunAngle : MonoBehaviour
{
    public Transform WeaponRoot;
    public Transform Hunter;

    private Vector3 originScale;

	void Start ()
    {
        originScale = Hunter.localScale;
    }

	void Update () {

        var mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);


	    if (mousePosition.x - WeaponRoot.position.x > 0)
	    {
	        Hunter.localScale = originScale;
		    mousePosition.z = WeaponRoot.position.z;
		    WeaponRoot.right = mousePosition - WeaponRoot.position;
	    }
	    if (mousePosition.x - WeaponRoot.position.x < 0)
	    {
	        Hunter.localScale = Vector3.Scale(new Vector3(-1,1,1),   originScale);
		    mousePosition.z = WeaponRoot.position.z;
		    WeaponRoot.right = WeaponRoot.position - mousePosition;
	    }

    }
}
