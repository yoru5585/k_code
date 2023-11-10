using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AwakeMessage : MonoBehaviour
{
    [SerializeField]
    Text MessText;
    [SerializeField]
    Text NameText;
    [SerializeField]
    GameObject messCanvas;

    int TextNum = 0;

    [SerializeField, TextArea(0, 6)]
    string[] MessStr;
    [SerializeField] 
    string[] NameStr;
    [SerializeField]bool flag;
    // Start is called before the first frame update
    void Start()
    {
        messCanvas.SetActive(true);
        if (flag) { GetComponent<player>().canMove = false; }
        MessText.text = MessStr[TextNum];
        NameText.text = NameStr[TextNum++];
    }

    // Update is called once per frame
    void Update()
    {
        if(TextNum >= MessStr.Length)
        {
            if (GetComponent<message>() != null)
            {
                GetComponent<message>().enabled = true;
            }
            messCanvas.SetActive(false);
            
            if (flag) { GetComponent<player>().canMove = true; GameObject.Find("hues").SetActive(false); }
            this.enabled = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            MessText.text = MessStr[TextNum];
            NameText.text = NameStr[TextNum++];
        }
    }
}
