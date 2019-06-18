

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighscoreTable : MonoBehaviour {


    public Transform entryContainer;
    public Transform entryTemplate;
    public List<Transform> highscoreEntryTransformList;
    public GameObject canvasObject;


  

        private float nextActionTime = 0.0f;
        public float period = 7.1f;
        
        void Update () {
            //PlayerPrefs.DeleteAll();
      
            
            if (Time.time > nextActionTime ) {
                nextActionTime += period;
                entryContainer = transform.Find("highscoreEntryContainer");
                entryTemplate = entryContainer.Find("highscoreEntryTemplate");

                entryTemplate.gameObject.SetActive(false);

                string jsonString = PlayerPrefs.GetString("highscoreTable");
                Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

                if (highscores == null) {
                    // There's no stored table, initialize
                    Debug.Log("Initializing table with default values...");
                    AddHighscoreEntry(1, " ");
                    // AddHighscoreEntry(1, "");
                    // AddHighscoreEntry(1, "");




                    // Reload
                    jsonString = PlayerPrefs.GetString("highscoreTable");
                    highscores = JsonUtility.FromJson<Highscores>(jsonString);
                }

                // Sort entry list by Score
                for (int i = 0; i < highscores.highscoreEntryList.Count; i++) {
                    for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++) {
                        if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score) {
                            // Swap
                            HighscoreEntry tmp = highscores.highscoreEntryList[i];
                            highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                            highscores.highscoreEntryList[j] = tmp;
                        }
                    }
                }
                Highscores newhighscores = new Highscores();
                if (highscores.highscoreEntryList.Count > 6) {
                newhighscores.highscoreEntryList = highscores.highscoreEntryList.GetRange(0,6);
                } else
                {
                    newhighscores.highscoreEntryList = highscores.highscoreEntryList;
                }

                highscoreEntryTransformList = new List<Transform>();

                var gameobjectList = GameObject.FindGameObjectsWithTag("higscoretext");
                for (var i = 0; i < gameobjectList.Length - 6; i++){
                    if (gameobjectList[i].name == "highscoreEntryTemplate(Clone)" && gameobjectList.Length > 6){
                        Destroy(gameobjectList[i]);
                    }
                }

                // foreach(GameObject fooObj in gameobjectList)
                //     {
                //     if(fooObj.name == "highscoreEntryTemplate(Clone)" && gameobjectList.Length > 6 && gameobjectList.Length )
                //     {
                //         Destroy(fooObj);
                //     }
                // }

                // GameObject highscoreBoard= GameObject.Find("highscoreEntryTemplate(Clone)");
                // Object.Destroy(highscoreBoard, 0.01f);
                // GameObject highscoreBoard2= GameObject.Find("highscoreEntryTemplate(Clone)");
                // Object.Destroy(highscoreBoard2, 0.01f);
                // GameObject highscoreBoard3= GameObject.Find("highscoreEntryTemplate(Clone)");
                // Object.Destroy(highscoreBoard3, 0.01f);
                // GameObject highscoreBoard4= GameObject.Find("highscoreEntryTemplate(Clone)");
                // Object.Destroy(highscoreBoard4, 0.01f);
                // GameObject highscoreBoard5= GameObject.Find("highscoreEntryTemplate(Clone)");
                // Object.Destroy(highscoreBoard5, 0.01f);
                // GameObject highscoreBoard6= GameObject.Find("highscoreEntryTemplate(Clone)");
                // Object.Destroy(highscoreBoard6, 0.01f);
                foreach (HighscoreEntry highscoreEntry in newhighscores.highscoreEntryList) {
                    CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
                }
                
                // GameObject highscoreBoard= GameObject.Find("highscoreEntryTemplate(Clone)");
                // Object.Destroy(highscoreBoard, 0.01f);
                // GameObject highscoreBoard2= GameObject.Find("highscoreEntryTemplate(Clone)");
                // Object.Destroy(highscoreBoard2, 0.01f);
                // GameObject highscoreBoard3= GameObject.Find("highscoreEntryTemplate(Clone)");
                // Object.Destroy(highscoreBoard3, 0.01f);
                // GameObject highscoreBoard4= GameObject.Find("highscoreEntryTemplate(Clone)");
                // Object.Destroy(highscoreBoard4, 0.01f);
                // GameObject highscoreBoard5= GameObject.Find("highscoreEntryTemplate(Clone)");
                // Object.Destroy(highscoreBoard5, 0.01f);
                // GameObject highscoreBoard6= GameObject.Find("highscoreEntryTemplate(Clone)");
                // Object.Destroy(highscoreBoard6, 0.01f);

                // execute block of code here
            }
        }

    private void Awake() {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

    

        entryTemplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null) {
            // There's no stored table, initialize
            Debug.Log("Initializing table with default values...");
            AddHighscoreEntry(1, " ");
         




            // Reload
            jsonString = PlayerPrefs.GetString("highscoreTable");
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }

        // Sort entry list by Score
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++) {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++) {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score) {
                    // Swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }
        Highscores newhighscores = new Highscores();
        if (highscores.highscoreEntryList.Count > 6) {
        newhighscores.highscoreEntryList = highscores.highscoreEntryList.GetRange(0,6);
        } else
        {
            newhighscores.highscoreEntryList = highscores.highscoreEntryList;
        }

        highscoreEntryTransformList = new List<Transform>();
        //for (int i = 0; i <=highscores.highscoreEntryList.Count; i++)
        //{
        //    CreateHighscoreEntryTransform(highscores.highscoreEntryList[i], entryContainer, highscoreEntryTransformList);
        //}
        foreach (HighscoreEntry highscoreEntry in newhighscores.highscoreEntryList) {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }



    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList) {
        float templateHeight = 31f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);
        int rank = transformList.Count + 1;
        if (rank < 10)
        {

            string rankString;
        switch (rank) {
        default:
            rankString = rank + "TH"; break;

        case 1: rankString = "1ST"; break;
        case 2: rankString = "2ND"; break;
        case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;

        int score = highscoreEntry.score;

        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        // Highlight First
        if (rank == 1) {
            entryTransform.Find("posText").GetComponent<Text>().color = Color.black;
            entryTransform.Find("scoreText").GetComponent<Text>().color =Color.black;
            entryTransform.Find("nameText").GetComponent<Text>().color = Color.black;
        }
        else {
          entryTransform.Find("posText").GetComponent<Text>().color = Color.grey;
          entryTransform.Find("scoreText").GetComponent<Text>().color =Color.grey;
          entryTransform.Find("nameText").GetComponent<Text>().color = Color.grey;
        }


        transformList.Add(entryTransform);
        }
        Debug.Log(transformList.Count);
    }

    public void AddHighscoreEntry(int score, string name) {
        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        // Load saved Highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null) {
            // There's no stored table, initialize
            highscores = new Highscores() {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }

        // Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    public static void AddHighscoreEntryS(int score, string name){
       HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        // Load saved Highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null) {
            // There's no stored table, initialize
            highscores = new Highscores() {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }

        // Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();

    }





    private class Highscores {
        public List<HighscoreEntry> highscoreEntryList;
    }

    /*
     * Represents a single High score entry
     * */
    [System.Serializable]
    private class HighscoreEntry {
        public int score;
        public string name;
    }

}
