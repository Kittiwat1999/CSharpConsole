using System;
using System.Linq;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Buffers;

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

        return new string(stack.ToArray().Reverse().ToArray());
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
}