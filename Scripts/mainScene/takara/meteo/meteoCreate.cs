using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteoCreate : MonoBehaviour
{

    [SerializeField]
    GameObject pointer;

    [SerializeField]
    GameObject meteoManager;

    notDestroy nds;

    // 位置座標
    private Vector3 position;
    // スクリーン座標をワールド座標に変換した位置座標
    private Vector3 screenToWorldPointPosition;

    // Start is called before the first frame update
    void Start()
    {
        nds = GameObject.Find("dontDes").GetComponent<notDestroy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nds.isEasyMode)
        {
            position = Vector3.zero;
            meteoDrop();
            this.enabled = false;
            return;
        }

        pointer.SetActive(true);

        position = Input.mousePosition;
        // Z軸修正
        position.z = 10f;
        // マウス位置座標をスクリーン座標からワールド座標に変換する
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        // ワールド座標に変換されたマウス座標を代入
        pointer.transform.position = screenToWorldPointPosition;

        if (Input.GetMouseButtonDown(0))
        {
            //メテオ落とす
            meteoDrop();
            Debug.Log("メテオ落とした");
            this.enabled = false;
            pointer.SetActive(false);
        }
    }

    void meteoDrop()
    {
        var parent = meteoManager.transform;
        Vector3 meteoPos = pointer.transform.position;
        GameObject pre = (GameObject)Resources.Load("meteo_coll");
        GameObject createObj = Instantiate(pre, meteoPos, Quaternion.identity, parent);
    }
}
