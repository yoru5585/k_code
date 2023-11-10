using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    message message_script;

    [SerializeField]
    GameObject[] ImageBG_array = new GameObject[]
    {

    };

    [SerializeField]
    int playerTatieNum;

    // Start is called before the first frame update
    void Start()
    {
        message_script = GetComponent<message>();
        playerTatieNum++;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ImageCheck1()
    {
        int i = message_script.ImageStr_1[message_script.textcount];

        if (i == 0)
        {
            return;
        }
        /*
        foreach (GameObject k in ImageBG_array)
        {
            k.GetComponent<SpriteRenderer>().enabled = false;
        }
        */

        for (int k = 0; k < playerTatieNum; k++)
        {
            ImageBG_array[k].GetComponent<SpriteRenderer>().enabled = false;
        }
        ImageBG_array[i].GetComponent<SpriteRenderer>().enabled = true;

    }

    public void ImageCheck2()
    {
        int j = message_script.ImageStr_2[message_script.textcount];

        if (j == 0)
        {
            return;
        }

        for (int k = playerTatieNum; k < ImageBG_array.Length; k++)
        {
            ImageBG_array[k].GetComponent<SpriteRenderer>().enabled = false;
        }
        ImageBG_array[j].GetComponent<SpriteRenderer>().enabled = true;

    }
}
