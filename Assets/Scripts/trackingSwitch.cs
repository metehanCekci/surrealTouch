using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackingSwitch : MonoBehaviour
{
    public patrollingAi ai;
    public GameObject bat;
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
        
        
            if (collision.gameObject == bat.transform.GetChild(2).gameObject)
            {
                if (ai.towardsA) { ai.towardsA = false; ai.gameObject.transform.rotation = Quaternion.Euler(Vector3.up * 0); }

                else { ai.towardsA = true; ai.gameObject.transform.rotation = Quaternion.Euler(Vector3.up * 180); }
            }
        
        
    }
}
