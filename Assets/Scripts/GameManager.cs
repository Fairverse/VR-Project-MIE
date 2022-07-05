using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public int coinCount;

    public GameObject character;

    public GameObject menuPanel;

    [Header("Scripts")]

    public UI UI;

    [Header("Cameras")]

    public CinemachineVirtualCamera vcam2;

    #region Singleton
    public static GameManager instance;

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
        menuPanel.SetActive(UI.isMenuActive);
        UI.isMenuActive = !UI.isMenuActive;
    }

    public void SetCharacter()
    {
        Debug.Log("char");
    }


}
