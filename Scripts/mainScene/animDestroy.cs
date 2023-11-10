using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void animDes()
    {
        Destroy(this.gameObject);
    }

    void animfade()
    {
        GetComponent<Image>().color -= new Color(0,0,0,0.8f);
    }

    void meteoSound()
    {
        GameObject.Find("dontDes").GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("sound/inseki"));
    }
}
