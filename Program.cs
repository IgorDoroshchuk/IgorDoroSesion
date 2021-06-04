using System;
using System.Collections.Generic;
using System.Threading;

namespace IgorDoroSesion
{
    class Program
    {
        static void moveElement(object data)
        {
            List<dynamic> info = (List<dynamic>)data;
            int[,] matrix = info[0];
            int currentRow = info[1];
            int column = info[2];
            try
            {
                if (currentRow != matrix.GetUpperBound(0))
                {
                    if (matrix[currentRow + 1, column] == 0)
                    {
                        matrix[currentRow + 1, column] = matrix[currentRow, column];
                        matrix[currentRow, column] = 0;
                    }
                    if (matrix[currentRow + 1, column] == 2)
                    {
                        matrix[currentRow + 1, column] = matrix[currentRow, column];
                        matrix[currentRow, column] = 0;
                    }
                    if (matrix[currentRow + 1, column] == 5)
                    {
                        matrix[currentRow + 1, column] = matrix[currentRow, column];
                        matrix[currentRow, column] = 0;
                    }
                }
               
                if(currentRow == matrix.GetUpperBound(0))
                {
                    matrix[currentRow, column] = 1;
                    matrix[currentRow - 1, column] = 0;
                    Console.WriteLine(Thread.CurrentThread.Name);
                }
                
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        static void Main(string[] args)
        {
            int[,] matrix = {
                {1, 1, 1, 1, 1, 1, 1 },
                {0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0 },
                {5, 5, 5, 5, 5, 5, 5 }
            };
            int[,] Obstacles =
            {
                {2, 0},
                {2, 1},
                {2, 2},
                {1, 2},
                {2, 3},
                {3, 5},
                {4, 5}
            };
            AddObstacles(matrix, Obstacles);
            for(int i = 0; i < matrix.GetUpperBound(0) + 1; i++)
            {
                ;
                for (int j = 0; j < matrix.GetUpperBound(1) + 1; j++)
                {
                    Thread t = new Thread(new ParameterizedThreadStart(moveElement)) { Name = $"ij : {i}{j}", IsBackground=true };
                    List<dynamic> data = new List<dynamic>() { matrix, i, j };
                    Thread.Sleep(50);
                    t.Start(data);
                }
            }
            printMatrix(matrix);
        }
        static void printMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < matrix.GetUpperBound(1) + 1; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        static void AddObstacles(int[,] matrix, int[,] obstacles)
        {
            for (int i = 0; i < obstacles.GetUpperBound(0) - 1; i++)
            {
                matrix[obstacles[i, 0], obstacles[i, 1]] = 2;
            }
        }
        
        }
    }
