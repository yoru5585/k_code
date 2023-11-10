using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeaSecondMessage : MonoBehaviour
{
    Text MessText;
    Text NameText;
    int TextNum = 0;

    [SerializeField, TextArea(0, 6)]
    string[] NameStr;
    [SerializeField, TextArea(0, 6)]
    string[] MessStr;

    GameObject ScriptManager;
    // Start is called before the first frame update
    void Start()
    {
        ScriptManager = GameObject.FindGameObjectWithTag("manager");
        MessText = gameObject.transform.GetChild(1).GetComponent<Text>();
        MessText.text = MessStr[TextNum];
        NameText = gameObject.transform.GetChild(0).GetComponent<Text>();
        NameText.text = NameStr[TextNum++];

    }

    // Update is called once per frame
    void Update()
    {
        if (TextNum >= MessStr.Length)
        {
            gameObject.transform.parent.gameObject.SetActive(false);
            GameObject tmp = GameObject.Find("Clear_Canvas").transform.GetChild(0).gameObject;
            tmp.transform.GetChild(2).gameObject.SetActive(true);
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (TextNum == 1)
            {
                GameObject.Find("Clear_Canvas").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("BGM").GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("sound/hatsuyuki");
                GameObject.Find("BGM").GetComponent<AudioSource>().Play();
            }
            MessText.text = MessStr[TextNum];
            NameText.text = NameStr[TextNum++];
        }
    }

    public void backStartScene()
    {
        SceneManager.LoadScene("startScene");

    }
}
