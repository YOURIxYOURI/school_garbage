using System;
using System.Threading;

class Program
{
    static Random random = new Random();
    static char[,] board = new char[10, 10];
    static int player1Row, player1Col, player2Row, player2Col;

    static void Main()
    {
        InitializeBoard();
        PlacePlayers();

        while (true)
        {
            Console.Clear();
            DrawBoard();

            Console.WriteLine("Gracz 1 (X) - Wprowadź kierunek ruchu (np. W, S, A, D): ");
            char move1 = Console.ReadKey().KeyChar;
            MovePlayer(1, move1);

            if (player1Row == player2Row && player1Col == player2Col)
            {
                player2Row = random.Next(10);
                player2Col = random.Next(10);
            }

            if (player1Row == 0)
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine("Gracz 1 (X) wygrywa!");
                break;
            }

            Console.Clear();
            DrawBoard();

            Console.WriteLine("Gracz 2 (O) - Komputer wykonuje ruch...");
            Thread.Sleep(1000); // Opóźnienie, aby ruch komputera był widoczny
            MoveComputer();

            if (player2Row == player1Row && player2Col == player1Col)
            {
                player1Row = random.Next(10);
                player1Col = random.Next(10);
            }

            if (player2Row == 9)
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine("Gracz 2 (O) wygrywa!");
                break;
            }
        }
    }

    static void InitializeBoard()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                board[i, j] = '-';
            }
        }
    }

    static void PlacePlayers()
    {
        player1Row = random.Next(10);
        player1Col = random.Next(10);
        player2Row = random.Next(10);
        player2Col = random.Next(10);

        board[player1Row, player1Col] = 'X';
        board[player2Row, player2Col] = 'O';
    }

    static void DrawBoard()
    {
        Console.WriteLine("Plansza gry:");

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void MovePlayer(int player, char move)
    {
        char playerSymbol = (player == 1) ? 'X' : 'O';
        int currentRow = (player == 1) ? player1Row : player2Row;
        int currentCol = (player == 1) ? player1Col : player2Col;

        int newRow = currentRow;
        int newCol = currentCol;

        switch (move)
        {
            case 'W':
                newRow--;
                break;
            case 'S':
                newRow++;
                break;
            case 'A':
                newCol--;
                break;
            case 'D':
                newCol++;
                break;
        }

        if (IsValidMove(newRow, newCol))
        {
            board[currentRow, currentCol] = '-';
            board[newRow, newCol] = playerSymbol;

            if (player == 1)
            {
                player1Row = newRow;
                player1Col = newCol;
            }
            else
            {
                player2Row = newRow;
                player2Col = newCol;
            }
        }
    }

    static void MoveComputer()
    {
        char[] possibleMoves = { 'W', 'S', 'A', 'D' };
        char computerMove = possibleMoves[random.Next(4)];
        MovePlayer(2, computerMove);
    }

    static bool IsValidMove(int row, int col)
    {
        return row >= 0 && row < 10 && col >= 0 && col < 10;
    }
}
