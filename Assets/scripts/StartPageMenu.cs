using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartPageMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Update(){
        if (Input.GetKeyDown("up")){
         
            SceneManager.LoadScene("Scene2New");
		

        };
        

    }    

    public void goToNewPlayerPageFromMenuScene(){
        if (Input.GetKeyDown("up")) {
            SceneManager.LoadScene("Scene2New");
		}
    }
    public void goToNewPlayerPageFromScene2NewScene(){
        if (Input.GetKeyDown("up")) {
            SceneManager.LoadScene("menu");
		}
    }
}
