using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField]
    bool notTalkingScene = true;

    [SerializeField] int moveSpeed_setting;
    int moveSpeed;
    public int fast_moveSpeed_setting;
    public int fast_moveSpeed;
    public Rigidbody2D player_rd2;

    GameObject playerObj;

    [SerializeField]
    Camera mainCamera;

    public bool fast_flag = false;
    public bool stop_flag = false;
    public bool canMove = true;

    notDestroy notDestroy_s;
    mainWeapon mainWeapon_s;
    playerAnim playerAnim_s;
    item item_s;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        if (notTalkingScene)
        {
            mainWeapon_s = GetComponent<mainWeapon>();

        }

        notDestroy_s = GameObject.Find("dontDes").GetComponent<notDestroy>();
        playerAnim_s = GetComponent<playerAnim>();
        item_s = GetComponent<item>();
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.position = new Vector3(playerObj.transform.position.x, playerObj.transform.position.y, -10.0f);

        if (Input.GetKeyDown("o"))
        {
            if (notTalkingScene)
            {
                mainWeapon_s.onMainAttack();
                playerAnim_s.MainAttackAnimationSelect();

            }

        }

        if (Input.GetKeyDown("p")||notDestroy_s.isEasyMode)
        {
            if (notTalkingScene)
            {
                item_s.onItemStockUsed();
            }
            
        }

        if (Input.GetKeyDown("k")|| notDestroy_s.isEasyMode)
        {
            //まだスタミナシステム作ってない→つくった。
            if (stop_flag == false)
            {
                fast_flag = true;

            }
            

        }

        if (Input.GetKeyUp("k")&& notDestroy_s.isEasyMode == false)
        {
            fast_flag = false;
        }

        if (fast_flag)
        {
            moveSpeed = fast_moveSpeed;
        }
        else
        {
            moveSpeed = moveSpeed_setting;
        }

        if (canMove)
        {
            player_rd2.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * moveSpeed;

        }
        

    }
}
