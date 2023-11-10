using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Diary : MonoBehaviour
{
    [SerializeField]
    int addNum;

    notDestroy notDestroyScript;
    void Start()
    {
        notDestroyScript = GameObject.Find("dontDes").GetComponent<notDestroy>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            notDestroyScript.DiaryFoundList.Add(addNum);
            Destroy(this.gameObject);
        }
    }
}
