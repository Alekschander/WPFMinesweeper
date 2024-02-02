using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperApp
{
    public class MineSweeper
    {
        public MineSweeperField[][] mineSweeperFields
        {
            get { return mineField; }
        }
        MineSweeperField[][] mineField;
        int totalMines = 0;
        int mineRate = 0;

        public MineSweeper(int sizeX, int sizeY)
        {

            mineRate = new Random().Next(10, 20);

            mineField = new MineSweeperField[sizeX][];

            for (int i = 0; i < mineField.Length; i++)
            {
                mineField[i] = new MineSweeperField[sizeY];
            }


        }

        public void Calc()
        {
            for (int i = 0; i < mineField.Length; i++)
            {
                for (int j = 0; j < mineField[i].Length; j++)
                {
                    int r = new Random().Next(0, 100);
                    if (r > mineRate)
                    {
                        mineField[i][j] = new MineSweeperField(false);
                    }
                    else
                    {
                        mineField[i][j] = new MineSweeperField(true);
                        //Console.WriteLine(r + ", [" + i + "][" + j + "]");
                        totalMines++;
                    }


                }
            }
            for (int i = 0; i < mineField.Length; i++)
            {
                for (int j = 0; j < mineField[i].Length; j++)
                {
                    int count = 0;
                    for (int x = -1; x <= 1; x++)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            if (x == 0 && y == 0) continue; // Skip the current cell

                            int ni = i + x, nj = j + y;
                            if (ni >= 0 && ni < mineField.Length && nj >= 0 && nj < mineField[i].Length)
                            {
                                if (mineField[ni][nj].IsMine())
                                {
                                    count++;
                                }
                            }
                        }
                    }
                    mineField[i][j].NeighbourMines = count;
                    //Console.WriteLine(mineField[i][j].NeighbourMines + ", [" + i + "][" + j + "]");
                }
            }
        }


        public void PrintDebug()
        {
            Console.Write("-+-");
            for (int i = 0; i < mineField[0].Length; i++)
            {
                Console.Write("[" + i + "]-+-");
            }
            for (int i = 0; i < mineField[0].Length; i++)
            {
                Console.WriteLine("\n");

                Console.Write("[" + i + "]");


                for (int j = 0; j < mineField[0].Length; j++)
                {
                    if (mineField[i][j].IsMine())
                    {
                        Console.Write("(X)-+-");
                    }
                    else
                    {
                        Console.Write("(" + mineField[i][j].NeighbourMines + ")-+-");
                    }
                }
            }
        }

        public string ToStringDebug()
        {
            string rw = "";
            rw += "-+-";
            for (int i = 0; i < mineField[0].Length; i++)
            {
                rw += "[" + i + "]-+-";
            }
            for (int i = 0; i < mineField[0].Length; i++)
            {
                rw += ("\n");

                rw += ("[" + i + "]");


                for (int j = 0; j < mineField[0].Length; j++)
                {
                    if (mineField[i][j].IsMine())
                    {
                        rw += ("(X)-+-");
                    }
                    else
                    {
                        rw += ("(" + mineField[i][j].NeighbourMines + ")-+-");
                    }
                }
            }
            return rw;
        }

        public void Print()
        {
            for (int i = 0; i < mineField[0].Length; i++)
            {

                Console.Write("-+-[" + i + "]-+-");
            }
            foreach (var row in mineField)
            {
                foreach (MineSweeperField field in row)
                {

                    Console.Write("-+-[?]-+-");
                }
            }
        }

       /* public static void Main()
        {
            MineSweeper m = new MineSweeper(9, 9);
            m.Calc();
            m.PrintDebug();
            int x = 0;

        }*/

    }






    public class MineSweeperField
    {
        public int NeighbourMines { get; set; }
        private bool isMine;
        private bool mined;

        public MineSweeperField(bool isMine)
        { this.isMine = isMine; }

        public bool IsMine()
        {
            return isMine;
        }
        public bool Mine()
        {
            mined = true;
            return isMine;
        }

    }
}