using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class notDestroy : MonoBehaviour
{
    public List<int> foodFoundList;

    public List<int> DiaryFoundList;

    public int shareExp;
    public float shareAP;

    public bool[] isStageCleared;

    public bool isEasyMode = true;
    PointerEventData pointer;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        pointer = new PointerEventData(EventSystem.current);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            List<RaycastResult> results = new List<RaycastResult>();
            pointer.position = Input.mousePosition;
            EventSystem.current.RaycastAll(pointer, results);
            foreach (RaycastResult target in results)
            {
                if (target.gameObject.tag == "button")
                {
                    GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("sound/button"));
                }
            }
        }

    }

    private void Awake()
    {
        int max = PlayerPrefs.GetInt("listMax");

        for (int i = 0; i < max; i++)
        {
            DiaryFoundList.Add(PlayerPrefs.GetInt(i.ToString()));
        }

    }
}
