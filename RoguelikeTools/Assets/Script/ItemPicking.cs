using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicking : MonoBehaviour
{

    public GameObject eventSystem;
    public GameObject thisAt;

    public ItemList itemList;

    // Start is called before the first frame update
    void Start()
    {
        itemList = eventSystem.GetComponent<ItemList>();
        thisAt = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(itemList.Item_break == true){
            itemList.Item_break = false;
            itemList.dropItem.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            itemList.dropItem = thisAt;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        itemList.dropItem = null;
    }
}
