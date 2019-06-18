using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreBoard : MonoBehaviour
{
    public Text scoreText1;
    public Text scoreText2;
    public Text scoreText3;
    public Text name1;
    public Text name2;
    public Text name3;


    void Start()
    {
        UpdateScoreBoard(0);
    }
    void UpdateScoreBoard(int score){
        if (score > PlayerPrefs.GetInt("1st")){
                PlayerPrefs.SetInt("3rd", PlayerPrefs.GetInt("2nd"));
                PlayerPrefs.SetInt("2nd", PlayerPrefs.GetInt("1st"));
                PlayerPrefs.SetString("name3", PlayerPrefs.GetString("name2"));
                PlayerPrefs.SetString("name2", PlayerPrefs.GetString("name1"));
                PlayerPrefs.SetString("name1", PlayerPrefs.GetString("username"));
                PlayerPrefs.Save();
            } 
            if (score< PlayerPrefs.GetInt("1st") && score > PlayerPrefs.GetInt("2nd")){
                PlayerPrefs.SetInt("3rd", PlayerPrefs.GetInt("2nd"));
                PlayerPrefs.SetInt("2nd", PlayerPrefs.GetInt("score"));
                PlayerPrefs.SetString("name3", PlayerPrefs.GetString("name2"));
                PlayerPrefs.SetString("name2", PlayerPrefs.GetString("username"));
                PlayerPrefs.Save();

            } 
            if (score< PlayerPrefs.GetInt("2nd") && score> PlayerPrefs.GetInt("3rd")){
                PlayerPrefs.SetInt("3rd", score);
                PlayerPrefs.SetString("name3", PlayerPrefs.GetString("username"));
                PlayerPrefs.Save();

            }

            scoreText1.text = PlayerPrefs.GetInt("1st").ToString();
            scoreText2.text = PlayerPrefs.GetInt("2nd").ToString();
            scoreText3.text = PlayerPrefs.GetInt("3rd").ToString();
            name1.text = PlayerPrefs.GetString("name1");
            name2.text = PlayerPrefs.GetString("name2");
            name3.text = PlayerPrefs.GetString("name3");
    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log(Int32.Parse(PlayerPrefs.GetString("score")));
        
        UpdateScoreBoard(Int32.Parse(PlayerPrefs.GetString("score")));
    }


    // // Start is called before the first frame update
    // void Start()
    // {
    //     UpdateScoreBoard();
    // }
    // void UpdateScoreBoard(){
    //     if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("1st")){
    //             PlayerPrefs.SetInt("3rd", PlayerPrefs.GetInt("2nd"));
    //             PlayerPrefs.SetInt("2nd", PlayerPrefs.GetInt("1st"));
    //             PlayerPrefs.SetString("name3", PlayerPrefs.GetString("name2"));
    //             PlayerPrefs.SetString("name2", PlayerPrefs.GetString("name1"));
    //             PlayerPrefs.SetString("name1", PlayerPrefs.GetString("username"));
    //         } 
    //         if (PlayerPrefs.GetInt("score")< PlayerPrefs.GetInt("1st") && PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("2nd")){
    //             PlayerPrefs.SetInt("3rd", PlayerPrefs.GetInt("2nd"));
    //             PlayerPrefs.SetInt("2nd", PlayerPrefs.GetInt("score"));
    //             PlayerPrefs.SetString("name3", PlayerPrefs.GetString("name2"));
    //             PlayerPrefs.SetString("name2", PlayerPrefs.GetString("username"));
    //         } 
    //         if (PlayerPrefs.GetInt("score")< PlayerPrefs.GetInt("2nd") && PlayerPrefs.GetInt("score")> PlayerPrefs.GetInt("3rd")){
    //             PlayerPrefs.SetInt("3rd", PlayerPrefs.GetInt("score"));
    //             PlayerPrefs.SetString("name3", PlayerPrefs.GetString("username"));
    //         }

    //         scoreText1.text = PlayerPrefs.GetInt("1st").ToString();
    //         scoreText2.text = PlayerPrefs.GetInt("2nd").ToString();
    //         scoreText3.text = PlayerPrefs.GetInt("3rd").ToString();
    //         name1.text = PlayerPrefs.GetString("name1");
    //         name2.text = PlayerPrefs.GetString("name2");
    //         name3.text = PlayerPrefs.GetString("name3");
    // }


    // // Update is called once per frame
    // void Update()
    // {
    //     Debug.Log(PlayerPrefs.GetInt("score"));
        
    //     UpdateScoreBoard();
    // }

}
