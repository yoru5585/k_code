using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    [SerializeField]
    GameObject soundObj;
    AudioSource soundclip;
    // Start is called before the first frame update
    void Start()
    {
        soundclip = soundObj.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void soundEffect()
    {
        soundclip.Play();

    }
}
