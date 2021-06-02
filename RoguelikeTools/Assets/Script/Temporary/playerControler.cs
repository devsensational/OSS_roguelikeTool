using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    public float moveSpeed = 1f;
    //이동속도


    Rigidbody2D rigid;

    Vector3 movement;

    public ItemList itemList;

    public bool item_pickupReady = false;

    public GameObject eventSystem;
    public GameObject gameObject_1;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        itemList = eventSystem.GetComponent<ItemList>();
    }

    // Update is called once per frame
    void Update()
    {
        if(item_pickupReady == true){
            itemList.ItemPickUpReady = true;
        }
        if(item_pickupReady == false){
            itemList.ItemPickUpReady = false;
        }
    }

    void FixedUpdate() {
        Move();   
    }

    void Move(){
        Vector3 moveVelocity = Vector3.zero;

        if(Input.GetAxisRaw("Horizontal") < 0){
            moveVelocity = Vector3.left;
        }
        else if(Input.GetAxisRaw("Horizontal") > 0){
            moveVelocity = Vector3.right;
        }

        if(Input.GetAxisRaw("Vertical") < 0){
            moveVelocity = Vector3.down;
        }
        else if(Input.GetAxisRaw("Vertical") > 0){
            moveVelocity = Vector3.up;
        }

        transform.position += moveVelocity*moveSpeed*Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "DropItem"){
            item_pickupReady = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "DropItem"){
            item_pickupReady = false;
        }
    }
}
