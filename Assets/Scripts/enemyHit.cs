using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHit : MonoBehaviour
{
    public GameObject player;
    
    
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

        Debug.Log("1");

        if (collision.gameObject.tag == "player")
        {
            Debug.Log("2");
            Destroy(player);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("1");

        if (collision.gameObject.tag == "player")
        {
            Debug.Log("2");
            Destroy(player);

        }

    }
}
