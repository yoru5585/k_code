using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healing : MonoBehaviour
{
    valueManagerScript vms;
    bool isTouched;

    // Start is called before the first frame update
    void Start()
    {
        vms = GameObject.FindGameObjectWithTag("manager").GetComponent<valueManagerScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouched && vms.HP_value <= vms.HP_max)
        {
            vms.HP_value += 50 * Time.deltaTime;
            //Debug.Log("sas");
        }

        //Debug.Log(isTouched);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isTouched = true;
            GameObject.Find("dontDes").GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("sound/shinein"));
            //Debug.Log("sss");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isTouched = false;
        }
    }

}
