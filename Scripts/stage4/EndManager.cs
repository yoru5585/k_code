using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndManager : MonoBehaviour
{
    [SerializeField, TextArea(0, 6)]
    string[] LastMess;
    [SerializeField, TextArea(0, 6)]
    string[] LastName;
    [SerializeField] GameObject shine;
    stage4message sms;
    bool IsLastMess;
    // Start is called before the first frame update
    void Start()
    {
        sms = GetComponent<stage4message>();
    }

    // Update is called once per frame
    void Update()
    {

        if (IsLastMess)
        {
            if (sms.TextNum == 16)
            {
                GameObject.Find("BGM").GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("sound/tanoshiibouken");
                GameObject.Find("BGM").GetComponent<AudioSource>().Play();
            }

            if (sms.TextNum == 7)
            {
                GameObject.Find("BGM").GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("sound/hatsuyuki");
                GameObject.Find("BGM").GetComponent<AudioSource>().Play();
            }

            if (sms.TextNum == 3)
            {
                GameObject.Find("Clear_Canvas").transform.GetChild(0).gameObject.SetActive(true);
            }

            if (sms.TextNum == 20)
            {
                GameObject.Find("Clear_Canvas").transform.GetChild(0).gameObject.GetComponent<Image>().sprite = null;
            }

            if (sms.IsMessEnd)
            {
                sms.IsMessEnd = false;


                GameObject.Find("BGM").transform.parent = GameObject.Find("dontDes").transform;
                FadeManager.Instance.LoadScene("credit", 0.7f);
            }
            return;
        }

        if (!shine)
        {
            OnEnd();
        }
    }

    public void OnEnd()
    {
        GameObject.FindGameObjectWithTag("manager").GetComponent<player>().canMove = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GameObject.Find("dragon").SetActive(false);
        GameObject.Find("BGM").GetComponent<AudioSource>().Stop();
        GameObject.Find("dontDes").GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("sound/longkirakira"));
        GameObject.Find("sitai").GetComponent<SpriteRenderer>().enabled = true;
        sms.SetUpMess(LastMess, LastName);
        sms.IsMessStart = true;
        IsLastMess = true;
    }
}
