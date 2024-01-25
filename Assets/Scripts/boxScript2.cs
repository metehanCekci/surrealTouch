using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxScript2 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D boxRigid;
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
            boxRigid.constraints = RigidbodyConstraints2D.None;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            boxRigid.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
