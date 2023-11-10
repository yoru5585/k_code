using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainWeapon : MonoBehaviour
{
    [SerializeField]
    GameObject[] mainWepColl;

    [SerializeField] Animator anim;

    int dir;
    playerAnim playerAnim_scripts;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim_scripts = GetComponent<playerAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        this.dir = playerAnim_scripts.dir;

    }

    public void onMainAttack()
    {
        //ボタン入力はplayerScriptでまとめて行う。
        mainWepColl[dir].SetActive(true);
        GameObject.Find("dontDes").GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("sound/ken"));
        anim.SetTrigger("mainAttack");
    }
    
    public void onMainAttackFinished()
    {
        //アニメーションにつける
        foreach (GameObject i in mainWepColl)
        {
            i.SetActive(false);
        }
    }
}
