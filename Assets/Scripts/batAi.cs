using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class batAi : MonoBehaviour
{
    public GameObject player;
    public float speed = 5;
    private float distance;
    public batAi bat;
    public movementScript movement;
    public int hp = 2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);


        if (player.transform.position.x < this.transform.position.x)
        {

            transform.rotation = Quaternion.Euler(Vector3.up * 180);

        }
        else
        {

            transform.rotation = Quaternion.Euler(Vector3.up * 0);

        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {

        

    }*/
    
    public void hpReduce()
    {

        if (hp > 1)
        {
            hp--;
        }
        else if (hp == 1)
        {

            Destroy(this.gameObject);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
                
                movement.damage();
            
        }
    }
}
