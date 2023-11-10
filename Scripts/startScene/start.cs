using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class start : MonoBehaviour
{


    [SerializeField]
    GameObject buttons;
    [SerializeField]
    GameObject grayButtons;
    [SerializeField]
    GameObject panel;
    [SerializeField]
    GameObject BG;
    [SerializeField]
    GameObject mode;
    [SerializeField]
    GameObject slime;
    [SerializeField]
    GameObject clickMess;

    notDestroy notDestroyScript;
    bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        notDestroyScript = GameObject.Find("dontDes").GetComponent<notDestroy>();
        for (int i = 0; i < buttons.transform.childCount; i++)
        {
            buttons.transform.GetChild(i).gameObject.SetActive(false);
            grayButtons.transform.GetChild(i).gameObject.SetActive(false);

        }
    }

    private void Awake()
    {
        if (GameObject.Find("dontDes") == null)
        {
            GameObject tmp = Instantiate((GameObject)Resources.Load("dontDes"));
            tmp.GetComponent<notDestroy>().isStageCleared = new bool[7];
            tmp.GetComponent<notDestroy>().isStageCleared[0] = true;
            tmp.GetComponent<notDestroy>().isStageCleared[4] = true;
            tmp.GetComponent<notDestroy>().isStageCleared[6] = true;
            tmp.GetComponent<notDestroy>().isEasyMode = true;
            tmp.GetComponent<notDestroy>().DiaryFoundList.Add(0);
            tmp.GetComponent<notDestroy>().DiaryFoundList.Add(1);
            tmp.GetComponent<notDestroy>().DiaryFoundList.Add(2);
            tmp.GetComponent<notDestroy>().DiaryFoundList.Add(3);
            tmp.gameObject.name = "dontDes";
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void stage1()
    {
        FadeManager.Instance.LoadScene("openingScene", 1.0f);
        
    }


    public void stage2()
    {
        FadeManager.Instance.LoadScene("santaTalkScene", 1.0f);
        
    }

    public void stage3()
    {
        FadeManager.Instance.LoadScene("mermaidTalkScene", 1.0f);
    }

    public void stage4()
    {
        FadeManager.Instance.LoadScene("stage4", 1.0f);
    }

    public void gallery()
    {
        FadeManager.Instance.LoadScene("galleryScene", 1.0f);
    }

    public void diary()
    {
        FadeManager.Instance.LoadScene("DiaryScene", 1.0f);
    }

    public void ModeChange()
    {
        if (GameObject.Find("dontDes").GetComponent<notDestroy>().isEasyMode)
        {
            GameObject.Find("dontDes").GetComponent<notDestroy>().isEasyMode = false;
            slime.SetActive(false);
            
        }
        else
        {
            GameObject.Find("dontDes").GetComponent<notDestroy>().isEasyMode = true;
            slime.SetActive(true);
        }
    }

    public void OnStartClicked()
    {
        for (int i = 0; i < buttons.transform.childCount; i++)
        {

            if (notDestroyScript.isStageCleared[i])
            {
                buttons.transform.GetChild(i).gameObject.SetActive(true);

            }
            else
            {
                grayButtons.transform.GetChild(i).gameObject.SetActive(true);
            }

        }
        flag = false;
        clickMess.SetActive(false);
        panel.SetActive(true);
        slime.SetActive(true);
        BG.GetComponent<Image>().sprite = Resources.Load<Sprite>("BG/taitoru2");
        panel.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Lv. " + notDestroyScript.shareExp;
        panel.transform.GetChild(1).gameObject.GetComponent<Text>().text = "çUåÇóÕ " + notDestroyScript.shareAP;
        GameObject.Find("dontDes").GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("sound/start"));
        //SceneManager.LoadScene("talkScene");
    }

    public void OnAwakeGame()
    {
        BG.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
        BG.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
        BG.transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(true);
    }
}
