using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [Header("Booleans")]

    public bool isMenuActive = false;

    [Header("Panels")]

    public GameObject menuPanel;
    public GameObject ccPanel;
    public GameObject interactionPanel;
    public GameObject tasksPanel;
    public GameObject commandsPanel;

    [Header("Texts")]

    public Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = GameManager.instance.coinCount.ToString();
    }

    public void Tasks()
    {
        menuPanel.SetActive(false);
        tasksPanel.SetActive(true);
    }

    public void Commands()
    {
        menuPanel.SetActive(false);
        commandsPanel.SetActive(true);
    }
}
