using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode.Day20
{
    public class PhotoTile
    {
        public int Id;
        public string[] Data;
        public List<PhotoTile> Neighbours;
        public PhotoTile(int id, string[] data) {
            Id = id;
            Data = data;
            Neighbours = new List<PhotoTile>();
        }

        public string Top => Data[0];
        public string Bottom => Data[Data.Length-1];
        public string Left => new string(Data.Select(line => line[0]).ToArray());
        public string Right => new string(Data.Select(line => line[line.Length-1]).ToArray());
    }
}