using System;
using System.Collections.Generic;

class Position
{
    public int x;
    public int y;

    public Position(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
class Player
{
    public string Name;
    Position position;
    public int Gemcount;
 
    public void Move(char direction)
    {
        switch (direction)
        {
            case 'U':
                break;
            case 'D':
                break;
            case 'L':
                break;
            case 'R':
                break;
        }
    }
}

class Board
{
    public Cell[,];

    public Board()
    {
        Grid = new Cell[6, 6];
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Grid[i, j] = new Cell("-");
            }
        }

        // Add players
        Grid[0, 0].Occupant = "P1";
        Grid[5, 5].Occupant = "P2";

    }


}




