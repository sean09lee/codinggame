using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Player
{
    static void Main(string[] args)
    {
        // Define building parameters
        string[] inputs;
        string previousClue = string.Empty;
        inputs = Console.ReadLine().Split(' ');
        var building = new Building();
        building.Width = int.Parse(inputs[0]) - 1; // width of the building, zero-index
        building.Height = int.Parse(inputs[1]) - 1; // height of the building, zero-index
        building.MaxTurns = int.Parse(Console.ReadLine()); // maximum number of turns before game over.

        // Define starting position
        inputs = Console.ReadLine().Split(' ');
        var position = new Position();
        position.X = int.Parse(inputs[0]);
        position.Y = int.Parse(inputs[1]);

        // game loop
        while (true)
        {
            string clue = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)
            Console.Error.WriteLine(clue);

            switch (clue) {
                case Clue.WARMER:
                    OnWarmer(position, building, previousClue);
                    break;
                case Clue.COLDER:
                    break;
                case Clue.SAME:
                    OnSame(position, building);
                    break;
                default:
                    // Unknown - first turn
                    (position.X0 == building.Width) ? JumpLeft(position, building) : JumpRight(position, building);
                    break;
            }

            previousClue = clue;

            // the location of the next window Batman should jump to.
            Console.WriteLine($"{position.X} {position.Y}");
        }
    }

    static void OnWarmer(Position position, Building building, string previousClue)
    {
        if (position.X - position.X0 > 0)
        {
            // last jump was right
            if (previousClue == Clue.WARMER)
            {

            }
        }
        else
        {

        }
    }

    static void OnSame(Position position, Building building)
    {

    }

    static void OnColder(Position position, Building building)
    {

    }

    static void JumUp(Position position, Building building)
    {
        // reset previous turn variables
        position.X0 = position.X;
        position.Y0 = position.Y;

        // set new current position
        var mid = (int)Math.Ceiling((decimal)position.Y / 2);
        position.Y = mid;
    }

    static void JumpDown(Position position, Building building)
    {
        // reset previous turn variables
        position.X0 = position.X;
        position.Y0 = position.Y;

        // set new current position
        var mid = (int)Math.Ceiling((decimal)position.Y + building.Height / 2);
        position.Y = mid;
    }

    static void JumpLeft(Position position)
    {
        // reset previous turn variables
        position.X0 = position.X;
        position.Y0 = position.Y;

        // set new current position
        var mid = (int)Math.Ceiling((decimal)position.X / 2);
        position.X = mid;
    }

    static void JumpRight(Position position, Building building)
    {
        // reset previous turn variables
        position.X0 = position.X;
        position.Y0 = position.Y;

        // set new current position
        var mid = (int)Math.Ceiling((decimal)position.X + building.Width / 2);
        position.X = mid;
    }
}

class Building
{
    public int Width {get;set;}
    public int Height {get;set;}
    public int MaxTurns {get;set;}
}

class Position
{
    public int X0 {get;set;} // previous x position
    public int Y0 {get;set;} // previous y position
    public int X {get;set;} // current x position
    public int Y {get;set;} // current y position
}

struct Clue {
    public const WARMER = "WARMER";
    public const COLER = "COLDER";
    public const SAME = "SAME";
    public const UKNOWN = "UNKNOWN";
}