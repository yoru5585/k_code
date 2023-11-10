using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class maxValueSetting : MonoBehaviour
{
    [SerializeField]
    GameObject HP_slider;

    valueManagerScript vms;

    // Start is called before the first frame update
    void Start()
    {
        vms = GetComponent<valueManagerScript>();

        HP_slider.GetComponent<Slider>().maxValue = vms.HP_value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
