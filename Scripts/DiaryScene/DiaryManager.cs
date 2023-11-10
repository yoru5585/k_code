using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DiaryManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] buttons;

    [SerializeField, TextArea(1, 6)]
    string[] explanationText;

    [SerializeField]
    GameObject Diary_s;

    //今開いているページの番号
    int PageNum;

    notDestroy notDestroyScript;
    // Start is called before the first frame update
    void Start()
    {
        notDestroyScript = GameObject.Find("dontDes").GetComponent<notDestroy>();
        buttons[1].SetActive(false);
        ChangeDiary();
    }

    public void endButtonClicked()
    {
        Debug.Log("もどる");
        SceneManager.LoadScene("startScene");
    }

    public void OnNextButtonClicked()
    {
        PageNum++;
        buttons[1].SetActive(true);
        ChangeDiary();
        if (PageNum >= 3)
        {
            buttons[2].SetActive(false);
        }
    }

    public void OnBackButtonClicked()
    {
        PageNum--;
        ChangeDiary();
        buttons[2].SetActive(true);
        if (PageNum <= 0)
        {
            buttons[1].SetActive(false);
        }
    }

    public void ChangeDiary()
    {
        for (int i = 0; i < Diary_s.transform.childCount; i++)
        {
            if (notDestroyScript.DiaryFoundList.Contains(2 * PageNum + i))
            {
                //Diary_s.transform.GetChild(i).transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite =[ ];

                Diary_s.transform.GetChild(i).transform.GetChild(2).gameObject.GetComponent<Text>().text =
                    explanationText[2 * PageNum + i];
            }
            else
            {
                Diary_s.transform.GetChild(i).transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = null;

                Diary_s.transform.GetChild(i).transform.GetChild(2).gameObject.GetComponent<Text>().text = "????????";
            }
        }
    }
}
