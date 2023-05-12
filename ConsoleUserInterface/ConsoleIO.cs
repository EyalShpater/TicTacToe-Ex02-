using System;
using TicTacToe;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleUserInterface
{
    class ConsoleIO
    {
        private const char k_Player1Sign = 'X';
        private const char k_Player2Sign = 'O';
        private const char k_EmptySquare = ' ';
        private const char k_QuitSign = 'Q';
        private const int k_QuitInt = -1;
        private const int k_MinBoardSize = 3;
        private const int k_MaxBoardSize = 9;

        private Game m_Game;
        private bool m_IsUserStillWantToPlay;

        public ConsoleIO()
        {
            m_Game = null;
            m_IsUserStillWantToPlay = true;
        }

        private void clearScreen()
        {
            Ex02.ConsoleUtils.Screen.Clear();
        }

        private void printBoard()
        {
            printLineOfNumbers();
            for (int i = 0; i < m_Game.BoardSize; i++)
            {
                printRowOfBoard(i);
                printLineBuffer();
            }
        }

        private void printLineOfNumbers()
        {
            Console.Write(" ");
            for (int i = 0; i < m_Game.BoardSize; i++)
            {
                Console.Write("  " + (i + 1) + " ");
            }

            Console.WriteLine();
        }

        private void printLineBuffer()
        {
            Console.Write(" ");
            for (int i = 0; i < m_Game.BoardSize; i++)
            {
                Console.Write("====");
            }

            Console.WriteLine("=\n");
        }

        private void printRowOfBoard(int i_RowIndex)
        {
            Console.Write(i_RowIndex + 1 + "|");
            for (int i = 0; i < m_Game.BoardSize; i++)
            {
                Board.eSquareValue eSign = m_Game.GetSignByCoordinates(i_RowIndex, i);
                char chSign = convertESquareValueToChar(eSign);

                Console.Write(" " + chSign + " |");
            }

            Console.WriteLine();
        }

        private char convertESquareValueToChar(Board.eSquareValue eSign)
        {
            char res = k_EmptySquare;

            switch (eSign)
            {
                case Board.eSquareValue.Player1:
                    res = k_Player1Sign;
                    break;
                case Board.eSquareValue.Player2:
                    res = k_Player2Sign;
                    break;
            }

            return res;
        }

        private void getDataForGameSetupAndInitGame()
        {
            int boardSize;
            bool? isTwoPlayerGame = null;

            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("At any stage enter '{0}' to quit.", k_QuitSign);
            boardSize = readBoardSize();
            if (m_IsUserStillWantToPlay)
            {
                isTwoPlayerGame = readIfTwoPlayers();
            }

            m_Game = m_IsUserStillWantToPlay ? new Game(boardSize, (bool)isTwoPlayerGame) : null;
        }

        private int readBoardSize()
        {
            int size = k_QuitInt;
            bool isValidInput = false;
            string input;

            while (!isValidInput)
            {
                Console.WriteLine("Enter board size between {0} and {1}: ", k_MinBoardSize, k_MaxBoardSize);
                input = Console.ReadLine();

                if (int.TryParse(input, out size))
                {
                    isValidInput = checkBoardSizeInputValidity(size);
                }
                else if (input == k_QuitSign.ToString())
                {
                    m_IsUserStillWantToPlay = false;
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                }
            }

            return size;
        }

        private bool checkBoardSizeInputValidity(int i_Input)
        {
            bool isValid = (i_Input >= k_MinBoardSize && i_Input <= k_MaxBoardSize);

            if (!isValid)
            {
                Console.WriteLine("Invalid input! Board size must be between {0} and {1}.",
                    k_MinBoardSize, k_MaxBoardSize);
            }

            return isValid;
        }

        private bool readIfTwoPlayers()
        {
            bool isTwoPlayersGame = true;
            bool isValidCohice = false;
            string input;

            while (!isValidCohice)
            {
                Console.Write("Enter 1 for one-player game, 2 for two-player game, or '{0}' to quit: ", k_QuitSign);
                input = Console.ReadLine();
                if (int.TryParse(input, out int choice))
                {
                    isValidCohice = checkIfValidNunmberOfPlayersChoice(choice);
                    isTwoPlayersGame = (choice == 2);
                }
                else if (input == k_QuitSign.ToString())
                {
                    m_IsUserStillWantToPlay = false;
                    isValidCohice = true;
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                }
            }

            return isTwoPlayersGame;
        }

        private bool checkIfValidNunmberOfPlayersChoice(int i_Input)
        {
            bool isValid = (i_Input >= 1 && i_Input <= 2);

            if (!isValid)
            {
                Console.WriteLine("Invalid input! Enter 1 or 2 only.");
            }

            return isValid;
        }

        public void StartGame()
        {
            getDataForGameSetupAndInitGame();
            while (m_IsUserStillWantToPlay && !m_Game.IsGameOver())
            {
                clearScreen();
                printBoard();
                if (m_Game.IsComputerTurn())
                {
                    m_Game.PlayAsComputer();
                }
                else
                {
                    playAsPlayer();
                }
            }

            if (!m_IsUserStillWantToPlay)
            {
                quitMode();
            }
            else
            {
                clearScreen();
                printBoard();
                gameOverMode();
            }
        }

        private void playAsPlayer()
        {
            int x, y;
            bool isTurnCompleted;

            getCoordinate(out x, out y);
            isTurnCompleted = m_IsUserStillWantToPlay ? m_Game.MarkSquare(x, y) : true;
            while (!isTurnCompleted && m_IsUserStillWantToPlay)
            {
                Console.WriteLine("Couldn't mark the selected square");
                getCoordinate(out x, out y);
                isTurnCompleted = m_Game.MarkSquare(x, y);
            }
        }

        private void getCoordinate(out int x, out int y)
        {
            Player currentPlayer = m_Game.CurrentPlayerTurn;

            Console.WriteLine($"{currentPlayer.Id}'s turn:");
            Console.WriteLine("Enter x and y coordinate (separates by 'ENTER'): ");
            x = readInt();
            y = m_IsUserStillWantToPlay ? readInt() : k_QuitSign;
            convertUserCoordinatesToBoardCoordinates(ref x, ref y);
        }

        private void convertUserCoordinatesToBoardCoordinates(ref int io_X, ref int io_Y)
        {
            io_X--;
            io_Y--;
        }

        private int readInt()
        {
            int result = k_QuitInt;
            bool isValidInput = false;

            while (!isValidInput)
            {
                string input = Console.ReadLine();

                isValidInput = int.TryParse(input, out result) || input == k_QuitSign.ToString();
                if (!isValidInput)
                {
                    Console.WriteLine("Invalid input! Please enter a number or {0} to quit.", k_QuitSign);
                }
                else if (input == k_QuitSign.ToString())
                {
                    m_IsUserStillWantToPlay = false;
                }
            }

            return result;
        }

        public void gameOverMode()
        {
            Console.WriteLine("Game Over!");

            if (m_Game.IsDraw())
            {
                Console.WriteLine("It's a draw!");
            }
            else
            {
                Console.WriteLine($"{m_Game.Winner.Id} won the game!");
            }

            Console.Read();
        }

        private void quitMode()
        {

        }
    }
}
