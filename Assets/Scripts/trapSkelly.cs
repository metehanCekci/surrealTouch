using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapSkelly : MonoBehaviour
{
    [SerializeField] private GameObject trapDoor;
    [SerializeField] private GameObject skellyDoor;
    [SerializeField] private GameObject skelly;
    [SerializeField] private float delay = 0;
    [SerializeField] private bool inFloor = false;
        // Start is called before the first frame update
    void Start()
    {
        skelly.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(skellTrap());
        }
    }

    IEnumerator skellTrap() 
    {
        yield return new WaitForSeconds(delay);
        if (inFloor)
        {
            skelly.SetActive(true);
        }
        else
        {
            skellyDoor.SetActive(false);
            skelly.SetActive(true);
        }
    }
}
