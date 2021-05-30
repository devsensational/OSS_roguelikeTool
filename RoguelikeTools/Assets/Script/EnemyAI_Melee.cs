using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_Melee : MonoBehaviour
{
    Rigidbody2D location;
    Transform target;

    public float moveSpeed = 1f;
    public float contactDistance = 1f;

    bool isFollow = false;

    void Start()
    {
        location = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        followTarget();
    }

    void followTarget()
    {
        if(Vector2.Distance(transform.position, target.position) > contactDistance && isFollow)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            location.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isFollow = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isFollow = false;
    }

}
