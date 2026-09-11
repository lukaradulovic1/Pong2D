using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject opponent;
    public static GameManager Instance { get; private set; }
    public BallSpawner ballSpawner;

    [SerializeField]
    private GameMode currentGameMode;
    public static GameMode SelectedGameMode { get; set; } = GameMode.Normal;
    public PointScoring pointScoring;

    private void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

    }

    public void StartNewGame(GameMode gameMode)
    {
        pointScoring.ResetScore();
        ballSpawner.StartMode(gameMode);
    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            var newPointScoring = FindFirstObjectByType<PointScoring>();
            pointScoring = newPointScoring; 

            var newBallSpawner = FindFirstObjectByType<BallSpawner>();
            var newPlayerScore = GameObject.FindGameObjectWithTag("PlayerScore");
            var newOpponentScore = GameObject.FindGameObjectWithTag("OpponentScore");
            

            ballSpawner = newBallSpawner;
            StartNewGame(SelectedGameMode);
        }
        
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //if (ShouldLoadGame)
    //{
    //    LoadSavedGame();
    //}

    //playerState = player.GetComponent<Player>();
    //opponentState = opponent.GetComponent<Opponent>();

    //ballState = balls[0].GetComponent<Ball>();


    //if (GameSession.ShouldLoadGame)
    //{
    //    LoadSavedGame();
    //    GameSession.ShouldLoadGame = false;
    //}
    //else
    //{
    //    StartNewGame(GameMode);
    //}

    //void FixedUpdate()
    //{
    //    playerScore.text = "Player: " + playerPoints.ToString();
    //    opponentScore.text = "Opponent: " + opponentPoints.ToString();
    //    playerState.score = playerPoints;
    //    opponentState.score = opponentPoints;
    //}

    //public Player GivePlayerData()
    //{
    //    Debug.Log(playerState);
    //    return playerState;
    //}
    //public Opponent GiveOpponentData()
    //{
    //    Debug.Log(opponentState);
    //    return opponentState;
    //}
    //public Ball GiveBallData()
    //{
    //    Debug.Log(ballState);
    //    return ballState;
    //}

    //public void LoadSavedGame()
    //{
    //    saveData = SaveSystem.LoadGame();

    //    if (saveData == null)
    //    {
    //        return;
    //    }

    //    player.gameObject.transform.position = saveData.PlayerPosition;
    //    opponent.gameObject.transform.position = saveData.OpponentPosition;

    //    balls[0].gameObject.transform.position = saveData.BallPosition;

    //    playerScore.text = saveData.PlayerScore.ToString();
    //    opponentScore.text = saveData.OpponentScore.ToString();
    //}

    //public void SaveAndQuit()
    //{
    //    Debug.Log(playerState);
    //    Debug.Log(opponentState);
    //    Debug.Log(ballState);

    //    //SaveSystem.SaveGame(playerState, opponentState, ballState);
    //    Application.Quit();
    //}

    public static void QuitGame()
    {
        Application.Quit();
    }
}
