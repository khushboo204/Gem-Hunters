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
class player
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

