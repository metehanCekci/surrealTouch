using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    
    public GameObject obje;
    
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Animator>().enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "arrow") 
        {

            this.GetComponent<Animator>().enabled = true;
            obje.GetComponent<doorScript>().start();

        }
    }
}
