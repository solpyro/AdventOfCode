# Advent of Code 2021

This year I'm attempting the challenges in python 3 using jupyter notebooks. This feels kind of limiting, but lets see how far I get before I switch to something else... or give up.

## Day 1: Sonar Sweep ⭐⭐

Nothing too special here, just a for loop and a simple comparison.

My sliding frame implementation is very lazy :D

### Techniques leared

General refresher of python syntax (it's been a while)

## Day 2: Dive! ⭐⭐

I thought it would be nicer to read the puzzle data directly from the url, but I dont know how to do that authentication in python's urllib, so I'll leave that and just get on with the puzzle.

Again nothing too special in my code here, but it's nice to be able to use tuples.

## Day 3: Binary Diagnostic ⭐⭐

### Calculate Power Consumption

Lots of simple lsits and parsing characters in strings. At least calculating the Epsilon value was easy once the Gamma was calculated. I'd hoped to get Gamma as an int and use ~ to calculate Epsilon for free, but python uses 16-bit ints so the value would have been off.

### Verify Life Support Rating

Reading the requirements was complicated, and I thought I needed the Gamma and Epsilon values here also. After implementing the filter method to take a flag list, passing in the Gamma or Epsilon flag 
set, and implementing a recursive filter, I was getting the correct response for the CO<sub>2</sub> scrubber value, but a bad value for the O<sub>2</sub> generator. 

After reviewing the instructions **again** I realised the majority was recalculated at each filtered version of the report, not from the complete report. This meant copying part of the code I used in my `calculateGamma` method, and I could have refactored the calcultion fo both Gamma and Epsilon to use the new code, but since they won't be used in the future there's not much point.

### Techniques leared

- Ternary statments: `('trueValue' if isTrue else 'falseValue')`  
- List filtering: `[element for element in list if isTrue]`
- Enumerate list: `for i,v in enumerate(list)`

## Day 4: Giant Squid ⭐⭐

It took some work just to parse the input data! Running the bingo game also looked daunting, but breaking the tasks down enough made most of them easy enough. The tricky part was recognising a winning board.

After looking through other solutions, I decidered there's no clever maths underneath this puzzle, so I'm solveing it in a bruteforcy way; running the solution to part 1 in a while loop, and removing the first winner from the list of boards as we go.

### Techniques leared

- List mapping: `[function(element) for element in list]`
- Initilizing empty lists: `list = [defaultValue]*length`
- Iterate of part of a list: `for element in list[start:end]`
- The difference & similarities between lists `[]` and dictionaries `{}`

## Day 5: Hydrothermal Venture ⭐⭐

Some basic assumptions made part 1 trickier than it should have been. Firstly, I hoped that I could just implement drawing lines in all directions, and filter the coordinates to just the straight lines, but I soon realized that the logic for drawing diagonal lines was more complicated (and probably specified in part 2).  
My second mistake was just passing x1 and x2 into the `range` function. Since some of the lines go backwards, they weren't being drawn, and were giving me bad results. in the end I defined my range as `range(min(x1,x2),max(x1,x2)+1)` which is fine for straight lines, but will need revisiting for the diagonals.

As I guessed, the diagonal behaviour is better defined here. I can't nicely merge my straight line and diagonal behaviours, so I'm using the `isStraight` method to decide which draw method to use. After my inital implementation, I was getting bad results for the test date, so I implenented a map renderer to see what's going wrong. After further investigation, it would appear I just hadn't committed some changes. It's not so obvious what's up to date in the jupyter kernal :/

## Day 6: Lanternfish ⭐⭐

Compared to playing bingo witha squid or mapping the hudrothermal vents, part 1 seems really easy. Part 2 is obviously supposed to get us to write more efficient code... but how? Even for the test data, calculating the 256 day value took a long time.

Following [u/Montag__](https://www.reddit.com/r/adventofcode/comments/r9z49j/2021_day_6_solutions/hng4ef3/)'s hint, I rebuilt my algoritm to store the number of fish on a given day's count, rather than individual fish each with their own clock. Clearly a much more efficient system, but I'm a lazy coder.

## Day 7: The Treachery of Whales ⭐⭐

A quick check of the test data in excel shows that I need to be looking for the median average, not the mean. A quick google reminded me that python has useful libraries, before I try to roll my own median algorithm, so I'll just import `statistics` and write a one-liner function. Totalling the moves to the median place is also easy.

With the changes in fuel consumption, it seems the median is a better fit. Since I've got `statistics` imported, I'll use their method, rather than impementing my own loop. Also the fuel increase appears to be a triangle number, so I can calculate the costs of a given move with `n(n+1)/2`.  
That's my first **wrong anwer** of the year. Checking the subreddit for clues, I heeded [u/kroppeb](https://www.reddit.com/r/adventofcode/comments/rars4g/2021_day_7_why_do_these_values_work_spoilers/hnk7n2z/)'s advice that the mean finds the best result for *n<sup>2</sup>*, not *n(n+1)/2*. After a quick check of every result for the test data, I can be confident at least that the results are continuous, and there should be just one minimum value.  
After reading more around the subject, it became apparent that the mean should get me close to the correct position, and from there I could just follow the gradient one way or the other.

### Techniques leared

- Incrementor: `+=`
    - Not exactly learning, but when I couldn't use `++` I assumed `+=` was also off limits, until I saw a python snippet today
- `statistics` library probably has some other useful things

## Day 8: Seven Segment Search ⭐⭐

This was a hard day to get into. From the start of the scenario explanation I was trying to figure out how to completley decode the output values, and it was only at the end that we're told the scope for part 1 is **much** simpler.

As expected part 2 was more complicated, but after some thinking I had the logical rules (mostly) figured out. During implmentation of the analysis phase, I used a dictionary to help easily reference the different numbers I'd deduced, as I used their strings to help select the other numbers. Then reversing the dictionary before returning it, and having ordered all of the input strings alphabetically, made it quick work to derive the output numbers. My only mistake was forgetting that the figure 6 should contain the figure 5 and *not* the figure 4, so for a while one of the test lines was giving me problems. Once I'd modified tht rule, it was plain sailing.

### Techniques leared

- `namedtuple` It's been bugging me using the array notation to reference my tuples, especially when they aren't logically ordered members
- `if len(number) in listOfNumbers` A nicer pattern for testing against multiple values, rather than testing each one separately
- `next(i for i in list if condition)` finds the first item in a list to match the condition
- `all(char in haystack for char in needle)))` an esoteric one; this returns `True` if all characters in `needle` are also in `haystack`. Any extra characters in the haystack are ignored

## Day 9: Smoke Basin ⭐⭐

Part 1 was nice and simple. Part 2 is going to be a little more complicated, but shouldn't be too tricky. I guess I just need to grow each low point until the border cells are peaks, then store the size of that so I can pick the top three at the end.

I opted to simply test each neighbouring cell that it exists and is less than 9. Starting with the lowest point, I construct a list of `newNeighbours` for the cells just found, and a larger list of `basinPoints`. I then repeat the search process on `newNeighbours` until there are none generated. The logic was simple but there was a lot of struggling with the python lists. This line
```
[neighbour for neighbour in newNeighbours if (neighbour not in newSearchPoints) and (neighbour not in basinPoints)]
```
does **a lot** of heavy lifting, but I can't see a way to break it down without iterating multiple times.

## Day 10: Syntax Scoring ⭐⭐

Is... is this [BrainFuck](https://esolangs.org/wiki/Brainfuck)?

My first thought was RegularExpressions, but I know that way lies folly. I could also probably do part 1 with some ugly string manipulation, but I know the *correct* way to do this is with a tree, and if I'm lucky I can implement the tools to solve part 2 at the same time.  
Having built the node and parser, I wanted to test the parser & filtering before writing the tree walker. That's when I realised my filter wasn't working as the example suggested it should. Looking closer at the test data I see that corrupted lines can also be incomplete, while I'd implemented those tests supposing they would be separate cases.  
Walking the tree wasn't as daunting as I'd first thought. once I got into it. And it's always nice to have a real excuse for some `recursion`!

Many of my assumptions about part 2 were spot on. I had to write some very minor changes to the Fragment class, and not too much extra code in the solution functions.

### Techniques leared

- Python classes
    - `__init__` as the constructor, taking `self` as the first argument, so you can reference the object's members
    - `__str__` and `__repr__` for printing the objects prettily, although I don't think calling `__str__` from `__repr__` is the correct way to do it
- using dictionaries as a stand-in for switch-case statements *(I miss them)*

## Day 11: Dumbo Octopus ⭐⭐

The [behaviour of dumbo octopuses](https://adventofcode.com/2021/day/11) is a very interesting version of the [GoL](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life). I'll keep a link to the day here so I can come back and try to visually model it in Processing.

### How many flashes after 100 steps

Back to the task at hand though... I can't see a way to mathematically model this, so I think I'm just going to have to simulate the process. Let's hope the puzzle data isn't too horrible!  
One complete simulation later, and I'm getting bad answers for the test data. At least one problem was that the `flash` function's neighbour referencing; I was incrementing cells between -1 and 1, without including the source coordinate in the references. Fixing that got us somewhat closer to the correct result, but it seems we're still not incrementing diagonal neighbours. A close look at the steps helped me realise that I was skipping the third column and row of the incrementing square, due to the rules of python's `range` function.

### When do they all flash together

As I mentioned before, I can't think of a way to calculate this mathematically, so I'll just run it until I see 100 flashes.  
So satisfying when part 2 is just 1 short function.

## Day 12: Passage Pathing ⭐⭐

I'm not too sure where to start here, traversing networks was never my strong suit. I guess I could check out the A* algorithm, although I guess that might be more important in part 2? At least I've mapped the data into a data structure that seems to make sense to me.  
After wrestling with passing lists by reference, I realsied I eneded to copy the existing path as I passed it into the next step. Both the extra tests passed perfectly.

After mulling it over for a while, modifying the rules to allow one small cave wasn't so hard after all.

## Day 13: Transparent Origami ⭐⭐

I started with a simple y-first dictionary implementation of the coordinates. After a full implementation, including a utility to print the map, I realised that empty rows would collapse into nothing. Not a problem for part 1 (with the test data at least) but an issue to be mindful of none the less.  
More importantly, I was also getting bad data back for my dot count. It seems my referencing of the target rows is off... because I was writing the merged rows into the lower half of the sheet, and then promptly deleting it.

And we're half way through the puzzles! Out of morbid curiosity, I thought I'd run part 2 against the dictionary implementation, even though I knew about the disappearing lines issue. I guess it didn't matter, because I got the correct answer first time. I even had the map printing method ready.

### Techniques leared

- Using *\*\*kwargs* to shallow copy and merge dictionaries with the pattern `dict3 = {**dict1, **dict2}`

## Day 14: Extended Polymerization ⭐⭐

Part 1 was quick and simple, and (as with day 6) I thought I'd made my solution general enough that I just needed to change the iteration argument for part 2. But of course the polymer is exponential, so this method is not efficient enough.

[u/Spirited-Airline4702](https://www.reddit.com/r/adventofcode/comments/rfzq6f/2021_day_14_solutions/hohrdqe/)'s solution should be a cleaner implementation, and after some careful examination of the code I think I understand how it works. I can take heart in that I have a better counting solution by avoiding the double count. For some reason I'm getting bad results, even though I can't see any issues with my implementation.  
It turns out my implementation was fine, but the counts for each letter were so large that they exceded `sys.maxsize`, so my search for the smallest value was actually returning `sys.maxsize`. In the end, I used `float('inf')` which is always higher than any other number.

### Techniques leared

- Using `defaultdict` to create dictionaries with a default value, rather than having to first check if the key has been instantiated
- `sys.maxsize` returns the maximum word size on the system, but note that python integers can be manyn words long
- `float('inf')` will **always** be more than a real number

## Day 15: Chiton ⭐⭐

Well this seems like the A* algorithm to me; let's implement it acccording to the [wikipedia article](https://en.wikipedia.org/wiki/A*_search_algorithm). I think that was the first time I've implemented an A*, it's pretty similar to the shape I had in my head, but probably otimized a little better.

Part 2 seems like the only way is to brute-force it by extending the map and running the A* again. That seems ok for the test data (taking just 0.0388030s) but the puzzle input takes 31 seconds to calculate. Having said that; it gets me the right answer, so is it wrong?

### Techniques leared

- A* algorithm
- sorting a list by a function of the element: `list.sort(key=lambda element: function(element))`

## Day 16: Packet Decoder ⭐

This was another day where there was too much information to take in all at once, but after a back and forth between implementing and reading the documentation, I was able to build a data structure and parser that could read the input and build a tree of packets. Everyhting seemed good, except that one of the four examples gave me the wrong result. I didn't go to the effort of manually decoding the packet, but since the other three gave correct answers, I'm reletively confident it's a problem in the test. To reinforce that, my puzzle input also returned the correct result.

## Day 17: ???

## Day 18: ???

## Day 19: ???

## Day 20: ???

## Day 21: ???

## Day 22: ???

## Day 23: ???

## Day 24: ???

## Day 25: ???

## Timings

|             | Data Parse | Part 1    | Part 2     |
| ----------- | ---------- | --------- | ---------- |
| Day 1       | -          | 0.0007390 |  0.0023072 |
| Day 2       | -          | 0.0016153 |  0.0018041 |
| Day 3       | -          | 0.0036569 |  0.0016066 |
| Day 4       |  0.0028788 | 0.0282778 |  1.9087163 |
| Day 5       |  0.0016026 | 0.3308574 |  0.4773194 |
| Day 6       |  0.0002656 | 1.9297476 |  0.0002458 |
| Day 7       | -          | 0.0016016 |  0.0080014 |
| Day 8       |  0.0056113 | 0.0003129 |  0.0166624 |
| Day 9       |  0.0054020 | 0.0160816 |  0.1398224 |
| Day 10      |  0.0425948 | 0.1374579 |  0.0434851 |
| Day 11      |  0.0000753 | 0.0594195 |  0.2384715 |
| Day 12      |  0.0000371 | 0.0721894 |  5.9727943 |
| Day 13      |  0.0038653 | 0.1530286 |  0.2168278 |
| Day 14      |  0.0001766 | 0.0261693 |  0.0038486 |
| Day 15      |  0.0037191 | 0.4255411 | 31.7277731 |
| Day 16      |  0.0025020 | 0.0003694 |            |
| Day 17      |            |           |            |
| Day 18      |            |           |            |
| Day 19      |            |           |            |
| Day 20      |            |           |            |
| Day 21      |            |           |            |
| Day 22      |            |           |            |
| Day 23      |            |           |            |
| Day 24      |            |           |            |
| Day 25      |            |           |            |
| Totals      |            |           |            |
| Grand Total |            |           |            |