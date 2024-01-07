using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class detectAi : MonoBehaviour
{

    public GameObject exclama;
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
            exclamaClone.transform.position = transform.position += Vector3.up * 0.20f;
            exclamaClone.SetActive(true);
            exclamaClone.transform.parent = this.gameObject.transform;
            Destroy(exclamaClone, 1);
            GetComponentInParent<batAi>().enabled = true;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponentInParent<patrollingAi>().enabled = false;

        }
    }
}
