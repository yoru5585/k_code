using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class santa : MonoBehaviour
{
    bool canTalk = false;
    [SerializeField]
    GameObject talkCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canTalk)
        {
            
        }
        else
        {
            return;
        }

        if (Input.GetKeyDown("o"))
        {
            Debug.Log("aaaaa");
            GameObject.FindGameObjectWithTag("manager").GetComponent<player>().canMove = false;
            talkCanvas.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Player"))
        {
            canTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Player"))
        {
            canTalk = false;
        }
    }
}
