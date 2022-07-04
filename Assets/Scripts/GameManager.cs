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

    [Header("Cameras")]

    public CinemachineVirtualCamera vcam2;

    [Header("Texts")]

    public Text coinText;

    bool isMenuActive = false;

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
        coinText.text = coinCount.ToString();

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
        menuPanel.SetActive(isMenuActive);
        isMenuActive = !isMenuActive;
    }

    public void SetCharacter()
    {
        Debug.Log("char");
    }
}
