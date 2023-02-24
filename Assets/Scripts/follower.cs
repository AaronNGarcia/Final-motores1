using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class follower : MonoBehaviour
{

    public Transform taget;
    private NavMeshAgent agent;
    public bool stuned;
    private float temporizador;
    public float stunDuration;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 3.2f;
        stuned = false;
    }

    // Update is called once per frame
    void Update()
    {


        agent.destination = taget.position;

        if (stuned == true)
        {
            agent.speed = 0f;
            temporizador += Time.deltaTime;
            if (temporizador > stunDuration)
            {
                stuned = false;
                temporizador = 0;
                agent.speed = 3.2f;
            }
        }
    }
}
