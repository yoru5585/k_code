using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnim : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField]Rigidbody2D player_rd2;

    public int dir;
    // Start is called before the first frame update
    void Start()
    {
        dir = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (player_rd2.velocity != Vector2.zero)
        {
            anim.SetBool("idle", false);

            if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                return;
            }

            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    //右
                    anim.SetFloat("X", 1f);
                    anim.SetFloat("Y", 0);

                    dir = 0;
                }
                else
                {
                    //左
                    anim.SetFloat("X", -1f);
                    anim.SetFloat("Y", 0);

                    dir = 1;
                }

            }
            else if (Input.GetAxisRaw("Vertical") > 0)
            {
                //後ろ
                anim.SetFloat("X", 0);
                anim.SetFloat("Y", 1f);

                dir = 2;
            }
            else
            {
                //前
                anim.SetFloat("X", 0);
                anim.SetFloat("Y", -1f);

                dir = 3;
            }
        }
        else
        {
            anim.SetBool("idle",true);

            if (dir == 0)
            {
                //右待機

                anim.SetFloat("idle_X", 1f);
                anim.SetFloat("idle_Y", 0);
            }
            else if(dir == 1)
            {
                //左待機

                anim.SetFloat("idle_X", -1f);
                anim.SetFloat("idle_Y", 0);
            }
            else if(dir == 2)
            {
                //後ろ待機

                anim.SetFloat("idle_X", 0);
                anim.SetFloat("idle_Y", 1f);
            }
            else if (dir == 3)
            {
                //前待機

                anim.SetFloat("idle_X", 0);
                anim.SetFloat("idle_Y", -1f);
            }

        }



    }

    public void MainAttackAnimationSelect()
    {
        if (dir == 0)
        {
            //右待機

            anim.SetFloat("main_X", 1f);
            anim.SetFloat("main_Y", 0);
        }
        else if (dir == 1)
        {
            //左待機

            anim.SetFloat("main_X", -1f);
            anim.SetFloat("main_Y", 0);
        }
        else if (dir == 2)
        {
            //後ろ待機

            anim.SetFloat("main_X", 0);
            anim.SetFloat("main_Y", 1f);
        }
        else if (dir == 3)
        {
            //前待機

            anim.SetFloat("main_X", 0);
            anim.SetFloat("main_Y", -1f);
        }
    }
}
