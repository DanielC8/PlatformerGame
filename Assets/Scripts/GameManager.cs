using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum GameState
    {
        StartMenu,
        LevelMenu,
        Game,
        Playing,
        Win,
        Lose,
        End
    }

    public GameState state;

    public int totalCoins;
    public int lives;
    public int time; //in seconds
    public int maxTime; //in seconds
    private bool reachedEnd;
    private TMP_Text scoreText;
    private TMP_Text timeText;

    private int scoreMultiplier;
    private int currentLevel; //1,2,3

    private void Awake()
    {
        //makes sure that there's only one game manager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = GameState.StartMenu;
        scoreMultiplier = 1;
        totalCoins = 0;
        lives = 3;
        time = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == GameState.Playing)
        {
            CheckGameEnd();
            UpdateScoreText();
        }
    }
    public void StartPlaying()
    {
        state = GameState.Playing;

        //start the timer
        //TODO
        //Invoke("TimeUp", time);
        Invoke("Tick", 1);

    }

    void TimesUp()
    {
        //what happens when the timer runs out
        //TODO player uo and dies
        Transform respawnPoint = GameObject.Find("RespawnPoint").transform;
        GameObject.Find("Player").transform.position = respawnPoint.position;
        GameObject.Find("Main Camera").transform.position = respawnPoint.position + new Vector3(7, 1, -3);
        GameManager.Instance.Respawn();
        GameManager.Instance.SubtractLives();
        
    }

    void Tick()
    {
        if (state == GameState.Playing)
        {
            time -= 1;
            if (time <= 0)
            {
                TimesUp();
            }
            else
            {
                Invoke("Tick", 1f);
            }

            if (time == 10)
            {
                //play a sound to tell player time is almost up
            }
            UpdateTimeText();
        }

        
    }
    

    public void ResetGameState()
    {
        //when I play again
        state = GameState.Game;
        lives = 3;
        time = maxTime;
        reachedEnd = false;
        if (SoundManager.Instance.isPlayingMenu)
        {
            SoundManager.Instance.StopMenuMusic();
            SoundManager.Instance.PlayMusic();
        }
        

    }

    public void Respawn()
    {
        state = GameState.Playing;
        time = maxTime;
        reachedEnd = false;
    }


    public void LevelSelectState()
    {
        state = GameState.LevelMenu;
    }

    public void CheckGameEnd()
    {
        // to end the game, 1. you clear all blocks, 2. the ball is destroyed
        if (lives <= 0 || reachedEnd)
        {
            if (lives <= 0)
            {
                state = GameState.Lose;
                StartCoroutine("EndGame");
                SoundManager.Instance.StopMusic();
                SoundManager.Instance.PlayMenuMusic();
            }
            else
            {
                StartCoroutine("NextLevel");
                if (PlayerPrefs.GetInt("Level") < 3)
                {
                    SoundManager.Instance.PlayWin();
                    PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
                    SceneManager.LoadScene("GameLevel" + PlayerPrefs.GetInt("Level"));
                    ResetGameState();
                    PlayerPrefs.Save();
                }
                else
                {
                    state = GameState.Win;
                    StartCoroutine("EndGame");
                    SoundManager.Instance.StopMusic();
                    SoundManager.Instance.PlayMenuMusic();
                }
            }

        }
    }
    IEnumerator NextLevel()
    {
        SoundManager.Instance.PlayWin();
        yield return new WaitForSeconds(3);

    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3);
        state = GameState.End;
        SceneManager.LoadScene("EndScene");
        Debug.Log("loaded scene");
    }



    public int GetScore()
    {
        return totalCoins;
    }

    public void AddScore(int coins)
    {
        totalCoins += coins * scoreMultiplier;
        UpdateScoreText();
    }

    public void AddLives()
    {
        lives += 1;
        GameObject.Find("UIManager").GetComponent<UIManager>().health = lives;
    }

    public void SubtractLives()
    {
        lives -= 1;
        GameObject.Find("UIManager").GetComponent<UIManager>().health = lives;
    }

    public void ReachedEnd()
    {
        reachedEnd = true;
    }


    public void UpdateScoreText()
    {
        if (scoreMultiplier == 1)
        {
            GameObject scoreObj = GameObject.Find("Score");
            scoreText = scoreObj.GetComponent<TextMeshProUGUI>();
            scoreText.text = "Score: " + totalCoins;
        }
        else
        {
            GameObject scoreObj = GameObject.Find("Score");
            scoreText = scoreObj.GetComponent<TextMeshProUGUI>();
            scoreText.text = "Score: " + totalCoins + "   x" + scoreMultiplier;
        }


    }

    public void UpdateTimeText()
    {
        GameObject scoreObj = GameObject.Find("Time");
        timeText = scoreObj.GetComponent<TextMeshProUGUI>();
        timeText.text = time.ToString();
    }

    public void DoublePoints()
    {
        StartCoroutine("DoublePoint");
    }

    IEnumerator DoublePoint()
    {
        scoreMultiplier = 2;
        GameObject scoreObj = GameObject.Find("Score");
        scoreText = scoreObj.GetComponent<TextMeshProUGUI>();
        scoreText.text = "Score: " + totalCoins + "   x2";
        yield return new WaitForSeconds(5);
        scoreMultiplier = 1;
        UpdateScoreText();
        yield return null;
    }

   

    

    
}
