using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed;
    public float startWaitTime;

    private int currentIndex;
    private float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = patrolPoints[0].position;
        transform.rotation = patrolPoints[0].rotation;
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentIndex].position, speed * Time.deltaTime);

        if (transform.position == patrolPoints[currentIndex].position)
        {
            //transform.rotation = patrolPoints[currentIndex].rotation;

            if (waitTime <= 0)
            {
                if (currentIndex + 1 < patrolPoints.Length)
                {
                    currentIndex++;
                }
                else
                {
                    currentIndex = 0;
                }
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else
        {
            transform.rotation = patrolPoints[currentIndex].rotation;
        }
    }
}
