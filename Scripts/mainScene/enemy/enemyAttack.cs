using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    [SerializeField]
    float myAP;

    valueManagerScript vms;
    GameObject playerObj;

    bool isAttacked;

    // Start is called before the first frame update
    void Start()
    {
        vms = GameObject.FindGameObjectWithTag("manager").GetComponent<valueManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacked)
        {
            if (gameObject.tag.Contains("sea"))
            {
                vms.HP_value -= myAP * 2 * Time.deltaTime;
            }
            else if(gameObject.tag.Contains("snow"))
            {
                vms.HP_value -= myAP * Time.deltaTime / 2;
            }
            else
            {
                vms.HP_value -= myAP * Time.deltaTime;
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerColl")
        {
            isAttacked = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerColl")
        {
            isAttacked = false;
        }
    }
}
