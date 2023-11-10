using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questionText : MonoBehaviour
{
    [SerializeField]
    GameObject messageObj;
    [SerializeField]
    GameObject nameObj;

    Text text;
    Text nametext;
    public int questionTextcount = 0;
    message message_script;

    //ここに質問に対する答え（いいえ）
    [TextArea(1, 6)]
    public string[] questionMessageStr = new string[]
    {

    };
    //名前変更
    public string[] questionNameStr = new string[]
    {

    };

    // Start is called before the first frame update
    void Start()
    {
        message_script = GetComponent<message>();

        text = messageObj.GetComponent<Text>();
        nametext = nameObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onButtonA_Cliked()
    {
        message_script.choiceFlag = false;

        foreach (GameObject i in message_script.buttonObjs)
        {
            i.SetActive(false);
        }

        message_script.messageChangeSystem();
    }

    public void onButtonB_Cliked()
    {

        nametext.text = questionNameStr[questionTextcount];
        text.text = questionMessageStr[questionTextcount];

        if (questionTextcount != questionMessageStr.Length - 1)
        {
            questionTextcount++;
        }

    }
}
