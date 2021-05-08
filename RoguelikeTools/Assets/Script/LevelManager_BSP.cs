using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager_BSP : MonoBehaviour
{
    [SerializeField]
    public GameObject floor;

    public int setWidth, setHeight;
    public int setMax;

    void Start()
    {
        Debug.Log("start");
        RoomNode root = new RoomNode(0, 0, setWidth, setHeight, 0, setMax, null);
        makeMap(root, "root");


    }

    void Update()
    {

    }
    void searchRoom()
    {

    }

    void makeMap(RoomNode ptr, string whereIs)
    {
        if (ptr != null)
        {
            makeMap(ptr.getLeftNode(), "left");
            makeMap(ptr.getRightNode(), "right");
            
        }else if(ptr == null)
        {
            return;
        }

        if (ptr.getLeftNode() == null && ptr.getRightNode() == null)
        {
            float floorSize = floor.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
            for (int i = ptr.getX(); i <= ptr.getWidth() + ptr.getX() -2 ; i++)
            {
                for (int j = ptr.getY(); j <= ptr.getHeight() + ptr.getY() -2 ; j++)
                {
                    GameObject RoomFloor = Instantiate(floor);
                    RoomFloor.transform.position = new Vector3(floorSize * i , floorSize * j , 0);
                    RoomFloor.name = ptr.getIndex() + "번 노드 " + whereIs;
                }
            }
        }
    }
    
    void makeHallway(RoomNode ptr)
    {
        if(ptr != null)
        {
            ptr.getLeftNode().getX();
        }

    }
}

class RoomNode
{
    RoomNode leftNode;
    RoomNode rightNode;
    RoomNode parentNode;

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
        if(this.parentNode != null)
        {
            searchNode(this.parentNode);
        }
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
            if (leftWidth > 4 && rightWidth > 4)
            {
                leftNode = new RoomNode(x, y, leftWidth, height, index, setMax, this);
                rightNode = new RoomNode(x + leftWidth, y, rightWidth, height, index, setMax, this);
            }
        }
        else
        {
            Debug.Log("가로노드 생성");
            int leftHeight = (int)(height * (randomNum * 0.1f));
            int rightHeight = height - leftHeight;
            if (leftHeight > 4 && rightHeight > 4)
            {
                leftNode = new RoomNode(x, y, width, leftHeight, index, setMax, this);
                rightNode = new RoomNode(x, y + leftHeight, width, rightHeight, index, setMax, this);
            }
        }
    
    }

    void searchNode(RoomNode ptr)
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
