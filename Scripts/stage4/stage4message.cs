using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stage4message : MonoBehaviour
{
    Text MessText;
    Text NameText;
    public int TextNum = 0;
    string[] MessStr;
    string[] NameStr;
    public bool IsMessStart;
    public bool IsMessEnd;
    [SerializeField]
    GameObject MessWindow;
    // Start is called before the first frame update
    void Start()
    {
        MessText = MessWindow.transform.GetChild(1).GetComponent<Text>();
        NameText = MessWindow.transform.GetChild(0).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMessStart != true)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (TextNum >= MessStr.Length)
            {
                IsMessEnd = true;
                IsMessStart = false;
                TextNum = 0;
                MessWindow.transform.parent.gameObject.SetActive(false);
                return;

            }
            MessText.text = MessStr[TextNum];
            NameText.text = NameStr[TextNum++];
        }
    }

    public void SetUpMess(string[] str, string[] name)
    {
        MessStr = str;
        NameStr = name;
        MessText.text = MessStr[TextNum];
        NameText.text = NameStr[TextNum++];
        MessWindow.transform.parent.gameObject.SetActive(true);
    }
}
