using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textBlink : MonoBehaviour
{
    [SerializeField]
    GameObject startTextObj;

    Text startText;
    float coolingTime;

    float fadeSpeed = 1.0f;
    float red, green, blue, alfa;

    bool isFadeOut = false;
    // Start is called before the first frame update
    void Start()
    {
        red = 255;
        startText = startTextObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeOut)
        {
            StartFadeOut();
        }
        else
        {
            EndFadeOut();
        }
    }

    void StartFadeOut()
    {
        alfa += fadeSpeed * Time.deltaTime;
        SetAlpha();
        if (alfa >= 1)
        {
            isFadeOut = false;

        }
    }

    void EndFadeOut()
    {
        alfa -= fadeSpeed * Time.deltaTime;
        SetAlpha();
        if (alfa <= 0)
        {
            isFadeOut = true;
        }
    }

    void SetAlpha()
    {
        startText.color = new Color(red, green, blue, alfa);
    }


}
