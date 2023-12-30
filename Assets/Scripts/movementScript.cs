using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class movementScript : MonoBehaviour
{

    public float jumpHeight = 100;
    public float runningSpeed = 100;
    public GameObject player;
    public Animator animator;
    public SpriteRenderer sprites;
    public GameObject arrow;
    public GameObject arrowPlace;
    public bool canattack = true;
    public float waitsecf = 0.5f;
    public float falljumpIntensity;
    public ledgeScript ledge;

    public bool goingLeft = false;
    public bool goingRight = false;
    public bool lookingRight = true;
    private Vector2 facingleft;
    private bool isKnight;
    private string CHAR_NAME = "Hero Knight 2";
    //Axell seçildiði vakit ok atma fonksiyonunu iptal etmeye çalýþtým, olmadý
    //(attack fonksiyonunun içinde) 

    //Axell'in kullanmadýðý fonksiyonlarý bi þekilde kapatmalýyýz,
    //ne olur ne olmaz boþta durup hata vermesinler
    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == CHAR_NAME) //iþe yaramýyo ;(
        {
        isKnight = true;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (goingLeft)
        {

            player.transform.position += player.transform.right * runningSpeed * Time.deltaTime;

        }
        if (goingRight)
        {

            player.transform.position += player.transform.right * runningSpeed * Time.deltaTime;

        }

        if (player.GetComponent<Rigidbody2D>().velocity.y > falljumpIntensity)
        {

            animator.SetBool("isJumping", true);
            animator.SetBool("isFalling", false);

        }
        else if(player.GetComponent<Rigidbody2D>().velocity.y < -1 * falljumpIntensity)
        {

            if(ledge.isTouching==false)
            {

                animator.SetBool("isJumping", false);
                animator.SetBool("isFalling", true);

            }
            

        }
        else
        {

            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);

        }
    }

    public void goRight()
    {

        animator.SetBool("isRunning", true);
        goingRight = true;

        if(lookingRight == false)
        {

            lookingRight = true;

            player.transform.rotation = Quaternion.Euler(Vector3.up * 0);

        }

    }

    public void goLeft()
    {

        animator.SetBool("isRunning", true);
        goingLeft = true;

        if(lookingRight)
        {

            lookingRight = false;

            player.transform.rotation = Quaternion.Euler(Vector3.up * 180);

        }
        
    }

    public void stop()
    {

        animator.SetBool("isRunning", false);
        goingLeft = false;
        goingRight = false;

    }

    public void attack()
    {
        if (canattack)
        {
        animator.SetBool("isAttacking", true);
            if (isKnight)
            {
                StartCoroutine(attackReset());
            }
            else 
            {
                StartCoroutine(attackDelay());
                StartCoroutine(attackReset());
            }
        
        
        }

    }

    public void jump()
    {
        if(player.GetComponent<Rigidbody2D>().velocity.y == 0)
        player.GetComponent<Rigidbody2D>().velocity += Vector2.up * jumpHeight;
        
    }

    public void death()
    {

        animator.SetBool("isDying", true);

    }

    IEnumerator attackReset()
    {

        canattack = false;
        yield return new WaitForSeconds(waitsecf);
        canattack = true;
        animator.SetBool("isAttacking", false);

    }

    IEnumerator attackDelay()
    {

        yield return new WaitForSeconds(0.43f);
        GameObject cloneArrow = Instantiate(arrow);
        cloneArrow.transform.position = (arrowPlace.transform.position);
        cloneArrow.SetActive(true);
        Destroy(cloneArrow , 3);

    }
}
