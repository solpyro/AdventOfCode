using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day16
{
    public class Tickets
    {
        public Dictionary<string, Validator> Rules;
        public int[] MyTicket;
        public int[][] OtherTickets;

        public Tickets(string[] rules, string myTicket, string[] otherTickets)
        {
            Rules = new Dictionary<string, Validator>();
            foreach (var rule in rules)
            {
                var groups = ParseRule.Match(rule).Groups;
                Rules.Add(groups[1].Value, new Validator(int.Parse(groups[2].Value), int.Parse(groups[3].Value), int.Parse(groups[4].Value), int.Parse(groups[5].Value)));
            }

            MyTicket = ParseTicket(myTicket);
            OtherTickets = otherTickets.Select(ParseTicket).ToArray();
        }

        public int SumInvalidValues()
        {
            var total = 0;

            foreach (var ticket in OtherTickets)
            {
                foreach (var field in ticket)
                {
                    var isValid = false;
                    
                    foreach (var rule in Rules)
                    {
                        if (rule.Value.IsValid(field))
                        {
                            isValid = true;
                            break;
                        }
                    }

                    if(!isValid)
                        total += field;
                }
            }
            return total;
        }

        private int[] ParseTicket(string ticket) => Array.ConvertAll(ticket.Split(','), int.Parse);
        private Regex ParseRule = new Regex(@"([a-z\s]+):\s([0-9]+)\-([0-9]+)\sor\s([0-9]+)\-([0-9]+)");
    }
}