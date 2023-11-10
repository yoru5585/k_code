using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyTracking : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;

    GameObject playerObj;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        float now = Vector2.Distance(transform.position, playerObj.transform.position);
        if (distance < now)
        {
            agent.destination = playerObj.transform.position;
            Vector2? vector = new Vector2(
                agent.destination.x - transform.position.x,
                agent.destination.y - transform.position.y
            );

        }
    }
}
