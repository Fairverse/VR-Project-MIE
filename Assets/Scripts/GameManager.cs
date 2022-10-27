using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public int coinCount;

    [Header("Scripts")]

    public UI UI;
    public Movement Movement;
    public AudioManager AudioManager;
    public SceneTrigger SceneTrigger;

    [Header("Cameras")]

    public CinemachineVirtualCamera vcam1;
    public CinemachineVirtualCamera vcam2;

    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

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
        UI.menuPanel.SetActive(false);
    }

    public void OpenMenuPanel()
    {
        UI.menuPanel.SetActive(!UI.isMenuActive);
        UI.isMenuActive = !UI.isMenuActive;
        UI.commandsPanel.SetActive(false);
        UI.tasksPanel.SetActive(false);
    }

    public void SetCharacter()
    {
        Debug.Log("char");
    }
    public void IncreaseCoin(int value)
    {
        coinCount += value;

        PlayerPrefs.SetInt("coinCount", coinCount);
    }

    private void OnApplicationQuit()
    {
        
    }
}
