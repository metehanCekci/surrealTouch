using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxScript : MonoBehaviour
{

    [SerializeField] private movementScript movement;
    private bool contactCondition = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            contactCondition = true;
            StartCoroutine(touchCondition());
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            contactCondition = false;
            StartCoroutine(touchCondition());
        }
    }

    IEnumerator touchCondition() 
    {
        if (contactCondition) 
        {
            movement.isTouchingBox = true;
        }
        else 
        {
            movement.isTouchingBox = false;
        }

        yield return new WaitForSeconds(0.1f);
    }


    
    
    

}
