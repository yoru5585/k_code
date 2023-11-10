using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class santaSkill : MonoBehaviour
{
    [SerializeField]
    Image santaImg;
    takaraPosSelect takaraPosSelect_s;
    Transform player_t;
    
    
    // Start is called before the first frame update
    void Start()
    {
        santaImg.GetComponent<Image>().fillAmount = 0;
        takaraPosSelect_s = GetComponent<takaraPosSelect>();
        player_t = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(player_t.position.x);
        santaImg.GetComponent<Image>().fillAmount += Time.deltaTime /10;
        if (santaImg.GetComponent<Image>().fillAmount >= 1)
        {
            santaImg.GetComponent<Image>().fillAmount = 0;
            var parent = GameObject.Find("UI_Canvas").transform;
            GameObject pre = (GameObject)Resources.Load("santaCutIn2");
            Instantiate(pre, new Vector3(740, 62, 0), Quaternion.identity, parent);
            for (int i = -3; i < 4; i++)
            {
                if (Math.Abs(i) > 1)
                {
                    Vector3 Pos = new Vector3(player_t.position.x + i, player_t.position.y + i, 0);
                    takaraPosSelect_s.takaraCreate(Pos);
                }
                
            }
            
        }
        
    }
}
