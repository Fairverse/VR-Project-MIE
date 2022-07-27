using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingTrigger : MonoBehaviour
{
    public Transform swingPlace;
    public Transform charPos;

    public bool isPressE;
    public bool isAvaiableForInteraction;

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

        if (isPressE && isAvaiableForInteraction)
        {
            GameManager.instance.Movement.player.transform.position = swingPlace.position;
            GameManager.instance.Movement.player.GetComponentInParent<Movement>().enabled = false;
            GameManager.instance.Movement.player.transform.eulerAngles = swingPlace.eulerAngles;
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
