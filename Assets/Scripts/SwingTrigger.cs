using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwingTrigger : MonoBehaviour
{
    public Transform swingPlace;
    public Transform charPos;
    public CinemachineVirtualCamera swingCam;

    public Animator swingAnimator;

    public bool isPressE;
    public bool isAvaiableForInteraction;
    public bool isSwing;

    #region Singleton
    public static SwingTrigger instance;

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

        if (isPressE && isAvaiableForInteraction)
        {
            Debug.Log("þu an");
            GameManager.instance.Movement.player.transform.position = charPos.position;
            GameManager.instance.Movement.player.GetComponentInParent<Movement>().enabled = false;
            GameManager.instance.Movement.player.transform.eulerAngles = swingPlace.eulerAngles;
            GameManager.instance.UI.interactionPanel.SetActive(false);

            StartCoroutine(Swing());
        }

        if (isSwing)
        {
            GameManager.instance.UI.interactionPanel.SetActive(true);

            if (isPressE)
            {
                GameManager.instance.Movement.enabled = true;
                swingAnimator.SetBool("Swing", false);
                swingCam.Priority = 8;
                GameManager.instance.Movement.player.gameObject.SetActive(true);
                isSwing = false;
                GameManager.instance.UI.interactionPanel.SetActive(false);
            }
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

    public IEnumerator Swing()
    {
        swingAnimator.SetBool("Swing", true);
        swingCam.Priority = 12;
        GameManager.instance.Movement.player.gameObject.SetActive(false);
        GameManager.instance.Movement.player.position = charPos.position;
        isAvaiableForInteraction = false;

        yield return new WaitForSeconds(1);

        isSwing = true;
    }
}
