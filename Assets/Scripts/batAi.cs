using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class batAi : MonoBehaviour
{
    public GameObject player;
    public GameObject heart;
    public GameObject blood;
    public sfxScript sfx;
    public float speed = 5;
    public float hop = 3;
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
            StartCoroutine(effect());           
            this.GetComponent<batAi>().enabled = true;
            this.GetComponentInChildren<detectAi>().enabled = false;
            this.GetComponent<patrollingAi>().enabled = false;
            
        }
        else if (hp == 1)
        {
            movement.rage++;
            sfx.playdeath();
            GameObject bloodClone = Instantiate(blood);
            bloodClone.transform.position = transform.position;
            bloodClone.SetActive(true);
            Destroy(bloodClone , 1);
            Destroy(this.gameObject);
            drop();

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            movement.damage();


        }

    }

    IEnumerator effect()
    {
        this.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void drop()
    {

        int chance = Random.Range(1, 10);

        if(chance > 5)
        {

            GameObject clone = Instantiate(heart);
            clone.SetActive(true);
            clone.GetComponent<Rigidbody2D>().velocity += Vector2.up * hop;
            clone.transform.position = transform.position;

        }

    }
}
