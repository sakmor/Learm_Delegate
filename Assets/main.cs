using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class main : MonoBehaviour
{
    int size;
    Dictionary<Vector2, Tile> cells;

    // Use this for initialization
    void Start()
    {
        size = 4;
        cells = new Dictionary<Vector2, Tile>();
        cells.Add(new Vector2(0, 0), new Tile(0, 0, 0));
        cells.Add(new Vector2(0, 1), new Tile(0, 1, 1));
        cells.Add(new Vector2(0, 2), new Tile(0, 2, 2));
        cells.Add(new Vector2(0, 3), new Tile(0, 3, 5));
        cells.Add(new Vector2(0, 4), new Tile(0, 4, 5));
        cells.Add(new Vector2(0, 5), new Tile(0, 5, 5));
        cells.Add(new Vector2(0, 6), new Tile(0, 6, 6));

        List<Tile> value5Cell = new List<Tile>();
        Action<int, int, Tile> finder = (x, y, t) =>
        {
            if (t.value == 5) value5Cell.Add(new Tile(x, y, t.value));
        };
        eachCell(finder);

        foreach (var k in cells) Debug.Log(k);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void eachCell(Action<int, int, Tile> act)
    {
        for (var x = 0; x < size; x++)
        {
            for (var y = 0; y < size; y++)
            {
                act(x, y, cells[new Vector2(x, y)]);
            }
        }

    }
}

public class Tile
{
    float x;
    float y;
    private int value;
    public int Value
    {
        get { return value; }
        set { this.value = value; }
    }
    public Tile(int x, int y, int value)
    {
        this.x = x;
        this.y = y;
        this.value = value;
    }

    public Tile()
    {
        this.x = 0;
        this.y = 0;
        this.value = 9;
    }

}
