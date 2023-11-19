using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public List<(string field, int value)> GetMyTicket()
        {
            var fields = GetFieldOrder();
            return MyTicket.Zip(fields, (v, f) => (f, v)).ToList();
        }
        private List<string> GetFieldOrder()
        {
            var validTickets = GetValidTickets();
            var availableRules = Rules.ToList();
            var fieldNames = new List<string>(MyTicket.Length);
            fieldNames.AddRange(Enumerable.Repeat(string.Empty, MyTicket.Length));
            var i = 0;

            validTickets.ForEach(t => Console.WriteLine(string.Join(", ", t)));
            Console.WriteLine();

            while (fieldNames.Contains(String.Empty))
            {
                if (i == fieldNames.Count) i = 0;
                if (fieldNames[i] != string.Empty)
                {
                    i++;
                    continue;
                }

                var candidates = new List<string>();

                foreach (var rule in availableRules)
                {
                    var validRule = true;
                    foreach (var ticket in validTickets)
                    {
                        if (!rule.Value.IsValid(ticket[i]))
                        {
                            validRule = false;
                            break;
                        }
                    }
                    if(validRule)
                        candidates.Add(rule.Key);
                }

                if (candidates.Count == 1)
                {
                    fieldNames[i] = candidates[0];
                    availableRules.RemoveAll(r => r.Key == candidates[0]);
                }
                else i++;
            }

            Console.Write("fieldNames: ");
            Console.WriteLine(string.Join(", ",fieldNames));
            return fieldNames;

        }
        private List<int[]> GetValidTickets()
        {
            var validTickets = new List<int[]>();

            foreach (var ticket in OtherTickets)
            {
                var isTicketValid = true;
                
                foreach (var field in ticket)
                {
                    var isFieldValid = false;
                    foreach (var rule in Rules)
                    {
                        if (rule.Value.IsValid(field))
                        {
                            isFieldValid = true;
                            break;
                        }
                    }

                    if (!isFieldValid)
                    {
                        isTicketValid = false;
                        break;
                    }
                }

                if(isTicketValid)
                    validTickets.Add(ticket);
            }

            return validTickets.ToList();
        }

        private int[] ParseTicket(string ticket) => Array.ConvertAll(ticket.Split(','), int.Parse);
        private Regex ParseRule = new Regex(@"([a-z\s]+):\s([0-9]+)\-([0-9]+)\sor\s([0-9]+)\-([0-9]+)");
    }
}