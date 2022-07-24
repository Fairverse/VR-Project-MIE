using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerList : MonoBehaviour
{
    public string chosenChar;
    public List<GameObject> CharacterList = new List<GameObject>();

    #region Singleton
    public static PlayerList instance;

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
        
    }

    public void SetCharacter1()
    {
        Movement.instance.player = CharacterList[0].transform;
        GameManager.instance.vcam1.Follow = CharacterList[0].transform;
        GameManager.instance.vcam2.Follow = CharacterList[0].transform;
        CharacterList[0].SetActive(true);
        GameManager.instance.UI.ccPanel.SetActive(false);
        GameManager.instance.Movement.enabled = true;
        
        PlayerPrefs.SetString(chosenChar, "Enes");

    }

    public void SetCharacter2()
    {
        Movement.instance.player = CharacterList[1].transform;
        GameManager.instance.vcam1.Follow = CharacterList[1].transform;
        GameManager.instance.vcam2.Follow = CharacterList[1].transform;
        CharacterList[1].SetActive(true);
        GameManager.instance.UI.ccPanel.SetActive(false);
        GameManager.instance.Movement.enabled = true;
        
        PlayerPrefs.SetString(chosenChar, "Reyhan");

    }

    public void SetCharacter3()
    {
        Movement.instance.player = CharacterList[2].transform;
        GameManager.instance.vcam1.Follow = CharacterList[2].transform;
        GameManager.instance.vcam2.Follow = CharacterList[2].transform;
        CharacterList[2].SetActive(true);
        GameManager.instance.UI.ccPanel.SetActive(false);
        GameManager.instance.Movement.enabled = true;

        PlayerPrefs.SetString(chosenChar, "Hakkican");

    }

    public void SetCharacter4()
    {
        Movement.instance.player = CharacterList[3].transform;
        GameManager.instance.vcam1.Follow = CharacterList[3].transform;
        GameManager.instance.vcam2.Follow = CharacterList[3].transform;
        CharacterList[3].SetActive(true);
        GameManager.instance.UI.ccPanel.SetActive(false);
        GameManager.instance.Movement.enabled = true;

        PlayerPrefs.SetString(chosenChar, "Hadise");

    }
}
