using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.Burst.CompilerServices;
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
    public float waitsecf = 3f;
    public float falljumpIntensity;
    public ledgeScript ledge;
    public sfxScript sfx;
    public int hp = 3;
    public float iFrameFloat = 0.5f;
    public Canvas buttons;
    public CapsuleCollider2D hitbox;
    public Rigidbody2D rigid;
    public float knockback = 5f;
    public SpriteRenderer playerSprite;
    public GameObject retryMenu;

    public bool goingLeft = false;
    public bool goingRight = false;
    public bool lookingRight = true;
    private Vector2 facingleft;
    private bool isKnight;
    private string CHAR_NAME = "Knight";
    //Axell seçildiði vakit ok atma fonksiyonunu iptal etmeye çalýþtým, olmadý
    //(attack fonksiyonunun içinde) 

    //Axell'in kullanmadýðý fonksiyonlarý bi þekilde kapatmalýyýz,
    //ne olur ne olmaz boþta durup hata vermesinler
    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


    // Start is called before the first frame update
    void Start()
    {
        if (player.gameObject.name == CHAR_NAME) //iþe yaramýyo ;(
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
        
        else if (player.GetComponent<Rigidbody2D>().velocity.y < -1 * falljumpIntensity)
        {

            if (player.gameObject.name == CHAR_NAME || ledge.isTouching == false)
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

    public void damage()
    {

        

        if(hp == 1)
        {
            
            sfx.playtakedamage();
            animator.SetBool("isDying", true);
            StartCoroutine(death());
        }
        else if(hp > 0)
        {
            rigid.AddForce(new Vector2((-1 * knockback) * Time.deltaTime, knockback * Time.deltaTime));
            sfx.playtakedamage();
            hp--;
            StartCoroutine(Iframes());

        }
        

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
        sfx.playbow();
        GameObject cloneArrow = Instantiate(arrow);
        cloneArrow.transform.position = (arrowPlace.transform.position);
        cloneArrow.SetActive(true);
        Destroy(cloneArrow , 3);

    }

    IEnumerator Iframes()
    {
        player.layer = 7;
        playerSprite.color = Color.red;
        yield return new WaitForSeconds(iFrameFloat);
        player.layer = 6;
        playerSprite.color = Color.white;
    }

    IEnumerator death()
    {
        buttons.enabled = false;
        hitbox.enabled = false;
        rigid.gravityScale = 0;

        yield return new WaitForSeconds(2);

        player.SetActive(false);
        //RETRY YAPACAK ADAM ÝÇÝN NOT TAM BURAYA KOY CANVASI AKTÝF ET SONRA RETRY VEYA PLAY AGAIN DÝYÝNCE BU SAHNEYÝ LOADLA//
        //eyw apo adam
        retryMenu.SetActive(true);
        Time.timeScale = 0;
        

    }
}
