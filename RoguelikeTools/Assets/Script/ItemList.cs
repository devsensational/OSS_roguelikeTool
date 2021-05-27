using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    public GameObject[] item_hold = new GameObject[3];

    public bool ItemPickUpReady = false;

    public bool Items_1 = false;
    public bool Items_2 = false;
    public bool Items_3 = false;
    public bool Item_break = false;

    public GameObject dropItem;
    public GameObject tempStorage;

    int SendNumber = 0;

    public GameObject Player;
    public playerControler PlayerControler;



    
    // Start is called before the first frame update
    void Start()
    { 
        PlayerControler = Player.GetComponent<playerControler>();
    }

    // Update is called once per frame
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            if(item_hold[0] == null && ItemPickUpReady == true){
                item_hold[0] = dropItem;
                Items_1 = true;
                ItemPickUpReady = false;
                Item_break = true;
            }
            else if(item_hold[0] != null && ItemPickUpReady == false){
                UseItem(0);
                Items_1 = false;
            }
            else if(item_hold[0] != null && ItemPickUpReady == true){
                Swapping(0);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            if(item_hold[1] == null && ItemPickUpReady == true){
                item_hold[1] = dropItem;
                Items_2 = true;
                ItemPickUpReady = false;
                Item_break = true;
            }
            else if(item_hold[1] != null && ItemPickUpReady == false){
                UseItem(1);
                Items_2 = false;
            }
            else if(item_hold[1] != null && ItemPickUpReady == true){
                Swapping(1);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            if(item_hold[2] == null && ItemPickUpReady == true){
                item_hold[2] = dropItem;
                Items_3 = true;
                ItemPickUpReady = false;
                Item_break = true;
            }
            else if(item_hold[2] != null && ItemPickUpReady == false){
                UseItem(2);
                Items_3 = false;
            }
            else if(item_hold[2] != null && ItemPickUpReady == true){
                Swapping(2);
            }
        }
    }

    public void UseItem(int i){
        if(item_hold[i].name == "HP_Potion"){
            Debug.Log("체력이 회복되었습니다.");
        }
        if(item_hold[i].name == "MP_Potion"){
            Debug.Log("마력이 회복되었습니다.");
        }
        if(item_hold[i].name == "3"){
            Debug.Log("????????????");
        }
        if(item_hold[i].name == "4"){
            Debug.Log("????????????");
        }
        if(item_hold[i].name == "5"){
            Debug.Log("????????????");
        }
        if(item_hold[i].name == "6"){
            Debug.Log("????????????");
        }
        if(item_hold[i].name == "7"){
            Debug.Log("????????????");
        }
        if(item_hold[i].name == "8"){
            Debug.Log("????????????");
        }
        if(item_hold[i].name == "9"){
            Debug.Log("????????????");
        }
        if(item_hold[i].name == "10"){
            Debug.Log("????????????");
        }

        item_hold[i] = null;
        i = -1;
        //i로 몇 번째 스토리지에 있는지 확인하고 그 스토리지에 있는 아이템을 사용함. 그 후 그 스토리지의 물건을 삭제함.
    }

    public void Swapping(int j){
        tempStorage = dropItem;
        //임시저장소에 드랍아이템을 넣고
        dropItem = item_hold[j];
        //드랍아이템에 가지고 있던 아이템을 내려놓고
        item_hold[j] = tempStorage;
        //빈 아이템칸에 임시저장소에 넣어둔 아이템을 넣는다.
        tempStorage = null;
        //임시저장소를 비운다.
        j = 0;
        Debug.Log("Changed");
    }
}
