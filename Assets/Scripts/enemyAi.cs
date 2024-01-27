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
    public float speed = 5f;
    public float jumpHeight = 5f;
    public int hp = 2;
    public int knockback = 5200;
    public bool lookingRight = true;
    public bool attacking = false;
    private bool isDead = false;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetBool("isAttacking") == false && !isDead)
        {

            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        }
        
        
        if(distance != 0 && !isDead)
        {

            anim.SetBool("isRunning", true);

        }


        

        if(player.transform.position.x < transform.position.x)
        {

            lookingRight = true;
            transform.rotation = Quaternion.Euler(Vector3.up * 180);

        }
        else
        {

            lookingRight = false;
            transform.rotation = Quaternion.Euler(Vector3.up * 0);

        }

        if(player.transform.position.y > transform.position.y) 
        {
            if(gameObject.GetComponent<Rigidbody2D>().velocity.y == 0) 
            {
                gameObject.GetComponent<Rigidbody2D>().velocity += Vector2.up * jumpHeight;
            }
        }

    }

    public void takeDamage()
    {
        

        if(hp>1)
        {

            hp--;
            if (lookingRight)
            { GetComponent<Rigidbody2D>().AddForce(new Vector2((1 * knockback) * Time.deltaTime, 0)); }
            else 
            { GetComponent<Rigidbody2D>().AddForce(new Vector2((-1 * knockback) * Time.deltaTime, 0)); }
            StartCoroutine(effect());

        }
        else if(hp == 1)
        {
            death();
        }

    }

    public void death()
    {
        isDead = true;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        anim.SetBool("isDying", true);
        sfx.playdeath();
        GameObject bloodClone = Instantiate(blood);
        bloodClone.transform.position = transform.position;
        bloodClone.SetActive(true);
        Destroy(bloodClone, 1);
        Destroy(gameObject.GetComponent<CapsuleCollider2D>());
        Destroy(gameObject.GetComponent<enemyAi>());
        Destroy(gameObject.GetComponent<CircleCollider2D>());
        Destroy(gameObject, 1);

    }

    public void enemyAttacks()
    {
        if (anim.GetBool("isAttacking") == false && !isDead)
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
        if (anim.GetBool("isAttacking")) 
        {
            anim.SetBool("isAttacking", false);
        }

        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
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
