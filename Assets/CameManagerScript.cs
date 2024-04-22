using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject playerPrefab;

    int[,] map = { };

    GameObject[,] field;

    //GameObject obj;
    //obj.tag;

    //void PrintArray()
    //{
    //    //GameObject instance = Instantiate(
    //    //    playerPrefab,
    //    //    new Vector3(0,0,0),
    //    //    Quaternion.identity
    //    //    );

    //    map = new int[,] {
    //        {0,0,0,0,0},     
    //        {0,0,1,0,0},
    //        {0,0,0,0,0}
    //    };

    //    string debugText = "";
    //    for (int y = 0;y < map.GetLength(0);y++)
    //    {
    //        for (int x = 0; x < map.GetLength(1); x++)
    //        {
    //            debugText += map[y, x].ToString() + ",";
    //        }
    //        debugText += "\n";
    //    }
    //    Debug.Log(debugText);
    //}

    //private Vector2Int GetPlayerIndex()
    //{
    //    for (int y = 0; y < map.Length; y++)
    //    {
    //        for (int x = 0; x < map.Length; x++)
    //        {
    //            if (field[y,x].tag == null)
    //            {

    //            }
    //            if (field[y,x].tag == "Player")
    //            {
    //                return new Vector2Int(x,y);
    //            }
    //        }
    //    }
    //    return new Vector2Int(-1, -1);
    //}

    //bool MoveNumber(string player, Vector2Int moveFrom, Vector2Int moveTo)
    //{
    //    if (moveTo < 0 || moveTo >= map.Length)
    //    {
    //        return false;
    //    }
    //    //if (map[moveTo] == 2)
    //    //{
    //    //    int velocity = moveTo - moveFrom;
    //    //    bool success = MoveNumber(2, moveTo, moveTo + velocity);
    //    //    if (!success)
    //    //    {
    //    //        return false;
    //    //    }
    //    //}
    //    field[moveTo] = number;
    //    field[moveFrom] = null;
    //    return true;
    //}

    // Start is called before the first frame update
    void Start()
    {
        //map = new int[] { 0, 0, 0, 1, 0, 2, 0, 0, 0 };
        //PrintArray();

        map = new int[,] {
            {1,0,0,0,0},
            {0,0,0,0,0},
            {0,0,0,0,0}
        };


        //map.GetLength(0) = s = 3s
        //map.GetLength(1) = —ñ = 5—ñ
        field = new GameObject[map.GetLength(0), map.GetLength(1)];

        string debugText = "";
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    //GameObject instance = Instantiate(
                    //playerPrefab,
                    //new Vector3(x, y, 0),
                    //Quaternion.identity
                    //);
                    field[y, x] = Instantiate(
                        playerPrefab,
                        new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity
                        );
                }
            }
            debugText += "\n";
        }
        Debug.Log(debugText);
    }


    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        int playerIndex = GetPlayerIndex();

    //        MoveNumber(1, playerIndex, playerIndex + 1);
    //        PrintArray();

    //    }
    //    if (Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        int playerIndex = GetPlayerIndex();

    //        MoveNumber(1, playerIndex, playerIndex - 1);
    //        PrintArray();

    //    }
    //}
}