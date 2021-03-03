using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Smallai : MonoBehaviour
{

    NavMeshAgent enemy;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
       // Chase Character
        enemy.SetDestination(target.position);
    }
}
