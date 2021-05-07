using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager_BSP : MonoBehaviour
{
    [SerializeField]
    public GameObject floor;

    public int setWidth , setHeight;
    public int setMax;

    void Start()
    {
        Debug.Log("start");
        RoomNode root = new RoomNode(0, 0, setWidth, setHeight, 0, setMax, null);
        Debug.Log("asd");
        makeMap(root);
    }

    void Update()
    {
        
    }

    void makeMap(RoomNode root)
    {
        RoomNode ptr = root;
        GameObject roomFloor = Instantiate(floor);

        float floorSize = floor.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        roomFloor.transform.position = new Vector3(ptr.getX(), ptr.getY(), 0);
        while(ptr.getLeftNode() != null)
        {
            ptr = ptr.getLeftNode();
            for (int i = ptr.getX(); i <= ptr.getWidth() + ptr.getX(); i++)
            {
                for (int j = ptr.getY(); j <= ptr.getHeight() + ptr.getY(); j++)
                {
                    GameObject leftRoomFloor = Instantiate(floor);
                    leftRoomFloor.transform.position = new Vector3(floorSize * i, floorSize * j, 0);
                    leftRoomFloor.name = ptr.getIndex() + "번 노드(왼쪽)";
                }
            }
            //leftRoomFloor.transform.position = new Vector3(floorSize * ptr.getX(), floorSize * ptr.getY(), 0);
            //leftRoomFloor.transform.localScale = new Vector3(floorSize * ptr.getWidth(), floorSize * ptr.getHeight(), 0);
            Debug.Log("L index = " + ptr.getIndex() + " x = " + ptr.getX() + " y = " + ptr.getY());
        }
        
        ptr = root;
        while (ptr.getRightNode() != null)
        {
            ptr = ptr.getRightNode();
            for (int i = ptr.getX(); i <= ptr.getWidth() + ptr.getX(); i++)
            {
                for (int j = ptr.getY(); j <= ptr.getHeight() + ptr.getY(); j++)
                {
                    GameObject rightRoomFloor = Instantiate(floor);
                    rightRoomFloor.transform.position = new Vector3(floorSize * i, floorSize * j, 0);
                    rightRoomFloor.name = ptr.getIndex() + "번 노드(오른쪽)";
                }
            }

            //rightRoomFloor.transform.position = new Vector3(ptr.getX(), ptr.getY(), 0);
            //rightRoomFloor.transform.localScale = new Vector3(ptr.getWidth(), ptr.getHeight(), 0);
            Debug.Log("R index = " + ptr.getIndex() + " x = " + ptr.getX() + " y = " + ptr.getY());
            Debug.Log("오른쪽 노드 오브젝트 생성됨");
        }
        
    }
}

class RoomNode
{
    RoomNode leftNode;
    RoomNode rightNode;
    RoomNode parentNode;

    RoomNode test;


    int x, y;
    int width, height;
    int index;
    int setMax;



    public RoomNode(int x, int y, int width, int height, int index, int setMax, RoomNode parentNode)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        this.parentNode = parentNode;
        this.index = index;
        this.setMax = setMax;

        this.index++;
        searchNode();
        if (this.index < this.setMax) { 
            makeNode();
        }
    }

    void makeNode()
    {
        int randomNum = Random.Range(3, 8);

        if (index % 2 == 1)
        {
            Debug.Log("세로 노드 생성");
            int leftWidth = (int)(width * (randomNum * 0.1f));
            int rightWidth = width - leftWidth;
            leftNode = new RoomNode(x, y, leftWidth, height, index, setMax, this);
            rightNode = new RoomNode(x + leftWidth, y, rightWidth, height, index, setMax, this);
            if (leftNode != null)
            {
                Debug.Log("세로 왼쪽노드 생성");
            }
            if(rightNode != null)
            {
                Debug.Log("세로 오른쪽노드 생성");
            }

        }
        else
        {
            Debug.Log("가로노드 생성");
            int leftHeight = (int)(height * (randomNum * 0.1f));
            int rightHeight = height - leftHeight;
            leftNode = new RoomNode(x, y, width, leftHeight, index, setMax, this);
            rightNode = new RoomNode(x, y + leftHeight, width, rightHeight, index, setMax, this); 
            if (leftNode != null)
            {
                Debug.Log("가로 왼쪽노드 생성");
            }
            else if (rightNode != null)
            {
                Debug.Log("가로 오른쪽노드 생성");
            }
        }
    
    }

    void searchNode()
    {

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
    public int getIndex()
    {
        return index;
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
