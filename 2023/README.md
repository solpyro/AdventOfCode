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

## Day 3: Gear Ratios

Compared to day 2, parsing the data here was pretty easy, but once again, I had to figure out how to express my idea in a _functional_ way. Having written a neat little script that would find all non-numeric characters, then find and sum all numeric neighbours, I realised I was getting the wrong result for the test data. Rereading the challenge, I realised I shouldn't be summing single digits, but every _string of numbers_ that touch the symbols (and not duplicating them at that).

## Day 4: Scratchcards ⭐

still feel like I'm "tricking" thento doing what i want, but from reading yesterday I was able to understand, and utilise the 'currying' pattern

## Day 5: If You Give A Seed A Fertilizer

I was able to write the parsing logic to conver the input into data structures, but the actual mapping task seemed so convoluted that I'm not sure I'd know where to start in an imperitive language, let alone something functional. Adding to that that the real input uses suspiciously large numbers, I'm not sure I'll be completing today's task at all.

## Day 6: Wait For It ⭐⭐

Parsing, mapping and computing part 1 was pretty simple, with the techniques I've discovered ove rthe past 5 days.

I accidentially tested my part 2 parser against my real input, which gave me the heads-up that this was designed to be too large for conventional numbers. I quickly realsised that I needed another way to solve this and, after shuffling the distance calculation a little, realised that I could use the quadratic equation solver on this: 

$$
\begin{aligned}
distance &= chargeTime \times (totalTime - chargeTime) \\
distance &= chargeTime \cdot totalTime - chargeTime^2 \\
0 &= -chargeTime^2 + totalTime \cdot chargeTime - distance \\
0 &= -1 \cdot c^2 + t \cdot c - d
\end{aligned}
$$

And with a little help from [F# Snippets](https://www.fssnip.net/38/title/Wicked-way-to-solve-quadratic-equation-using-list-of-operators) I quickly had the quadratic formula implemented and part 2 solved.

## Day 7: Camel Cards ⭐⭐

Basic parsing was easy and I'd even gotten most of the logic down, but I hit a wall figuring out how to evalute the hand types. After a day chewing it over, I checked the reddit megathread and took inspiration from [r\_so9](https://www.reddit.com/r/adventofcode/comments/18cnzbm/2023_day_7_solutions/kcitbv3/)'s solution. I took some shortcuts because I thought I knew what I was doing, but clearly I didn't and had some issues getting the suits ordered correctly. There's a few artifacts in r\_so9's code that I don't understand but seem critical.

For part two, there wasn't much I could do beyond crib a lite more from r\_so9. I understood what needed to be done, but my lack of F# knowledge meant I didn't know how to do it. I had something that I thought would work (and did for the example case), but failed to sort my input correctly. Thanks to [LxsterGames](https://www.reddit.com/r/adventofcode/comments/18cr4xr/2023_day_7_better_example_input_not_a_spoiler/?ref=share&ref_source=link) and their comprehensive example data, I was able to find a couple of key steps I'd skipped.

## Day 8: Haunted Wasteland

Having freshly completed Day 7, the Map structure was helpfully fresh in my mind, and mapping the input to a map of nodes was a simple task. Turning my mind towards writing a solution, I felt the call of recursion. Despite my apprehension, I impelemented a recursive algorithm with suprisingly little code and, to my suprise, it worked perfectly first time.
