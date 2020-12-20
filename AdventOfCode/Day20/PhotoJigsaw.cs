using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System;

namespace AdventOfCode.Day20
{
    public class PhotoJigsaw
    {
        List<PhotoTile> _tiles;
        int _puzzelSize;
        PhotoTile[,] _puzzle;
        List<PhotoTile> _corners;
        List<PhotoTile> _edges;
        List<PhotoTile> _other;


        public PhotoJigsaw(string[] data) {
            ParseData(data);
            
            _puzzelSize = (int)Math.Sqrt(_tiles.Count);
            _puzzle = new PhotoTile[_puzzelSize, _puzzelSize];
            
            SortPieces(); 

            // FindTopRow();
            // for(int i = 1; i < _puzzelSize - 1; i++){
            //     FindRow();
            // }            
            // FindBottomRow();
        }

        public List<PhotoTile> CornerTiles => _corners;

        private void ParseData(string[] data) {
            _tiles = new List<PhotoTile>();
            var ptr = 0;
            while(ptr<data.Length) {
                _tiles.Add(new PhotoTile(
                    ParseId(data[ptr]),
                    data.Skip(ptr + 1).Take(data[ptr + 1].Length).ToArray()
                ));
                ptr += data[ptr + 1].Length + 1;
            };
        }
        private int ParseId(string line) {
            var match = IdRx.Match(line);
            return int.Parse(match.Groups[1].Value);
        }
        private readonly Regex IdRx = new Regex(@"Tile (\d+):");

        private void SortPieces() {
            for(var i = 0; i < _tiles.Count - 1; i++) {
                for(var j = i+1; j < _tiles.Count && _tiles[i].Neighbours.Count!=4; j++) {
                    if(_tiles[j].Neighbours.Count!=4 && TilesMatch(_tiles[i], _tiles[j])) {
                        _tiles[i].Neighbours.Add(_tiles[j]);
                        _tiles[j].Neighbours.Add(_tiles[i]);
                    }
                }
            }

            _corners = _tiles.Where(t => t.Neighbours.Count == 2).ToList();
            _edges = _tiles.Where(t => t.Neighbours.Count == 3).ToList();
            _other = _tiles.Where(t => t.Neighbours.Count == 4).ToList();

        }
        private bool TilesMatch(PhotoTile a, PhotoTile b) {
            //check each side, flipped and reveresed
        }
    }
}