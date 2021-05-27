using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyExit : MonoBehaviour
{
    public GameObject infoWin;
    public GameObject infoToEscape;
    public GameObject MonsterSpawn;
    
    public static int keyPisces = 0;
    public static int keyPiscesToWin = 7;
    private bool isFirstKeyPickedUp=false;

    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        if (keyPisces == 1)
        {
            isFirstKeyPickedUp = true;
        }
        if (isFirstKeyPickedUp)
        {
            MonsterSpawn.SetActive(true);
        }
        if (keyPisces == keyPiscesToWin-1)
        {
            StartCoroutine(ExitReady());
            keyPisces += 1;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (keyPisces == keyPiscesToWin)
        {
            infoWin.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            SceneManager.LoadScene(3);
            
        }
    }

    IEnumerator ExitReady()
    {
        infoToEscape.SetActive(true);
        yield return new WaitForSeconds(5);
        infoToEscape.SetActive(false);
    }
    
}
