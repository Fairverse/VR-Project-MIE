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
            GameManager.instance.Movement.player.transform.eulerAngles = trampolinePlace.eulerAngles;
            GameManager.instance.UI.interactionPanel.SetActive(false);

            StartCoroutine(Jump());
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

    public IEnumerator Jump()
    {
        yield return new WaitForSeconds(1);

        GameManager.instance.Movement.player.transform.Translate(0, 1, 0);

        yield return new WaitForSeconds(0.5f);

        GameManager.instance.Movement.player.transform.Translate(0, -1, 0);

        yield return new WaitForSeconds(0.5f);

        GameManager.instance.Movement.player.transform.Translate(0, 1, 0);

        yield return new WaitForSeconds(0.5f);

        GameManager.instance.Movement.player.transform.Translate(0, -1, 0);

        yield return new WaitForSeconds(0.5f);

        GameManager.instance.Movement.player.transform.Translate(0, 1, 0);

        yield return new WaitForSeconds(0.5f);

        GameManager.instance.Movement.player.transform.Translate(0, -1, 0);
    }
}
