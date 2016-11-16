namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class Mines
    {
        public static void Main()
        {
            const int MaxTurnsPossible = 35;

            string command = string.Empty;
            char[,] gameField = GenerateGameField();
            char[,] minesField = DistributeMines();
            int turnCounter = 0;
            bool hasMineBlown = false;
            List<Score> topScoreBoard = new List<Score>(6);
            int row = 0;
            int col = 0;
            bool isFirstGameFieldPrint = true;
            bool isMaxTurnPossibleReached = false;

            do
            {
                if (isFirstGameFieldPrint)
                {
                    Console.WriteLine("Let's play 'Minesweeper'! Try your luck and open as many mine free cells as you can!");
                    Console.WriteLine("Commands: 'top' - shows scoreBoard, 'restart' - new game, 'exit' - to stop playing");

                    PrintField(gameField);
                    isFirstGameFieldPrint = false;
                }

                Console.Write("Input row and column (separated by space): ");

                command = Console.ReadLine().Trim();

                if (command.Length == 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out col) &&
                        row <= gameField.GetLength(0) &&
                        col <= gameField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintScoreBoard(topScoreBoard);
                        break;
                    case "restart":
                        gameField = GenerateGameField();
                        minesField = DistributeMines();
                        PrintField(gameField);
                        hasMineBlown = false;
                        isFirstGameFieldPrint = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye bye...");
                        break;
                    case "turn":
                        if (minesField[row, col] != '*')
                        {
                            if (minesField[row, col] == '-')
                            {
                                NextTurn(gameField, minesField, row, col);
                                turnCounter++;
                            }

                            if (turnCounter == MaxTurnsPossible)
                            {
                                isMaxTurnPossibleReached = true;
                            }
                            else
                            {
                                PrintField(gameField);
                            }
                        }
                        else
                        {
                            hasMineBlown = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Wrong command!\n");
                        break;
                }

                if (hasMineBlown)
                {
                    PrintField(minesField);
                    Console.Write("\nHrrrrrr! Died like a hero with {0} points. Input nickname: ", turnCounter);

                    string nickname = Console.ReadLine();
                    Score currentScore = new Score(nickname, turnCounter);
                    if (topScoreBoard.Count < 5)
                    {
                        topScoreBoard.Add(currentScore);
                    }
                    else
                    {
                        for (int i = 0; i < topScoreBoard.Count; i++)
                        {
                            if (topScoreBoard[i].Points < currentScore.Points)
                            {
                                topScoreBoard.Insert(i, currentScore);
                                topScoreBoard.RemoveAt(topScoreBoard.Count - 1);
                                break;
                            }
                        }
                    }

                    topScoreBoard.Sort((Score firstScore, Score secondScore)
                        => secondScore.Name.CompareTo(firstScore.Name));
                    topScoreBoard.Sort((Score firstScore, Score secondScore)
                        => secondScore.Points.CompareTo(firstScore.Points));

                    PrintScoreBoard(topScoreBoard);

                    gameField = GenerateGameField();
                    minesField = DistributeMines();
                    turnCounter = 0;
                    hasMineBlown = false;
                    isFirstGameFieldPrint = true;
                }

                if (isMaxTurnPossibleReached)
                {
                    Console.WriteLine("\nGood job! You have opened 35 cells without a single drop of blood!");

                    PrintField(minesField);

                    Console.WriteLine("Input nickname: ");
                    string nickname = Console.ReadLine();

                    Score currentScore = new Score(nickname, turnCounter);

                    topScoreBoard.Add(currentScore);
                    PrintScoreBoard(topScoreBoard);

                    gameField = GenerateGameField();
                    minesField = DistributeMines();
                    turnCounter = 0;
                    isMaxTurnPossibleReached = false;
                    isFirstGameFieldPrint = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria");
        }

        private static void PrintScoreBoard(List<Score> scores)
        {
            Console.WriteLine("\nPoints:");
            if (scores.Count > 0)
            {
                for (int i = 0; i < scores.Count; i++)
                {
                    Console.WriteLine(
                        "{0}. {1} --> {2} mine cells",
                        i + 1, 
                        scores[i].Name, 
                        scores[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty scoreboard\n");
            }
        }

        private static void NextTurn(
            char[,] gameField,
            char[,] minesField,
            int row,
            int col)
        {
            char numberOfMines = CheckSurroundingMinesCount(minesField, row, col);
            minesField[row, col] = numberOfMines;
            gameField[row, col] = numberOfMines;
        }

        private static void PrintField(char[,] board)
        {
            int numberOfRows = board.GetLength(0);
            int numberOfCols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < numberOfRows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < numberOfCols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] GenerateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] DistributeMines()
        {
            int rows = 5;
            int columns = 10;
            char[,] gameField = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            List<int> uniqueRandomNumbers = new List<int>();
            while (uniqueRandomNumbers.Count < 15)
            {
                Random randomGenerator = new Random();
                int randomNumber = randomGenerator.Next(50);
                if (!uniqueRandomNumbers.Contains(randomNumber))
                {
                    uniqueRandomNumbers.Add(randomNumber);
                }
            }

            foreach (int randomNumber in uniqueRandomNumbers)
            {
                int col = randomNumber / columns;
                int row = randomNumber % columns;
                if (row == 0 && randomNumber != 0)
                {
                    col--;
                    row = columns;
                }
                else
                {
                    row++;
                }

                gameField[col, row - 1] = '*';
            }

            return gameField;
        }

        private static void SetSurroundingMinesCountOnGameField(char[,] gameField)
        {
            int numberOfRows = gameField.GetLength(0);
            int numberOfCols = gameField.GetLength(1);

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfCols; j++)
                {
                    if (gameField[i, j] != '*')
                    {
                        char numberOfSurroundingMines = CheckSurroundingMinesCount(gameField, i, j);
                        gameField[i, j] = numberOfSurroundingMines;
                    }
                }
            }
        }

        private static char CheckSurroundingMinesCount(char[,] gameField, int row, int col)
        {
            int surroundingMinesCount = 0;
            int rows = gameField.GetLength(0);
            int cols = gameField.GetLength(1);

            if (row - 1 >= 0)
            {
                if (gameField[row - 1, col] == '*')
                {
                    surroundingMinesCount++;
                }
            }

            if (row + 1 < rows)
            {
                if (gameField[row + 1, col] == '*')
                {
                    surroundingMinesCount++;
                }
            }

            if (col - 1 >= 0)
            {
                if (gameField[row, col - 1] == '*')
                {
                    surroundingMinesCount++;
                }
            }

            if (col + 1 < cols)
            {
                if (gameField[row, col + 1] == '*')
                {
                    surroundingMinesCount++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (gameField[row - 1, col - 1] == '*')
                {
                    surroundingMinesCount++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (gameField[row - 1, col + 1] == '*')
                {
                    surroundingMinesCount++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (gameField[row + 1, col - 1] == '*')
                {
                    surroundingMinesCount++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (gameField[row + 1, col + 1] == '*')
                {
                    surroundingMinesCount++;
                }
            }

            return char.Parse(surroundingMinesCount.ToString());
        }
    }
}
