using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace consola4en1
{
    class Program
    {
        static int[,] board = new int[7, 6];
        static void Main(string[] args)
        {
            bool seguir = true;
            for (int i = 0; i<7; i++) {
                for (int j = 0; j < 6; j++) {
                    board[i, j] = 0;
                }
            }

            while (seguir) {
                int i, columna;
                do
                {
                    Console.Write("columna: ");
                    ValidarInput(out columna, 0, 5);
                    SumarFicha(1, columna, out i);
                } while (i == -1);

                if (checkHorizontal(1, columna, i))
                    seguir = false;
                else
                    printBoard();

                do
                {
                    Console.Write("columna: ");
                    ValidarInput(out columna, 0, 5);
                    SumarFicha(2, columna, out i);
                } while (i == -1);
                if (checkHorizontal(2, columna, i))
                    seguir = false;
                else
                    printBoard();
            }

            printBoard();
            Console.WriteLine("Has ganado!");
            Console.ReadKey();
        }

        static void ValidarInput(out int input, int min, int max)
        {
            while (!int.TryParse(Console.ReadLine(), out input) || input < min || input > max)
            {
                Console.WriteLine("\n La opción ingresada no es válida, inténtelo nuevamente");
            }
        }

        static public void printBoard() {
            Console.WriteLine("--------------------------------------");
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j] + "     ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("--------------------------------------");
        }

        static public void SumarFicha(int p, int columna, out int i)
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

        static public bool checkHorizontal(int p, int columna, int i) {
            int c = columna;
            int f = i;
            int counter = 0;
            while (board[f,c] == p) {
                c--;
                if (c == 0) break;
            }
            c++;
            while (board[f,c] == p) {
                counter++;
                c++;
                if (c >= board.GetLength(1)) break;
            }
            if (counter > 3) return true;
            else return checkVertical(p, columna, i);
        }

        static public bool checkVertical(int p, int columna, int i)
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

        static public bool checkPendienteNegativa(int p, int columna, int i)
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

        static public bool checkPendientePositiva(int p, int columna, int i)
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
