using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFactory : MonoBehaviour
{
    [SerializeField] GameObject enemyBase;
    [SerializeField] private float count;
    [SerializeField] private int firstEnemyPopNum;
    private float coolingtime;

    private int enemyPopNum;
    private int i = 1;
    [SerializeField] int enemyPopSetNum;
    // Start is called before the first frame update
    void Start()
    {
        coolingtime = count;
        enemyPopNum = enemyPopSetNum;
        for (int i = 0; i < firstEnemyPopNum; i++)
        {
            Instantiate(enemyBase, new Vector3(Random.Range(-10f, 10), Random.Range(-10f, 10), 0), Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        coolingtime -= Time.deltaTime;
        if (coolingtime < 0)
        {
            while (i <= enemyPopNum)
            {
                //Debug.Log("¡‚Ìi‚Í"+i);
                i += 1;
                GameObject pre = (GameObject)Resources.Load("slime");
                Instantiate(pre, new Vector3(-8.4f, 3.0f, 0), Quaternion.identity);

                //Instantiate(pre, new Vector3(3.0f, 3.0f, 0), Quaternion.identity);
            }

            coolingtime = count;
            i = 0;

        }
    }
}
