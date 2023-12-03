# Advent of Code 2023

To expand my horizons, I'm trying to solve the [AdventOfCode 2023](https://adventofcode.com/2023) puzzles with F#. 
I'm using VSCode and the [Ionide for F#](https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-fsharp) plugin for the language support. 

To run the F# scripts, I'm having to select the code and press <kbd>alt</kbd>+<kbd>enter</kbd> which writes the selected code to the FSI terminal. 

## Day 1: Trebuchet?! ⭐⭐

I'd spent a little time yesterday trying to prepare the workspace, but today's first task shows that I'm _really_ not used to the F# syntax. I wrote something I thought would work, but got nowhere at the start of the day. It was only later that I struggled more and started to get a grasp on how the language behaves. The compiler messages still feel really rough, and remind me of when I was first learning to program.

After some umming and arring, I was trying to figure out how to replace the strings with numerals, but I'd already spotted the trap of overlapping numbers and was trying to find a way that would handle that nicely. Ultimately, I went to check [Wotee](https://github.com/Wotee)'s solution and spotted the simple idea he came up with; replacing the string with `string\dstring`, preserving any overlapping and ordering, and only adding a few letter characters that get ignored anyway.  

## Day 2: Cube Conundrum ⭐⭐

I learned about defining `records` and the different mindset required for functional programming.
I created a record for the game, so I could store the game id againt the rounds, and I'd thought I would parse the rounds into their own record also, but in the end it was easier to map the lines into a dictionary and, with a little error handling, evaluate them to find the games that fit the criteria for part 1. 

Part 2 felt like it would be easy, but once again I ran into some problems with thinking functionally. I had hoped that I could collapse the rounds into a single tuple, but both `Array.fold` and `Seq.reduce` requited functions that would create objects of the same type as the array that was generated. In the end I had to parse the arrys three times (once for each colour) to get the max values.  

