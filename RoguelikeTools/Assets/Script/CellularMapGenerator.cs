using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CellularMapGenerator
{
    RoomNode ptr;

    public int setRandomFillPercent;


    int[,] grid;
    public CellularMapGenerator(RoomNode ptr, int setRandomFillPercent)
    {
        if(ptr != null)
        {
            this.setRandomFillPercent = setRandomFillPercent;
            createArr(ptr);
        }

    }

    void createArr(RoomNode ptr)
    {
        this.ptr = ptr;
        if (ptr.getLeftNode() != null)
            createArr(ptr.getLeftNode());
        if (ptr.getRightNode() != null)
            createArr(ptr.getRightNode());
        grid = ptr.getGrid();
        randomFillMap();
        calcMap();

    }

    void randomFillMap()
    {
        for (int x = 0; x < ptr.getWidth(); x++)
        {
            for (int y = 0; y < ptr.getHeight() ; y++)
            {
                Debug.Log("rnd work");
                if (Random.Range(0, 100) < setRandomFillPercent)
                {
                    grid[x, y] = 1;
                }
                else
                {
                    grid[x, y] = 0;

                }

            }
        }
        ptr.setGrid(grid);

        
    }

    void calcMap()
    {
        for (int x = 0; x < ptr.getWidth(); x++)
        {
            for (int y = 0; y < ptr.getHeight(); y++)
            {
                Debug.Log("clac work");
                if (isDeadCell(x, y) > 4)
                {
                    grid[x, y] = 1;

                }
                else
                {
                    grid[x, y] = 0;
                }
            }
        }

        ptr.setGrid(grid);

       
    }

    int isDeadCell(int x, int y)
    {
        int cnt = 0;
        for (int neighbourX = x - 1; neighbourX <= x + 1; neighbourX++)
        {
            for (int neighbourY = y - 1; neighbourY <= y + 1; neighbourY++)
            {
                if (neighbourX >= 0 && neighbourX < ptr.getWidth() && neighbourY >= 0 && neighbourY < ptr.getHeight())
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
        return 0;
    }


}