using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class animation : MonoBehaviour
{

    public Animator anim;
    public bool flashanim;
    public GameObject efekt;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(start());
    }

    // Update is called once per frame
    void Update()
    {
        if (flashanim)
        {

            efekt.transform.localScale += Vector3.one;

        }
    }

    IEnumerator start()
    {

        yield return new WaitForSeconds(2);
        anim.enabled = false;
        yield return new WaitForSeconds(1);
        flashanim = true;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);

    }
}
