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
}
