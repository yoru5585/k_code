using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage4Manager : MonoBehaviour
{
    bool IsfirstMess;
    bool IsSecondMess;
    bool IsLastMess;
    bool flag = false;
    bool flag2 = true;
    bool flag3 = false;
    [SerializeField, TextArea(0, 6)]
    string[] FirstMess;
    [SerializeField, TextArea(0, 6)]
    string[] FirstName;
    [SerializeField, TextArea(0, 6)]
    string[] SecondMess;
    [SerializeField, TextArea(0, 6)]
    string[] SecondName;
    [SerializeField, TextArea(0, 6)]
    string[] LastMess;
    [SerializeField, TextArea(0, 6)]
    string[] LastName;
    stage4message sms;

    public int WhistleNum;
    GameObject dragon;
    GameObject hues;

    float TimeCount = 0;
    float TimeInterval = 10;
    // Start is called before the first frame update
    void Start()
    {
        sms = GetComponent<stage4message>();
        sms.SetUpMess(FirstMess, FirstName);
        GetComponent<player>().canMove = false;
        sms.IsMessStart = true;
        IsfirstMess = true;
        dragon = GameObject.Find("dragon");
        hues = GameObject.Find("hues");
        hues.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //if (dragon == null && flag3)
        //{
        //    //Instantiate((GameObject)Resources.Load("hikari_0"));
        //    GetComponent<dragon>().enabled = false;
        //    GetComponent<player>().canMove = false;
        //    GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //    sms.SetUpMess(LastMess, LastName);
        //    sms.IsMessStart = true;
        //    IsLastMess = true;
        //    flag3 = false;
        //}

        if (WhistleNum == 3 && flag2)
        {

            notDestroy nds = GameObject.Find("dontDes").GetComponent<notDestroy>();
            nds.shareExp = GetComponent<valueManagerScript>().nowLevel;
            nds.shareAP = GetComponent<valueManagerScript>().playerMainWeaponAP;
            nds.isStageCleared[5] = true;
            GameObject.Find("scriptManager").GetComponent<SaveManager>().Save();
            flag2 = false;
            flag3 = true;
            SceneManager.LoadScene("end");

            //Ç±ÇÍà»ç~ï ÉVÅ[Éìèàóù
            //GetComponent<dragon>().enabled = false;
            //dragon.GetComponent<enemyHP>().setMyEnemyHP(10);
            //flag2 = false;
            //flag3 = true;
            return;
        }

        if (flag)
        {
            TimeCount += Time.deltaTime;
            if (TimeCount >= TimeInterval)
            {
                GetComponent<dragon>().enabled = false;
                GetComponent<player>().canMove = false;
                GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-0.610000014f, -3.18000007f, 0);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                sms.SetUpMess(SecondMess, SecondName);
                sms.IsMessStart = true;
                IsSecondMess = true;
                flag = false;
                return;
            }
        }

        if (IsfirstMess && sms.IsMessEnd)
        {
            IsfirstMess = false;
            sms.IsMessEnd = false;
            flag = true;
            GetComponent<player>().canMove = true;
            GetComponent<dragon>().enabled = true;
            return;
        }

        if (IsSecondMess && sms.IsMessEnd)
        {
            IsSecondMess = false;
            sms.IsMessEnd = false;
            GetComponent<player>().canMove = true;
            GetComponent<dragon>().enabled = true;
            hues.SetActive(true);
            GetComponent<item>().IsStage4 = true;
            return;
        }

        //if (IsLastMess)
        //{
        //    if (sms.TextNum == 1)
        //    {
        //        GameObject.Find("ScriptManager").GetComponent<SaveManager>().Save();
        //        GameObject.Find("BGM").GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("sound/tanoshiibouken");
        //        GameObject.Find("BGM").GetComponent<AudioSource>().Play();
        //    }

        //    if (sms.TextNum == 5)
        //    {
        //        GameObject.Find("Clear_Canvas").transform.GetChild(0).gameObject.SetActive(true);
        //    }

        //    if (sms.IsMessEnd)
        //    {
        //        IsLastMess = false;
        //        sms.IsMessEnd = false;
        //        notDestroy nds = GameObject.Find("dontDes").GetComponent<notDestroy>();
        //        nds.shareExp = GetComponent<valueManagerScript>().nowLevel;
        //        nds.shareAP = GetComponent<valueManagerScript>().playerMainWeaponAP;
        //        nds.isStageCleared[5] = true;
        //        GameObject.Find("BGM").GetComponent<AudioSource>().Stop();
        //        GameObject.Find("dontDes").GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("sound/longkirakira"));
        //        FadeManager.Instance.LoadScene("startScene", 0.7f);
        //        return;
        //    }
        //}

    }
}
