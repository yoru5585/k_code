using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellowSlime : MonoBehaviour
{
    float TimeCount = 0;
    float TimeInterval = 5;

    GameObject playerObj;
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount += Time.deltaTime;
        if (TimeCount > TimeInterval)
        {
            TimeCount = 0;
            GameObject pre = Instantiate((GameObject)Resources.Load("YellowSlimeBall"));
            pre.transform.position = transform.position;
        }
        
    }
}
