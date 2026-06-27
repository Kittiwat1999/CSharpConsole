using System;
using System.Linq;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Buffers;
using System.Text;

namespace MyApp;

static class Stack
{
    public static string RemoveStars(string s) {
        var stack = new Stack<char>();
        foreach(char c in s)
        {
            if(c == '*')
            {
                stack.Pop();
            } 
            else
            {
                stack.Push(c);
            }
        }

        return new string(stack.Reverse().ToArray());
    }

    public static int[] AsteroidCollision(int[] asteroids) {
        var stack = new Stack<int>();
        foreach(int asteroid in asteroids)
        {
            bool destroyed = false;

            while(stack.Count > 0 && stack.Peek() > 0 && asteroid < 0)
            {
                int top = stack.Peek();
                if(top < -asteroid)
                {
                    stack.Pop();
                    continue;
                }

                if(top == -asteroid)
                {
                    stack.Pop();
                }

                destroyed = true;
                break;
            }

            if(!destroyed)
            {
                stack.Push(asteroid);
            }
        }

        return stack.Reverse().ToArray<int>();
    }

    public static  string DecodeString(string s) {
        var stackNum = new Stack<int>();
        var stackString = new Stack<StringBuilder>();
        var currentNum = 0;
        var currentString = new StringBuilder();

        foreach(char c in s)
        {
            if(char.IsDigit(c))
            {
                currentNum = currentNum * 10 + (c - '0');
            } else if (c == '[')
            {
                stackNum.Push(currentNum);
                stackString.Push(currentString);

                currentNum = 0;
                currentString = new StringBuilder();
            } else if (c == ']')
            {
                int repeatCount = stackNum.Pop();
                StringBuilder prevString = stackString.Pop();
                for(int i = 0; i < repeatCount; i++)
                {
                    prevString.Append(currentString);
                }

                currentString = prevString;
            } else
            {
                currentString.Append(c);
            }
        }

        return currentString.ToString();
    }
}