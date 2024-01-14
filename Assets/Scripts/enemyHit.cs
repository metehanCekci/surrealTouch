using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHit : MonoBehaviour
{
    public GameObject player;
    public movementScript mv;
    
    
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

        

        if (collision.gameObject.tag == "Player")
        {

            mv.damage();

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        

        if (collision.gameObject.tag == "player")
        {
            
            mv.damage();

        }

    }
}
