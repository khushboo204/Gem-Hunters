using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

class Position
{   
    public int X { get; }
    public int Y { get; }

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

    //public Board Board { get; set; }
    public int Gemcount { get; set; }

    public Player(string name, Position position)
    {
        Name = name;
        Position = position;
        Gemcount = 0;
    }
    public void Move(char direction, Board board)
    {
        Console.WriteLine(Name);
        //board.updateCurrentPosition(Position.X, Position.Y);
        //board.Grid[Position.Y, Position.X] = "-";
        //Change the position of the player based on the input
        switch (direction)
        {
            case 'U':
                board.updateCurrentPosition(Position.X, Position.Y);
                Position = new Position(Position.X, Position.Y - 1);
                break;
            case 'D':
                board.updateCurrentPosition(Position.X, Position.Y);
                Position = new Position(Position.X, Position.Y + 1);
                break;
            case 'L':
                board.updateCurrentPosition(Position.X, Position.Y);
                Position = new Position(Position.X - 1, Position.Y);
                break;
            case 'R':
                board.updateCurrentPosition(Position.X, Position.Y);
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
        int x = player.Position.X;
        int y = player.Position.Y;

        //Console.WriteLine(x);
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

        /*Console.WriteLine(x);
        Console.WriteLine(y);*/
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

    public bool CollectGem(Player player)
    {
        if (Grid[player.Position.Y, player.Position.X] == "G")
        {
            player.Gemcount++;
            Grid[player.Position.Y, player.Position.X] = "-";
            return true;
        }
        return false;
    }

    public bool updateUpcomingPosition(Player player)
    {
        if (Grid[player.Position.Y, player.Position.X] != "0")
        {
            Grid[player.Position.Y, player.Position.X] = player.Name;
            return true;
        }

        Console.WriteLine("Obstacle hit.");
        return false;
    }

    public bool updateCurrentPosition(int x, int y)
    {
        if (Grid[y, x] != "0")
        {
            Grid[y, x] = "-";
            return true;
        }

        Console.WriteLine("Upcoming position is Obstacle.");
        return false;
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
        while (!IsGameOver())
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

            CurrentTurn.Move(direction, Board);
            if (Board.CollectGem(CurrentTurn))
            {
                Console.WriteLine($"{CurrentTurn.Name} collected a gem!");
            }

            Board.updateUpcomingPosition(CurrentTurn);


            TotalTurns++;
            SwitchTurn();
        }
        AnnounceWinner();
        
        
    }

   

    public void SwitchTurn()
    {

        if( CurrentTurn == Player1)
        {
            CurrentTurn = Player2;
        }
        else
        {
            CurrentTurn = Player1;
        }
    }

    public bool IsGameOver()
    {
        if(TotalTurns >= 30)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AnnounceWinner()
    {
        Console.WriteLine("Game over!");
        Console.WriteLine($"Player 1 collected {Player1.Gemcount} gems.");
        Console.WriteLine($"Player 2 collected {Player2.Gemcount} gems.");

        if (Player1.Gemcount > Player2.Gemcount)
        {
            Console.WriteLine("Player 1 wins!");
        }
        else if (Player2.Gemcount > Player1.Gemcount)
        {
            Console.WriteLine("Player 2 wins!");
        }
        else
        {
            Console.WriteLine("It's a tie!");
        }
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


