using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class opening : MonoBehaviour
{
    [SerializeField]
    Image still;
    [SerializeField]
    Text text;

    Sprite[] stillImageDatas;
    [SerializeField, TextArea(1, 6)]
    string[] textDatas;

    int stillNum = 1;
    // Start is called before the first frame update
    void Start()
    {
        stillImageDatas = Resources.LoadAll<Sprite>("sutiru/");
        text.text = textDatas[0];
        still.sprite = stillImageDatas[0];

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (stillNum >= stillImageDatas.Length)
            {
                Debug.Log("èIóπ");
                SceneManager.LoadScene("stage1");
                return;
            }

            still.sprite = stillImageDatas[stillNum];
            text.text = textDatas[stillNum];
            /*
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
            for (float i = 0; i < 1; i += 0.1f)
            {
                text.color += new Color(0,0,0,i);
            }
            */
            stillNum++;
        }
    }

    public void skipButton()
    {
        SceneManager.LoadScene("stage1");
    }
}
