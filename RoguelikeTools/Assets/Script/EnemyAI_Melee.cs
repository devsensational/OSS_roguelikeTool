using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_Melee : MonoBehaviour
{
    GameObject bang;
    Rigidbody2D location;
    Transform target;

    public int hp;
    public int dmg;

    public float moveSpeed = 1f;
    public float contactDistance = 1f;

    bool isFollow = false;
    bool isFirst = true;

    void Start()
    {
        location = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    void Update()
    {
        if (isFirst && isFollow)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 255);
            Invoke("bangOff", 2f);
            isFirst = false;
        }
        Invoke("followTarget", 1f) ;
    }
    void bangOff()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0);
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


}
