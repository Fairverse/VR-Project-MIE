using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosenCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerList.instance.chosenChar = PlayerPrefs.GetString(PlayerList.instance.chosenChar);
        if (PlayerList.instance.chosenChar == "Enes")
        {
            PlayerList.instance.SetCharacter1();
        }

        if (PlayerList.instance.chosenChar == "Reyhan")
        {
            PlayerList.instance.SetCharacter2();
        }

        if (PlayerList.instance.chosenChar == "Hakkican")
        {
            PlayerList.instance.SetCharacter3();
        }

        if (PlayerList.instance.chosenChar == "Hadise")
        {
            PlayerList.instance.SetCharacter4();
        }

        if (PlayerList.instance.chosenChar == "Tarkan")
        {
            PlayerList.instance.SetCharacter5();
        }

        if (PlayerList.instance.chosenChar == "Kivanc")
        {
            PlayerList.instance.SetCharacter6();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
