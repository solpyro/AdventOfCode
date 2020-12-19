# AdventOfCode2020
My solutions to the [AdventOfCode 2020](https://adventofcode.com/2020) puzzles
## Day 1 - Expence reports
Pretty simple and straightforward, just some dirty exhaustive searching in 2-3 iterative loops.
## Day 2 - Valid passwords
This was also straightforward. For part 1 I'd created a Pwd lass to take the password, parse the rule and handle the validation, so for the part 2 validation it easy enough to add a secnd validation method.
## Day 3 - Dodging trees
This task was also pretty simple. I kept the data as a List\<string\> which meant I could use the array accessors for both of those.
## Day 4 - Passport validation
Simple but fun, I basicly threw a lot of Regex at this one.
## Day 5 - Seat numbers
I implemented the Range class to run the binary searches on the data. After that the task results were easy to collect.
## Day 6 - Data entry
Part 1 and Part 2 went in slightly different directions here, which at least made me glad that I hadn't preprocessed my data input to group the answer in one string.
## Day 7 - Matryoska bags
Regex for parsing the rules into a Dictionary of bags and the bags they contain.

**Part 1** is a for loop finding all bags that contain a set of bags, counting them, then running the search again on those.

**Part 2** is a recursive select in Linq
## Day 8 - Debuggin Assembly
I created an Instruction class to contain each lin of the program, although it might have been easier to use a tuple instead.

**Part 1** Easy loop processing the instructions and setting a 'ran' flag until we found a ran flag that's already set.

**Part 2** Take all the *JMP* or *NOP* elements with a Arg > 0 and loop through them flipping one operation and seeing if we loop.
## Day 9 - Encryptoin hacking
**Part 1** Fairly easy to implement the moving searchspace and test each pair of values.

**Part 2** Ran an exhaustive search for a set that sum to the hardcoded value (dirty) from part 1.
## Day 10 - Adapters
*Test data day* - (actually 12/12) This was the day I finally went to visit the subreddit for some clues to part 2 and realised that the explainations all contain test data.

**Part 1** Really simple walk through the set of adapters, counting each 1-jump and 3-jump

**Part 2** This one defeated me. I knew there was something mathsy that I wasn't grasping, but I just couldn't figure it out. In the end, I fell back on the wisdom of the subreddit and borrowed u/pseale's implementation.
## Day 11 - Seats of Life
I was almost expecting some kind of GoL puzzle, and here it is.

**Part 1** Nice and simple impementation, similar to many others I've written before.

**Part 2** I had a little trouble understanding the part 2 rules. At one point I was trying to write a function that would check *all* chairs in a given direction, but once again the subreddit helped clear up my misunderstanding, and then the solution wasn't so hard to grasp.
## Day 12 - Sailing the seas
This task reminded me of a task we had on the very first day of my university OOP course; where we had to write an algorithm to navigte a submarine out of a maze.
**Part 1** Created the Ship class to process each of the commands.
**Part 2** The addition of the waypoint was a bit more tricky, especially the waypoint turning. I knew the 0, 90, 180 and 270 outputs from Sin & Cos had special values, so after a bit of algebra, I'd written a reletively optimized transformation function.
## Day 13 - Bus timetables
**Part 1** was very trivial. I calculate when each bus would leave after my arrival time, and return the one with the shortest wait.

**Part 2** was not so easy, and again I turned to the subreddit for 'inspiration', which is how I ended up implmenenting a sieve.
## Day 14 - Memory initilisation
Why use 36-bit strings and numbers? All my ints are 16\*(2^n) so I ended up with *ulong*'s everywhere.

**Part 1** was a simple bitmasking excercise.

**Part 2** again flipped the task, rather than extended it. Most of the new code structure was simple enough, I just needed an extra function to compose a list of the possible memory addresses.
## Day 15 - Memory ~~drinking~~ game
Maybe there's some clever way to solve this, but I can't see it and I had actual work to do as well, so implement the actual counting game I did. At least for part 2, In just had to count further than in part 1.
## Day 16 - Train tickets
**Part 1** Another day, another Regex parser. After getting the rules into a usable (numeric) form, checking each field was a straightforward task. 

**Part 2** Having cleaned the data, implementing a procecess of elimination was a satisfying exercise. 
## Day 17 - Conway cubes
I don't know why I'd never thought to implement a multi-dimentional GoL, but now I can say I have. Both parts were simple, although I have to confess I did implement them such that I hold all the active space in memory and I had separte ^3 and ^4 classes.
## Day 18 - Weird Maths
**Part 1** A pretty quick implmentation of a token consumer, handling the brackets recursively solving the contents.

**Part 2** First attempt was the same as part 1, but with more recursion, now that we have to evaluate the + before the \*. I had a working implementation, but C# didn't have a big enough call stack for some of the tests. In the end I impemented some tricks from u/LotOfDilemmaMan's solution, making the call stack much shorter & sing Regex to simplify the simple additions.
## Day 19 - Satellite messages
