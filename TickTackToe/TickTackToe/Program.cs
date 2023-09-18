using System;
using System.Collections.Generic;

class Program
{
    static char[] board = { '1', '2', '3', '4', 'X', '6', '7', '8', '9' };
    static char player = 'O';
    static char computer = 'X';

    static void Main()
    {
        Console.WriteLine("Witaj w \"Tic Tac Toe\". Oto wygląd planszy:");
        DisplayBoard();
        int moves;
        for (moves = 1; moves < 9; moves++)
        {
            if (moves % 2 != 0)
            {
                EnterMove();
                if (VictoryFor(player))
                {
                    Console.Clear();
                    DisplayBoard();
                    Console.WriteLine("GAME OVER. Wygrał gracz.");
                    break;
                }
            }
            else
            {
                if (DrawMove())
                {
                    Console.Clear();
                    DisplayBoard();
                    Console.WriteLine("GAME OVER. Wygrał komputer.");
                    break;
                }
            }
            Console.Clear();
            DisplayBoard();
        }
        if(moves == 9)
        Console.WriteLine("REMIS");
        Console.WriteLine("Dziękujemy za grę! Zagraj jeszcze raz kiedyś.");
    }

    static void DisplayBoard()
    {
        Console.WriteLine("+---+---+---+");
        Console.WriteLine($"| {board[0]} | {board[1]} | {board[2]} |");
        Console.WriteLine("+---+---+---+");
        Console.WriteLine($"| {board[3]} | {board[4]} | {board[5]} |");
        Console.WriteLine("+---+---+---+");
        Console.WriteLine($"| {board[6]} | {board[7]} | {board[8]} |");
        Console.WriteLine("+---+---+---+");
    }

    static void EnterMove()
    {
        while (true)
        {
            Console.Write("Podaj pole (1-9): ");
            string move = Console.ReadLine();
            if (int.TryParse(move, out int position) && position >= 1 && position <= 9)
            {
                if (board[position - 1] != 'X' && board[position - 1] != 'O')
                {
                    board[position - 1] = player;
                    break;
                }
                else
                {
                    Console.WriteLine("To pole jest już zajęte. Wybierz inne.");
                }
            }
            else
            {
                Console.WriteLine("Podaj poprawną wartość (1-9).");
            }
        }
    }

    static bool DrawMove()
    {
        for (int i = 0; i < 9; i++)
        {
            if (board[i] != computer && board[i] != player)
            {
                char prev = board[i];
                board[i] = computer;
                if (VictoryFor(computer))
                {
                    return true;
                }
                board[i] = prev;
            }
        }

        for (int i = 0; i < 9; i++)
        {
            if (board[i] != computer && board[i] != player)
            {
                char prev = board[i];
                board[i] = player;
                if (VictoryFor(player))
                {
                    board[i] = computer;
                    return false;
                }
                board[i] = prev;
            }
        }


        List<int> freeFields = new List<int>();
        for (int i = 0; i < board.Length; i++)
        {
            if (board[i] != 'X' && board[i] != 'O')
            {
                freeFields.Add(i);
            }
        }

        Random random = new Random();
        int index = random.Next(freeFields.Count);
        board[freeFields[index]] = computer;
        return false;
    }

    static bool VictoryFor(char sign)
    {
        if ((board[0] == sign && board[1] == sign && board[2] == sign) ||
            (board[3] == sign && board[4] == sign && board[5] == sign) ||
            (board[6] == sign && board[7] == sign && board[8] == sign) ||
            (board[0] == sign && board[3] == sign && board[6] == sign) ||
            (board[1] == sign && board[4] == sign && board[7] == sign) ||
            (board[2] == sign && board[5] == sign && board[8] == sign) ||
            (board[0] == sign && board[4] == sign && board[8] == sign) ||
            (board[2] == sign && board[4] == sign && board[6] == sign))
        {
            return true;
        }

        return false;
    }
}
