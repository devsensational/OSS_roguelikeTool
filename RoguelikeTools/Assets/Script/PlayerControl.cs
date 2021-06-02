using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float moveSpeed = 1f;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Chara Move
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveCheck(0);
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveCheck(1);
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveCheck(2);
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveCheck(3);
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        
        //DashKey = LShift
        if (Input.GetButtonDown("Dash"))
        {
            moveSpeed = 2f;
        }
        if (Input.GetButtonUp("Dash"))
        {
            moveSpeed = 1f;
        }

        //Fire1 Key = LCtrl
        if (Input.GetButtonDown("Fire1")){
            anim.SetBool("isAttack", true);

        }
        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("isAttack", false);

        }
    }

    void moveCheck(int directionNum)
    { // UP = 0, DOWN = 1, LEFT = 2, RIGHT = 3
        if(directionNum == 0) //UP
        {
            anim.SetBool("isUp", true);
            anim.SetBool("isDown", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
        }
        else if(directionNum == 1) //DOWN
        {
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", true);
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
        }
        else if (directionNum == 2) //LEFT
        {
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", false);
            anim.SetBool("isLeft", true);
            anim.SetBool("isRight", false);
        }
        else if (directionNum == 3) //RIGHT
        {
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", true);
        }
    }
}
