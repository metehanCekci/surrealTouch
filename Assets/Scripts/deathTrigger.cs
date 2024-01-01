using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class deathTrigger : MonoBehaviour
{
    [SerializeField] private movementScript movement;
    [SerializeField] private sfxScript sfx;
    [SerializeField] private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sfx.playtakedamage();
            animator.SetBool("isDying", true);
            movement.StartCoroutine(movement.death());
        }
    }

}
