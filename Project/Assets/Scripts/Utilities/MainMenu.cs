using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GUISkin skin;


    void OnGUI()
    {
        GUI.skin = skin;


        GUI.Label(new Rect(10, 10, 400, 45), "TEST");

        if (PlayerPrefs.GetInt("Level Completed") > 1)
        {
            if (GUI.Button(new Rect(10, 110, 400, 100), "Continue"))
            {
                //SceneManager.LoadScene(PlayerPrefs.GetInt("Level Completed"));
                SceneManager.LoadScene("World Select");
            }
        }

        if (GUI.Button(new Rect(10, 220, 400, 100), "NEW GAME"))
        {
            PlayerPrefs.SetInt("Level Completed", 1);
            SceneManager.LoadScene("World Select");
        }
        if (GUI.Button(new Rect(10, 330, 400, 100), "QUIT"))
        {
            Application.Quit();
        }

    }

}
