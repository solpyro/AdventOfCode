namespace AdventOfCode.Day16
{
    public class Validator
    {
        private int _lowerMin;
        private int _lowerMax;
        private int _upperMin;
        private int _upperMax;

        public Validator(int lowerMin, int lowerMax, int upperMin, int upperMax)
        {
            _lowerMin = lowerMin;
            _lowerMax = lowerMax;
            _upperMin = upperMin;
            _upperMax = upperMax;
        }

        public bool IsValid(int candidate) => ((candidate >= _lowerMin) && (candidate <= _lowerMax) ||
                                               (candidate >= _upperMin) && (candidate <= _upperMax));
    }
}