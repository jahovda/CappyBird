using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePhone : MonoBehaviour
{
    public InputField inputTextPhone;
    string tutorialTextPhone;

    void Start(){
        tutorialTextPhone = PlayerPrefs.GetString("phone");
        inputTextPhone.text = tutorialTextPhone;
    }

    public void SaveThis(){
        tutorialTextPhone = inputTextPhone.text;
        PlayerPrefs.SetString("phone", tutorialTextPhone);
    }
}
