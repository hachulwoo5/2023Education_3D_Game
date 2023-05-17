using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target;
    private float spawnRate;
    public float spawntime;
    public float Checktime;

    


    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform; 
    }

    // Update is called once per frame
    void Update()
    {
        spawntime = Time.time - Checktime;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        if (GameManager.instance.playerController.isDie == false)
        {
           
            if (spawntime > spawnRate)
            { 
                StartCoroutine(BulletSpawn());
                DoTimerOffset();
            }
        }

        transform.LookAt(target);
        
        
    }

    IEnumerator BulletSpawn()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(0f);
        
    }

   
    
  
    void DoTimerOffset()

    {
        Checktime = Time.time;
    }
}
