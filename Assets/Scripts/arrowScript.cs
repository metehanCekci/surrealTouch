using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{

    public float arrowspeed = 10;
    public movementScript mov;
    public Transform tr;
    private float degrees = 180;
    public sfxScript audio;
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
        Destroy(this, 5);
    }

    // Update is called once per frame
    void Update()
    {

        if(mov.onrage)
        { transform.localScale = new Vector3(0.1f, 0.12f, 0); }
        else
        { transform.localScale = new Vector3(0.03566787f, 0.04169711f, 0); }
        this.transform.position += this.transform.right * arrowspeed * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "enemy")
        {

            
            collision.gameObject.GetComponent<batAi>().hpReduce();
            audio.playhit();
            Destroy(this.gameObject);
            
            
        }
        else if(collision.gameObject.tag == "arrowDestroyer")
        {

            
            Destroy(this.gameObject);

        }

    }
}
