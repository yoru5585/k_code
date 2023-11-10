using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermaidAttack : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(1.5f, 1.5f , 0) * Time.deltaTime;
        if (transform.localScale.x > 4)
        {
            Destroy(gameObject);
        }
    }
}
