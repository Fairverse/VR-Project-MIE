using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    public bool isPressE;
    public bool isAvaiableForInteraction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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

        /*if (isAvaiableForInteraction)
        {
            GameManager.instance.UI.interactionPanel.SetActive(true);
        }

        else
        {
            GameManager.instance.UI.interactionPanel.SetActive(false);
        }*/

        if (isPressE && isAvaiableForInteraction)
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
                SceneManager.LoadScene(1);

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
                SceneManager.LoadScene(0);
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
