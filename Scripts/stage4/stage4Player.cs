using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage4Player : MonoBehaviour
{
    valueManagerScript vms;
    bool IsAttacked;
    // Start is called before the first frame update
    void Start()
    {
        vms = GameObject.FindGameObjectWithTag("manager").GetComponent<valueManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAttacked)
        {
            vms.HP_value -= 500 * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Weap"))
        {
            IsAttacked = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Weap"))
        {
            IsAttacked = false;
        }
    }
}
