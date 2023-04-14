using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Diagnostics;
using TicTacToe.Models;

namespace TicTacToe.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            var board = new TicTacToeBoard();

            foreach (Cell cell in board.Cells)
            {
                cell.Mark = TempData[cell.Id]?.ToString();
            }
            board.CheckForWinner();

            var model = new TicTacToeViewModel
            {
                Cells = board.Cells,
                Selected = new Cell { Mark = TempData["nextTurn"]?.ToString() ?? "X" },
                IsGameOver = board.HasWinner || board.HasAllCellsSelected
            };

            if(model.IsGameOver)
            {
                TempData["nextTurn"] = "X";
                TempData["message"] = (board.HasWinner) ? $"{board.WinningMark} wins!" : "It's a tie!";
            }
            else
            {
                TempData.Keep();
            }
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Index(TicTacToeViewModel vm)
        {
            TempData[vm.Selected.Id] = vm.Selected.Mark;

            TempData["nextTurn"] = (vm.Selected.Mark == "X") ? "O" : "X";

            return RedirectToAction("Index");
        }

    }
}