using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCont : MonoBehaviour
{
    float RotationX;
    float RotationZ;
 



    // Update is called once per frame
    private void FixedUpdate()
    {
      
        if(!Ball_GameManager.instance.isGoal)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(new Vector3(0, 0, 30f) * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(new Vector3(0, 0, -30f) * Time.deltaTime);
            }
        }
       
    }
    
}
