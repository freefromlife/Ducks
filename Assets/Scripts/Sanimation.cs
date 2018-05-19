using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sanimation : MonoBehaviour {

    public RectTransform S;
    public bool flag;
    public float speed;
    public float maxAngle;
    public float minAngle;
    public int direction;


    public void Update()
    {
        if (flag == true)
        {
            while (speed>0)
            {
               S.Rotate(0, 0, Time.deltaTime * speed*direction);
               if (S.rotation.z > maxAngle || S.rotation.z < minAngle)
                {
                    direction *= -1;
                    maxAngle = maxAngle - 5;
                    minAngle = minAngle + 5;
                }
               if (maxAngle == minAngle)
                {
                  speed = 0;
                  flag = false;
                }
                
            }
            
        }
    }

    public void Spressed()
    {
        flag = true;
        direction = 1;
        maxAngle = -120;
        minAngle = -160;
    }
   }
