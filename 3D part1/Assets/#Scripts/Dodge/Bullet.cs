using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody bulletRigidbody;
    public float speed = 4f;
    public GameObject target;

    public GameObject hitVFX;
    public GameObject hitWallVFX;


    void Start()
    {
        target = GameObject.Find("Player");
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;

        /*
        Vector3 dir = (target.transform.position - transform.position).normalized;
        Vector3 PlayerPos = target.transform.position;
        bulletRigidbody.velocity = dir * speed;
        */


    }


    void Update()
    {
        
        if (GameManager.instance.playerController.isDie==true)
        {
            Destroy(gameObject);
            Instantiate(hitVFX, transform.position,transform.rotation);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                Destroy(gameObject);

                Vector3 contactPoint = other.ClosestPointOnBounds(transform.position);
                Quaternion rot = Quaternion.FromToRotation(Vector3.up, contactPoint.normalized);
                Vector3 pos = contactPoint;
                Instantiate(hitVFX, pos, rot);
                
            }

        }

        if (other.tag == "Wall")
        {
            Destroy(gameObject);
            Vector3 contactPoint = other.ClosestPointOnBounds(transform.position);
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contactPoint.normalized);
            Vector3 pos = contactPoint;
            Instantiate(hitWallVFX, pos, rot);
        }


    }


}
