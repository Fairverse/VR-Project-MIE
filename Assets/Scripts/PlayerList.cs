using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerList : MonoBehaviour
{
    public List<GameObject> CharacterList = new List<GameObject>();

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
        GameManager.instance.UI.ccPanel.SetActive(false);
    }

    public void SetCharacter2()
    {
        Movement.instance.player = CharacterList[1].transform;
        GameManager.instance.vcam1.Follow = CharacterList[1].transform;
        GameManager.instance.vcam2.Follow = CharacterList[1].transform;
        GameManager.instance.UI.ccPanel.SetActive(false);
    }
}
