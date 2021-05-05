using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

static class ConstDirectionNum
{
    public const int root = 0;
    public const int right = 1;
    public const int left = 2;
    public const int down = 3;
    public const int up = 4;
}
public class DiceLevelManager : MonoBehaviour
{
    [SerializeField] //priavete의 직렬화
    public GameObject tile;
    public GameObject wall; //게임오브젝트
    public int x_sizeField, y_sizeField, map_sizeField;

    // Start is called before the first frame update
    void Start()
    {
        LevelTree lvTree = new LevelTree(map_sizeField, x_sizeField, y_sizeField, ConstDirectionNum.root, tile, wall, 0 ,0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    class LevelTree : MonoBehaviour
    {
        public GameObject tile;
        public GameObject wall;

        LevelTree leftTree;
        LevelTree righTree;
        LevelTree upTree;
        LevelTree downTree;


        int x = 0, y = 0;
        int x_size, y_size;
        int direction;
        int number;

        public LevelTree(int number, int x_size, int y_size, int direction, GameObject tile, GameObject wall, int x, int y)
        {
            this.x_size = x_size;
            this.y_size = y_size;
            this.number = number;
            this.direction = direction;
            this.tile = tile;
            this.wall = wall;

            makeWall(this.x_size, this.y_size, x, y);
            makeMap(this.x_size, this.y_size, x, y);
            if (number > 0)
            {
                if (direction != ConstDirectionNum.right) //Left Direction
                {
                    LevelTree leftTree = new LevelTree(UnityEngine.Random.Range(0, number-1), x_size, y_size, ConstDirectionNum.left, tile, wall, x - x_size, y);
                }
                if (direction != ConstDirectionNum.left) //Right Direction
                {
                    LevelTree leftTree = new LevelTree(UnityEngine.Random.Range(0, number-1), x_size, y_size, ConstDirectionNum.right, tile, wall, x + x_size, y);
                }
                if (direction != ConstDirectionNum.up) // Down Direction
                {
                    LevelTree leftTree = new LevelTree(UnityEngine.Random.Range(0, number-1), x_size, y_size, ConstDirectionNum.down, tile, wall, x, y - y_size);
                }
                if (direction != ConstDirectionNum.down) //Up Direction
                {
                    LevelTree leftTree = new LevelTree(UnityEngine.Random.Range(0, number-1), x_size, y_size, ConstDirectionNum.up, tile, wall, x, y + y_size);
                }
            }

        }

        void makeMap(int x_size, int y_size, int x, int y)
        {


            float tileSize = tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x;

            for (int i = x; i <= x_size + x; i++)
            {
                for (int j = y; j <= y_size + y; j++)
                {
                    GameObject newTile = Instantiate(tile);
                    newTile.transform.position = new Vector3(tileSize * i, tileSize * j, 0);
                }
            }
          
        }

        void makeWall(int x_size, int y_size, int x, int y)
        {
            float wallSize = wall.GetComponent<SpriteRenderer>().sprite.bounds.size.x;

            for (int i = x; i <= x_size + x; i++)
            {
                GameObject newWallUp = Instantiate(wall);
                GameObject newWallDown = Instantiate(wall);
                newWallUp.transform.position = new Vector3(wallSize * i, wallSize * y, -1);
                newWallDown.transform.position = new Vector3(wallSize * i, wallSize * (y+ y_size), -1);

            }

            for (int j = y; j <= y_size + y; j++)
            {
                GameObject newWallLeft = Instantiate(wall);
                GameObject newWallRight = Instantiate(wall);
                newWallLeft.transform.position = new Vector3(wallSize * x, wallSize * j, -1);
                newWallRight.transform.position = new Vector3(wallSize * (x + x_size) , wallSize * j, -1);

            }
        }
    }
}


