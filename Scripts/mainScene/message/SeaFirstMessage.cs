using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeaFirstMessage : MonoBehaviour
{
    Text MessText;
    Text NameText;
    int TextNum = 0;

    [SerializeField, TextArea(0, 6)]
    string[] NameStr;
    [SerializeField, TextArea(0,6)] 
    string[] MessStr;

    GameObject ScriptManager;
    // Start is called before the first frame update
    void Start()
    {
        ScriptManager = GameObject.FindGameObjectWithTag("manager");
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
            ScriptManager.GetComponent<enemyFactory>().enabled = true;
            ScriptManager.GetComponent<SeaManager>().enabled = true;
            ScriptManager.GetComponent<santaSkill>().enabled = true;
            ScriptManager.GetComponent<mermaidSkill>().enabled = true;
            ScriptManager.GetComponent<player>().canMove = true;
            Instantiate((GameObject)Resources.Load("YellowSlime"), new Vector3(6.4f, 3.0f, 0), Quaternion.identity);
            Instantiate((GameObject)Resources.Load("YellowSlime"), new Vector3(-6.4f, 3.0f, 0), Quaternion.identity);
            Instantiate((GameObject)Resources.Load("YellowSlime"), new Vector3(6.4f, -3.0f, 0), Quaternion.identity);
            Instantiate((GameObject)Resources.Load("YellowSlime"), new Vector3(-6.4f, -3.0f, 0), Quaternion.identity);
            GetComponent<SeaFirstMessage>().enabled = false;
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
