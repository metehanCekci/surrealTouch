using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxScript : MonoBehaviour
{
    public AudioClip hit;
    public AudioClip death;
    public AudioClip takedamage;
    public AudioClip bow;
    public AudioClip sword;
    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playhit()
    {
        this.GetComponent<AudioSource>().PlayOneShot(hit);
    }
    public void playdeath()
    {
        this.GetComponent<AudioSource>().PlayOneShot(death);
    }
    public void playtakedamage()
    {
        this.GetComponent<AudioSource>().PlayOneShot(takedamage);
    }
    public void playbow()
    {
        this.GetComponent<AudioSource>().PlayOneShot(bow);
    }
    public void playSword()
    {
        this.GetComponent<AudioSource>().PlayOneShot(sword);
    }
}
