using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tonakai_iceManager : MonoBehaviour
{
    float timeInterval = 2;
    float timeCount;
    public bool isAttack;

    GameObject tonakai_iceObj;
    // Start is called before the first frame update
    void Start()
    {
        isAttack = false;
        timeCount = timeInterval;
        tonakai_iceObj = new GameObject("tonakai_iceBase");

    }

    // Update is called once per frame
    void Update()
    {
        if (isAttack == false)
        {
            return;
        }

        timeCount -= Time.deltaTime;
        if (timeCount < 0)
        {
            timeCount = timeInterval;

            var parent = tonakai_iceObj.transform;
            Vector3 Pos = new Vector3(Random.Range(-6, 6), Random.Range(-5, 7), 0);


            GameObject pre = (GameObject)Resources.Load("tonakai_ice");
            Instantiate(pre, Pos, Quaternion.identity, parent);
        }
    }
}
