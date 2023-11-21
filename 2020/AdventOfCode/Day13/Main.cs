using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day13
{
    public static class Main
    {
        public static void Run()
        {
            var (id, time) = TimeToNextBus(test);
            Console.WriteLine($"Wait {time} (5) for bus {id} (59). Solutions {time*id} (295)");

            (id, time) = TimeToNextBus(data);
            Console.WriteLine($"Wait {time} for bus {id}. Solutions {time * id}");

            
            Console.WriteLine($"Earliest timestamp is {FirstSequencialDeparture(test.List)} (1068781)");
            Console.WriteLine($"Earliest timestamp is {FirstSequencialDeparture(new List<int> { 17, 0, 13, 19 })} (3417)");
            Console.WriteLine($"Earliest timestamp is {FirstSequencialDeparture(new List<int> { 67, 7, 59, 61 })} (754018)");
            Console.WriteLine($"Earliest timestamp is {FirstSequencialDeparture(new List<int> { 67, 0, 7, 59, 61 })} (779210)");
            Console.WriteLine($"Earliest timestamp is {FirstSequencialDeparture(new List<int> { 67, 7, 0, 59, 61 })} (1261476)");
            Console.WriteLine($"Earliest timestamp is {FirstSequencialDeparture(new List<int> { 1789, 37, 47, 1889 })} (1202161486)");

            Console.WriteLine($"Earliest timestamp is {FirstSequencialDeparture(data.List)}");
        }

        private static (int, int) TimeToNextBus(Data d)
        {
            return d.List.Where(id => id > 0)
                .Select(id => (Id: id, TimeToWait: id - (d.Time % id)))
                .OrderBy(t => t.TimeToWait).First();
        }
        private static long FirstSequencialDeparture(List<int> list)
        {
            var pList = list.Select((s, ix) => (i: ix, id: (long)s))
                .Where(t => t.id > 0)
                .ToList();

            var (inc, i) = (pList[0].id, pList[0].id);
            int index = 1;

            do
            {
                if ((i + pList[index].i) % pList[index].id == 0)
                {
                    inc *= pList[index].id;
                    index++;
                }
                i += inc;
            } while (index < pList.Count);
            return i - inc;
        }

        private static Data test = new Data
        {
            Time = 939,
            List = new List<int> { 7, 13, 0, 0, 59, 0, 31, 19 }
        };
        private static Data data = new Data
        {
            Time = 1001171,
            List = new List<int> { 17, 0, 0, 0, 0, 0, 0, 41, 0, 0, 0, 37, 0, 0, 0, 0, 0, 367, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 19, 0, 0, 0, 23, 0, 0, 0, 0, 0, 29, 0, 613, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 13 }
        };
    }
}