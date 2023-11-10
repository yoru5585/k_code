using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takaraPosSelect : MonoBehaviour
{
    [SerializeField]
    int takaraCreateNum;
    [SerializeField]
    GameObject TakaraObj;

    [SerializeField]
    float timeInterval;
    float timeCount;

    [SerializeField]
    int size_x;
    [SerializeField]
    int size_y;

    [SerializeField]
    bool Seaflag;
    [SerializeField]
    float FixSize_x;
    [SerializeField]
    float FixSize_y;
    // Start is called before the first frame update
    void Start()
    {
        if (Seaflag)
        {
            for (int i = 0; i < takaraCreateNum; i++)
            {
                var parent = TakaraObj.transform;
                GameObject pre = (GameObject)Resources.Load("takarabakokai");
                Instantiate(pre, new Vector3(FixSize_x,FixSize_y,0), Quaternion.identity, parent);
                Instantiate(pre, new Vector3(-FixSize_x, FixSize_y, 0), Quaternion.identity, parent);
                Instantiate(pre, new Vector3(FixSize_x, -FixSize_y, 0), Quaternion.identity, parent);
                Instantiate(pre, new Vector3(-FixSize_x, -FixSize_y, 0), Quaternion.identity, parent);
            }
        }
        else
        {
            for (int i = 0; i < takaraCreateNum; i++)
            {
                var parent = TakaraObj.transform;
                //ランダムpos
                Vector3 Pos = new Vector3(Random.Range(-size_x, size_x), Random.Range(-size_y, size_y), 0);
                GameObject pre = (GameObject)Resources.Load("takarabakokai");
                Instantiate(pre, Pos, Quaternion.identity, parent);
            }

        }
        

        timeCount = timeInterval;
    }
    //フライウェイトパターン

    // Update is called once per frame
    void Update()
    {
        if (TakaraObj.transform.childCount > 4)
        {
            return;
        }


        timeCount -= Time.deltaTime;
        if (timeCount < 0)
        {
            timeCount = timeInterval;
            //ここに出現させたいオブジェクト
            if (Seaflag)
            {
                
                for (int i = 0; i < takaraCreateNum; i++)
                {
                    takaraCreate(new Vector3(FixSize_x, FixSize_y, 0));
                    takaraCreate(new Vector3(-FixSize_x, FixSize_y, 0));
                    takaraCreate(new Vector3(FixSize_x, -FixSize_y, 0));
                    takaraCreate(new Vector3(-FixSize_x, -FixSize_y, 0));

                }
                
            }
            else
            {
                for (int i = 0; i < takaraCreateNum; i++)
                {
                    Vector3 Pos = new Vector3(Random.Range(-size_x, size_x), Random.Range(-size_y, size_y), 0);
                    takaraCreate(Pos);

                }
            }
        }
    }

    public void takaraCreate(Vector3 Pos)
    {
        var parent = TakaraObj.transform;
        GameObject pre = (GameObject)Resources.Load("takarabakokai");
        Instantiate(pre, Pos, Quaternion.identity, parent);
    }
}
