using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHP : MonoBehaviour
{
    [SerializeField]
    float myEnemyHP;
    float mainAP;

    bool isAttacked_main = false;
    bool isAttacked_meteo = false;
    bool isAttacked_deathblow = false;
    bool isAttacked_mermaid = false;
    bool isAttacked_ice = false;
    Slider mySlider;

    valueManagerScript valueManagerScript_s;
    Transform playerTrans;
    

    // Start is called before the first frame update
    void Start()
    {
        mySlider = transform.Find("Canvas/Slider").gameObject.GetComponent<Slider>();
        valueManagerScript_s = GameObject.FindGameObjectWithTag("manager").GetComponent<valueManagerScript>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;

        mySlider.maxValue = myEnemyHP;
        mySlider.value = mySlider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        //ダメージを受けたらHP表示
        //bool

        mySlider.value = myEnemyHP;

        if (isAttacked_main)
        {
            //nockback();
            isAttacked_main = false;

            mainAP = valueManagerScript_s.playerMainWeaponAP;
            myEnemyHP -= mainAP;

            Debug.Log(myEnemyHP);

        }

        if (isAttacked_meteo)
        {
            isAttacked_meteo = false;

            //nockback(1.2f);
            if (myEnemyHP -150 <= 0)
            {
                myEnemyHP = 1;
            }
            else
            {
                myEnemyHP -= 150;
            }
            

            Debug.Log("メテオ当たった");

        }

        if (isAttacked_deathblow)
        {
            isAttacked_deathblow = false;

            //nockback(1.5f);
            if (this.gameObject.tag.Contains("snow"))
            {
                myEnemyHP -= (valueManagerScript_s.playerMainWeaponAP * 10);

            }
            else
            {
                myEnemyHP -= (valueManagerScript_s.playerMainWeaponAP * 1.2f);
            }
            
        }

        if (isAttacked_mermaid)
        {
            isAttacked_mermaid = false;
            if (this.gameObject.tag.Contains("fire"))
            {
                myEnemyHP -= (valueManagerScript_s.playerMainWeaponAP * 10);

            }
            else
            {
                myEnemyHP -= (valueManagerScript_s.playerMainWeaponAP * 1.2f);
            }
        }

        if (isAttacked_ice)
        {
            isAttacked_ice = false;
            if (this.gameObject.tag.Contains("sea"))
            {
                myEnemyHP -= (valueManagerScript_s.playerMainWeaponAP * 10);

            }
            else
            {
                myEnemyHP -= (valueManagerScript_s.playerMainWeaponAP * 1.2f);
            }
        }

        if (myEnemyHP <= 0)
        {
            valueManagerScript_s.expIncrease();
            valueManagerScript_s.killNum++;
            Destroy(this.gameObject);
            
        }

        //GetComponent<Rigidbody2D>().velocity *= 0.001f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //武器の種類（手持ち、メテオ、炎）に応じてタグ分けする
        //仲介役となるスプライトに現在の主人公の武器のダメージ量を取得させ、それをここでget
        //メテオ、炎はダメージ固定だから取得する必要ないかもね。

        if (gameObject.name == "dragon")
        {
            if (collision.gameObject.tag == "mainWeap")
            {
                isAttacked_main = true;
                return;
            }
        }

        switch (collision.gameObject.tag)
        {
            case "mainWeap":
                isAttacked_main = true;
                break;
            case "meteoWeap":
                isAttacked_meteo = true;
                break;
            case "deathblowWeap":
                isAttacked_deathblow = true;
                break;
            case "MermaidWeap":
                isAttacked_mermaid = true;
                break;
            case "iceWeap":
                isAttacked_ice = true;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "mainWeap":
                isAttacked_main = false;
                break;
            case "meteoWeap":
                isAttacked_meteo = false;
                break;
            case "deathblowWeap":
                isAttacked_deathblow = false;
                break;
            case "MermaidWeap":
                isAttacked_mermaid = false;
                break;
            case "iceWeap":
                isAttacked_ice = false;
                break;

        }

    }

    void nockback(float mag = 1)
    {
        Vector3 dir = (playerTrans.position - this.transform.position);

        GetComponent<Rigidbody2D>().AddForce(-dir * mag, ForceMode2D.Impulse);
        //GetComponent<SpriteRenderer>().color = new Color(0.8f,0,0);
    }

    public float getMyEnemyHP()
    {
        return myEnemyHP;
    }

    public void setMyEnemyHP(float i)
    {
        myEnemyHP = i;
        mySlider.maxValue = myEnemyHP;
        mySlider.value = mySlider.maxValue;
    }
}
