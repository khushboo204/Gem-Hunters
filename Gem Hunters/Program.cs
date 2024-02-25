using System;
using System.Collections.Generic;

class Position
{
    public int X;
    public int Y;

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
}
class Player
{
    public string Name { get; }
    public Position Position { get; set; }
    public int Gemcount { get; set; } 
    public void Move(char direction)
    {
        //Change the position of the player based on the input
        switch (direction)
        {
            case 'U':
                Position = new Position(Position.X, Position.Y - 1);
                break;
            case 'D':
                Position = new Position(Position.X, Position.Y + 1);
                break;
            case 'L':
                Position = new Position(Position.X - 1, Position.Y);
                break;
            case 'R':
                Position = new Position(Position.X + 1, Position.Y);
                break;
        }
    }
}

class Board
{
    public Cell[,] Grid;

    public Board()
    {
        //Initial board 
        Grid = new Cell[6, 6];

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


