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

        else if (PlayerList.instance.chosenChar == "Reyhan")
        {
            PlayerList.instance.SetCharacter2();
        }

        else if (PlayerList.instance.chosenChar == "Hakkican")
        {
            PlayerList.instance.SetCharacter3();
        }

        else if (PlayerList.instance.chosenChar == "Hadise")
        {
            PlayerList.instance.SetCharacter4();
        }

        else if (PlayerList.instance.chosenChar == "Tarkan")
        {
            PlayerList.instance.SetCharacter5();
        }

        else if (PlayerList.instance.chosenChar == "Kivanc")
        {
            PlayerList.instance.SetCharacter6();
        }
    }
}
