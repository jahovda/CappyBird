using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public delegate void GameDelegate();
	public static event GameDelegate OnGameStarted;
	public static event GameDelegate OnGameOverConfirmed;

	public static GameManager Instance;

	public GameObject startPage;
	public GameObject gameOverPage;
	public GameObject countdownPage;
	public GameObject newPlayerPage;
	//public 
	GameObject highScorePage;
	public Text scoreText;

	public InputField inputTextName;
    string tutorialText;

    // public InputField inputTextPhone;
    // string tutorialTextPhone;


    void StartSave(){
		// tutorialTextPhone = PlayerPrefs.GetString("phone");
        // inputTextPhone.text = tutorialTextPhone;
        tutorialText = PlayerPrefs.GetString("username");
        inputTextName.text = tutorialText;
    }

    public void SaveThis(){
        tutorialText = inputTextName.text;
        PlayerPrefs.SetString("username", tutorialText);
    //  tutorialTextPhone = inputTextPhone.text;
    //     PlayerPrefs.SetString("phone", tutorialTextPhone);
        
    }

	enum PageState {
		None,
		Start,
		Countdown,
		GameOver,
		NewPlayer,
		HighScore
	}

	int score = 0;
	bool gameOver = true;

	public bool GameOver { get { return gameOver; } }

	void Awake() {
		 highScorePage = GameObject.Find("/HighScorePage");
		if (Instance != null) {
			Destroy(gameObject);
		}
		else {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		
	}

	void OnEnable() {
		TapController.OnPlayerDied += OnPlayerDied;
		TapController.OnPlayerScored += OnPlayerScored;
		CountdownText.OnCountdownFinished += OnCountdownFinished;
	}

	void OnDisable() {
		TapController.OnPlayerDied -= OnPlayerDied;
		TapController.OnPlayerScored -= OnPlayerScored;
		CountdownText.OnCountdownFinished -= OnCountdownFinished;
	}

	void OnCountdownFinished() {
		SetPageState(PageState.None);
		OnGameStarted();
		score = 0;
		gameOver = false;
	}

	void OnPlayerScored() {
		score++;
//		scoreText.text = PlayerPrefs.GetString("username") + "-" + score.ToString();
		scoreText.text = score.ToString();

	}

	void OnPlayerDied() {
		gameOver = true;
		PlayerPrefs.SetString("score", score.ToString());
		int savedScore = PlayerPrefs.GetInt("HighScore");
		if (score > savedScore) {
			PlayerPrefs.SetInt("HighScore", score);

		}
		

		HighscoreTable.AddHighscoreEntryS(score, PlayerPrefs.GetString("username"));

		SetPageState(PageState.GameOver);
		// Debug.Log(PlayerPrefs.GetString("username"));
		// Debug.Log(PlayerPrefs.GetString("phone"));
		// Debug.Log(PlayerPrefs.GetString("score"));
		// // string[] lines = {PlayerPrefs.GetString("username"), ";", PlayerPrefs.GetString("phone"),";", PlayerPrefs.GetString("score")};
		// // System.IO.File.WriteAllLines(@"./tapgeminiscore.txt", lines);
		// WRITE TO TEXT FILE
		using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./highscore.txt", true))
        {
            file.WriteLine("username:" + PlayerPrefs.GetString("username") + ";phone:" + PlayerPrefs.GetString("phone") + ";score:" +PlayerPrefs.GetString("score") );
        }
	}

	void Update(){
		//PlayerPrefs.DeleteAll();
		if (highScorePage == null){
		highScorePage = GameObject.Find("/HighScorePage");
		}
		if (startPage.active == true) {
			if (Input.GetKeyDown(KeyCode.Return)){
				SetPageState(PageState.NewPlayer);
			} else if (Input.GetKeyDown("r")){
				SetPageState(PageState.Countdown);
			}
		}

		// else if (newPlayerPage.active == true) {
		// 	if (Input.GetKeyDown(KeyCode.Return)){
		// 		StartSave();
		// 		SaveThis();
		// 		PlayerPrefs.Save();
		// 		SetPageState(PageState.Countdown);
		// 	}
		// } 
		else if (gameOverPage.active == true){
			if (Input.GetKeyDown(KeyCode.Return)){
				ConfirmGameOver();

			
			
			} else if (Input.GetKeyDown("r")){
				ConfirmGameOverAndReplay();
			}
		}
	}


	void SetPageState(PageState state) {
		switch (state) {
			case PageState.None:
				startPage.SetActive(false);
				gameOverPage.SetActive(false);
				countdownPage.SetActive(false);
				newPlayerPage.SetActive(false);
				
				highScorePage.SetActive(true);
				break;
			case PageState.Start:
				startPage.SetActive(true);
				gameOverPage.SetActive(false);
				countdownPage.SetActive(false);
				newPlayerPage.SetActive(false);
			
				highScorePage.SetActive(false);

				break;
			case PageState.Countdown:
				startPage.SetActive(false);
				gameOverPage.SetActive(false);
				countdownPage.SetActive(true);
				newPlayerPage.SetActive(false);
			
				highScorePage.SetActive(true);

				break;
			case PageState.GameOver:
				startPage.SetActive(false);
				gameOverPage.SetActive(true);
				countdownPage.SetActive(false);
				newPlayerPage.SetActive(false);
			
				highScorePage.SetActive(true);
				break;
			case PageState.NewPlayer:
				
				startPage.SetActive(false);
				gameOverPage.SetActive(false);
				countdownPage.SetActive(false);
				newPlayerPage.SetActive(true);
				highScorePage.SetActive(false);
				inputTextName.ActivateInputField();

				break;
		}
	}
	
	public void ConfirmGameOver() {
		SetPageState(PageState.Start);
		scoreText.text = "0";
		OnGameOverConfirmed();
	}

	public void ConfirmGameOverAndReplay() {
		SetPageState(PageState.Start);
		scoreText.text = "0";
		OnGameOverConfirmed();
		SetPageState(PageState.Countdown);
	}

	public void StartGame() {
		//PlayerPrefs.DeleteAll();
		
		//GameObject.Instantiate(gameObject.GetComponent<HighscoreTable>());
		SetPageState(PageState.Countdown);
	}

	
	public void setNewPlayerPage(){
		SetPageState(PageState.NewPlayer);
	}

	public void StartGameAndSavePlayerPrefs() {
		PlayerPrefs.Save();
		// JsonPlayerPrefs prefs = new JsonPlayerPrefs(Application.persistentDataPath + "/Preferences.json");
		// Debug.Log(Application.persistentDataPath);
		// prefs.Save();
		// Debug.Log(GameObject.Find("/HighScorePage"));
		// GameObject.Instantiate(GameObject.Find("/HighScorePage"));
		//GameObject.Instantiate(, transform.position, Quaternion.identity);
		//PlayerPrefs.DeleteAll();
		SetPageState(PageState.Countdown);
	}

	public void ShowHighScoreTable(){

	}

}
