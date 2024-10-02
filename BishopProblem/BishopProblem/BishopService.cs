using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BishopProblem
{
    public class BishopService
    {
        public static int GetMoves(int from, int to)
        {
            var blackSquares = new List<int> { 0, 2, 4, 6, 9, 11, 13, 15, 16, 18, 20, 22, 25, 27, 29, 31, 32, 34, 36, 38, 41, 43, 45, 47, 48, 50, 52, 54, 57, 59, 61, 63 };
            if ((blackSquares.Contains(from) && !blackSquares.Contains(to)) || (!blackSquares.Contains(from) && blackSquares.Contains(to))) return -1;
            var possibles = GetSquares(from);
            if (possibles.Contains(to)) return 1;
            else return 2;
        }

        public static List<int> GetSquares(int from)
        {
            var outcome = new List<int>();
            var left = (from % 8);
            var right = 8 - (from % 8) - 1;
            var top = Math.Floor((double)from/8);
            var bottom = 8 - Math.Floor((double)from / 8) - 1;
            for(var i = 1; i<=Math.Min(left,top); i++)
            {
                outcome.Add(from - i * 9);
            }
            for(var i=1; i<=Math.Min(right, top); i++)
            {
                outcome.Add(from - i * 7);
            }
            for (var i = 1; i <= Math.Min(left, bottom); i++)
            {
                outcome.Add(from + i * 7);
            }
            for (var i = 1; i <= Math.Min(right, bottom); i++)
            {
                outcome.Add(from + i * 9);
            }
            return outcome;
        }
    }
}
