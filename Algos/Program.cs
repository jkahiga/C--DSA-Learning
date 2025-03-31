namespace ConsoleApp1;

using System;
using System.Collections.Generic;

public class Class1
{
    // Stack Backtrack Algo usimg C#

    /*A Maze is given as N*M binary matrix of blocks and there is a rat initially at (0, 0) ie. maze[0][0] 
    and the rat wants to eat food which is present at some given block in the maze (fx, fy). In a maze matrix, 
    0 means that the block is a dead end and 1 means that the block can be used in the path from source to destination. 
    The rat can move in any direction (not diagonally) to any block provided the block is not a dead end. 
    The task is to check if there exists any path so that the rat can reach the food or not. It is not needed to print the path.
    
    Time Complexity: O(2^(N*M))
    Auxiliary Space: O(N*M)*/
    public class Node
    {
        private int x, y;
        private int dir;

        public Node(int i, int j)
        {
            this.x = i;
            this.y = j;
            // Default direction value for up is 0
            this.dir = 0;
        }

        public int getX()
        {
            return x;
        }
        
        public void setX(int x)
        {
            this.x = x;
        }

        public int getY()
        {
            return y;
        }

        public void setY(int y)
        {
            this.y = y;
        }

        public int getDir()
        {
            return dir;
        }

        public void setDir(int dir)
        {
            this.dir = dir;
        }
    }

    public class RatInMaze
    {
        private static readonly int N = 4;
        private static readonly int M = 5;

        // Creation of maze
        int n = N, m = M;

        private static bool [,]visited = new bool[N, M];

        public static void Main(String[] args)
        {
            // Set visited array to true = unvisited
            setVisited(true);

            // Maze matrix creation
            int[,] maze = {
                { 1, 0, 0, 0, 1 },
                { 1, 1, 0, 1, 1 },
                { 0, 1, 0, 0, 0 },
                { 1, 1, 1, 1, 1 }
            };

            if (isReachable(maze))
            {
                Console.WriteLine("Path Found!\n")
            }
            else
            {
                Console.WriteLine("No Path Found!\n");
            }
        }

        private static void setVisited(bool b)
        {
            for (int i = 0; i < visited.GetLength(0); i++)
            {
                for (int j = 0; j < visited.GetLength(0); j++)
                {
                    visited[i, j] = b;
                }
            }
        }

        private static bool isReachable(int [,]maze)
        {
            // Start poimt  at (0, 0)
            int i = 0, j = 0;

            // Food coordinates
            int fx, fy;
            fx = 2;
            fy = 3;

            // Create stack node
            Stack<Node> s = new Stack<Node>();
            Node temp = new Node(i, j);
            s.Push(temp);

            while(s.Count!= 0)
            {
                /*Pop top node
                Move the node according to the node's dir variable*/
                temp = s.Peek();
                int d = temp.getDir();
                i = temp.getX();
                j = temp.getY();

                // Increment direction and push node to stack again
                temp.setDir(temp.getDir() + 1);
                s.Pop();
                s.Push(temp);

                // Return trrue if food is found
                if (i == fx && j == fy)
                {
                    return true;
                }
                // Check if the node is unvisited and not a dead end
                if(d == 0)
                {
                    if(i - 1 >= 0 && maze[i-1, j] == 1 && visited[i-1, j])
                    {
                        Node temp1 = new Node[i - 1, j];
                        visited[i - 1, j] = false;
                        s.Push(temp1);
                    }
                }
                else if(d == 1)
                {
                    // Check directions
                    if(j - 1 >= 0 && maze[i, j - 1] == 1 && visited[i, j - 1])
                    {
                        Node temp1 = new Node(i, j - 1);
                        visited[i, j - 1] = false;
                        s.Push(temp1);
                    }
                }
                else if(d == 2)
                {
                    if(i + 1 < n && maze[i + 1, j] == 1 && visited[i + 1, j])
                    {
                        Node temp1 = new Node(i + 1, j);
                        visited[i + 1, j] = false;
                        s.Push(temp1);
                    }
                }
                else if(d == 3)
                {
                    if(j + 1 < m && maze[i, j + 1] == 1 && visited[i, j + 1])
                    {
                        Node temp4 = new Node(i, j + 1);
                        visited[i, j + 1] = false;
                        s.Push(temp4);
                    }
                }
                // If no direction to food, retraxt back
                else
                {
                    visited[temp.getX(),temp.getY()] = true;
                    s.Pop();
                }
            }
            // If no path found, return false
            return false;
        }
    }
}

