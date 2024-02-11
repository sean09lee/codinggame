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
        var startingPosition = new Position();
        startingPosition.X0 = int.Parse(inputs[0]);
        startingPosition.Y0 = int.Parse(inputs[1]);

        // game loop
        while (true)
        {
            string clue = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)

            switch (clue) {
                case Clue.COLDER:
                    break;
                case Clue.WARMER:
                    break;
                case Clue.SAME:
                    break;
                default:
                    // Unknown - first turn
                    break;
            }


            // the location of the next window Batman should jump to.
            Console.WriteLine("0 0");
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