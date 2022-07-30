using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    public GameObject Buttons;

    public int questionOrder;

    public bool isPressE;
    public bool isAvaiableForInteraction;

    public Transform charPos;

    public GameObject NPC;

    #region Singleton
    public static NPCTrigger instance;

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
            GameManager.instance.Movement.player.transform.position = charPos.position;
            GameManager.instance.Movement.player.transform.eulerAngles = charPos.eulerAngles;
            GameManager.instance.Movement.player.GetComponentInParent<Movement>().enabled = false;
            GameManager.instance.UI.interactionPanel.SetActive(false);

            AskQuestion();
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

    public void AskQuestion()
    {
        NPC.GetComponent<Questions>().questionPanel.SetActive(true);
        Buttons.SetActive(true);
        
        if (questionOrder == 0)
        {
            NPC.GetComponent<Questions>().Q2.SetActive(false);
            NPC.GetComponent<Questions>().Q3.SetActive(false);

            NPC.GetComponent<Questions>().Q1.SetActive(true);
        }

        if (questionOrder == 1)
        {
            NPC.GetComponent<Questions>().Q1.SetActive(false);
            NPC.GetComponent<Questions>().Q3.SetActive(false);

            NPC.GetComponent<Questions>().Q2.SetActive(true);
        }

        if (questionOrder == 2)
        {
            NPC.GetComponent<Questions>().Q1.SetActive(false);
            NPC.GetComponent<Questions>().Q2.SetActive(false);

            NPC.GetComponent<Questions>().Q3.SetActive(true);
        }

    }

    public void FinishQuestion()
    {
        NPC.GetComponent<Questions>().questionPanel.SetActive(false);
        GameManager.instance.Movement.player.GetComponentInParent<Movement>().enabled = true;
        Buttons.SetActive(false);

        NPC.GetComponent<Questions>().Q1.SetActive(false);
        NPC.GetComponent<Questions>().Q2.SetActive(false);
        NPC.GetComponent<Questions>().Q3.SetActive(false);
    }
}
