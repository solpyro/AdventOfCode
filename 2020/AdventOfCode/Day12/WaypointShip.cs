using System;

namespace AdventOfCode.Day12
{
    public class WaypointShip
    {
        private int _sx;
        private int _sy;
        private int _wx;
        private int _wy;

        public WaypointShip()
        {
            (_sx, _sy) = (0, 0);
            (_wx, _wy) = (10, 1);
        }

        public void Move(char action, int arg)
        {
            switch (action)
            {
                case 'N':
                    _wy += arg;
                    break;
                case 'S':
                    _wy -= arg;
                    break;
                case 'E':
                    _wx += arg;
                    break;
                case 'W':
                    _wx -= arg;
                    break;
                case 'L':
                    Turn(360-arg);
                    break;
                case 'R':
                    Turn(arg);
                    break;
                case 'F':
                    _sx += arg * _wx;
                    _sy += arg * _wy;
                    break;
                default:
                    Console.WriteLine($"Unhandled Command: {action} ({arg})");
                    break;
            }
        }

        public int ManhattanDist => Math.Abs(_sx) + Math.Abs(_sy);

        private void Turn(int deg)
        {
            var (wx, wy) = (_wx, _wy);
            switch (deg)
            {
                case 90:
                    wx = 1 * _wy;
                    wy = -1 * _wx;
                    break;
                case 180:
                    wx = -1 * _wx;
                    wy = -1 * _wy;
                    break;
                case 270:
                    wx = -1 * _wy;
                    wy = 1 * _wx;
                    break;
            }
            (_wx, _wy) = (wx, wy);
        }
    }
}