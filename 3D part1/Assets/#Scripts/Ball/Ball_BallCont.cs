using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_BallCont : MonoBehaviour
{
    public GameObject GoalVFX;

    public List<GameObject> currentList;
    public List<GameObject> previousList;

    private Rigidbody rigid;
    private MeshRenderer meshRenderer;

    public float speed;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Ball_Goal")
        {
            Instantiate(GoalVFX, transform.position, transform.rotation);
            Ball_GameManager.instance.isGoal = true;
        }

        if (other.gameObject.tag == "Floor")
        {       
            currentList[0] = other.gameObject;       
        }
    }

 

  

    private void Update()
    {
        CheckListChange();

        Vector3 velocity = rigid.velocity;
        speed = velocity.magnitude;
 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(speed);
        }
    }


    private void CheckListChange()
    {
        
        if (!ListsAreEqual(previousList, currentList))
        {
            GameObject Effect = Instantiate(GoalVFX, transform.position, transform.rotation);
            if(speed>=1)
            {
                Effect.transform.localScale *=  speed *0.25f ;

            }
            previousList.Clear();
            previousList.AddRange(currentList);
        }
    }

    private bool ListsAreEqual(List<GameObject> list1, List<GameObject> list2)
    {
        
        // List의 순서와 요소가 일치해야 동일하다고 판단, 여러 과정을 거쳐 true 까지 도달
        if (list1.Count != list2.Count)
            return false;

        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i] != list2[i])
                return false;
        }
        return true;
    }

   
}

