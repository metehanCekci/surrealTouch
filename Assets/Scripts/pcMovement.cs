using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pcMovement : MonoBehaviour
{
    public movementScript movementscript;
    public PauseMenuScript pauseMenuScript;

    void Start()
    {
        //movementscript = GameObject.Find("movementScript").GetComponent<movementScript>();
        //pauseMenuScript = GameObject.Find("PauseMenuScript").GetComponent<PauseMenuScript>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            movementscript.jump();
        }

        if (Input.GetKey(KeyCode.K))
        {
            movementscript.attack();
        }

        if (Input.GetKey(KeyCode.D))
        {
            movementscript.goRight();
        }

        if (Input.GetKey(KeyCode.A))
        {
            movementscript.goLeft();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuScript.PauseEnable();
        }

        // Durma koþulu
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            movementscript.stop();
        }
    }
}

