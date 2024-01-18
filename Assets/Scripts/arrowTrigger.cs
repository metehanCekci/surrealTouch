using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class arrowTrigger : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private trapArrowScript trpArrow;
    [SerializeField] private bool isArrowDelayed = false;
    [SerializeField] private float delay = 0;
    
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
        if (collision.gameObject.CompareTag("Player")) {
            if (!trpArrow.isArrowActive)
            {
                if (!isArrowDelayed)
                {
                    arrow.SetActive(true);

                }
                else
                {
                    StartCoroutine(arrowDelay());
                }
            }
        }
        
        
    }

    IEnumerator arrowDelay() 
    {
        yield return new WaitForSeconds(delay);
        arrow.SetActive(true);
    }
}
