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
      

    }

    public void Display()
    {
        for (int i = 0; i< 6; i++)
        {
            for (int j = 0; j< 6; j++)
            {
                Console.WriteLine();
            }
        Console.WriteLine();
        }
    }

    public void IsValidMove(Player player, char direction)
    {
        int x = player.X;
        int y = player.Y;

        switch (direction)
        {
            case 'U':
                y--;
                break;
            case 'D':
                y++;
                break;
            case 'L':
                x--;
                break;
            case 'R':
                x++;
                break;
        }
    }

    public void CollectGem(Player player)
    {
        
    }

}

class Cell
{
    public string Occupant;

}

class Game
{
    public Board Board;
    public Player Player1;
    public Player Player2;
    public Player CurrentTurn;
    public int TotalTurns;

    public Game()
    {
        
    }

    public void Start()
    {
        
    }

    public void SwitchTurn()
    {
        
    }

    public void IsGameOver()
    {
        
    }

    public void AnnounceWinner()
    {
        
    }

}

class Program
{
    static void Main(string[] args)
    {
        
    }
}


