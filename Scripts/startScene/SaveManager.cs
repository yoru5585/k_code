using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    string filePath;
    SaveData save;
    notDestroy nd;
    //多分リスト保存できない
    //やるならstringにしてデータ小さくするしかない

    void Awake()
    {
        filePath = Application.persistentDataPath + "/" + ".savedata.json";
        Debug.Log(filePath);
        save = new SaveData();
    }

    void Start()
    {
        nd = GameObject.Find("dontDes").GetComponent<notDestroy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        GetData();
        string json = JsonUtility.ToJson(save);
        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(json); streamWriter.Flush();
        streamWriter.Close();
        
        Debug.Log("セーブしました。");
    }

    public void Load()
    {
        if (File.Exists(filePath))
        {
            StreamReader streamReader;
            streamReader = new StreamReader(filePath);
            string data = streamReader.ReadToEnd();
            streamReader.Close();
            save = JsonUtility.FromJson<SaveData>(data);

            SetData();
            Debug.Log("ロードしました。");
            return;
        }

        Debug.Log("データがないのでロードできませんでした。");
    }

    public void GetData()
    {
        save.save_isStageCleared_0 = nd.isStageCleared[0];
        save.save_isStageCleared_1 = nd.isStageCleared[1];
        save.save_isStageCleared_2 = nd.isStageCleared[2];
        save.save_isStageCleared_3 = nd.isStageCleared[3];
        save.save_isStageCleared_4 = nd.isStageCleared[4];
        save.save_isStageCleared_5 = nd.isStageCleared[5];
        save.save_isStageCleared_6 = nd.isStageCleared[6];
        save.save_shareAP = nd.shareAP;
        save.save_shareExp = nd.shareExp;
        Debug.Log(save.save_shareExp);
    }

    public void SetData()
    {
        nd.isStageCleared[0] = save.save_isStageCleared_0;
        nd.isStageCleared[1] = save.save_isStageCleared_1;
        nd.isStageCleared[2] = save.save_isStageCleared_2;
        nd.isStageCleared[3] = save.save_isStageCleared_3;
        nd.isStageCleared[4] = save.save_isStageCleared_4;
        nd.isStageCleared[5] = save.save_isStageCleared_5;
        nd.isStageCleared[6] = save.save_isStageCleared_6;
        nd.shareAP = save.save_shareAP;
        nd.shareExp = save.save_shareExp;
    }
}
