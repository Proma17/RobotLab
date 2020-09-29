
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class BoardInfo
{
    public List<ObjInfo> objsInfoList;
    public List<int> CalcPos(int player_init_x, int player_init_y, int direction)
    {
        List<int> returnList = new List<int>();
        //direction 1=>South 2=>Est 3=Nord 4=West
        List<ObjInfo> collision_items = new List<ObjInfo>();
        ObjInfo collision_item;
        switch (direction)
        {
            case 1: //South
                //finds first item going south direction
                collision_items = objsInfoList.FindAll(obj => obj.x_coord == player_init_x && player_init_y >= obj.y_coord && (obj.type == 1 || obj.type == 0));
                collision_item = collision_items.OrderBy(obj => obj.y_coord).ThenBy(obj => obj.type).First();
                returnList.Add(player_init_x);
                if (collision_item.type == 0)
                {
                    returnList.Add(collision_item.y_coord + 1);
                }
                else
                {
                    returnList.Add(collision_item.y_coord);
                }
                break;
            case 2: //Est
                //finds first item going East direction
                collision_items = objsInfoList.FindAll(obj => obj.y_coord == player_init_y && player_init_x < obj.x_coord && (obj.type == 2 || obj.type == 0));
                collision_item = collision_items.OrderBy(obj => obj.y_coord).First();
                returnList.Add(collision_item.x_coord - 1);
                returnList.Add(player_init_y);
                break;
            case 3:
                //finds first item going Nord direction
                collision_items = objsInfoList.FindAll(obj => obj.x_coord == player_init_x && player_init_y < obj.y_coord && (obj.type == 1 || obj.type == 0));
                collision_item = collision_items.OrderBy(obj => obj.y_coord).First();
                returnList.Add(player_init_x);
                returnList.Add(collision_item.y_coord - 1);
                break;
            case 4:
                //finds first item going West direction
                collision_items = objsInfoList.FindAll(obj => obj.y_coord == player_init_y && player_init_x >= obj.x_coord && (obj.type == 2 || obj.type == 0));
                collision_item = collision_items.OrderBy(obj => obj.y_coord).First();
                if (collision_item.type == 0)
                {
                    returnList.Add(collision_item.x_coord + 1);
                }
                else
                {
                    returnList.Add(collision_item.x_coord);
                }
                returnList.Add(player_init_y);
                break;
        }
        /*
         switch (direction)
        {
            case 1: //South
                //finds first item going south direction
                collision_items = digits.FindAll(obj => obj.x_coord == player_init_x && player_init_y >= obj.y_coord && (obj.type == 1 || obj.type == 3));
                ObjInfo collision_item = collision_items.OrderBy(obj => obj.y_coord).First();
                break;
            case 2: //Est
                //finds first item going south direction
                collision_items = digits.FindAll(obj => obj.y_coord == player_init_y && player_init_x <= obj.x_coord && (obj.type == 2 || obj.type == 4));
                break;
            case 3:
                //finds first item going Nord direction
                collision_items = digits.FindAll(obj => obj.x_coord == player_init_x && player_init_y <= obj.y_coord && (obj.type == 1 || obj.type == 3));
                break;
            case 4:
                //finds first item going south direction
                collision_items = digits.FindAll(obj => obj.y_coord == player_init_y && player_init_x >= obj.x_coord && (obj.type == 2 || obj.type == 4));
                break;
        }
        */

        return returnList;
    }
}
[System.Serializable]
public class ObjInfo
{
    public int x_coord;
    public int y_coord;
    public int type;
}