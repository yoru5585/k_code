using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class waveManager : MonoBehaviour
{
    
    valueManagerScript vms;
    notDestroy nds;

    [SerializeField]
    int waveQuota;
    [SerializeField]
    GameObject messageObj;

    bool[] flag = new bool[3];
    GameObject snowBoss;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < flag.Length; i++){ flag[i] = true; }
        flag[2] = false;
        vms = GetComponent<valueManagerScript>();
        nds = GameObject.Find("dontDes").GetComponent<notDestroy>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vms.killNum >= waveQuota)
        {
            //Debug.Log("ボス出現　敵復活など");

            if (SceneManager.GetActiveScene().name == "stage1")
            {
                nds.shareExp = GetComponent<valueManagerScript>().nowLevel;
                nds.shareAP = GetComponent<valueManagerScript>().playerMainWeaponAP;
                nds.isStageCleared[1] = true;

                GameObject.Find("Clear_Canvas").transform.GetChild(0).gameObject.SetActive(true);

                
            }

            if (SceneManager.GetActiveScene().name == "stage2")
            {
                if (flag[0])
                {
                    flag[0] = false;
                    GameObject pre = (GameObject)Resources.Load("snowBoss");
                    snowBoss = Instantiate(pre, new Vector3(3.0f, 3.0f, 0), Quaternion.identity);

                    GetComponent<tonakai_iceManager>().isAttack = true;

                }

                if (snowBoss)
                {
                    //Debug.Log("存在してます" + flag[1]);
                    
                    if (flag[1]==true)
                    {
                        flag[1] = false;
                        GetComponent<santaSkill>().enabled = false;
                        GetComponent<enemyFactory>().enabled = false;
                        GetComponent<player>().canMove = false;
                        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        GetComponent<tonakai_iceManager>().isAttack = false;
                        messageObj.SetActive(true);
                        if (GameObject.Find("playerColl") != null)
                        {
                            GameObject.Find("playerColl").gameObject.SetActive(false);

                        }
                        //会話に入る前の処理
                    }

                    if (flag[1]!=true&&messageObj.activeSelf==false)
                    {
                        flag[2] = true;
                        GetComponent<santaSkill>().enabled = true;
                        GetComponent<enemyFactory>().enabled = true;
                        GetComponent<player>().canMove = true;
                        GetComponent<tonakai_iceManager>().isAttack = true;
                        messageObj.transform.GetChild(0).gameObject.GetComponent<BossSecondMessage>().enabled = true;
                        messageObj.transform.GetChild(0).gameObject.GetComponent<BossMessage>().enabled = false;
                        messageObj.SetActive(false);
                        nds.shareExp = GetComponent<valueManagerScript>().nowLevel;
                        nds.shareAP = GetComponent<valueManagerScript>().playerMainWeaponAP;
                        nds.isStageCleared[2] = true;
                        if (GameObject.Find("playerColl") != null)
                        {
                            GameObject.Find("playerColl").gameObject.SetActive(true);

                        }
                    }

                }
                else
                {
                    if (flag[2])
                    {
                        flag[2] = false;
                        GetComponent<santaSkill>().enabled = false;
                        GetComponent<enemyFactory>().enabled = false;
                        GetComponent<player>().canMove = false;
                        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        GetComponent<tonakai_iceManager>().isAttack = false;
                        GameObject.Find("BGM").GetComponent<AudioSource>().Stop();
                        messageObj.SetActive(true);
                        if (GameObject.Find("playerColl") != null)
                        {
                            GameObject.Find("playerColl").gameObject.SetActive(false);

                        }

                        GameObject[] allEnemy = GameObject.FindGameObjectsWithTag("enemy");
                        foreach (GameObject i in allEnemy)
                        {
                            Destroy(i);
                        }
                    }
                }

                

            }
            
        }
    }

    public void backStartScene()
    {
        SceneManager.LoadScene("startScene");

    }

    public void nextScene()
    {
        SceneManager.LoadScene("santaTalkScene");
    }
    
}
