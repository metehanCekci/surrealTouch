using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightSwordScript : MonoBehaviour
{

    public Animator anim;
    public GameObject swordHitbox;
    public float hitboxDelayFloat = 0.1f;
    public bool onQueue = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (anim.GetBool("isAttacking"))
        {
            if (onQueue==false) {

                onQueue = true;
                StartCoroutine(hitboxDelay());

            }

        }




    }

    IEnumerator hitboxDelay()
    {
        
        yield return new WaitForSeconds(hitboxDelayFloat);
        swordHitbox.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        swordHitbox.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        onQueue = false;

    }
}
