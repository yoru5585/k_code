using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowSlimeBall : MonoBehaviour
{
    float TimeCount = 0;
    float TimeInterval = 2;
    Transform PlayerPos;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount += Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, PlayerPos.position, 0.02f);

        if (TimeCount > TimeInterval)
        {
            Destroy(gameObject);
        }
    }


}
