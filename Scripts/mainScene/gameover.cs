using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{


    [SerializeField]
    float fadeSpeed;
    float red, green, blue, alfa;

    public bool isFadeIn = false;

    Image fadeImage;

    [SerializeField]
    GameObject fadeImageObj;

    // Start is called before the first frame update
    void Start()
    {
        fadeImage = fadeImageObj.GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeIn)
        {
            EndFadeIn();
        }

    }

    void EndFadeIn()
    {
        alfa += fadeSpeed * Time.deltaTime;
        SetAlpha();
        if (alfa >= 1)
        {
            //Debug.Log("sssssss");
            isFadeIn = false;
            SceneManager.LoadScene("gameoverScene");

        }
    }



    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}
