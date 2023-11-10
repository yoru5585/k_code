using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragon : MonoBehaviour
{
    float TimeCount = 0;
    float TimeInterval = 1;
    bool flag = true;
    float MeteoPos_x, MeteoPos_y;
    int MeteoCount;
    int OtherCount;
    GameObject dragonObj;
    // Start is called before the first frame update
    void Start()
    {
        dragonObj = GameObject.Find("dragon");
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount += Time.deltaTime;

        if (TimeCount > TimeInterval)
        {
            TimeCount = 0;
            if (flag)
            {
                if (OtherCount >= 6)
                {
                    flag = false;
                    TimeInterval = 2;
                    OtherCount = 0;
                    return;
                }

                OtherCount++;
                Instantiate((GameObject)Resources.Load("fire_circle"), new Vector3(Random.Range(-8, 8), Random.Range(-10, 10), 0) , Quaternion.identity);
                Instantiate((GameObject)Resources.Load("DragonFire Variant"), new Vector3(Random.Range(-8, 8), Random.Range(-10, 10), 0), Quaternion.identity);
                GameObject.Find("dontDes").GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("sound/fire"));
            }
            else
            {
                if (MeteoCount >= 6)
                {
                    TimeInterval = 1;
                    MeteoCount = 0;
                    flag = true;
                    return;
                }

                MeteoPos_x = Random.Range(-8, 8);
                MeteoPos_y = Random.Range(-10, 10);
                Instantiate((GameObject)Resources.Load("meteo_coll"), new Vector3(MeteoPos_x, MeteoPos_y, 0), Quaternion.identity);
                MeteoCount++;
            }
            
        }
    }
}
