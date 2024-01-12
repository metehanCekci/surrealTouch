using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inRoomScript : MonoBehaviour
{
    private bool isNotInRoom = true;
    [SerializeField] private GameObject roomCover;
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
            isNotInRoom = !isNotInRoom;
            roomCover.SetActive(isNotInRoom);
        }
    }
}
