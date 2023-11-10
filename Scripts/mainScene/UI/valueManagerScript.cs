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

    //�o���l�n
    public float[] necessExpArray;
    public float[] getExpArray;
    public int nowLevel = 0;
    public int maxLevel;
    [SerializeField]
    float getExp_thisStage;

    //��l���̎莝������@���݂̍U����
    //�����G�͎擾���A�����̗̑͂����炷�B
    public float playerMainWeaponAP;

    //�E�F�[�u�Ǘ��p�@�L����
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
