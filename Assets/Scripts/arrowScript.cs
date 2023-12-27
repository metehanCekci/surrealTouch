using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{

    public float arrowspeed = 10;
    public movementScript mov;
    public Transform tr;
    private float degrees = 180;
    // Start is called before the first frame update
    void Start()
    {

        if (mov.lookingRight)
        {

            transform.rotation = Quaternion.Euler(Vector3.forward * 0);

        }
        else
        {


            transform.rotation = Quaternion.Euler(Vector3.forward * degrees);

        }

    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position += this.transform.right * arrowspeed * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "enemy")
        {

            Destroy(collision.gameObject);
            Destroy(this.gameObject
                );
            
        }

    }
}