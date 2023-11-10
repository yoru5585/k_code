using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penguin : MonoBehaviour
{
    float speed;
    public Transform start;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.05f;
        target.transform.position = new Vector3(31.4f,-11.8f,0);
        start.transform.position = new Vector3(-17.2f, -5.5f, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
        if (transform.position == target.position)
        {
            transform.position = start.position;
            
        }

    }
}
