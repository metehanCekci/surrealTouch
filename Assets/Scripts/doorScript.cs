using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    public float doorSpeed = 1;
    public bool doorMoving = false;
    private bool stop = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (doorMoving)
        {
            if(stop==false)
            this.transform.position += transform.up * doorSpeed * Time.deltaTime;

        }
    }

    public void start()
    {

        doorMoving = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "stopper")
        { 
            stop = true;
        }
    }
}
