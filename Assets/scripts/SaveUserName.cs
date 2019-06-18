using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveUserName : MonoBehaviour
{
    public InputField inputTextName;
    string tutorialText;

    void Start(){
        inputTextName.ActivateInputField();
        tutorialText = PlayerPrefs.GetString("username");
        inputTextName.text = tutorialText;
    }

    public void SaveThis(){
        tutorialText = inputTextName.text;
        PlayerPrefs.SetString("username", tutorialText);
    }

    void Update(){
        //inputTextName.ActivateInputField();
    }
}
