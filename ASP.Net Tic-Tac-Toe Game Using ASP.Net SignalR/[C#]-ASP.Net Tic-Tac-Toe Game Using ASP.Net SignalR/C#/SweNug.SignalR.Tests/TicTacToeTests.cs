using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SweNug.SignalR.Server;

namespace SweNug.SignalR.Tests
{
    [TestClass]
    public class TicTacToeTests
    {
        [TestMethod]
        public void TicTacToe_PlaceFirstRow_Winning()
        {
            var ticTacToe = new TicTacToe();
            ticTacToe.Player1 = new Client { ConnectionId = Guid.NewGuid().ToString() };
            ticTacToe.Player2 = new Client { ConnectionId = Guid.NewGuid().ToString() };

            ticTacToe.Play(0, 0);
            ticTacToe.Play(1, 3);
            ticTacToe.Play(0, 1);
            ticTacToe.Play(1, 7);
            ticTacToe.Play(0, 2);

            Assert.IsTrue(ticTacToe.IsGameOver);
        }
        [TestMethod]
        public void TicTacToe_PlaceSecondRow_Winning()
        {
            var ticTacToe = new TicTacToe();
            ticTacToe.Player1 = new Client { ConnectionId = Guid.NewGuid().ToString() };
            ticTacToe.Player2 = new Client { ConnectionId = Guid.NewGuid().ToString() };

            ticTacToe.Play(0, 0);
            ticTacToe.Play(1, 3);
            ticTacToe.Play(0, 1);
            ticTacToe.Play(1, 4);
            ticTacToe.Play(0, 6);
            ticTacToe.Play(1, 5);

            Assert.IsTrue(ticTacToe.IsGameOver);
        }

        [TestMethod]
        public void TicTacToe_PlaceThirdRow_Winning()
        {
            var ticTacToe = new TicTacToe();
            ticTacToe.Player1 = new Client { ConnectionId = Guid.NewGuid().ToString() };
            ticTacToe.Player2 = new Client { ConnectionId = Guid.NewGuid().ToString() };

            ticTacToe.Play(0, 0);
            ticTacToe.Play(1, 6);
            ticTacToe.Play(0, 1);
            ticTacToe.Play(1, 7);
            ticTacToe.Play(0, 6);
            ticTacToe.Play(1, 8);

            Assert.IsTrue(ticTacToe.IsGameOver);
        }
        [TestMethod]
        public void TicTacToe_PlaceDiagonalOne_Winning()
        {
            var ticTacToe = new TicTacToe();
            ticTacToe.Player1 = new Client { ConnectionId = Guid.NewGuid().ToString() };
            ticTacToe.Player2 = new Client { ConnectionId = Guid.NewGuid().ToString() };

            ticTacToe.Play(0, 0);
            ticTacToe.Play(1, 1);
            ticTacToe.Play(0, 4);
            ticTacToe.Play(1, 7);
            ticTacToe.Play(0, 8);
            ticTacToe.Play(1, 6);

            Assert.IsTrue(ticTacToe.IsGameOver);
        }
        [TestMethod]
        public void TicTacToe_PlaceDiagonalTwo_Winning()
        {
            var ticTacToe = new TicTacToe();
            ticTacToe.Player1 = new Client { ConnectionId = Guid.NewGuid().ToString() };
            ticTacToe.Player2 = new Client { ConnectionId = Guid.NewGuid().ToString() };

            ticTacToe.Play(0, 2);
            ticTacToe.Play(1, 1);
            ticTacToe.Play(0, 4);
            ticTacToe.Play(1, 7);
            ticTacToe.Play(0, 6);
            ticTacToe.Play(1, 8);

            Assert.IsTrue(ticTacToe.IsGameOver);
        }
    }
}
