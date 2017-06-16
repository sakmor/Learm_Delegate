using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class main : MonoBehaviour
{
    private int size;
    Dictionary<Vector2, Tile> cells;

    // Use this for initialization
    void Start()
    {
        size = 4;
        cells = new Dictionary<Vector2, Tile>();
        cells.Add(new Vector2(2, 2), new Tile(1, 2, 9)); // tile紀錄的座標與實際cells儲存位置不符，會被setCellsTileCorrect修正。
        List<Tile> availableCell = new List<Tile>(getAvailableCell());
        setCellsTileCorrect();
        List<Tile> occupyedCell = new List<Tile>(getOccupyedCell());
        foreach (var k in occupyedCell) Debug.Log(k + ": " + k.x + " " + k.y + " " + k.value);
    }

    // 更新tile紀錄的xy座標，使之與實際cells儲存位置相符
    void setCellsTileCorrect()
    {
        Action<int, int, Tile> finder = (x, y, t) =>
         {
             if (t != null)
             {
                 if (x != t.x || y != t.y)
                 {
                     t.x = x;
                     t.y = y;
                 }
             }
         };

        eachCell(finder);
    }

    // 回傳被佔據的座標清單
    List<Tile> getOccupyedCell()
    {
        List<Tile> cells = new List<Tile>();

        Action<int, int, Tile> finder = (x, y, t) =>
        {
            if (t != null) cells.Add(t);
        };

        eachCell(finder);
        return cells;
    }

    // 回傳被空置的座標清單
    List<Tile> getAvailableCell()
    {
        List<Tile> cells = new List<Tile>();

        Action<int, int, Tile> finder = (x, y, t) =>
        {
            if (t == null) cells.Add(new Tile(x, y, -1));
        };

        eachCell(finder);
        return cells;
    }



    //對cells內所儲存的資料進行動作
    //傳入參數：Action<int, int, Tile>
    void eachCell(Action<int, int, Tile> act)
    {
        for (var x = 0; x < size; x++)
        {
            for (var y = 0; y < size; y++)
            {
                act(x, y, cells.ContainsKey(new Vector2(x, y)) ? cells[new Vector2(x, y)] : null);
            }
        }

    }
}

public class Tile
{
    public int x { get; set; }
    public int y { get; set; }
    public int value { get; set; }

    public Tile(int x, int y, int value)
    {
        this.x = x;
        this.y = y;
        this.value = value;
    }

    public Tile()
    {
        x = 0;
        y = 0;
        value = 9;
    }

}
