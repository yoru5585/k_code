using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentChange : MonoBehaviour
{
    [SerializeField] GameObject ConClone;
    [SerializeField] GameObject PageClone;

    [SerializeField, TextArea(0, 6)]
    string[] mainText = { };
    int TextMaxNum = 1;
    void Start()
    {
        TextMaxNum = mainText.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClicked()
    {
        Transform Contents = ConClone.transform.parent;
        Transform pages = PageClone.transform.parent;
        
        ConClone.transform.GetChild(0).gameObject.GetComponent<Text>().text = mainText[0];

        for (int i = Contents.childCount - 1; i > 0; i--)
        {
            Destroy(Contents.GetChild(i).gameObject);
            Destroy(pages.GetChild(i).gameObject);
        }


        for (int i = 1; i < TextMaxNum; i++)
        {
            GameObject ins = Instantiate(ConClone,Contents);
            ins.transform.GetChild(0).gameObject.GetComponent<Text>().text = mainText[i];
            Instantiate(PageClone, PageClone.transform.parent);
        }
        
        SVManager svm = GameObject.Find("ScriptsManager").GetComponent<SVManager>();
        svm.Init();
    }
}
