using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class armer : MonoBehaviour
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
    [SerializeField]
    GameObject playerColl;

    Image fill;

    //Text countText;

    //public bool armerFlag;
    // Start is called before the first frame update
    void Start()
    {
        timeCount = timeSP;
        //countText = timeCountTextObj.GetComponent<Text>();
        fill = fill_Image.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ringObj.activeSelf == false)
        {
            return;
        }

        playerColl.SetActive(false);
        //armerFlag = true;

        //countText.text = timeCount.ToString();
        timeCount -= Time.deltaTime;
        fill.fillAmount = timeCount / timeSP;
        if (timeCount < 0)
        {
            timeCount = timeSP;
            //armerFlag = false;
            playerColl.SetActive(true);
            //countText.text = " ";
            ringObj.SetActive(false);
        }



    }
}
