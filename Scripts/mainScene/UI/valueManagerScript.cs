using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class valueManagerScript : MonoBehaviour
{
    public float HP_max;
    public float HP_value;
    //public float experience_value;
    public float physical_value;
    public int deathblow_value;

    //経験値系
    public float[] necessExpArray;
    public float[] getExpArray;
    public int nowLevel = 0;
    public int maxLevel;
    [SerializeField]
    float getExp_thisStage;

    //主人公の手持ち武器　現在の攻撃力
    //これを敵は取得し、自分の体力を減らす。
    public float playerMainWeaponAP;

    //ウェーブ管理用　キル数
    public int killNum = 0;

    private void Awake()
    {
        nowLevel = GameObject.Find("dontDes").GetComponent<notDestroy>().shareExp;
        if (GameObject.Find("dontDes").GetComponent<notDestroy>().shareAP != 0)
        {
            playerMainWeaponAP = GameObject.Find("dontDes").GetComponent<notDestroy>().shareAP;
        }

        if (GameObject.Find("dontDes").GetComponent<notDestroy>().isEasyMode)
        {
            deathblow_value = 3;
        }

        HP_max = HP_value;
    }


    private void Start()
    {
        
        
    }

    public void expIncrease()
    {
        if (nowLevel < maxLevel)
        {
            getExpArray[nowLevel] += getExp_thisStage;
        }
        
        
    }
}
