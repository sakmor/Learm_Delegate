using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class main : MonoBehaviour
{
    private int size = 4;


    // Use this for initialization
    void Start()
    {
        Dictionary<Vector2, int> cells = createGrid(10);
        printGrild(cells);



    }
    //對cells內所儲存的資料進行動作
    //傳入參數：Action<int, int, Tile>
    void eachCell(Action<int, int, Dictionary<Vector2, int>> act, Dictionary<Vector2, int> dictionary)
    {
        for (var x = 0; x < size; x++)
        {
            for (var y = 0; y < size; y++)
            {
                act(x, y, dictionary);
            }
        }

    }
    Dictionary<Vector2, int> createGrid(int s)
    {
        Dictionary<Vector2, int> temp = new Dictionary<Vector2, int>();
        //宣告一個Action委派名為act ，該委派接收三個 int 參數 x y v
        Action<int, int, Dictionary<Vector2, int>> act = (x, y, value) =>
       {
           Vector2 v2 = new Vector2(x, y);
           temp.Add(v2, UnityEngine.Random.Range(0, s));
       };

        //將委派act 跟 字典 dictionary 傳送到 eachCell方法
        eachCell(act, temp);
        return temp;
    }
    void printGrild(Dictionary<Vector2, int> n)
    {
        Action<int, int, Dictionary<Vector2, int>> act = (x, y, value) =>
        {
            Vector2 v2 = new Vector2(x, y);
            if (value.ContainsKey(v2)) Debug.Log(value[v2]);
        };

        eachCell(act, n);
    }


}

