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

    // �ʒu���W
    private Vector3 position;
    // �X�N���[�����W�����[���h���W�ɕϊ������ʒu���W
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
        // Z���C��
        position.z = 10f;
        // �}�E�X�ʒu���W���X�N���[�����W���烏�[���h���W�ɕϊ�����
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        // ���[���h���W�ɕϊ����ꂽ�}�E�X���W����
        pointer.transform.position = screenToWorldPointPosition;

        if (Input.GetMouseButtonDown(0))
        {
            //���e�I���Ƃ�
            meteoDrop();
            Debug.Log("���e�I���Ƃ���");
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
