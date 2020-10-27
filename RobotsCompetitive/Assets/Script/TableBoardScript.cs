using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TableBoardScript : MonoBehaviour
{
    // Start is called before the first frame update
    public BoardInfo board = new BoardInfo();
    private GameObject relativePosition;

    void Start()
    {
        relativePosition = GameObject.Find("RelativePosition");
        InitializeObjsInfoList();

    }

    void InitializeObjsInfoList()
    {
        List<GameObject> wallsChild = new List<GameObject>();
        ObjInfo toAdd; 

        foreach (Transform dirDirChild in relativePosition.transform)
        {
            if (dirDirChild.name == "Walls")
            {
                foreach (Transform dirChild in dirDirChild.transform)
                {
                    foreach (Transform child in dirChild.transform)
                    {
                        if (child.tag == "Wall_X")
                        {
                            toAdd = new ObjInfo();
                            toAdd.type = 1;
                            toAdd.x_coord = (int)child.transform.localPosition.x;
                            toAdd.y_coord = (int)child.transform.localPosition.y;
                            board.objsInfoList.Add(toAdd);
                        }
                        else if (child.tag == "Wall_Y")
                        {
                            toAdd = new ObjInfo();
                            toAdd.type = 2;
                            toAdd.x_coord = (int)child.transform.localPosition.x;
                            toAdd.y_coord = (int)child.transform.localPosition.y;
                            board.objsInfoList.Add(toAdd);
                        }
                    }
                }
            }
            else if (dirDirChild.name == "Players")
            {
                foreach (Transform child in dirDirChild.transform)
                {
                    toAdd = new ObjInfo();
                    toAdd.type = 0;
                    toAdd.x_coord = (int)child.transform.localPosition.x;
                    toAdd.y_coord = (int)child.transform.localPosition.y;
                    toAdd.player_name = child.name;
                    board.objsInfoList.Add(toAdd);
                }
            }
        }      
    }

    void Update()
    {
        
    }
}
