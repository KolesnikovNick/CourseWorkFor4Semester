using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCounter : MonoBehaviour
{
    public GameObject keyPickUp;

    public AudioSource keyPickUpSound;
    // Start is called before the first frame update

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            keyPickUpSound.Play();
            KeyExit.keyPisces += 1;
            keyPickUp.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        keyPickUp.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        keyPickUp.SetActive(false);
    }
}
