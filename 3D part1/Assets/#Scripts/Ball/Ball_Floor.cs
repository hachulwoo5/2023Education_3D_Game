using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Floor : MonoBehaviour
{
    public bool isCool;

    public void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag =="Ball_Ball")
        {
            StartCoroutine(Cooldown());
        }
    }

 
    IEnumerator Cooldown()
    {
      
        yield return new WaitForSeconds(3f);
        isCool = false;
    }
}
