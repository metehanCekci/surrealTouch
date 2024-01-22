using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampolineScript : MonoBehaviour
{

    public float jumpBoost = 350;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        collision.gameObject.GetComponent<Rigidbody2D>().velocity += Vector2.up * jumpBoost * Time.deltaTime;
        StartCoroutine(anim());
        

    }
    IEnumerator anim()
    {
        this.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<Animator>().enabled = false;
    }
}
