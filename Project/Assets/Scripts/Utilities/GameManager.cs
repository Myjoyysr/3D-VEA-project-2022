using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Counts
    public int currentScore;
    public int highScore;
    public int bananaCount;
    private int totalBananaCount;
    public int currentLevel = 0;
    public int unlockedLevel;


    //For timers
    public Rect timerRect;
    public Color warningColorTimer;
    public Color defaultColorTimer;
    public float startTime = 5;
    private string currentTime;

    // Skin
    public GUISkin skin;

    //Refs
    public GameObject bananaParent;

    private bool completed = false;

    private bool showWinScreen = false;
    public int winScreenWidth, winScreenHeight;

    void Update()
    {
        if (!completed)
        {
            startTime -= Time.deltaTime;
            currentTime = string.Format("{0:0.0}", startTime);
            if (startTime <= 0)
            {
                startTime = 0;
                SceneManager.LoadScene("main_menu");
            }
        }


    }

    void Start()
    {
        totalBananaCount = bananaParent.transform.childCount;
        print(currentLevel.ToString());
        print(PlayerPrefs.GetInt("Level Completed"));
        //if (PlayerPrefs.GetInt("Level Completed") > 0)
        if (PlayerPrefs.GetInt("Level Completed") > 1)
        {
            currentLevel = PlayerPrefs.GetInt("Level Completed");
        }
        else
        {
            //currentLevel = 0;
            currentLevel = 1;
        }

        //DontDestroyOnLoad(gameObject);
    }

    public void CompleteLevel()
    {
        showWinScreen = true;
        completed = true;

    }

    void LoadNextLevel()
    {
        Time.timeScale = 1f;


        if (currentLevel == SceneManager.GetActiveScene().buildIndex)
        {
            currentLevel += 1;
        }
        SaveGame();
        SceneManager.LoadScene("World Select");
        //SceneManager.LoadScene(currentLevel);

    }

    void SaveGame()
    {
        PlayerPrefs.SetInt("Level Completed", currentLevel);
        PlayerPrefs.SetInt("Level " + currentLevel.ToString() + " score", currentScore);
    }

    public void AddBanana()
    {
        bananaCount += 1;
    }

    void OnGUI()
    {
        GUI.skin = skin;
        if (startTime < 5f)
        {
            skin.GetStyle("Timer").normal.textColor = warningColorTimer;
        }
        else
        {
            skin.GetStyle("Timer").normal.textColor = defaultColorTimer;
        }
        GUI.Label(timerRect, currentTime, skin.GetStyle("Timer"));
        GUI.Label(new Rect(45, 100, 200, 200), ("Bananas collected: " + bananaCount.ToString() + " / " + totalBananaCount.ToString()), skin.GetStyle("Timer"));

        if (showWinScreen)
        {
            Rect winScreenRect = new Rect(Screen.width / 2 - (winScreenWidth / 2), Screen.height / 2 - (winScreenHeight / 2), winScreenWidth, winScreenHeight);
            GUI.Box(winScreenRect, "YEES!");



            currentScore = bananaCount * (int)startTime;
            if (GUI.Button(new Rect(winScreenRect.x + winScreenRect.width - (170), winScreenRect.y + winScreenRect.height - (60), 150, 40), "Continue"))
            {
                LoadNextLevel();
                //SceneManager.LoadScene("World Select");
            }
            if (GUI.Button(new Rect(winScreenRect.x + 20, winScreenRect.y + winScreenRect.height - (60), 150, 40), "Quit"))
            {
                currentLevel += 1;
                SaveGame();
                SceneManager.LoadScene("main_menu");
                Time.timeScale = 1f;
            }
            GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 40, 300, 50), currentScore.ToString() + " Score!");
            GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 70, 300, 50), "Completed Level " + currentLevel.ToString());

        }

    }
}
