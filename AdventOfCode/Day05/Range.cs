namespace AdventOfCode.Day05
{
    public class Range
    {
        private int _min;
        private int _max;

        private int _half => (_max - (_min - 1)) / 2;

        public Range(int size)
        {
            _min = 0;
            _max = size - 1;
        }

        public bool TakeLower()
        {
            //drop max by half the range
            if (_min != _max) _max -= _half;
            return _min == _max;
        }

        public bool TakeUpper()
        {
            //raise min by half the range
            if (_min != _max) _min += _half;

            return _min == _max;
        }

        public int Value => (_min == _max) ? _min : -1;
    }
}