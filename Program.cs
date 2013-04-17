
using System;

namespace SpiralPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = new char[,]
                              {
                                  { 'H', 'A', 'V' }, 
                                  { 'D', 'A', 'E' }, 
                                  { 'E', 'Y', 'A' }, 
                                  { 'C', 'I', 'N' }
                              };
            PrintSpiral(message);
            Console.ReadKey();
        }


        private static void PrintSpiral(char[,] msg)
        {
            var width = msg.GetLength(1);
            var height = msg.GetLength(0);

            var currentPosition = new Position() { x = 0, y = 0, xDirection = 1, yDirection = 0 };

            for (int i = 0; i < width * height; i++)
            {

                Console.Write(msg[currentPosition.y, currentPosition.x]);
                msg[currentPosition.y, currentPosition.x] = '\0';
                if (i < width * height -1)
                    currentPosition = NextPosition(currentPosition, msg);

            }
        }

        private static Position NextPosition(Position currPosition, char[,] msg)
        {
            var nextPosition = new Position()
                                   {
                                       x = currPosition.x + currPosition.xDirection,
                                       y = currPosition.y + currPosition.yDirection,
                                       xDirection = currPosition.xDirection,
                                       yDirection = currPosition.yDirection
                                   };

            if (!IsInRange(nextPosition, msg))
                return NextPosition(TurnRight(currPosition),msg);

            return  nextPosition;
        }

        private static bool IsInRange(Position position, char[,] msg)
        {
            var width = msg.GetLength(1);
            var height = msg.GetLength(0);

            return position.x >= 0 && position.x < width &&
                   position.y >= 0 && position.y < height && 
                   msg[position.y, position.x] != '\0';
        }

        private static Position TurnRight(Position currentPosition)
        {
            if (currentPosition.xDirection == 1 && currentPosition.yDirection == 0)
                return new Position() { x = currentPosition.x, y = currentPosition.y, xDirection = 0, yDirection = 1 };

            if (currentPosition.xDirection == 0 && currentPosition.yDirection == 1)
                return new Position() { x = currentPosition.x, y = currentPosition.y, xDirection = -1, yDirection = 0 };

            if (currentPosition.xDirection == -1 && currentPosition.yDirection == 0)
                return new Position() { x = currentPosition.x, y = currentPosition.y, xDirection = 0, yDirection = -1 };

            if (currentPosition.xDirection == 0 && currentPosition.yDirection == -1)
                return new Position() { x = currentPosition.x, y = currentPosition.y, xDirection = 1, yDirection = 0 };

            return currentPosition;
        }

        private struct Position
        {
            public int x;
            public int y;

            public int xDirection;
            public int yDirection;
        }


    }
}
