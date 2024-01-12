using System.Collections;
using UnityEngine;

public class keyScript : MonoBehaviour
{

    public doorScript door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(GetComponentInParent<Animator>().enabled)
        {

            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine(delay());

        }
        
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(1);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        door.doorMoving = true;
        this.enabled = false; 
    }


}
