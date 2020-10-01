using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject board;
    void Start()
    {
        board = GameObject.Find("TableBoard");
        
        //table.board;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovePlayer(1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovePlayer(2);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MovePlayer(3);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MovePlayer(4);
        }
    }
    void MovePlayer(int direction)
    {
        TableBoardScript table = board.GetComponent<TableBoardScript>();
        var cur_x = (int)this.transform.localPosition.x;
        var cur_y = (int)this.transform.localPosition.y;
        List<int> pos = table.board.CalcPos(cur_x, cur_y, direction);
        transform.localPosition = new Vector3(pos[0], pos[1], this.transform.localPosition.z);
    }
}