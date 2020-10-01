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
        ObjInfo toAdd = new ObjInfo();

        foreach (Transform dirDirChild in relativePosition.transform)
        {
            if (dirDirChild.name == "Walls")
            {
                foreach (Transform dirChild in dirDirChild.transform)
                {
                    foreach (Transform Child in dirChild.transform)
                    {
                        if (Child.tag == "Wall_X")
                        {
                            toAdd.type = 1;
                            toAdd.x_coord = (int)Child.transform.position.x;
                            toAdd.y_coord = (int)Child.transform.position.y;
                            board.objsInfoList.Add(toAdd);
                        }
                        else if (Child.tag == "Wall_Y")
                        {
                            toAdd.type = 2;
                            toAdd.x_coord = (int)Child.transform.position.x;
                            toAdd.y_coord = (int)Child.transform.position.y;
                            board.objsInfoList.Add(toAdd);
                        }
                    }
                }
            }
            else if (dirDirChild.name == "Players")
            {
                foreach (Transform Child in dirDirChild.transform)
                {
                    if (Child.tag == "Player")
                    {
                        toAdd.type = 0;
                        toAdd.x_coord = (int)Child.transform.position.x;
                        toAdd.y_coord = (int)Child.transform.position.y;
                        board.objsInfoList.Add(toAdd);
                    }
                }
            }
        }      
    }

    void Update()
    {
        
    }
}
