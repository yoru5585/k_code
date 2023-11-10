using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    notDestroy notDestroyScript;
    // Start is called before the first frame update
    void Start()
    {
        notDestroyScript = GameObject.Find("dontDes").GetComponent<notDestroy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            for (int i = 0; i < notDestroyScript.DiaryFoundList.Count; i++)
            {
                PlayerPrefs.SetInt(i.ToString(), notDestroyScript.DiaryFoundList[i]);
            }

            PlayerPrefs.SetInt("listMax", notDestroyScript.DiaryFoundList.Count);

            PlayerPrefs.Save();
        }

        if (Input.GetKeyDown("o"))
        {
            PlayerPrefs.DeleteAll();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
        }
    }
}
