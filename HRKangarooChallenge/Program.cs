/* 
 You are choreographing a circus show with various animals. For one act, you are given two kangaroos on a number line ready to jump in the positive direction (i.e, toward positive infinity).

The first kangaroo starts at location x1 and moves at a rate of v1 meters per jump.
The second kangaroo starts at location x2 and moves at a rate of v2 meters per jump.
You have to figure out a way to get both kangaroos at the same location at the same time as part of the show. 
If it is possible, return YES, otherwise return NO.

For example, kangaroo 1 starts at x1=2 with a jump distance v1=1 and
kangaroo 2 starts at x2=1  with a jump distance of v2=2.
After one jump, they are both at x= 3 ,(x1+v1 = 2+1 = 3, x2+v2 = 1+2 = 3 ), so our answer is YES.

Function Description

Complete the function kangaroo in the editor below. It should return YES if they reach the same position at the same time, or NO if they don't.

kangaroo has the following parameter(s):

x1, v1: integers, starting position and jump distance for kangaroo 1
x2, v2: integers, starting position and jump distance for kangaroo 2
Input Format

A single line of four space-separated integers denoting the respective values of , , , and .

Constraints
0 <= x1 <= x2 <= 10000
0 <= v1 <= 10000
0 <= v2 <= 10000
Output Format

Print YES if they can land on the same location at the same time; otherwise, print NO.

Note: The two kangaroos must land at the same location after making the same number of jumps.

Sample Input
0 3 4 2

Sample Output
YES
Doing some Algebra, I came up with the logic that Kangaroos meet at the point calculated using below formula
(X1-X2)
-------  = Meeting Point
(V1-V2)

I was not able to pass 2 -3 test cases when simply checked (X1-X2)%(V1-V2) == 0 ,

I refered to below blog section which helped me pass the remaining test cases.
A very nice article that emphasize " BEST SOLUTION IS SIMPLE SOLUTION" !!!
https://bmizepatterson.com/2018/10/01/the-kangaroo-problem/
*/
using System;
using System.IO;

namespace HRKangarooChallenge
{
    class Program
    {
        static string kangaroo(int x1, int v1, int x2, int v2)
        {
            string result = "NO";
            double diff = (x1 - x2) % (v2 - v1); // diff is the point where 2 kangaroos can possibly meet
            if (v2 > v1) // if Kangaroo 2 moves faster than kangaroo 1,then there is no possibility of meeting at same point
            {
                result = "NO";
            }
            else if (diff == 0) // When there is possibility that kangaroos can meet
            {
                if (diff == Math.Round(diff) && diff > 0) // We are ensuring that kangaroos meet at ground and they are at same direction
                {
                    result = "YES";
                }
                else // When diff is not integer and decimal ,then kangaroos are at air
                {
                    result = "NO";
                }
            }
            return result;

        }

        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] x1V1X2V2 = Console.ReadLine().Split(' ');

            int x1 = Convert.ToInt32(x1V1X2V2[0]);

            int v1 = Convert.ToInt32(x1V1X2V2[1]);

            int x2 = Convert.ToInt32(x1V1X2V2[2]);

            int v2 = Convert.ToInt32(x1V1X2V2[3]);

            string result = kangaroo(x1, v1, x2, v2);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
