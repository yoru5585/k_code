using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSecondMessage : MonoBehaviour
{
    Text MessText;
    Text NameText;
    int TextNum = 0;

    [SerializeField, TextArea(0, 6)] string[] MessStr;
    [SerializeField, TextArea(0, 6)] string[] NameStr;
    // Start is called before the first frame update
    void Start()
    {
        NameText = gameObject.transform.GetChild(0).GetComponent<Text>();
        MessText = gameObject.transform.GetChild(1).GetComponent<Text>();
        NameText.text = NameStr[TextNum];
        MessText.text = MessStr[TextNum++];

    }

    // Update is called once per frame
    void Update()
    {
        if (TextNum >= MessStr.Length)
        {
            GameObject.Find("Clear_Canvas").transform.GetChild(0).gameObject.SetActive(true);
            gameObject.GetComponent<ClearMessage>().enabled = true;
            gameObject.GetComponent<BossSecondMessage>().enabled = false;
            GameObject.Find("BGM").GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("sound/hatsuyuki");
            GameObject.Find("BGM").GetComponent<AudioSource>().Play();
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            NameText.text = NameStr[TextNum];
            MessText.text = MessStr[TextNum++];
        }
    }
}
