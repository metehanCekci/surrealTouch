using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Timeline;

public class movementScript : MonoBehaviour
{
    public float jumpHeight = 100;
    public float jumpHeightUnchanged = 100;
    public float enragedJumpHeight = 150;
    public float runningSpeed = 100;
    public float runningSpeedUnchanged = 100;
    public float enragedRunningSpeed = 150;
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

    public bool goingLeft = false;
    public bool goingRight = false;
    public bool lookingRight = true;
    private Vector2 facingleft;
    private bool isKnight;
    private string CHAR_NAME = "Knight";
    

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

    }

    // Update is called once per frame
    void Update()
    {

        if (rage==6 && onrage==false) onRage();
        
        if(onrage)
        {

            rage = 6;

        }
        
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

    public void onRage()
    {
        onrage = true;
        player.layer = 7;
        runningSpeed = enragedRunningSpeed;
        jumpHeight = enragedJumpHeight;
        player.GetComponent<SpriteRenderer>().color = Color.yellow;
        rageM.playRage();
        StartCoroutine(quitRage());

    }

    IEnumerator quitRage()
    {

        yield return new WaitForSeconds(15f);
        player.layer = 6;
        runningSpeed = runningSpeedUnchanged;
        jumpHeight = jumpHeightUnchanged;
        player.GetComponent<SpriteRenderer>().color = Color.white;
        rage = 0;
        onrage = false;

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
                animator.SetBool("isAttacking", true);
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

        if (player.layer == 6)
        {

            if (hp == 1)
            {
                hp--;
                sfx.playtakedamage();
                animator.SetBool("isDying", true);
                StartCoroutine(death());
            }
            else if (hp > 0)
            {
                if(lookingRight)
                {
                    rigid.AddForce(new Vector2((-1 * knockback) * Time.deltaTime, knockback * Time.deltaTime));
                }
                else
                {
                    rigid.AddForce(new Vector2((knockback) * Time.deltaTime, knockback * Time.deltaTime));
                }
                sfx.playtakedamage();
                hp--;
                StartCoroutine(Iframes());

            }
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

    [HideInInspector]public IEnumerator death()
    {
        buttons.SetActive(false);
        hitbox.enabled = false;
        rigid.velocity = Vector3.zero;
        rigid.gravityScale = 0;
        
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
