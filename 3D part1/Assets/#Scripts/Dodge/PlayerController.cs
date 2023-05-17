using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    private Rigidbody playerRigidbody;
    public float Speed = 8f;
    public float rotateSpeed = 10.0f;       // 회전 속도
    public int maxhp = 5;
    public GameObject boom;
    public GameObject revive;
    public GameObject tp;

    public bool isDie;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {


        if (maxhp<=0)
        {
            maxhp = 0;
            Die();
        }
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Teleport();
        }
    }

    void FixedUpdate()
    {
        float h, v;

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v); // new Vector3(h, 0, v)가 자주 쓰이게 되었으므로 dir이라는 변수에 넣고 향후 편하게 사용할 수 있게 함

        if (!(h == 0 && v == 0))
        {
            transform.position += dir * Speed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);
        }
    }

    public void Die()
    {
        isDie = true;
        gameObject.SetActive(false);
        Instantiate(boom, transform.position, transform.rotation);
        GameManager.instance.EndGame();

       
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            maxhp--;
        }
    }

    public void Init()
    {
        // [Player]
        isDie = false; maxhp = 5; transform.position = new Vector3(0, 0.7622f, 0);
        GameObject ReviveVFX = Instantiate(revive, transform.position, transform.rotation); Destroy(ReviveVFX, 0.4f);

        // [Gamemanager]
        GameManager.instance.DoTimerOffset();
        GameManager.instance.StartGame();
    }

    public void Teleport()
    {
        transform.Translate(Vector3.forward * 2f);
        GameObject TpVFX = Instantiate(tp, transform.position, transform.rotation);
    }
}
