using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gallery : MonoBehaviour
{
    [SerializeField]
    GameObject[] buttons;

    [SerializeField]
    GameObject illust_Objs_parent;
    [SerializeField]
    GameObject diary_Objs_parent;

    [SerializeField, TextArea(1,6)]
    string[] explanationText;

    Sprite[] foodsImageData;

    int nowPageNum = 0;

    notDestroy notDestroyScript;

    // Start is called before the first frame update
    void Start()
    {
        foodsImageData = Resources.LoadAll<Sprite>("foods/");
        notDestroyScript = GameObject.Find("dontDes").GetComponent<notDestroy>();
        changeGalleryPack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeExplanationTextAndillust(GameObject i, int num)
    {

        i.SetActive(true);

        if (nowPageNum * illust_Objs_parent.transform.childCount + num >= foodsImageData.Length)
        {

            i.SetActive(false);
            return;

        }

        if (notDestroyScript.foodFoundList.Contains(nowPageNum * illust_Objs_parent.transform.childCount + num))
        {
            i.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite =
            foodsImageData[nowPageNum * illust_Objs_parent.transform.childCount + num];

            i.transform.GetChild(2).gameObject.GetComponent<Text>().text =
                explanationText[nowPageNum * illust_Objs_parent.transform.childCount + num];
        }
        else
        {
            i.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = null;

            i.transform.GetChild(2).gameObject.GetComponent<Text>().text = "????????";
        }

        
    }

    void changeGalleryPack()
    {
        for (int i = 0; i < illust_Objs_parent.transform.childCount; i++)
        {
            changeExplanationTextAndillust(illust_Objs_parent.transform.GetChild(i).gameObject, i);
        }
    }

    public void backButtonClicked()
    {
        nowPageNum--;
        buttons[1].SetActive(true);

        if (nowPageNum <= 0)
        {
            buttons[0].SetActive(false);
        }
        
        changeGalleryPack();
        
    }

    public void nextButtonClicked()
    {
        nowPageNum++;
        buttons[0].SetActive(true);

        if (nowPageNum >= foodsImageData.Length/ illust_Objs_parent.transform.childCount)
        {
            buttons[1].SetActive(false);
        }

        changeGalleryPack();
    }

    public void endButtonClicked()
    {
        Debug.Log("‚à‚Ç‚é");
        SceneManager.LoadScene("startScene");
    }

    public void husen1Clicked()
    {
        illust_Objs_parent.SetActive(true);
        diary_Objs_parent.SetActive(false);
        GameObject.Find("husen1").GetComponent<Image>().enabled = true;
        GameObject.Find("husen2").GetComponent<Image>().enabled = false;
        foreach (GameObject i in buttons)
        {
            i.SetActive(true);
        }
    }

    public void husen2Clicked()
    {
        illust_Objs_parent.SetActive(false);
        diary_Objs_parent.SetActive(true);
        GameObject.Find("husen1").GetComponent<Image>().enabled = false;
        GameObject.Find("husen2").GetComponent<Image>().enabled = true;
        foreach (GameObject i in buttons)
        {
            i.SetActive(false);
        }
    }
}
