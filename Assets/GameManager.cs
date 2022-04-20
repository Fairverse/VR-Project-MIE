using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject character;

    public GameObject menuPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            OpenMenuPanel();
        }
    }

    public void PressButton()
    {
        menuPanel.SetActive(false);
    }

    public void OpenMenuPanel()
    {
        menuPanel.SetActive(true);
    }

    public void SetCharacter()
    {
        Debug.Log("char");
    }
}
