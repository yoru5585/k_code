using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mermaidSkill : MonoBehaviour
{
    [SerializeField]
    Image mermaidImg;
    Transform player_t;

    // Start is called before the first frame update
    void Start()
    {
        mermaidImg.GetComponent<Image>().fillAmount = 0;
        player_t = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        mermaidImg.GetComponent<Image>().fillAmount += Time.deltaTime / 6;
        if (mermaidImg.GetComponent<Image>().fillAmount >= 1)
        {
            mermaidImg.GetComponent<Image>().fillAmount = 0;
            var parent = GameObject.Find("UI_Canvas").transform;
            GameObject pre = (GameObject)Resources.Load("mermaidCutIn");
            Instantiate(pre, new Vector3(740, 42, 0), Quaternion.identity, parent);
            pre = (GameObject)Resources.Load("MermaidAttack");
            Instantiate(pre, player_t);

        }
    }
}
