//개발자 : 김선호

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 class SortList
{
    int size;
    RoomNode ptr;

    public SortList(int size, RoomNode ptr)
    {
        this.size = size;
        this.ptr = ptr;
    }

    public int getSize()
    {
        return size;
    }

    public RoomNode getPtr()
    {
        return ptr;
    }
}

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

    int[,] buf;

    
    List<SortList> sizeList = new List<SortList>();

    [Range(0, 100)]
    public int setRandomFillPercent;

    void Start()
    {
        RoomNode root = new RoomNode(0, 0, setWidth, setHeight, 0, setMax, null, setRandomFillPercent, sizeList);
        makeMap(root, "root");
        for(int ptr1 = 0; ptr1 < sizeList.Count -1; ptr1++)
        {
            for(int ptr2 =1; ptr2 < sizeList.Count - ptr1; ptr2++)
            {
                if(sizeList[ptr2 - 1].getSize() > sizeList[ptr2].getSize())
                {
                    SortList buf = sizeList[ptr2 - 1];
                    sizeList[ptr2 - 1] = sizeList[ptr2];
                    sizeList[ptr2] = buf;
                }
            }
        }

        for(int ptr = 0; ptr < sizeList.Count; ptr++)
        {
            Debug.Log(sizeList[ptr].getSize());
            Debug.Log("인덱스 " + sizeList[ptr].getPtr().getIndex());
        }
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

        }
        else if (ptr == null)
        {
            return;
        }

        if (ptr.getLeftNode() == null && ptr.getRightNode() == null)
        {

            buf = ptr.getGrid();

            for (int a = 0; a < ptr.getWidth(); a++)
            {
                for (int b = 0; b < ptr.getHeight(); b++)
                {
                    Debug.Log((a + b) + "," + (a + b) + " = " + buf[a, b] + " getgridvalue = " + ptr.getGridValue(a,b));
                }
            }

            float floorSize = floor.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
            for (int i = ptr.getX(); i <= ptr.getWidth() + ptr.getX() - 1; i++)
            {
                for (int j = ptr.getY(); j <= ptr.getHeight() + ptr.getY() - 1; j++)
                {
                    if (buf[i - ptr.getX(), j - ptr.getY()] == 0)
                    {
                        GameObject RoomFloor = Instantiate(floor);
                        RoomFloor.transform.position = new Vector3(floorSize * i, floorSize * j, 0);
                        RoomFloor.name = ptr.getIndex() + "번 노드 바닥" + whereIs;
                    }
                    else if (buf[i - ptr.getX(), j - ptr.getY()] == 1)
                    {
                        GameObject RoomWall = Instantiate(wall);
                        RoomWall.transform.position = new Vector3(floorSize * i, floorSize * j, 0);
                        RoomWall.name = ptr.getIndex() + "번 노드 벽 " + whereIs;
                    }
                }
            }

            sizeList.Add(new SortList(ptr.getWidth() * ptr.getHeight(), ptr));
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
    int setRandomFillPercent;
    List<SortList> sizeList;

    public RoomNode(int x, int y, int width, int height, int index, int setMax, RoomNode parentNode, int setRandomFillPercent, List<SortList> sizeList)
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
        this.setRandomFillPercent = setRandomFillPercent;
        this.sizeList = sizeList;

       // this.sizeList.Add(new SortList(width * height, this)); 

        if (this.index < this.setMax) { 
            makeNode();
        }
        if(leftNode == null && rightNode == null)
        {
            randomFillMap();
            calcMap();
            debugFucn();
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
                leftNode = new RoomNode(x, y, leftWidth, height, index, setMax, this, setRandomFillPercent, sizeList);
                rightNode = new RoomNode(x + leftWidth, y, rightWidth, height, index, setMax, this, setRandomFillPercent, sizeList);
            }
        }
        else
        {
            Debug.Log("가로노드 생성");
            int leftHeight = (int)(height * (randomNum * 0.1f));
            int rightHeight = height - leftHeight;
            if (leftHeight > 4 && rightHeight > 4)
            {
                leftNode = new RoomNode(x, y, width, leftHeight, index, setMax, this, setRandomFillPercent, sizeList);
                rightNode = new RoomNode(x, y + leftHeight, width, rightHeight, index, setMax, this, setRandomFillPercent, sizeList);
            }
        }
    }

    void randomFillMap()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (Random.Range(0, 100) < setRandomFillPercent)
                {
                    grid[i, j] = 1;
                }
                else
                {
                    grid[i, j] = 0;

                }

            }
        }
    }

    void calcMap()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (isDeadCell(i, j) > 4)
                {
                    grid[i, j] = 1;

                }
                else
                {
                    grid[i, j] = 0;
                }
            }
        }

    }

    int isDeadCell(int x, int y)
    {
        int cnt = 0;
        for (int neighbourX = x - 1; neighbourX <= x + 1; neighbourX++)
        {
            for (int neighbourY = y - 1; neighbourY <= y + 1; neighbourY++)
            {
                if (neighbourX >= 0 && neighbourX < width && neighbourY >= 0 && neighbourY < height)
                {
                    if (neighbourX != x || neighbourY != y)
                    {
                        cnt += grid[neighbourX, neighbourY];
                    }
                }
                else
                {
                    cnt++;
                }
            }
        }
        return cnt;
    }

    void debugFucn()
    {

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Debug.Log(index+"번째 노드 " + (i + j) + "," + (i + j) + " = " + grid[i, j]);
            }
        }
    }


    //Get Set Function
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
    public int getGridValue(int x, int y)
    {
        return grid[x, y];
    }
}
