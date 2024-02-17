using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public int levelToLoad;
    private string loadPromt;

    public GameObject portalFog;

    private bool inRange;

    private int completedLevel;

    private bool canLoadLevel;

    void Start()
    {

        completedLevel = PlayerPrefs.GetInt("Level Completed");
        Debug.Log("completed level: " + completedLevel);
        Debug.Log("level to load :" + levelToLoad);

        //canLoadLevel = levelToLoad <= completedLevel + 1 ? canLoadLevel = true : false;
        canLoadLevel = levelToLoad <= completedLevel + 0 ? canLoadLevel = true : false;
        Debug.Log("canloadlevel :" + canLoadLevel);

        if (canLoadLevel)
        {
            Instantiate(portalFog, new Vector3(transform.position.x, transform.position.y + 0.65f, transform.position.z), Quaternion.identity);
        }

    }

    void Update()
    {
        if (canLoadLevel && Input.GetButton("X") && inRange)
        {

            SceneManager.LoadScene("Level " + levelToLoad);

        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag != "Bullet")
        {
            inRange = true;

            if (!canLoadLevel)
            {
                loadPromt = "Level" + levelToLoad.ToString() + " is locked! Complete previous levels first!";
            }
            else
            {
                loadPromt = "Press [x] to load Level " + levelToLoad.ToString();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag != "Bullet")
        {
            inRange = false;
            loadPromt = "";
        }
    }


    void OnGUI()
    {
        GUI.Label(new Rect(30, Screen.height * .9f, 200, 40), loadPromt);
    }




}
