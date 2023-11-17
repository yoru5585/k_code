using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class message : MonoBehaviour
{
    [SerializeField]
    GameObject messageObj;
    [SerializeField]
    GameObject nameObj;
    [SerializeField]
    public GameObject[] buttonObjs;

    [SerializeField]
    int []questionTextNum;
    [SerializeField]
    string NextScene;
    //テキスト内容
    [TextArea(1, 6)]
    public string[] messageStr = new string[]
    {

    };
    //立ち絵変更。数字で割り当て
    //0のときはそのまま
    public int[] ImageStr_1 = new int[]
    {

    };
    public int[] ImageStr_2 = new int[]
    {

    };
    //名前変更
    public string[] nameStr = new string[]
    {

    };

    Text text;
    Text nametext;
    public int textcount = 0;
    bool messFlag = true;
    public bool choiceFlag = false;

    ImageChange ImageChange_script;
    // Start is called before the first frame update
    void Start()
    {
        ImageChange_script = GetComponent<ImageChange>();
        text = messageObj.GetComponent<Text>();
        nametext = nameObj.GetComponent<Text>();
        messageChangeSystem();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (choiceFlag)
        {
            return;
        }


        if (messFlag)
        {


            if (Input.GetMouseButtonDown(0))
            {
                messageChangeSystem();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                //シーンロード
                Debug.Log("シーン切り替え");
                SceneManager.LoadScene(NextScene);
            }
        }
    }

    void selectButtonEnableTrue()
    {
        //配列の中に指定された要素が含まれていたらその値を返す。
        if (Array.IndexOf(questionTextNum, textcount) != -1)
        {
            choiceFlag = true;

            foreach (GameObject i in buttonObjs)
            {
                i.SetActive(true);
            }
        }
    }

    public void messageChangeSystem()
    {
        selectButtonEnableTrue();

        nametext.text = nameStr[textcount];
        text.text = messageStr[textcount];

        ImageChange_script.ImageCheck1();
        ImageChange_script.ImageCheck2();


        textcount += 1;
        if (textcount == messageStr.Length)
        {
            messFlag = false;
        }
    }
}
