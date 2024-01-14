using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class detectAi : MonoBehaviour
{

    public GameObject exclama;
    public bool isSkeleton = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject exclamaClone = Instantiate(exclama);
            exclamaClone.transform.position = transform.position += Vector3.up * 0.32f;
            exclamaClone.SetActive(true);
            exclamaClone.transform.parent = this.gameObject.transform;
            Destroy(exclamaClone, 1);
            if(isSkeleton) 
            {

                GetComponentInParent<enemyAi>().enabled = true;

            }
            else
            {

                GetComponentInParent<batAi>().enabled = true;

            }
            
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponentInParent<patrollingAi>().enabled = false;

        }
    }
}
