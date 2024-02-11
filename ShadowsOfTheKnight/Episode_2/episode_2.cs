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
        position.X0, position.X = int.Parse(inputs[0]);
        position.Y0, position.Y = int.Parse(inputs[1]);

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
                    OnColder(position, building);
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
        if (previousClue == Clue.SAME)
        {
            // last jump was done to the correct position for a single axis
            var xDiff = Math.Abs(position.X - position.X0);
            if (xDiff > 0)
            {
                // last jump was horizontal, so jump vertically
                JumpVertically(position, building);
            }
            else
            {
                // last jump was vertical, so jump horizontally
                JumpHorizontally(position, building);
            }
        }
        else if (position.X == position.X0 || position.X == building.Width || position.X == 0)
        {
            // last jump was vertical OR we have reached an edge, so jump vertically
            JumpVertically(position, building);
        }
        else
        {
            // last jump was horizontal, so continue jumping horizontally 
            if (position.X > position.X0)
            {
                // continue jumping right
                JumpRight(position, building);
            }
            else
            {
                // continue jumping left
                JumpLeft(position);
            }
        }
    }

    // TODO: finish logic
    static void OnColder(Position position, Building building, string previousClue)
    {
        switch (previousClue) {
            case Clue.WARMER:
                break;
            case Clue.COLDER:
                break;
            case Clue.SAME:
                break;
            case Clue.UKNOWN:
                // last x position was correct, so jump vertically
                position.X = position.X0;
                JumpVertically(position);
                break;
        }
        if (previousClue == Clue.WARMER)
        {
            var xDiff = Math.Abs(position.X - position.X0);
            var yDiff = Math.Abs(position.Y - position.Y0);
            if (xDiff == 1)
            {
                // last x position was correct, so jump vertically
                position.X = position.X0;
                JumpVertically(position);
            }
            else if (xDiff > 1)
            {
                // difference is greater than 1, so retry horizontal jump
                RetryHorizontalJump(position);
            }
            else if (yDiff == 1)
            {
                // last y position was correct, so jump horizontally
            }
            else if (yDiff > 1)
            {
                // difference is greater than 1, so retry vertical jump
                RetryVerticalJump(position);
            }
            else
            {
                Console.Error.WriteLine(@$"Impossible scneario:
                    X: {position.X}, X0: {position.X0}
                    Y: {position.Y}, Y0: {position.Y0}");
                throw;
            }
        }
        else if(previousClue == Clue.COLDER)
        {

        }
        else if()
        {

        }
    }

    static void OnSame(Position position, Building building)
    {
        // this means the correct position is the midpoint
        var xDiff = Math.Abs(position.X - position.X0);
        if (xDiff > 0)
        {
            // last jump was horizontal
            RetryHorizontalJump(position);
        }
        else
        {
            // last jump was vertical
            RetryVerticalJump(position);
        }
    }

    static void JumpVertically(Position position, Building building)
    {
        if (position.Y < building.Height)
        {
            // we have not hit the bottom floor, so jump down
            JumpDown(position, building);
        }
        else
        {
            // we are at the bottom floor, so jump up
            JumpUp(position);
        }
    }

    static void JumpHorizontally(Position position, Building building)
    {
        if (position.X < building.Width)
        {
            // we have not hit the right edge, so jump right
            JumpRight(position, building);
        }
        else
        {
            // we are at the right edge, so jump left
            JumpLeft(position);
        }
    }

    static void JumpUp(Position position)
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

    static void RetryHorizontalJump(Position position)
    {
        // Note: do NOT reset previous turn variables as we are doing a retry
        // set new current position halfway
        var mid = (int)Math.Ceiling((decimal)position.X + position.X0 / 2);
        position.X = mid;
    }

    static void RetryVerticalJump(Position position)
    {
        // Note: do NOT reset previous turn variables as we are doing a retry
        // set new current position halfway
        var mid = (int)Math.Ceiling((decimal)position.Y + position.Y0 / 2);
        position.Y = mid;
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