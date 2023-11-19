using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCode.Day21
{
    public class Food
    {
        public List<string> Ingredients;
        public List<string> Allergens;

        public Food(string line) {
            Ingredients = WordRx.Matches(line.Split('(')[0]).Select(m => m.Value).ToList();
            Allergens = WordRx.Matches(line.Split('(')[1]).Select(m => m.Value).Where(a => a!="contains").ToList();
        }

        private readonly Regex WordRx = new Regex("[a-z]+");
    }
}