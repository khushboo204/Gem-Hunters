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

    public Player(string name, Position position)
    {
        Name = name;
        Position = position;
        Gemcount = 0;
    }
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
    public string[,] Grid;

    public Board()
    {
        //Initial board 
        Grid = new string[6, 6];

        // Initialize grid with empty cells
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Grid[i, j] = "-";
            }
        }

        // Place obstacles on random position
    
        Grid[0, 3] = "0";
        Grid[1, 2] = "0";
        Grid[2, 4] = "0";
        Grid[3, 0] = "0";
        Grid[3, 3] = "0";
        Grid[5, 2] = "0";


        // Place players
        Grid[0, 0] = "P1";
        Grid[5, 5] = "P2";

        // Place gems
        Grid[0, 2] = "G";
        Grid[1, 5] = "G";
        Grid[2, 0] = "G";
        Grid[3, 5] = "G";
        Grid[3, 2] = "G";
        Grid[5, 4] = "G";
    }


    public void Display()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Console.Write(Grid[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public bool IsValidMove(Player player, char direction)
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
        if (x < 0 || x >= 6 || y < 0 || y >= 6)
        {
            return false;
        }

        // Check if the new position is an obstacle
        if (Grid[y, x] == "O")
        {
            return false;
        }
        return true;
    }

    public void CollectGem(Player player)
    {
        
    }

    
}

class Cell
{
    public string Occupant { get; set; }

    public Cell(string occupant)
    {
        Occupant = occupant;
    }

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
        Board = new Board();
        Player1 = new Player("P1", new Position(0, 0));
        Player2 = new Player("P2", new Position(5, 5));
        CurrentTurn = Player1;
        TotalTurns = 0;

    }

    public void Start()
    {
        char direction;
        Console.WriteLine($"Turn {TotalTurns + 1}: {CurrentTurn.Name}'s turn");

        Board.Display();
        do
        {
            Console.Write("Enter direction (U/D/L/R): ");
            direction = Console.ReadKey().KeyChar;
            Console.WriteLine();
        } while (!Board.IsValidMove(CurrentTurn, direction));

        CurrentTurn.Move(direction);
        if (Board.CollectGem(CurrentTurn))
        {
            Console.WriteLine($"{CurrentTurn.Name} collected a gem!");
        }

        TotalTurns++;
        SwitchTurn();
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
        Game gemHunters = new Game();
        gemHunters.Start();
    }
}


