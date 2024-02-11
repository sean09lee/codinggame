using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{
    static void Main(string[] args)
    {
        // Define building parameters
        string[] inputs;
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
                case Clue.Up:
                    break;
                case Clue.UpRight:
                    break;
                case Clue.Right:
                    break;
                default:
                    // Unknown - first turn
                    (position.X0 == building.Width) ? JumpLeft(position, building) : JumpRight(position, building);
                    break;
            }

            // the location of the next window Batman should jump to.
            Console.WriteLine($"{position.X} {position.Y}");
        }
    }

    static void JumUp(Position position, Building building)
    {

    }

    static void JumpDown(Position position, Building building)
    {
        

    }

    static void JumpLeft(Position position, Building building)
    {
        
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
    public const Up = "U";
    public const UpRight = "UR";
    public const Right = "R";
    public const DownRight = "DR";
    public const Down = "D";
    public const UpLeft = "UL";

    // Episode 2
    // public const WARMER = "WARMER";
    // public const COLER = "COLDER";
    // public const SAME = "SAME";
    // public const UKNOWN = "UNKNOWN";
}