using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    //public int levelToLoad;
    private string loadPromt;
    //public GameObject portalFog;
    private bool inRange;
    private int completedLevel;
    private bool canLoadLevel;
    private int dialog = 0;

    public int dialogScreenWidth, dialogScreenHeight;

    public GUISkin skin;

    private Animator anim;

    float animSmoother;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();


        completedLevel = PlayerPrefs.GetInt("Level Completed");
        completedLevel -=1;
        //Debug.Log("completed level: " + completedLevel);
        //Debug.Log("level to load :" +levelToLoad);
        /*
                canLoadLevel = levelToLoad <= completedLevel+1 ? canLoadLevel = true : false;

                Debug.Log("canloadlevel :" +canLoadLevel);

                if (canLoadLevel)
                {
                    Instantiate(portalFog, new Vector3(transform.position.x + 2f, 0f, transform.position.z),Quaternion.identity);
                }*/

    }

    void Update()
    {
        if (Input.GetButtonDown("X") && inRange && (dialog < 1 || dialog == 3))
        {
            if (dialog == 0 || dialog == 3)
            {
                dialog += 1;
                loadPromt = "";

            }

        }
        else if (Input.GetButtonDown("X") && dialog > 0)
        {
            if (dialog < 3)
            {
                dialog += 1;

            }
            else if (dialog == 4)
            {

                dialog -= 1;
            }


        }
        //Debug.Log("DIALOG STATE: " + dialog + "\ncompelted leve: " + completedLevel);
        if (dialog == 0 || dialog == 3)
        {
            animSmoother = anim.GetFloat("forward");
            if (animSmoother >= 0.0f)
            {
                anim.SetFloat("forward", (animSmoother - 0.01f));
            }
        }
        else
        {
            animSmoother = anim.GetFloat("forward");
            if (animSmoother <= 0.4f)
            {
                anim.SetFloat("forward", (animSmoother + 0.01f));
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag != "Bullet")
        {
            inRange = true;
            if (dialog < 1)
            {
                loadPromt = "Press [X] to interact";
            }
            if (dialog == 3)
            {
                loadPromt = "Press [X] to interact";
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
        GUI.skin = skin;

        GUI.Label(new Rect(Screen.width * .5f - 150, Screen.height * .9f, 600, 50), loadPromt);


        if (dialog == 1)
        {
            Rect winScreenRect = new Rect(Screen.width / 2 - (dialogScreenWidth / 2), Screen.height / 2 - (dialogScreenHeight / 2), dialogScreenWidth, dialogScreenHeight);


            if (completedLevel == 0)
            {

                GUI.Box(winScreenRect, "Cool Bob");
                GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 40, 300, 50), "Hello Ser!", skin.GetStyle("Label2"));
                GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 70, 300, 50), "I need your help!", skin.GetStyle("Label2"));

                if (GUI.Button(new Rect(winScreenRect.x + winScreenRect.width - (170), winScreenRect.y + winScreenRect.height - (60), 150, 40), "Continue [X]"))
                {
                    dialog += 1;
                }
            }
            else if (completedLevel == 1)
            {
                GUI.Box(winScreenRect, "Cool Bob");
                GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 40, 300, 50), "Hello Ser!", skin.GetStyle("Label2"));
                GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 70, 300, 50), "You are back!", skin.GetStyle("Label2"));

                if (GUI.Button(new Rect(winScreenRect.x + winScreenRect.width - (170), winScreenRect.y + winScreenRect.height - (60), 150, 40), "Continue [X]"))
                {
                    dialog += 1;
                }
            }
            else if (completedLevel == 2)
            {
                GUI.Box(winScreenRect, "Cool Bob");
                GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 40, 300, 50), "Hello Ser!", skin.GetStyle("Label2"));
                GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 70, 300, 150), "You are back and still alive!", skin.GetStyle("Label2"));

                if (GUI.Button(new Rect(winScreenRect.x + winScreenRect.width - (170), winScreenRect.y + winScreenRect.height - (60), 150, 40), "Continue [X]"))
                {
                    dialog += 1;
                }
            }
            else if (completedLevel == 3)
            {
                GUI.Box(winScreenRect, "Cool Bob");
                GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 40, 300, 50), "Hello Ser!", skin.GetStyle("Label2"));
                GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 70, 300, 150), "You have finished every challenges!", skin.GetStyle("Label2"));

                if (GUI.Button(new Rect(winScreenRect.x + winScreenRect.width - (170), winScreenRect.y + winScreenRect.height - (60), 150, 40), "Continue [X]"))
                {
                    dialog += 1;
                }
            }

        }
        if (dialog == 2)
        {
            if (completedLevel == 0)
            {
                Rect winScreenRect = new Rect(Screen.width / 2 - (dialogScreenWidth / 2), Screen.height / 2 - (dialogScreenHeight / 2), dialogScreenWidth, dialogScreenHeight);
                GUI.Box(winScreenRect, "Cool Bob");
                GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 40, 300, 50), "I engrave for bananas!", skin.GetStyle("Label2"));
                GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 70, 300, 150), "Please bring me bananas from the left portal!", skin.GetStyle("Label2"));

                if (GUI.Button(new Rect(winScreenRect.x + winScreenRect.width - (170), winScreenRect.y + winScreenRect.height - (60), 150, 40), "Continue [X]"))
                {
                    dialog += 1;
                }
            }

            if (completedLevel == 1)
            {
                Rect winScreenRect = new Rect(Screen.width / 2 - (dialogScreenWidth / 2), Screen.height / 2 - (dialogScreenHeight / 2), dialogScreenWidth, dialogScreenHeight);
                GUI.Box(winScreenRect, "Cool Bob");
                GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 40, 300, 50), "Thank you for bananas!", skin.GetStyle("Label2"));
                GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 70, 300, 150), "Now, please! Go and investigate the right portal!", skin.GetStyle("Label2"));

                if (GUI.Button(new Rect(winScreenRect.x + winScreenRect.width - (170), winScreenRect.y + winScreenRect.height - (60), 150, 40), "Continue [X]"))
                {
                    dialog += 1;
                }
            }

            if (completedLevel == 2)
            {
                Rect winScreenRect = new Rect(Screen.width / 2 - (dialogScreenWidth / 2), Screen.height / 2 - (dialogScreenHeight / 2), dialogScreenWidth, dialogScreenHeight);
                GUI.Box(winScreenRect, "Cool Bob");
                GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 40, 300, 50), "Thank you for bananas!", skin.GetStyle("Label2"));
                GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 70, 300, 150), "Now, please! The last challenge! The middle one! Only the brave shall enter!", skin.GetStyle("Label2"));

                if (GUI.Button(new Rect(winScreenRect.x + winScreenRect.width - (170), winScreenRect.y + winScreenRect.height - (60), 150, 40), "Continue [X]"))
                {
                    dialog += 1;
                }
            }
            if (completedLevel == 3)
            {
                Rect winScreenRect = new Rect(Screen.width / 2 - (dialogScreenWidth / 2), Screen.height / 2 - (dialogScreenHeight / 2), dialogScreenWidth, dialogScreenHeight);
                GUI.Box(winScreenRect, "Cool Bob");
                GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 40, 300, 50), "But do not be afraid!", skin.GetStyle("Label2"));
                GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 70, 300, 150), "Fun shall continue! Please feel free to use portals and hone your skills!", skin.GetStyle("Label2"));

                if (GUI.Button(new Rect(winScreenRect.x + winScreenRect.width - (170), winScreenRect.y + winScreenRect.height - (60), 150, 40), "Continue [X]"))
                {
                    dialog += 1;
                }
            }


        }
        if (dialog == 4)
        {
            if (completedLevel == 0)
            {
                Rect winScreenRect = new Rect(Screen.width / 2 - (dialogScreenWidth / 2), Screen.height / 2 - (dialogScreenHeight / 2), dialogScreenWidth, dialogScreenHeight);
                GUI.Box(winScreenRect, "Cool Bob");
                GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 40, 300, 50), "Hello again, ser!!!", skin.GetStyle("Label2"));
                GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 70, 300, 150), "Bring me those bananas from the left portal!", skin.GetStyle("Label2"));

                if (GUI.Button(new Rect(winScreenRect.x + winScreenRect.width - (170), winScreenRect.y + winScreenRect.height - (60), 150, 40), "Continue [X]"))
                {
                    dialog -= 1;
                }
            }
            if (completedLevel == 1)
            {
                Rect winScreenRect = new Rect(Screen.width / 2 - (dialogScreenWidth / 2), Screen.height / 2 - (dialogScreenHeight / 2), dialogScreenWidth, dialogScreenHeight);
                GUI.Box(winScreenRect, "Cool Bob");
                GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 40, 300, 50), "Hello again, ser!!!", skin.GetStyle("Label2"));
                GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 70, 300, 150), "It might be dangerous to go right portal but I am sure you can handle it!", skin.GetStyle("Label2"));

                if (GUI.Button(new Rect(winScreenRect.x + winScreenRect.width - (170), winScreenRect.y + winScreenRect.height - (60), 150, 40), "Continue [X]"))
                {
                    dialog -= 1;
                }
            }
            if (completedLevel == 2)
            {
                Rect winScreenRect = new Rect(Screen.width / 2 - (dialogScreenWidth / 2), Screen.height / 2 - (dialogScreenHeight / 2), dialogScreenWidth, dialogScreenHeight);
                GUI.Box(winScreenRect, "Cool Bob");
                GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 40, 300, 50), "Hello again, ser!!!", skin.GetStyle("Label2"));
                GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 70, 300, 150), "Praise the allmighty frog god! I will be waiting for you here! Go to the middle portal!", skin.GetStyle("Label2"));

                if (GUI.Button(new Rect(winScreenRect.x + winScreenRect.width - (170), winScreenRect.y + winScreenRect.height - (60), 150, 40), "Continue [X]"))
                {
                    dialog -= 1;
                }
            }
            if (completedLevel == 3)
            {
                Rect winScreenRect = new Rect(Screen.width / 2 - (dialogScreenWidth / 2), Screen.height / 2 - (dialogScreenHeight / 2), dialogScreenWidth, dialogScreenHeight);
                GUI.Box(winScreenRect, "Cool Bob");
                GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 40, 300, 50), "Hello again, ser!!!", skin.GetStyle("Label2"));
                GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 70, 300, 150), "Praise the almighty frog god! Go and hone your skills by repeating those difficult challenges!", skin.GetStyle("Label2"));

                if (GUI.Button(new Rect(winScreenRect.x + winScreenRect.width - (170), winScreenRect.y + winScreenRect.height - (60), 150, 40), "Continue [X]"))
                {
                    dialog -= 1;
                }
            }
        }





    }


}
