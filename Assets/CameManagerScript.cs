﻿using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject playerPrefab;

    public GameObject boxPrefab;

    public GameObject GoalPrefab;

    public GameObject clearText;

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

private 
    Vector2Int GetPlayerIndex()
    {
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                if (field[y, x] == null)
                {
                    continue;
                }
                if (field[y, x].tag == "Player")
                {
                    return new Vector2Int(x, y);
                }
            }
        }
        return new Vector2Int(-1, -1);
    }

    bool MoveNumber(Vector2Int moveFrom, Vector2Int moveTo)
    {
        if (moveTo.y < 0 || moveTo.y >= field.GetLength(0))
        {
            return false;
        }
        if (moveTo.x < 0 || moveTo.x >= field.GetLength(1))
        {
            return false;
        }
        if (field[moveTo.y,moveTo.x] != null && field[moveTo.y,moveTo.x].tag == "Box")
        {
            Vector2Int velocity = moveTo - moveFrom;
            bool success = MoveNumber(moveTo, moveTo + velocity);
            if (!success)
            {
                return false;
            }
        }

        field[moveTo.y,moveTo.x] = field[moveFrom.y, moveFrom.x];
        field[moveFrom.y, moveFrom.x].transform.position = new Vector3(moveTo.x, map.GetLength(0) - moveTo.y, 0);
        field[moveFrom.y, moveFrom.x] = null;
        return true;
    }
    bool IsCleard()
    {
        List<Vector2Int> goals = new List<Vector2Int>();
        for (int y = 0;y < map.GetLength(0); y++)
        {
            for (int x = 0;x < map.GetLength(1); x++)
            {
                if (map[y,x] == 3)
                {

                    goals.Add(new Vector2Int(x, y));
                }
            }
        }

        for(int i = 0;i < goals.Count; i++)
        {
            GameObject f = field[goals[i].y, goals[i].x];
            if(f == null || f.tag != "Box")
            {
                return false;
            }
        }
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        //map = new int[] { 0, 0, 0, 1, 0, 2, 0, 0, 0 };
        //PrintArray();

        map = new int[,] {
            {0,0,0,0,0},
            {0,3,0,3,0},
            {0,1,2,0,0},
            {0,2,3,2,0},
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
                if (map[y,x] == 2)
                {
                    field[y, x] = Instantiate(
                        boxPrefab,
                        new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity
                        );
                }
                if (map[y, x] == 3)
                {
                    field[y, x] = Instantiate(
                        GoalPrefab,
                        new Vector3(x, map.GetLength(0) - y, 0.01f),
                        Quaternion.identity
                        );
                }


            }
            debugText += "\n";
        }
        Debug.Log(debugText);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector2Int playerIndex = GetPlayerIndex();
            MoveNumber(playerIndex, playerIndex + new Vector2Int(0, -1));
            //PrintArray();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector2Int playerIndex = GetPlayerIndex();
            MoveNumber(playerIndex, playerIndex + new Vector2Int(0, 1));
            //PrintArray();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector2Int playerIndex = GetPlayerIndex();
            MoveNumber(playerIndex, playerIndex + new Vector2Int(1, 0));
            //PrintArray();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector2Int playerIndex = GetPlayerIndex();
            MoveNumber(playerIndex, playerIndex + new Vector2Int(-1, 0));
            //PrintArray();
        }

        if(IsCleard())
        {
            clearText.SetActive(true);
        }
    }
}