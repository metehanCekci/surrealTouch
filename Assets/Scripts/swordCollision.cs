using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordCollision : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {

            collision.gameObject.GetComponent<Animator>().SetBool("isDying", true);
            Destroy(collision.gameObject.GetComponent<enemyAi>());
            Destroy(collision.gameObject.GetComponent<CircleCollider2D>());
            Destroy(collision.gameObject, 1);

        }
    }


}
