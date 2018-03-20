/*Many areas of Computer Science use simple, abstract domains for both analytical and empirical studies.
For example, an early AI study of planning and robotics (STRIPS) used a block world in which a robot
arm performed tasks involving the manipulation of blocks.
In this problem you will model a simple block world under certain rules and constraints. Rather
than determine how to achieve a specified state, you will “program” a robotic arm to respond to a
limited set of commands.
The problem is to parse a series of commands that instruct a robot arm in how to manipulate blocks
that lie on a flat table. Initially there are n blocks on the table (numbered from 0 to n − 1) with block
bi adjacent to block bi+1 for all 0 ≤ i < n − 1 as shown in the diagram below:
Initial Blocks World
The valid commands for the robot arm that manipulates blocks are:
• move a onto b
where a and b are block numbers, puts block a onto block b after returning any blocks that are
stacked on top of blocks a and b to their initial positions.
• move a over b
where a and b are block numbers, puts block a onto the top of the stack containing block b, after
returning any blocks that are stacked on top of block a to their initial positions.
• pile a onto b
where a and b are block numbers, moves the pile of blocks consisting of block a, and any blocks
that are stacked above block a, onto block b. All blocks on top of block b are moved to their
initial positions prior to the pile taking place. The blocks stacked above block a retain their order
when moved.
• pile a over b
where a and b are block numbers, puts the pile of blocks consisting of block a, and any blocks
that are stacked above block a, onto the top of the stack containing block b. The blocks stacked
above block a retain their original order when moved.
• quit
terminates manipulations in the block world.
Any command in which a = b or in which a and b are in the same stack of blocks is an illegal
command. All illegal commands should be ignored and should have no affect on the configuration of
blocks.
Input
The input begins with an integer n on a line by itself representing the number of blocks in the block
world. You may assume that 0 < n < 25.
The number of blocks is followed by a sequence of block commands, one command per line. Your
program should process all commands until the quit command is encountered.
You may assume that all commands will be of the form specified above. There will be no syntactically
incorrect commands.
Output
The output should consist of the final state of the blocks world. Each original block position numbered
i (0 ≤ i < n where n is the number of blocks) should appear followed immediately by a colon. If there
is at least a block on it, the colon must be followed by one space, followed by a list of blocks that appear
stacked in that position with each block number separated from other block numbers by a space. Don’t
put any trailing spaces on a line.
There should be one line of output for each block position (i.e., n lines of output where n is the
integer on the first line of input).
Sample Input
10
move 9 onto 1
move 8 over 1
move 7 over 1
move 6 over 1
pile 8 over 6
pile 8 over 5
move 2 over 1
move 4 over 9
quit
Sample Output
0: 0
1: 1 9 2 4
2:
3: 3
4:
5: 5 8 7 6
6:
7:
8:
9:
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem101
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Input number of blocks and check the input must less than 25 
            int numberOfBlock;
            string strNumberOfBlock = Console.ReadLine();
            numberOfBlock = Int32.Parse(strNumberOfBlock);
            while (numberOfBlock <= 0 || numberOfBlock >= 25)
            {
                Console.WriteLine("Invalid input, please try again, the number of block must greater than 0 and lesser than 25");
                strNumberOfBlock = Console.ReadLine();
                numberOfBlock = Int32.Parse(strNumberOfBlock);
            }
            List<string> block = new List<string>();

            // Format the elements of the list of block
            for (int i = 0; i < numberOfBlock; i++)
            {
                block.Add(i.ToString() + ": " + i);
            }

            // Move the blocks
            string input = Console.ReadLine();
            while (input != "quit")
            {
                command(input, block);
                input = Console.ReadLine();
            }

            //Print out
            foreach (string item in block)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        public static void command(string input, List<string> block)
        {
            //Analyze the input
            string firstCommand, firstPosition, secondCommand, secondPostion;
            int firstSpace = input.IndexOf(" ");
            int secondSpace = input.IndexOf(" ", firstSpace + 1);
            int thirdSpace = input.IndexOf(" ", secondSpace + 1);
            firstCommand = input.Substring(0, firstSpace);
            firstPosition = input.Substring(firstSpace + 1, secondSpace - firstSpace - 1);
            secondCommand = input.Substring(secondSpace + 1, thirdSpace - secondSpace - 1);
            secondPostion = input.Substring(thirdSpace + 1);

            //• move a onto b
            //where a and b are block numbers, puts block a onto block b after returning any blocks that are
            //stacked on top of blocks a and b to their initial positions.
            if (firstCommand == "move" && secondCommand == "onto")
            {
                string firstBlock = block[Int32.Parse(firstPosition)];
                string secondBlock = block[Int32.Parse(secondPostion)];
                // Remove block a
                firstBlock = firstBlock.Replace(" " + firstPosition, "");
                block[Int32.Parse(firstPosition)] = firstBlock;
                // returning any blocks that are stacked on top of blocks a to their initial positions.
                while (firstBlock.LastIndexOf(" ") != -1)
                {
                    string topBlock = firstBlock.Substring(firstBlock.LastIndexOf(" ") + 1);
                    firstBlock = firstBlock.Remove(firstBlock.LastIndexOf(" "));
                    block[Int32.Parse(topBlock)] = String.Concat(block[Int32.Parse(topBlock)]," " + Int32.Parse(topBlock));
                    block[Int32.Parse(firstPosition)] = firstBlock;
                }
                //Add block a to block b
                secondBlock = String.Concat(secondBlock, " " + firstPosition);
                block[Int32.Parse(secondPostion)] = secondBlock;
                // returning any blocks that are stacked on top of blocks b to their initial positions.
                while (secondBlock.LastIndexOf(" ") != -1)
                {
                    string topBlock = secondBlock.Substring(secondBlock.LastIndexOf(" ") + 1);
                    secondBlock = secondBlock.Remove(secondBlock.LastIndexOf(" "));
                    block[Int32.Parse(topBlock)] = String.Concat(block[Int32.Parse(topBlock)], " " + Int32.Parse(topBlock));
                    block[Int32.Parse(secondPostion)] = secondBlock;
                }
            }
            //• pile a onto b
            //where a and b are block numbers, moves the pile of blocks consisting of block a, and any blocks
            //that are stacked above block a, onto block b.All blocks on top of block b are moved to their
            //initial positions prior to the pile taking place.The blocks stacked above block a retain their order
            //when moved.
            if (firstCommand == "pile" && secondCommand == "onto")
            {

            }
            //• move a over b
            //where a and b are block numbers, puts block a onto the top of the stack containing block b, after
            //returning any blocks that are stacked on top of block a to their initial positions.
            if (firstCommand == "move" && secondCommand == "over")
            {
                block[Int32.Parse(firstPosition)] = block[Int32.Parse(firstPosition)].Remove(3, 1);
                block[Int32.Parse(secondPostion)] = String.Concat(block[Int32.Parse(secondPostion)], " " + firstPosition);
            }
            //• pile a over b
            //where a and b are block numbers, puts the pile of blocks consisting of block a, and any blocks
            //that are stacked above block a, onto the top of the stack containing block b.The blocks stacked
            //above block a retain their original order when moved.
            if (firstCommand == "pile" && secondCommand == "over")
            {

            }
        }
    }
}
