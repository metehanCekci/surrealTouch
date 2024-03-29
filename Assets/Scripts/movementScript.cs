using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Timeline;

public class movementScript : MonoBehaviour
{
    public float jumpHeight = 100f;
    private float jumpHeightUnchanged = 100f;
    private float enragedJumpHeight = 150f;
    public float runningSpeed = 100f;
    private float runningSpeedUnchanged = 100f;
    private float enragedRunningSpeed = 150f;
    public GameObject player;
    public Animator animator;
    public GameObject arrow;
    public GameObject arrowPlace;
    public bool canattack = true;
    private int selam=1;
    public bool isAttacking = false;
    public float waitsecf = 3f;
    public float falljumpIntensity;
    public ledgeScript ledge;
    public sfxScript sfx;
    public int hp = 3;
    public int rage = 0;
    public bool onrage = false;
    public float iFrameFloat = 0.5f;
    public GameObject buttons;
    public CapsuleCollider2D hitbox;
    public Rigidbody2D rigid;
    public float knockback = 5f;
    public SpriteRenderer playerSprite;
    public GameObject retryMenu;
    public knightSwordScript swordScript;
    public rageMusic rageM;
    public boxScript box;

    
    public bool lookingRight = true;
    private bool isKnight;
    private string CHAR_NAME = "Knight";
    private bool isMoving = false;
    private bool isDead = false;
    public bool isTouchingBox = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
        if (player.gameObject.name == CHAR_NAME) 
        {
            isKnight = true;
        }
        else
        {
            isKnight = false;
        }

        Application.targetFrameRate = 60;
        isDead = false;
        isMoving = false;
        isTouchingBox = false;

        jumpHeightUnchanged = jumpHeight;
        runningSpeedUnchanged = runningSpeed;

    }

    // Update is called once per frame
    void Update()
    {

        

        if (rage==6 && onrage==false) onRage();
        
        if(onrage)
        {

            rage = 6;

        }

        /* ÝKÝ KERE KARÞILAÞTIRMAYA GEREK YOK, "MOVING" DURUMU YETERLÝ
        if (goingLeft)
        {

            player.transform.position += player.transform.right * runningSpeed * Time.deltaTime;
            

        }
        if (goingRight)
        {

            player.transform.position += player.transform.right * runningSpeed * Time.deltaTime;
            

        }
        */

        if (isMoving && !isDead && (isAttacking==false || isKnight)) 
        {
            player.transform.position += player.transform.right * runningSpeed * Time.deltaTime;
        }

        
        if (rigid.velocity.y > falljumpIntensity)
        {

            animator.SetBool("isJumping", true);
            animator.SetBool("isFalling", false);
            isTouchingBox = false;
        }
        
        else if (rigid.velocity.y < -1 * falljumpIntensity)
        {

            if (player.gameObject.name == CHAR_NAME || ledge.isTouching == false)
            {

                animator.SetBool("isJumping", false); 
                animator.SetBool("isFalling", true);
                
            }
            
            isTouchingBox = false;

        }
        else
        {
            
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);

        }
    }

    public void onRage()
    {
        onrage = true;
        player.layer = 7;
        runningSpeed = enragedRunningSpeed;
        jumpHeight = enragedJumpHeight;
        playerSprite.color = Color.yellow;
        rageM.playRage();
        StartCoroutine(quitRage());

    }

    IEnumerator quitRage()
    {

        yield return new WaitForSeconds(15f);
        player.layer = 6;
        runningSpeed = runningSpeedUnchanged;
        jumpHeight = jumpHeightUnchanged;
        playerSprite.color = Color.white;
        rage = 0;
        onrage = false;

    }

    public void goRight()
    {

        animator.SetBool("isRunning", true);
        isMoving = true;
        if(lookingRight == false)
        {

            lookingRight = true;

            player.transform.rotation = Quaternion.Euler(Vector2.up * 0);

        }

    }

    public void goLeft()
    {

        animator.SetBool("isRunning", true);
        isMoving = true;

        if(lookingRight)
        {

            lookingRight = false;

            player.transform.rotation = Quaternion.Euler(Vector2.up * 180);

        }
        
    }

    public void stop()
    {

        animator.SetBool("isRunning", false);
        isMoving = false;

    }

    public void attack()
    {
        if (canattack)
        {
            
            if (isKnight)
            {
                if (swordScript.onQueue == false) 
                {
                    player.GetComponentInChildren<knightSwordScript>().attack();
                    animator.SetBool("isAttacking", true);
                    sfx.playSword();
                    StartCoroutine(attackReset());

                }
            }
            else 
            {

                rigid.constraints = RigidbodyConstraints2D.FreezeAll;
                animator.SetBool("isAttacking", true);
                sfx.playDraw();
                isAttacking = true;
                StartCoroutine(attackDelay());
                StartCoroutine(attackReset());
                
            }
        
        
        }

    }

    public void jump()
    {
        if (rigid.velocity.y == 0 || isTouchingBox) 
        { 
            if (isKnight)
                { 

                    rigid.velocity += Vector2.up * jumpHeight;
                    isTouchingBox = false;
                }
            else
                {

                

                    rigid.velocity += Vector2.up * jumpHeight;

                

                }
        }
        
        
    }

    public void damage()
    {

        if (player.layer == 6 && !isDead)
        {
            if (hp > 0 && hp != 1)
            {
                if(lookingRight)
                {
                    rigid.AddForce(new Vector2((-1 * knockback) * Time.deltaTime, knockback * Time.deltaTime), ForceMode2D.Impulse);
                }
                else
                {
                    rigid.AddForce(new Vector2((knockback) * Time.deltaTime, knockback * Time.deltaTime), ForceMode2D.Impulse);
                }
                sfx.playtakedamage();
                hp--;
                StartCoroutine(Iframes());

            }

            else if (hp == 1)
            {
                hp--;
                sfx.playtakedamage();
                animator.SetBool("isDying", true);
                StartCoroutine(death());
            }
            
        }

    }

    IEnumerator attackReset()
    {

        canattack = false;
        
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("isAttacking", false);
        yield return new WaitForSeconds(waitsecf);
        canattack = true;
       
        
        

    }

    public void afterAttack()
    {

            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.up * 0.1f;
            isAttacking = false;
    }
    

    IEnumerator attackDelay()
    {

        yield return new WaitForSeconds(0.43f);
        sfx.playbow();
        GameObject cloneArrow = Instantiate(arrow);
        cloneArrow.transform.position = (arrowPlace.transform.position);
        cloneArrow.SetActive(true);
        Destroy(cloneArrow , 3);
        afterAttack();
        

    }

    

    IEnumerator Iframes()
    {
        player.layer = 7;
        playerSprite.color = Color.red;
        yield return new WaitForSeconds(iFrameFloat);
        player.layer = 6;
        playerSprite.color = Color.white;
    }

    [HideInInspector]public IEnumerator death()
    {   
        rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        isDead = true;
        buttons.SetActive(false);
        hitbox.enabled = false;


        if (isKnight) 
        {
            yield return new WaitForSeconds(1);
        }
        else 
        {
            yield return new WaitForSeconds(2);
            
        }
        player.SetActive(false);
        retryMenu.SetActive(true);
        Time.timeScale = 0;



    }
}
