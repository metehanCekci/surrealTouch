using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rageMusic : MonoBehaviour
{
    public AudioClip rage;
    public AudioSource musicSource;
    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playRage()
    {
        this.GetComponent<AudioSource>().PlayOneShot(rage);
        musicSource.mute = true;
        StartCoroutine(waitSec());
    }

    IEnumerator waitSec()
    {

        yield return new WaitForSeconds(15f);
        musicSource.mute = false;

    }
    
}
