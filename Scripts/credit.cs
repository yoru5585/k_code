using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class credit : MonoBehaviour
{
    bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (flag)
            {
                OnClicked();
            }
            else
            {
                Destroy(GameObject.Find("BGM"));
                FadeManager.Instance.LoadScene("startScene", 2.0f);
            }
            
        }
    }

    public void OnClicked()
    {
        GameObject.Find("Img").GetComponent<Image>().enabled = false;
        GameObject.Find("Img_2").GetComponent<Image>().enabled = true;
        flag = false;
    }
}
