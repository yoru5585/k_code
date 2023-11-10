using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    [SerializeField]
    Text textObj;
    [SerializeField]
    GameObject[] button;
    [SerializeField]
    GameObject messCanvas;

    float timeInterval = 0.1f;
    float timeCount = 0;
    int visibleLen = 0;
    int sentenceNum = 0;

    bool buttonFlag = true;

    [SerializeField, TextArea(0, 6)]
    string[] messData = { };
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (visibleLen < messData[sentenceNum].Length)
        {
            timeCount += Time.deltaTime;

            if (Input.GetMouseButtonDown(0))
            {
                visibleLen = messData[sentenceNum].Length -1;
            }

            if (timeCount >= timeInterval)
            {
                timeCount = 0;
                visibleLen++;
                textObj.text = messData[sentenceNum].Substring(0, visibleLen);
            }
        }
        else
        {

            if (buttonFlag)
            {

                foreach (GameObject i in button)
                {
                    i.SetActive(true);
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    visibleLen = 0;
                    sentenceNum++;
                    if (sentenceNum >= messData.Length)
                    {
                        messCanvas.SetActive(false);
                        this.enabled = false;

                        for (int i = 0; i < 10; i++)
                        {
                            GameObject pre = (GameObject)Resources.Load("slime");
                            Instantiate(pre, new Vector3(10.0f, 10.0f, 0), Quaternion.identity);

                        }
                        
                    }
                }

            }

            
        }
    }

    public void onButtonB_Clicked()
    {
        sentenceNum = messData.Length -1;

        foreach (GameObject i in button)
        {
            i.SetActive(false);
        }
        buttonFlag = false;
    }

    public void onButtonA_Clicked()
    {
        visibleLen = 0;
        sentenceNum++;
        if (sentenceNum >= messData.Length)
        {
            messCanvas.SetActive(false);
            this.enabled = false;
        }

        foreach (GameObject i in button)
        {
            i.SetActive(false);
        }
        buttonFlag = false;
    }
}
