using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class valueChange : MonoBehaviour
{
    //HP-----------------------
    [SerializeField]
    GameObject HP_slider;
    [SerializeField]
    GameObject HP_fill;
    [SerializeField]
    GameObject ouji_meter;
    Sprite[] oujiImageData;
    bool[] flag = {true, true, true};
    gameover gameoverScript;

    //physical-----------------
    [SerializeField]
    GameObject physical_slider;
    [SerializeField]
    GameObject physical_fill;
    //magで減る量を調整
    [SerializeField]
    float mag_dec_set;
    [SerializeField]
    float mag_inc_set;
    [SerializeField]
    float mag_dec;
    [SerializeField]
    float mag_inc;
    public bool isHighSpeed = false;

    //experience---------------
    [SerializeField]
    GameObject experience_slider;
    [SerializeField]
    Text expText;
    bool isMax = false;
    

    //deathblow----------------
    [SerializeField]
    GameObject deathblow_slider;
    [SerializeField]
    GameObject deathblows;
    bool isEnough = true;



    valueManagerScript vms;
    notDestroy nds;
    player player_script;

    

    // Start is called before the first frame update
    void Start()
    {
        nds = GameObject.Find("dontDes").GetComponent<notDestroy>();
        vms = GetComponent<valueManagerScript>();
        gameoverScript = GetComponent<gameover>();

        oujiImageData = Resources.LoadAll<Sprite>("ouji/");
        player_script = GetComponent<player>();

        mag_dec = mag_dec_set;
        mag_inc = mag_inc_set;

        vms.necessExpArray = new float[vms.maxLevel];
        if (vms.nowLevel != 0)
        {
            expText.text = " " + vms.nowLevel;
        }
        
        for (int i = 0; i < vms.necessExpArray.Length; i++)
        {
            vms.necessExpArray[i] = Mathf.Pow(i + 1, 2);
            //Debug.Log(necessExpArray[i]);
        }
        vms.getExpArray = new float[vms.maxLevel];
    }

    // Update is called once per frame
    void Update()
    {
        HP_slider.GetComponent<Slider>().value = vms.HP_value;
        physical_slider.GetComponent<Slider>().value = vms.physical_value;
        
        deathblow_slider.GetComponent<Slider>().value = vms.deathblow_value;

        HPiconChanger();
        physicalValueChanger();
        if (Input.GetKeyDown("j")||nds.isEasyMode)
        {
            onDeathblowSelected();
        }
        if (isMax != true)
        {
            expChanger();
        }

        //デバッグ用(gで経験値増やす,回復)
        if (Input.GetKeyDown("g"))
        {
            vms.HP_value += 1000;
            vms.getExpArray[vms.nowLevel] += 10000;
        }

    }

    void HPiconChanger()
    {

        if (vms.HP_value <= 0)
        {
            player_script.canMove = false;
            gameoverScript.isFadeIn = true;
            Debug.Log("gameover");
        }

        if (vms.HP_value <= HP_slider.GetComponent<Slider>().maxValue / 4)
        {

            if (flag[0])
            {
                flag[0] = false;
                flag[1] = true;
                flag[2] = true;

                ouji_meter.GetComponent<Image>().sprite = oujiImageData[2];
                HP_fill.GetComponent<Image>().color = new Color(1, 0, 0);

                Debug.Log("体力25％以下");
            }
            
        }
        else if (vms.HP_value <= HP_slider.GetComponent<Slider>().maxValue / 2)
        {

            if (flag[1])
            {
                flag[0] = true;
                flag[1] = false;
                flag[2] = true;

                ouji_meter.GetComponent<Image>().sprite = oujiImageData[1];
                HP_fill.GetComponent<Image>().color = new Color(1, 1, 0);

                Debug.Log("体力50％以下");
            }
            
        }
        else
        {
            if (flag[2])
            {
                flag[0] = true;
                flag[1] = true;
                flag[2] = false;

                ouji_meter.GetComponent<Image>().sprite = oujiImageData[0];
                HP_fill.GetComponent<Image>().color = new Color(0, 1, 0);

                Debug.Log("体力満タン");
            }

        }
    }

    void physicalValueChanger()
    {

        if (player_script.fast_flag)
        {
            vms.physical_value -= Time.deltaTime * mag_inc;
        }
        else
        {
            if (vms.physical_value < 100)
            {
                vms.physical_value += Time.deltaTime * mag_dec;

            }


        }

        if (vms.physical_value <= 0f)
        {
            player_script.stop_flag = true;
            player_script.fast_flag = false;

            physical_fill.GetComponent<Image>().color = new Color(1.000f, 0.192f, 0.325f);
        }

        if (vms.physical_value >= 50.0f)
        {
            player_script.stop_flag = false;

            physical_fill.GetComponent<Image>().color = new Color(0, 0.6136f, 1);
        }

        //デバッグ
        if (Input.GetKeyDown("b") || isHighSpeed)
        {

            mag_dec = 30;
            mag_inc = 5;

            player_script.fast_moveSpeed = 12;
        }

    }

    public void slowSpeed()
    {
        mag_dec = mag_dec_set;
        mag_inc = mag_inc_set;

        player_script.fast_moveSpeed = player_script.fast_moveSpeed_setting;
    }

    void expChanger()
    {
        if (vms.nowLevel == vms.maxLevel)
        {
            experience_slider.GetComponent<Image>().fillAmount = 1;
            expText.text = "MAX";
            isMax = true;
        }

        if (isMax != true)
        {
            experience_slider.GetComponent<Image>().fillAmount = vms.getExpArray[vms.nowLevel] / vms.necessExpArray[vms.nowLevel];

            if (vms.getExpArray[vms.nowLevel] >= vms.necessExpArray[vms.nowLevel])
            {
                vms.nowLevel += 1;
                vms.playerMainWeaponAP++;
                experience_slider.GetComponent<Image>().fillAmount = 0;
                expText.text = " "+(vms.nowLevel + 1);
            }


        }
        

        

        
    }

    void onDeathblowSelected()
    {
        if (vms.deathblow_value > 2)
        {
            isEnough = false;
        }

        if (isEnough)
        {
            vms.deathblow_value += 1;
            var parent = deathblows.transform;
            Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            GameObject pre = (GameObject)Resources.Load("fire_circle");
            GameObject createObj = Instantiate(pre, playerPos, Quaternion.identity, parent);
            GameObject.Find("dontDes").GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("sound/fire"));
        }

        isEnough = true;
    }


}
