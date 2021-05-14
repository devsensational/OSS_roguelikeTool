using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager_BSP : MonoBehaviour
{
    [SerializeField]
    public GameObject floor;
    public GameObject wall;
    public GameObject monster1, monster2;
    public GameObject item;

    public int setWidth, setHeight;
    public int setMax;
    public int setHallwaySize;


    [Range(0, 100)]
    public int setRandomFillPercent;

    void Start()
    {
        Debug.Log("start");
        RoomNode root = new RoomNode(0, 0, setWidth, setHeight, 0, setMax, null);
        CellularMapGenerator cellGene = new CellularMapGenerator(root, setRandomFillPercent);
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
            int[,] buf = ptr.getGrid();
            for (int i = ptr.getX(); i <= ptr.getWidth() + ptr.getX() -1 ; i++)
            {
                for (int j = ptr.getY(); j <= ptr.getHeight() + ptr.getY() -1 ; j++)
                {
                    if (buf[i - ptr.getX(), j - ptr.getY()]  == 1)
                    {
                        GameObject RoomFloor = Instantiate(floor);
                        RoomFloor.transform.position = new Vector3(floorSize * i, floorSize * j, 0);
                        RoomFloor.name = ptr.getIndex() + "�� ��� �ٴ�" + whereIs;
                    }else if (buf[i - ptr.getX(), j - ptr.getY()] == 0)
                    {
                        GameObject RoomWall = Instantiate(wall);
                        RoomWall.transform.position = new Vector3(floorSize * i, floorSize * j, 0);
                        RoomWall.name = ptr.getIndex() + "�� ��� �� " + whereIs;
                    }
                }
            }
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
    int[,] grid;


    public RoomNode(int x, int y, int width, int height, int index, int setMax, RoomNode parentNode)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        this.parentNode = parentNode;
        this.index = index;
        this.setMax = setMax;
        this.grid = new int[width, height]; 
        this.index++;
        if (this.index < this.setMax) { 
            makeNode();
        }
    }

    void makeNode()
    {
        int randomNum = Random.Range(3, 8);

        if (index % 2 == 1)
        {
            Debug.Log("���� ��� ����");
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
            Debug.Log("���γ�� ����");
            int leftHeight = (int)(height * (randomNum * 0.1f));
            int rightHeight = height - leftHeight;
            if (leftHeight > 4 && rightHeight > 4)
            {
                leftNode = new RoomNode(x, y, width, leftHeight, index, setMax, this);
                rightNode = new RoomNode(x, y + leftHeight, width, rightHeight, index, setMax, this);
            }
        }
    
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

    public void setGrid(int[,] grid)
    {
        this.grid = grid;
    }
    
    public int[,] getGrid()
    {
        return grid;
    }


}
