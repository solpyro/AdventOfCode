using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace AdventOfCode.Day17
{
    internal class PocketDimention3
    {
        private bool[,,] _state;
        
        public void Init(string[] seed)
        {
            _state = new bool[seed.Length,seed[0].Length,1];
            for (var x = 0; x < seed.Length;x++)
            {
                for (var y = 0; y < seed[x].Length; y++)
                {
                    _state[x, y, 0] = seed[x][y] == '#';
                }
            }
        }

        public void RunCycles(int count)
        {
            for (var i = 0;i<count;i++)
                RunCycle();
        }

        private void RunCycle()
        {
            var newState = new bool[_state.GetLength(0) + 2, _state.GetLength(1) + 2, _state.GetLength(2) + 2];
            for (var x = 0; x < newState.GetLength(0); x++)
            {
                for (var y = 0; y < newState.GetLength(1); y++)
                {
                    for (var z = 0; z < newState.GetLength(2); z++)
                    {
                        var neighbours = GetNeighbours(x, y, z);
                        if (IsActive(x, y, z))
                            newState[x, y, z] = (neighbours == 2 || neighbours == 3);
                        else
                            newState[x, y, z] = neighbours == 3;
                    }
                }
            }

            _state = newState;
        }
        private int GetNeighbours(int x, int y, int z)
        {
            var counter = 0;
            for (var dx = -1; dx <= 1; dx++)
                for (var dy = -1; dy <= 1; dy++)
                    for (var dz = -1; dz <= 1; dz++)
                        if (dx != 0 || dy != 0 || dz != 0)
                            counter += IsActive(x + dx, y + dy, z + dz) ? 1 : 0;
            return counter;
        }
        private bool IsActive(int x, int y, int z)
        {
            if (x <= 0 || y <= 0 || z <= 0)
                return false;

            (x, y, z) = TupleMinusInt((x, y, z), 1);

            if (x >= _state.GetLength(0) || y >= _state.GetLength(1) || z >= _state.GetLength(2))
                return false;

            return _state[x, y, z];
        }

        public int ActiveCubes => _state.Cast<bool>().Count(v => v);

        private (int,int,int) TupleMinusInt((int,int,int) a, int b) => (a.Item1-b, a.Item2 - b, a.Item3 - b);
    }
}