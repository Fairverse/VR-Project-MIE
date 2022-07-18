using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosenCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerList.instance.chosenChar = PlayerPrefs.GetString(PlayerList.instance.chosenChar);
        if (PlayerList.instance.chosenChar == "Gozde")
        {
            PlayerList.instance.SetCharacter1();
        }

        if (PlayerList.instance.chosenChar == "NPC")
        {
            PlayerList.instance.SetCharacter2();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
