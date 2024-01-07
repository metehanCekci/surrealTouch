using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulderTrigger : MonoBehaviour
{
    [SerializeField] private GameObject boulder;
    [SerializeField] private trapBoulderScript trpBoulder;
    [SerializeField] private float delay;
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
        if (!trpBoulder.isBoulderActive) 
        {
        StartCoroutine(boulderDelay());
        }
        
    }
    IEnumerator boulderDelay() 
    {
        yield return new WaitForSeconds(delay);
        boulder.SetActive(true);
    }
}
