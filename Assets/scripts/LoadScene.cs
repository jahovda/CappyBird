using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class LoadScene : MonoBehaviour
{
    public InputField input;
    public void SceneLoader(int SceneIndex)
    {
        //Debug.Log(GameObject.Find("/HighScorePage"));
		GameObject.Instantiate(GameObject.Find("HighScorePage"));
        input.ActivateInputField();
        SceneManager.LoadScene(SceneIndex);

    }
}
