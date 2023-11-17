using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class takara_destroy : MonoBehaviour
{
    [SerializeField]
    float fadeSpeed;
    float red, green, blue, alfa;

    SpriteRenderer fadeImage;

    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GetComponent<SpriteRenderer>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        fadeOut();
    }

    void fadeOut()
    {
        alfa -= fadeSpeed * Time.deltaTime;
        SetAlpha();
        if (alfa <= 0)
        {
            //ここでオブジェクト消す
            Destroy(this.gameObject);
            
        }
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}
