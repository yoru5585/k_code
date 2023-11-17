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
    //�e�L�X�g���e
    [TextArea(1, 6)]
    public string[] messageStr = new string[]
    {

    };
    //�����G�ύX�B�����Ŋ��蓖��
    //0�̂Ƃ��͂��̂܂�
    public int[] ImageStr_1 = new int[]
    {

    };
    public int[] ImageStr_2 = new int[]
    {

    };
    //���O�ύX
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
                //�V�[�����[�h
                Debug.Log("�V�[���؂�ւ�");
                SceneManager.LoadScene(NextScene);
            }
        }
    }

    void selectButtonEnableTrue()
    {
        //�z��̒��Ɏw�肳�ꂽ�v�f���܂܂�Ă����炻�̒l��Ԃ��B
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
