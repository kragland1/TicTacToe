namespace TicTacToe.Models
{
    public class TicTacToeBoard
    {
        public TicTacToeBoard()
        {
            string[] rows = new string[] { "Top", "Middle", "Bottom" };
            string[] cols = new string[] { "Left", "Middle", "Right" };

            Cells = new List<Cell>();

            foreach (string r in rows)
            {
                foreach (string c in cols)
                {
                    Cell cell = new Cell { Id = r + c };
                    Cells.Add(cell);
                }
            }

        }

        public List<Cell> Cells { get; set; }
        public bool HasWinner { get; set; }
        public string WinningMark { get; set; } = string.Empty;
        public bool HasAllCellsSelected { get; set; }

        public void CheckForWinner()
        {
            HasWinner = false;
            WinningMark = null!;

            if (IsWinner(Cells[0].Mark, Cells[1].Mark, Cells[2].Mark))
            {
                HasWinner = true;
                WinningMark=Cells[0].Mark;
            }
            else if (IsWinner(Cells[3].Mark, Cells[4].Mark, Cells[5].Mark))
            {
                HasWinner= true;
                WinningMark=Cells[3].Mark;
            }
            else if (IsWinner(Cells[6].Mark, Cells[7].Mark, Cells[8].Mark))
            {
                HasWinner = true;
                WinningMark = Cells[6].Mark;
            }
            else if (IsWinner(Cells[0].Mark, Cells[3].Mark, Cells[6].Mark))
            {
                HasWinner = true;
                WinningMark = Cells[0].Mark;
            }
            else if (IsWinner(Cells[1].Mark, Cells[4].Mark, Cells[7].Mark))
            {
                HasWinner = true;
                WinningMark = Cells[1].Mark;
            }
            else if (IsWinner(Cells[2].Mark, Cells[5].Mark, Cells[8].Mark))
            {
                HasWinner = true;
                WinningMark = Cells[2].Mark;
            }
            else if (IsWinner(Cells[0].Mark, Cells[4].Mark, Cells[8].Mark))
            {
                HasWinner = true;
                WinningMark = Cells[0].Mark;
            }
            else if (IsWinner(Cells[2].Mark, Cells[4].Mark, Cells[6].Mark))
            {
                HasWinner = true;
                WinningMark = Cells[2].Mark;
            }

            HasAllCellsSelected = true;

            foreach (Cell cell in Cells)
            {
                if (cell.IsBlank)
                {
                    HasAllCellsSelected = false;
                    return;
                }
            }

        }
        private bool IsWinner(string mark1, string mark2, string mark3)
        {
            return mark1 == mark2 && mark2 == mark3 && !string.IsNullOrEmpty(mark1);
        }
    }
}
