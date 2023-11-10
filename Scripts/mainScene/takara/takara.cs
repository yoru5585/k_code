using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takara : MonoBehaviour
{
    public bool takaraOpen_flag;

    GameObject managerObj;

    takara_open takara_opne_script;
    sound sound_script;
    item item_script;

    notDestroy nds;

    // Start is called before the first frame update
    void Start()
    {
        sound_script = managerObj.GetComponent<sound>();
        item_script = managerObj.GetComponent<item>();
        nds = GameObject.Find("dontDes").GetComponent<notDestroy>();
    }

    private void Awake()
    {
        managerObj = GameObject.FindGameObjectWithTag("manager");
        takara_opne_script = managerObj.GetComponent<takara_open>();
    }

    // Update is called once per frame
    void Update()
    {

        if (takaraOpen_flag)
        {
            if (Input.GetKeyDown("o")||nds.isEasyMode)
            {
                //プレイヤーが宝を開くタイミングで行わせたい命令をここに書く
                //Debug.Log("アイテムの内容はまだ");
                Vector3 t = gameObject.transform.parent.position;
                Debug.Log("q:" + t);
                item_script.itemLottery(t);
                takara_opne_script.onTakaraOpen(gameObject.transform.parent.gameObject);
                sound_script.soundEffect();
                


            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            takaraOpen_flag = true;

        }

        if (collision.gameObject.name == "wall" || collision.gameObject.name == "dragon" || collision.gameObject.name.Contains("tree"))
        {
            takara_opne_script.onTakaraOpen(this.gameObject.transform.parent.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            takaraOpen_flag = false;

        }
    }
}
