using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    GameObject[] waypoint;
    NavMeshAgent enemy;
    public Transform target;
    int currentWP;
    // Set default mode to patrol
    private Mode mode = Mode.patrol;


    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
       // Find all the waypoints
        waypoint = GameObject.FindGameObjectsWithTag("Waypoint");
       // Initial waypoint set to 0
        currentWP = 0;
    }

    // Update is called once per frame
    void Update()
    {
      switch (mode)
        {
            case Mode.patrol:
                patroling();
             if (Vector3.Distance(target.position, transform.position) < 20f)
                {
                    mode = Mode.attack;
                }
                break;
            case Mode.attack:
                attack();
                if (Vector3.Distance(target.position, transform.position) > 20f)
                {
                    mode = Mode.patrol;
                }
                break;

            default:
                break;
        }
    }

    private void patroling()
    {
        if (Vector3.Distance(waypoint[currentWP].transform.position,
            enemy.transform.position) < 3f)
        {
            currentWP++;
            if (currentWP >= waypoint.Length)
            {
                currentWP = 0;
            }
        }
        enemy.SetDestination(waypoint[currentWP].transform.position);
    }

    private void attack()
    {
        enemy.SetDestination(target.position);
    }

    public enum Mode
    {
        patrol,
        attack
    }

}
