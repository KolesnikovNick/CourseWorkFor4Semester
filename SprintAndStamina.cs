using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintAndStamina : MonoBehaviour
{
    float stamina = 5; 
    float maxStamina = 5;
    float walkSpeed, runSpeed;
    PlayerMovement pm;
    bool isRunning;


    // Start is called before the first frame update
    void Start()
    {
        pm = gameObject.GetComponent<PlayerMovement>();
        walkSpeed = pm.speed;
        runSpeed = walkSpeed * 2;
    }

    void SetRunning(bool isRunning)
    {
        this.isRunning = isRunning;
        pm.speed = isRunning ? runSpeed : walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SetRunning(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            SetRunning(false);
        }

        if (isRunning)
        {
            stamina -= Time.deltaTime;
            if (stamina < 0)
            {
                stamina = 0;
                SetRunning(false);
            }
        }            
        else if (stamina < maxStamina)
        {
                stamina += Time.deltaTime;
        }
    }
}
