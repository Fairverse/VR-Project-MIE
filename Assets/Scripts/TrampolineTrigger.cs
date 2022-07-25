using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineTrigger : MonoBehaviour
{
    public Transform trampolinePlace;

    public bool isPressE;
    public bool isAvaiableForInteraction;

    #region Singleton
    public static TrampolineTrigger instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
            GameManager.instance.Movement.player.transform.position = trampolinePlace.position;
            GameManager.instance.Movement.player.GetComponentInParent<Movement>().enabled = false;
            GameManager.instance.Movement.player.transform.eulerAngles = new Vector3(0, -150, 0);
            GameManager.instance.UI.interactionPanel.SetActive(false);
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
