using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator_Cell
{
    RoomNode ptr;

    string seed;

    [Range(0, 100)]
    public int setRandomFillPercent;


    int[,] mapInfo;
    MapGenerator_Cell(RoomNode ptr)
    {
        this.ptr = ptr;

    }

    void createArr()
    {
        mapInfo = new int[ptr.getWidth(), ptr.getHeight()];
    }

    void RandomFillMap()
    {
        seed = Time.time.ToString();
        System.Random prng = new System.Random(seed.GetHashCode());


    }


}
