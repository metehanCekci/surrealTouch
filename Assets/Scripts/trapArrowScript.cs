using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapArrowScript : MonoBehaviour
{
    [SerializeField] private float arrowSpeed;
    [SerializeField] private movementScript movement;
    [HideInInspector] public bool isArrowActive = false;
    // Start is called before the first frame update
    void Start()
    {
        isArrowActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * arrowSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            movement.damage();
            if(isArrowActive) Destroy(gameObject);
        }
        
       
    }

}
