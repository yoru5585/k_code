using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highSpeed : MonoBehaviour
{

    float timeCount;
    [SerializeField]
    float timeSP;

    /*
    [SerializeField]
    GameObject timeCountTextObj;
    */
    [SerializeField]
    GameObject ringObj;
    [SerializeField]
    GameObject fill_Image;

    Image fill;

    //スタミナを上げ下げしているスクリプトにアクセスして、その上げ下げの値を変更する。
    valueChange vc;

    //Text countText;
    // Start is called before the first frame update
    void Start()
    {
        vc = GetComponent<valueChange>();

        timeCount = timeSP;
        fill = fill_Image.GetComponent<Image>();
        //countText = timeCountTextObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        if (ringObj.activeSelf == false)
        {
            return;
        }

        //countText.text = timeCount.ToString();
        vc.isHighSpeed = true;
        timeCount -= Time.deltaTime;
        fill.fillAmount = timeCount/timeSP;

        if (timeCount < 0)
        {
            timeCount = timeSP;
            vc.isHighSpeed = false;
            vc.slowSpeed();
            //countText.text = " ";
            ringObj.SetActive(false);
        }

    }
}
