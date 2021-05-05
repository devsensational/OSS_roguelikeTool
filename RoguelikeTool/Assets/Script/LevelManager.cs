using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Constants
{
    public const int MAX_X = 100;
    public const int MAX_Y = 100;
}

 class BinaryTree
{
    BinaryTree left;
    BinaryTree right;
    BinaryTree parent;
    public int[] p1 = new int[2]; //사각형 왼쪽 위
    public int[] p2 = new int[2]; //사각형 오른쪽 아래


}

public class LevelManager : MonoBehaviour
{
    [SerializeField] //priavete의 직렬화
    public GameObject tile; //게임오브젝트

    public int width;
    public int height;
    private void binaryTree()
    {




    }

    private void createLevel()
    {

        float tileSize = tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        for (int y=0; y<5; y++)
        {
            for (int x = 0; x<5; x++)
            {

                GameObject  newTile  = Instantiate(tile);
                newTile.transform.position = new Vector3(tileSize * x, tileSize * y, 0);
            }
        }
    }

    private void proceduralMapGenerator()
    {
        
    }

    void Start()
    {
        GameObject newTile = new GameObject("Maximum");
        newTile.transform.localScale = new Vector3(width, height, 0);

        BSPTree rootNode = new BSPTree(0, 0, width, height, 0, width, height, tile);
    }


    void Update()
    {
        
    }
}

public class BSPTree : MonoBehaviour
{
    BSPTree leftNode;
    BSPTree rightNode;
    BSPTree prentNode;

    GameObject tile;

    int indexNum = 0;
    int x, y;
    int rootWidth, rootHeight;
    float width, height;

    public BSPTree(int x, int y, float width, float height, int indexNum, int rootWidth, int rootHeight, GameObject tile)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        this.indexNum = indexNum;
        this.rootWidth = rootWidth;
        this.rootHeight = rootHeight;
        this.tile = tile;

        GameObject newTile = Instantiate(tile);
        newTile.transform.position = new Vector3(x, y, 0);
        newTile.transform.localScale = new Vector3(width, height, 0);
        
        makeTree();
    }

    void makeTree() {

        int rndWidth, rndHeight;
        if (indexNum < 5)
        {
            if (indexNum % 2 == 0)
            {
                rndWidth = (int)Random.Range(width * 0.3f, width * 0.7f);
                leftNode = new BSPTree(x, y, rndWidth, height, indexNum++, rootWidth, rootHeight, tile);
                rightNode = new BSPTree(x + rndWidth, y, rndWidth, height, indexNum++, rootWidth, rootHeight, tile);

            }
            else
            {
                rndHeight = (int)Random.Range(height * 0.3f, height * 0.7f);
                leftNode = new BSPTree(x, y + rndHeight, width, rndHeight, indexNum++, rootWidth, rootHeight, tile);
                rightNode = new BSPTree(x, y, width, rndHeight, indexNum++, rootWidth, rootHeight, tile);
            }
        }


        //left tree

    }
}
