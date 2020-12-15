using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day14
{
    public class InitParser
    {
        string _mask;
        Dictionary<ulong,ulong> _mem;
        
        public ulong Parse_v1(List<string> prog)
        {
            Init();

            prog.ForEach(cmd =>
            {
                if (MaskRx.IsMatch(cmd))
                {
                    _mask = MaskRx.Match(cmd).Groups[1].Value;
                }
                else
                {
                    var match = MemRx.Match(cmd);

                    _mem[ulong.Parse(match.Groups[1].Value)] = BitMask_v1(match.Groups[2].Value);
                }
            });

            return _mem.Select((kv => kv.Value)).Aggregate((a, b) => a + b);
        }
        private ulong BitMask_v1(string val)
        {
            var mVal = ulong.Parse(val);

            for (int i = 0; i < _mask.Length; i++)
            {
                switch (_mask[i])
                {
                    case '1':
                        mVal = mVal | (1ul << (35 - i));
                        continue;
                    case '0':
                        mVal = mVal & ~(1ul << (35 - i));
                        continue;
                    default:
                        continue;
                }
            }

            return mVal;
        }

        public ulong Parse_v2(List<string> prog)
        {
            Init();

            prog.ForEach(cmd =>
            {
                if (MaskRx.IsMatch(cmd))
                {
                    _mask = MaskRx.Match(cmd).Groups[1].Value;
                }
                else
                {
                    var match = MemRx.Match(cmd);

                    WriteToBitMaskedAddress(ulong.Parse(match.Groups[1].Value), ulong.Parse(match.Groups[2].Value));
                }
            });

            return _mem.Select((kv => kv.Value)).Aggregate((a, b) => a + b);
        }
        private void WriteToBitMaskedAddress(ulong addr, ulong val)
        {
            var addrs = new List<ulong> {addr};
            
            for (int i = 0; i < _mask.Length; i++)
            {
                switch (_mask[i])
                {
                    case '0':
                        continue;
                    case '1': 
                       addrs = addrs.Select(addr => addr | (1ul << (35 - i))).ToList();
                        continue;
                    case 'X': 
                        var addrs1 = addrs.Select(addr => addr | (1ul << (35 - i)));
                        var addrs2 = addrs.Select(addr => addr & ~(1ul << (35 - i)));
                        addrs = addrs1.Concat(addrs2).ToList();   
                        continue;
                }
            }
            addrs.ForEach(addr => _mem[addr] = val);
        }

        private void Init()
        {
            _mem = new Dictionary<ulong, ulong>();
            _mask = string.Empty;
        }

        private static Regex MaskRx = new Regex(@"mask = ([01X]{36})");
        private static Regex MemRx = new Regex(@"mem\[([0-9]+)\] = ([0-9]+)");
    }
}