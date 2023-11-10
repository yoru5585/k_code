using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaManager : MonoBehaviour
{
    [SerializeField]
    GameObject messageObj;
    GameObject [] SeaSlimes;
    // Start is called before the first frame update
    void Start()
    {
        SeaSlimes = GameObject.FindGameObjectsWithTag("seaEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < SeaSlimes.Length; i++)
        {
            if (SeaSlimes[i] != null)
            {
                return;
            }
        }

        GetComponent<enemyFactory>().enabled = false;
        GetComponent<player>().canMove = false;
        GetComponent<santaSkill>().enabled = false;
        GetComponent<mermaidSkill>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GameObject.Find("BGM").GetComponent<AudioSource>().Stop();
        notDestroy nds = GameObject.Find("dontDes").GetComponent<notDestroy>();
        nds.shareExp = GetComponent<valueManagerScript>().nowLevel;
        nds.shareAP = GetComponent<valueManagerScript>().playerMainWeaponAP;
        nds.isStageCleared[3] = true;
        messageObj.SetActive(true);
        messageObj.transform.GetChild(0).gameObject.GetComponent<SeaSecondMessage>().enabled = true;
        if (GameObject.Find("playerColl") != null)
        {
            GameObject.Find("playerColl").gameObject.SetActive(false);

        }
        GetComponent<SeaManager>().enabled = false;
    }


}
