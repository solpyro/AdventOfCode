using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace AdventOfCode.Day17
{
    internal class PocketDimention4
    {
        private bool[,,,] _state;
        
        public void Init(string[] seed)
        {
            _state = new bool[seed.Length,seed[0].Length,1,1];
            for (var x = 0; x < seed.Length;x++)
            {
                for (var y = 0; y < seed[x].Length; y++)
                {
                    _state[x, y, 0, 0] = seed[x][y] == '#';
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
            var newState = new bool[
                _state.GetLength(0) + 2, 
                _state.GetLength(1) + 2, 
                _state.GetLength(2) + 2,
                _state.GetLength(3) + 2
            ];
            for (var x = 0; x < newState.GetLength(0); x++)
            {
                for (var y = 0; y < newState.GetLength(1); y++)
                {
                    for (var z = 0; z < newState.GetLength(2); z++)
                    {
                        for (var w = 0; w < newState.GetLength(3); w++)
                        {
                            var neighbours = GetNeighbours(x, y, z, w);
                            if (IsActive(x, y, z, w))
                                newState[x, y, z, w] = (neighbours == 2 || neighbours == 3);
                            else
                                newState[x, y, z, w] = neighbours == 3;
                        }
                    }
                }
            }

            _state = newState;
        }
        private int GetNeighbours(int x, int y, int z, int w)
        {
            var counter = 0;
            for (var dx = -1; dx <= 1; dx++)
                for (var dy = -1; dy <= 1; dy++)
                    for (var dz = -1; dz <= 1; dz++)
                    for (var dw = -1; dw <= 1; dw++)
                        if (dx != 0 || dy != 0 || dz != 0 || dw != 0)
                            counter += IsActive(x + dx, y + dy, z + dz, w + dw) ? 1 : 0;
            return counter;
        }
        private bool IsActive(int x, int y, int z, int w)
        {
            if (x <= 0 || y <= 0 || z <= 0 || w <= 0)
                return false;

            (x, y, z, w) = TupleMinusInt((x, y, z, w), 1);

            if (x >= _state.GetLength(0) || y >= _state.GetLength(1) || z >= _state.GetLength(2) || w >= _state.GetLength(3))
                return false;

            return _state[x, y, z, w];
        }

        public int ActiveCubes => _state.Cast<bool>().Count(v => v);

        private (int,int,int,int) TupleMinusInt((int x,int y,int z,int w) a, int b) => (a.x-b, a.y- b, a.z- b, a.w - b);
    }
}