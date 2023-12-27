using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAi : MonoBehaviour
{

    public GameObject player;
    public GameObject enemyHit;
    public Transform tr;
    public Animator anim;
    public float speed = 5;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        
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

            transform.rotation = Quaternion.Euler(Vector3.up * 180);

        }
        else
        {

            transform.rotation = Quaternion.Euler(Vector3.up * 0);

        }

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
        yield return new WaitForSeconds(1f);
        enemyHit.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        enemyHit.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("isAttacking", false);


    }
}
