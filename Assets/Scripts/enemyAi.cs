using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class enemyAi : MonoBehaviour
{

    public GameObject player;
    public GameObject enemyHit;
    public GameObject blood;
    public sfxScript sfx;
    public movementScript mv;
    public Transform tr;
    public Animator anim;
    public float speed = 5;
    public int hp = 2;
    public int knockback = 5200;
    public bool lookingRight = true;
    public bool attacking = false;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetBool("isAttacking") == false)
        {

            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        }
        
        
        if(distance != 0)
        {

            anim.SetBool("isRunning", true);

        }


        

        if(player.transform.position.x < this.transform.position.x)
        {

            lookingRight = true;
            transform.rotation = Quaternion.Euler(Vector3.up * 180);

        }
        else
        {

            lookingRight = false;
            transform.rotation = Quaternion.Euler(Vector3.up * 0);

        }

    }

    public void takeDamage()
    {
        StartCoroutine(effect());

        if(hp>1)
        {

            hp--;
            if(lookingRight)
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2((1 * knockback) * Time.deltaTime,0));
            else
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2((-1 * knockback) * Time.deltaTime,0));

        }
        else if(hp == 1)
        {
            death();
        }

    }

    public void death()
    {

        this.gameObject.GetComponent<Animator>().SetBool("isDying", true);
        sfx.playdeath();
        GameObject bloodClone = Instantiate(blood);
        bloodClone.transform.position = transform.position;
        bloodClone.SetActive(true);
        Destroy(bloodClone, 1);
        Destroy(this.gameObject.GetComponent<enemyAi>());
        Destroy(this.gameObject.GetComponent<CircleCollider2D>());
        Destroy(this.gameObject, 1);

    }

    public void enemyAttacks()
    {
        if (anim.GetBool("isAttacking") == false)
        { 
            StartCoroutine(enemyAttackDelay());
        }

    }

    IEnumerator enemyAttackDelay()
    {

        anim.SetBool("isAttacking", true);
        yield return new WaitForSeconds(0.65f);
        enemyHit.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        enemyHit.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        
        anim.SetBool("isAttacking", false);


    }

    IEnumerator effect()
    {
        this.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            mv.damage();

        }

       /*
        if (collision.gameObject.CompareTag("enemy")) 
        {
            StartCoroutine(passThru());
        }
       */
    }

    

   /* 
    IEnumerator passThru() //ÝSKELETLERÝN BÝRBÝRÝNE TAKILMAMASI ÝÇÝN (çalýþmýyo biriniz hallediverin)
    { 
        gameObject.layer = 7;
        yield return new WaitForSeconds(1f);
       gameObject.layer = 6;
    }
   */
}
