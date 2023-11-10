using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

public class item : MonoBehaviour
{
    [SerializeField]
    GameObject armerImageObj;
    [SerializeField]
    GameObject speedImageObj;
    [SerializeField]
    GameObject foodAnimationObj;
    [SerializeField]
    GameObject itemGaugeObj;

    Sprite[] foodsImageData;
    Sprite[] itemsImageData;
    Sprite[] friendskillImageData;

    Queue itemStock = new Queue();

    Vector3 foodPos;

    valueManagerScript vms;
    notDestroy notDestroyScript;

    public bool IsStage4;
    public bool flag;

    //アイテムスロットをつくる。そこから溢れたアイテムはスカ。
    //キューで実装？

    // Start is called before the first frame update
    void Start()
    {
        foodsImageData = Resources.LoadAll<Sprite>("foods/");
        itemsImageData = Resources.LoadAll<Sprite>("itemStock/");
        friendskillImageData = Resources.LoadAll<Sprite>("friendskill/");
        notDestroyScript = GameObject.Find("dontDes").GetComponent<notDestroy>();
        vms = GetComponent<valueManagerScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void itemLottery(Vector3 obj)
    {
        int random = Random.Range(0, 6);
        if (IsStage4)
        {
            random = Random.Range(0, 5);
        }
        //int random = 4;

        if (random == 0)
        {
            //ストック対象
            itemQueEnqueue(random);

            
        }
        else if (random == 1)
        {
            //ストック対象
            if (IsStage4)
            {
                itemQueEnqueue(2);
            }
            else
            {
                if (flag) { itemQueEnqueue(0); return; }
                itemQueEnqueue(random);
            }


        }
        else if (random == 2)
        {
            //ストック対象
            itemQueEnqueue(random);
            
        }
        else if (random == 3)
        {
            if (vms.HP_value <= vms.HP_max)
            {
                vms.HP_value += 100;
            }
            
            //Debug.Log("food");
            //Debug.Log(vms.HP_value);
            foodPos = obj;
            foodSelect();
            
        }
        else if (random == 4)
        {
            if (IsStage4)
            {
                GetComponent<stage4Manager>().WhistleNum++;
                GameObject.Find("hues").transform.GetChild(GetComponent<stage4Manager>().WhistleNum).gameObject.GetComponent<Image>().enabled = true;
                return;
            }

            if (GameObject.Find("santa") == null)
            {
                vms.deathblow_value -= 1;
                return;
            }

            GameObject.Find("santa").GetComponent<Image>().fillAmount += 0.2f;

            foodPos = obj;
            friendskillSelect();
            Debug.Log("kyara");
        }
        else if (random == 5)
        {
            vms.deathblow_value -= 1;
            Debug.Log("sukiru");
        }

    }

    void foodSelect()
    {
        int random = Random.Range(0, foodsImageData.Length);
        //int random = 0;

        var parent = foodAnimationObj.transform;
        //なぜかpositionが変わらない。アニメーションの相対座標の問題だった。解決
        GameObject pre = (GameObject)Resources.Load("foodAnimation");
        GameObject createObj = Instantiate(pre, foodPos, Quaternion.identity, parent);

        notDestroyScript.foodFoundList.Add(random);
        createObj.GetComponent<SpriteRenderer>().sprite = foodsImageData[random];
        

    }
    void friendskillSelect()
    {
        int random = Random.Range(0, friendskillImageData.Length);
        //int random = 0;

        var parent = foodAnimationObj.transform;
        GameObject pre = (GameObject)Resources.Load("foodAnimation");
        GameObject createObj = Instantiate(pre, foodPos, Quaternion.identity, parent);

        createObj.GetComponent<SpriteRenderer>().sprite = friendskillImageData[random];


    }

    void itemQueEnqueue(int inputItem)
    {
        if (itemStock.Count >= 3)
        {
            return;
        }

        itemStock.Enqueue(inputItem);
        itemDisplay();
    }

    int itemQueDequeue()
    {
        if (itemStock.Count <= 0)
        {
            Debug.Log("item_null");
            return 4;
        }

        int n = (int)itemStock.Dequeue();
        itemDisplay();
        return n;
    }

    public  void onItemStockUsed()
    {
        int tmp = itemQueDequeue();

        if (tmp == 0)
        {
            armerImageObj.SetActive(true);
            return;
        }

        if (tmp == 1)
        {
            GetComponent<meteoCreate>().enabled = true;
            Debug.Log("innseki");

            return;
        }

        if (tmp == 2)
        {
            speedImageObj.SetActive(true);
            return;
        }

    }

    void itemDisplay()
    {
        Debug.Log(itemStock.Count);

        
        for (int i = 0; i < itemGaugeObj.transform.childCount; i++)
        {
            itemGaugeObj.transform.GetChild(i).gameObject.GetComponent<Image>().color += new Color(0, 0, 0, -1f);
        }
        
        

        int tmp = 0;

        foreach (int i in itemStock)
        {
            //Debug.Log(i);
            Color tmp_c = itemGaugeObj.transform.GetChild(tmp).gameObject.GetComponent<Image>().color;
            itemGaugeObj.transform.GetChild(tmp).gameObject.GetComponent<Image>().color = new Color(tmp_c.r,tmp_c.g,tmp_c.b, 1);
            itemGaugeObj.transform.GetChild(tmp).gameObject.GetComponent<Image>().sprite = itemsImageData[i];
            tmp++;
        }
    }
}
