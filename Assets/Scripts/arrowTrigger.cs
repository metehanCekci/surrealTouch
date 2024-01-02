using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class arrowTrigger : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private bool isArrowDelayed = false;
    [SerializeField] private float delay = 0;
    [SerializeField] private float arrowSpeed = 0;
    // Start is called before the first frame update
    private void Awake()
    {
       

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (arrow.activeInHierarchy == false) ;
        else 
        {
            arrow.transform.position += arrow.transform.position * arrowSpeed * Time.deltaTime;
        }
        
            
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
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

    IEnumerator arrowDelay() 
    {
        yield return new WaitForSeconds(delay);
        arrow.SetActive(true);
    }
}
