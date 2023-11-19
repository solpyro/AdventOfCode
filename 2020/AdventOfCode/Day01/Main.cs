﻿using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day01
{
    public static class Main
    {
        public static void Run()
        {
            //find two from list that = 2020
            //return product fo those numbers
            (var v1, var v2) = SumTo(2020, data);
            Console.WriteLine($"{v1} * {v2} = {v1 * v2}");

            //find three from list that = 2020
            //return product fo those numbers
            foreach (var v3 in data)
            {
                try
                {
                    (v1, v2) = SumTo(2020 - v3, data.FindAll(v => v != v3));
                    Console.WriteLine($"{v1} * {v2} * {v3} = {v1 * v2 * v3}");
                    break;
                }
                catch (InvalidDataException)
                {
                    continue;
                }

            }
        }

        private static (int, int) SumTo(int target, List<int> data)
        {
            foreach (var v1 in data)
            {
                foreach (var v2 in data)
                {
                    if (v1 == v2)
                        continue;

                    if (v1 + v2 == target)
                        return (v1, v2);
                }
            }

            throw new InvalidDataException($"No match found when aiming for {target}");
        }

        private static List<int> data = new List<int>{
            1531,
            1959,
            1344,
            1508,
            1275,
            1729,
            1904,
            1740,
            1977,
            1992,
            1821,
            1647,
            1404,
            1893,
            1576,
            1509,
            1995,
            1637,
            1816,
            1884,
            1608,
            1943,
            1825,
            1902,
            1227,
            1214,
            1675,
            1650,
            1752,
            1818,
            862 ,
            2006,
            227 ,
            1504,
            1724,
            1961,
            1758,
            1803,
            1991,
            1126,
            1909,
            1643,
            1980,
            1889,
            811 ,
            1699,
            1654,
            1734,
            1770,
            1754,
            1828,
            1811,
            1997,
            1767,
            1854,
            1653,
            1800,
            1762,
            1962,
            1797,
            877 ,
            1660,
            1895,
            1939,
            1679,
            1496,
            1606,
            1262,
            1727,
            2005,
            1796,
            1595,
            1846,
            1822,
            1974,
            1829,
            1347,
            1341,
            1875,
            1726,
            1963,
            1659,
            337 ,
            1826,
            1777,
            1523,
            1979,
            1805,
            1987,
            2009,
            1993,
            374 ,
            1546,
            1706,
            1748,
            1743,
            1725,
            281 ,
            1317,
            1839,
            1683,
            1794,
            1898,
            1824,
            1960,
            1292,
            1876,
            1760,
            1956,
            1701,
            1565,
            1680,
            1932,
            1632,
            1494,
            1630,
            1838,
            1863,
            1328,
            1490,
            1751,
            1707,
            1567,
            1917,
            1318,
            1861,
            519 ,
            1716,
            1891,
            1636,
            1684,
            1200,
            1933,
            1911,
            1809,
            1967,
            1731,
            1921,
            1827,
            1663,
            1720,
            1976,
            1236,
            1986,
            1942,
            1656,
            1733,
            1541,
            1640,
            1518,
            1897,
            1676,
            1307,
            1978,
            1998,
            1674,
            1817,
            1845,
            1658,
            1639,
            1842,
            1929,
            1972,
            2010,
            1951,
            858 ,
            1928,
            1562,
            1787,
            1916,
            1561,
            1694,
            1944,
            1922,
            1882,
            1691,
            589 ,
            1940,
            1624,
            1570,
            1557,
            1791,
            1492,
            1919,
            1615,
            1571,
            1657,
            1984,
            1521,
            1766,
            1790,
            1782,
            1874,
            1198,
            1764,
            1278,
            1688,
            1905,
            1786,
            1281
        };
    }
}