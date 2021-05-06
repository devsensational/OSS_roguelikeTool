using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager_BSP : MonoBehaviour
{
    [SerializeField]
    public GameObject floor;

    int setWidth =10 , setHeight = 6;
    public int setMax;

    void Start()
    {
        Debug.Log("start");
        RoomNode root = new RoomNode(0, 0, setWidth, setHeight, 0, setMax, null, floor);
        Debug.Log("asd");
    }

    void Update()
    {
        
    }

}

class RoomNode : MonoBehaviour
{
    RoomNode leftNode;
    RoomNode rightNode;
    RoomNode parentNode;

    GameObject floor;

    int x, y;
    int width, height;
    int index;
    int setMax;


    
    public RoomNode(int x, int y, int width, int height, int index, int setMax, RoomNode parentNode, GameObject floor)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        this.parentNode = parentNode;
        this.index = index;
        this.setMax = setMax;

        Debug.Log("1");
        searchNode();
        makeNode();
        makeMap();
    }

    void makeNode()
    {
        int randomNum = Random.Range(3, 8);
        int leftWidth = (int)(width * (randomNum * 0.1f));
        int rightWidth = width - leftWidth;
        leftNode = new RoomNode(x, y, leftWidth, height, index++, setMax, this, floor);
        rightNode = new RoomNode(x + leftWidth, y, rightWidth, height, index++, setMax, this, floor);
        Debug.Log("2");
    }
    public void makeMap()
    {
        GameObject roomFloor = Instantiate(floor);
        roomFloor.transform.position = new Vector3(x, y, 0);
        roomFloor.transform.localScale = new Vector3(width, height, 0);
        Debug.Log("3");
    }

    void searchNode()
    {

        Debug.Log("4");
    }


    public int getX()
    {
        return x;
    }

    public int getY()
    {
        return y;
    }
    public int getWidth()
    {
        return width;
    }
    public int getHeight()
    {
        return height;
    }

    public RoomNode getLeftNode()
    {
        return leftNode;
    }

    public RoomNode getRightNode()
    {
        return rightNode;
    }

    public RoomNode getParentNode()
    {
        return parentNode;
    }

}
