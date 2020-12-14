using System;

namespace AdventOfCode.Day12
{
    public class Ship
    {
        private int _x;
        private int _y;
        private int _t;

        public Ship()
        {
            (_x, _y, _t) = (0, 0, 90);
        }

        public void Move(char action, int arg)
        {
            switch (action)
            {
                case 'N':
                    _y += arg;
                    break;
                case 'S':
                    _y -= arg;
                    break;
                case 'E':
                    _x += arg;
                    break;
                case 'W':
                    _x -= arg;
                    break;
                case 'L':
                    Turn(-arg);
                    break;
                case 'R':
                    Turn(arg);
                    break;
                case 'F':
                    switch (_t)
                    {
                        case 0:
                            _y += arg;
                            break;
                        case 90:
                            _x += arg;
                            break;
                        case 180:
                            _y -= arg;
                            break;
                        case 270:
                            _x -= arg;
                            break;
                        default:
                            Console.WriteLine($"Unhandled direction: {_t}");
                            throw new NotImplementedException();
                    }
                    break;
                default:
                    Console.WriteLine($"Unhandled Command: {action} ({arg})");
                    break;
            }
        }

        public int ManhattanDist => Math.Abs(_x) + Math.Abs(_y);

        private void Turn(int deg)
        {
            _t += deg;
            _t %= 360;
            if (_t < 0)
                _t += 360;
        }
    }
}