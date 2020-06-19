using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace consola4en1
{
    class GameController
    {
        public int[,] board = new int[7, 6];
        public void SumarFicha(int p, int columna, out int i)
        {
            if (board[0, columna] != 0)
            {
                Console.WriteLine("columna llena");
                Console.WriteLine("--------------------------------------");
                i = -1;
                return;
            }

            for (i = board.GetLength(0) - 1; i > -1; i--)
            {
                if (board[i, columna] == 0)
                {
                    board[i, columna] = p;
                    break;
                }
            }
        }

        public bool checkHorizontal(int p, int columna, int i)
        {
            int c = columna;
            int f = i;
            int counter = 0;
            while (board[f, c] == p)
            {
                c--;
                if (c <= 0) break;
            }
            c++;
            while (board[f, c] == p)
            {
                counter++;
                c++;
                if (c >= board.GetLength(1)) break;
            }
            if (counter > 3) return true;
            else return checkVertical(p, columna, i);
        }

        public bool checkVertical(int p, int columna, int i)
        {
            int c = columna;
            int f = i;
            int counter = 0;
            while (board[f, c] == p)
            {
                f--;
                if (f <= 0) break;
            }
            f++;
            while (board[f, c] == p)
            {
                counter++;
                f++;
                if (f >= board.GetLength(0)) break;
            }
            if (counter > 3) return true;
            else return checkPendienteNegativa(p, columna, i);
        }

        public bool checkPendienteNegativa(int p, int columna, int i)
        {
            int c = columna;
            int f = i;
            int counter = 0;
            while (board[f, c] == p)
            {
                f--;
                c--;
                if (c <= 0 || f <= 0) break;
            }
            f++;
            c++;
            while (board[f, c] == p)
            {
                counter++;
                f++;
                c++;
                if (f >= board.GetLength(0) || c >= board.GetLength(1)) break;
            }
            if (counter > 3) return true;
            else return checkPendientePositiva(p, columna, i);
        }

        public bool checkPendientePositiva(int p, int columna, int i)
        {
            int c = columna;
            int f = i;
            int counter = 0;
            while (board[f, c] == p)
            {
                f++;
                c--;
                if (c <= 0 || f >= board.GetLength(0)) break;
            }
            f--;
            c++;
            while (board[f, c] == p)
            {
                counter++;
                f--;
                c++;
                if (f <= 0 || c >= board.GetLength(1)) break;
            }
            return counter > 3;
        }
    }
}
