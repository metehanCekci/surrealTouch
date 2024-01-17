using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartScript : MonoBehaviour
{

    public movementScript mv;
    public sfxScript sfx;
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

        if (collision.gameObject.tag == "Player")
        {

            if(mv.hp <=2)
            mv.hp++;
            Destroy(this.gameObject);
            sfx.playHeart();

        }

    }
}
