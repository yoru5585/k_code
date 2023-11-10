using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takara_open : MonoBehaviour
{
    [SerializeField]
    GameObject TakaraObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onTakaraOpen(GameObject Obj)
    {
        var parent = TakaraObj.transform;
        Vector3 Pos = Obj.gameObject.transform.position;
        GameObject pre = (GameObject)Resources.Load("takarabakohei");
        Instantiate(pre, Pos, Quaternion.identity, parent);

        Destroy(Obj);
    }
}
