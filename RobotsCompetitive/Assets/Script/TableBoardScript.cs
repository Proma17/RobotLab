using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBoardScript : MonoBehaviour
{
    // Start is called before the first frame update
    public BoardInfo board;
    private GameObject relativePosition;
    private List<GameObject> player_type_0 = new List<GameObject>();
    private List<GameObject> wall_type_1 = new List<GameObject>();
    private List<GameObject> wall_type_2 = new List<GameObject>();

    void Start()
    {
        
        board = new BoardInfo();
        relativePosition = GameObject.Find("RelativePosition");

        List<GameObject> walls_child = new List<GameObject>();
        foreach (Transform child in relativePosition.transform)
        {
            if (child.name == "Walls")
            {
                walls_child.Add(child.gameObject);
            }
            else if (child.name == "Players")
            {

            }
        }


    }

    void InitializeObjsInfoList()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
