using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrollingAi : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float speed = 5;

    public bool towardsA = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (towardsA)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, pointA.transform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(this.transform.position, pointB.transform.position, speed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        

    }
}
