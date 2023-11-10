using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMessage : MonoBehaviour
{
    Text MessText;
    Text NameText;
    int TextNum = 0;

    [SerializeField, TextArea(0,6)] string[] MessStr;
    [SerializeField] string[] NameStr;
    // Start is called before the first frame update
    void Start()
    {
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
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            MessText.text = MessStr[TextNum];
            NameText.text = NameStr[TextNum++];
        }
    }
}
