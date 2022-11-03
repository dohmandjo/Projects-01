// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace Tic_Tac_Toe_01
{
    class Program
    {
        static void Main(string[] args)
        {
             List<string> GameBoard = MakeNewBoard();
             string actualPlayer = "x";

             while (!EndGame(GameBoard))
             {
                ShowBoard(GameBoard);

                int choice = MoveChoice(actualPlayer);
                MoveNext(GameBoard, choice,actualPlayer);

                actualPlayer = NextPlayer(actualPlayer);
             }
            

             ShowBoard(GameBoard);
             Console.WriteLine("Cool, thanks for playing!");
        }

        /// creates a new board
        static List<string> MakeNewBoard()
        {
            List<string> GameBoard = new List<string>();

            for (int i = 1; i <= 9; i++)
            {
                GameBoard.Add(i.ToString());
            }

            return GameBoard;
        }

        /// Display the board
        static void ShowBoard(List<string> GameBoard)
        {

            Console.WriteLine($"{GameBoard[0]}|{GameBoard[1]}|{GameBoard[2]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{GameBoard[3]}|{GameBoard[4]}|{GameBoard[5]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{GameBoard[6]}|{GameBoard[7]}|{GameBoard[8]}");
        }

        /// End the game once one of the player wins or if there is a draw
        static bool EndGame(List<string> GameBoard)
        {
            bool EndGame = false;

            if (Winner (GameBoard, "x") || Winner(GameBoard, "o") || Draw(GameBoard))
            {
                EndGame = true;
            }
            return EndGame;
        }

        /// Determines how a player can win the game
        static bool Winner(List<string> GameBoard, string Gammer)
        {
            bool Winner = false;

            if ((GameBoard[0] == Gammer && GameBoard[1] == Gammer && GameBoard[2] == Gammer)
                || (GameBoard[3] == Gammer && GameBoard[4] == Gammer && GameBoard[5] == Gammer)
                || (GameBoard[6] == Gammer && GameBoard[7] == Gammer && GameBoard[8] == Gammer)
                || (GameBoard[0] == Gammer && GameBoard[3] == Gammer && GameBoard[6] == Gammer)
                || (GameBoard[1] == Gammer && GameBoard[4] == Gammer && GameBoard[7] == Gammer)
                || (GameBoard[2] == Gammer && GameBoard[5] == Gammer && GameBoard[8] == Gammer)
                || (GameBoard[0] == Gammer && GameBoard[4] == Gammer && GameBoard[8] == Gammer)
                || (GameBoard[2] == Gammer && GameBoard[4] == Gammer && GameBoard[6] == Gammer)
                )
            {
                Winner = true;
            }

            return Winner;
        }

        /// Determines Draw
        static bool Draw(List<string> GameBoard)
        {
            bool EmptySpot = false;

            foreach (string spot in GameBoard)
            {
                if (char.IsDigit(spot[0]))
                {
                    EmptySpot = true;
                    break;
                }
            }

            return !EmptySpot;
        }

        /// switches players
        static string NextPlayer(string actualPlayer)
        {
            string next = "x";

            if (actualPlayer == "x")
            {
                next = "o";
            }

            return next;
        }

        /// Player choose new spot everytime
        static int MoveChoice(string actualPlayer)
        {
            Console.Write($"{actualPlayer} it's your turn to choose a spot (1-9): ");
            string new_spot = Console.ReadLine();

            int choice = int.Parse(new_spot);

            return choice;
        }

        /// Places the player where he wants to be
        static void MoveNext(List<string> GameBoard, int choice, string actualPlayer)
        {
            int index = choice - 1;

            GameBoard[index] = actualPlayer;
        }
    }
}