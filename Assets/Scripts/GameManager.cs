using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI playerScore;
    public TextMeshProUGUI opponentScore;
    int playerPoints = 0, opponentPoints = 0;
    public GameObject player;
    public GameObject opponent;
    public List<GameObject> balls;
    public GameObject ball;
    public Player playerState;
    public Opponent opponentState;
    public Ball ballState;
    public BallMovement ballMovement;
    private GameData saveData;
    public static bool ShouldLoadGame { get; set; } = false;
    public static GameManager Instance { get; private set; }
    public static GameMode GameMode { get; set; }
    public SpeedUpMode speedUpMode;
    public MultipleBallsMode multipleBallsMode;
    void Start()
    {
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

        if (ShouldLoadGame)
        {
            LoadSavedGame();
        }

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player"); 
        }

        playerState = player.GetComponent<Player>();
        opponentState = opponent.GetComponent<Opponent>();
        balls.Add(ball);

        ballState = balls[0].GetComponent<Ball>();

        if (GameSession.ShouldLoadGame)
        {
            LoadSavedGame();
            GameSession.ShouldLoadGame = false;
        }
        else
        {
            StartNewGame(GameMode);
        }

    }

    private void StartNewGame(GameMode gameMode)
    {
        GameManager.GameMode = gameMode;


            ballMovement.StartBall();
        playerPoints = 0;
        opponentPoints = 0;

        switch (gameMode)
        {   
            case GameMode.Normal:
                break;
            case GameMode.SpeedUp:
                speedUpMode.StartMode();
                break;
            case GameMode.MultipleBalls:
                multipleBallsMode.StartMode();
                break;
            case GameMode.TopScore:
                break;
            default:
                break;
        }
    }

    public void AddBall(GameObject ball)
    {
        balls.Add(ball);
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void FixedUpdate()
    {
        playerScore.text = "Player: " + playerPoints.ToString();
        opponentScore.text = "Opponent: " + opponentPoints.ToString();
        playerState.score = playerPoints;
        opponentState.score = opponentPoints;
    }

    public void ScorePointForPlayer()
    {
        playerPoints += 1;
    }
    public void ScorePointForOpponent()
    {
        opponentPoints += 1;
    }

    public Player GivePlayerData()
    {
        Debug.Log(playerState);
        return playerState;
    }
    public Opponent GiveOpponentData()
    {
        Debug.Log(opponentState);
        return opponentState;
    }
    public Ball GiveBallData()
    {
        Debug.Log(ballState);
        return ballState;
    }

    public void LoadSavedGame()
    {
        saveData = SaveSystem.LoadGame();

        if (saveData == null)
        {
            return;
        }

        player.gameObject.transform.position = saveData.PlayerPosition;
        opponent.gameObject.transform.position = saveData.OpponentPosition;

        balls[0].gameObject.transform.position = saveData.BallPosition;

        playerScore.text = saveData.PlayerScore.ToString();
        opponentScore.text = saveData.OpponentScore.ToString();
    }

    public void SaveAndQuit()
    {
        Debug.Log(playerState);
        Debug.Log(opponentState);
        Debug.Log(ballState);

        SaveSystem.SaveGame(playerState, opponentState, ballState);
        Application.Quit();
    }
}
