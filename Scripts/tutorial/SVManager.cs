using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SVManager : MonoBehaviour
{
    [SerializeField] GameObject content;
    [SerializeField] Scrollbar Scrollbar;
    GameObject[] points;

    int ContentLen;
    void Start()
    {
        Init();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init()
    {
        GameObject parent = GameObject.Find("points");
        Debug.Log(parent.transform.childCount);
        points = new GameObject[parent.transform.childCount];
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            points[i] = parent.transform.GetChild(i).gameObject;
            
        }
        ContentLen = content.transform.childCount;
        Scrollbar.value = 0;
        OnValueChange();
    }

    public void OnValueChange()
    {
        float duration = 1.0f / ContentLen;
        int index = (int)(Scrollbar.value / duration);
        if (index >= points.Length) { index = points.Length - 1; }
        foreach (GameObject i in points) { i.GetComponent<Image>().color = new Color(255, 255, 255); }
        points[index].GetComponent<Image>().color = new Color(0,0,0);
    }
}
