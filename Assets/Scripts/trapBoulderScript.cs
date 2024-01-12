using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapBoulderScript : MonoBehaviour
{
    [SerializeField] private movementScript movement;
    [HideInInspector] public bool isBoulderActive = false;
    // Start is called before the first frame update
    void Start()
    {
        isBoulderActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            movement.damage();
            if(isBoulderActive) Destroy(gameObject);
        }
    }
}
