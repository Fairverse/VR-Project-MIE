using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NatureTrigger: MonoBehaviour
{
    public bool isPressE;
    public bool isAvaiableForInteraction;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isPressE);
        if (Input.GetKeyDown(KeyCode.E))
        {
            isPressE = true;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            isPressE = false;
        }

        if (isPressE && isAvaiableForInteraction)
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
                SceneManager.LoadScene(2);

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
                SceneManager.LoadScene(1);
          
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isAvaiableForInteraction)
        {
            isAvaiableForInteraction = true;
            GameManager.instance.UI.interactionPanel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isAvaiableForInteraction)
        {
            isAvaiableForInteraction = false;
            GameManager.instance.UI.interactionPanel.SetActive(false);
        }
    }
}
