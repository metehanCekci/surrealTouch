using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapDoorScript : MonoBehaviour
{
    [SerializeField] private GameObject trapDoor;
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
            trapDoor.SetActive(false);
        }
    }
}
