using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweNug.SignalR.Server
{
    public class Game : Hub
    {
        private static object _syncRoot = new object();
        private static int _gamesPlayed = 0;
        /// <summary>
        /// The list of clients is used to keep track of registered clients and clients that are looking for games
        /// The client will be removed from this list as soon as the client is in a game or has left the game
        /// </summary>
        private static readonly List<Client> clients = new List<Client>();

        /// <summary>
        /// This list is used to keep track of games and their states
        /// </summary>
        private static readonly List<TicTacToe> games = new List<TicTacToe>();

        /// <summary>
        /// Used for fair dice rolls
        /// </summary>
        private static readonly Random random = new Random();

        /// <summary>
        /// When a client disconnects remove the game and announce a walk-over if there's a game in place then the client is removed from the clients and game list
        /// </summary>
        /// <returns>If the operation takes long, run it asynchronously and return the task in which it runs</returns>
        public override Task OnDisconnected()
        {
            var game = games.FirstOrDefault(x => x.Player1.ConnectionId == Context.ConnectionId || x.Player2.ConnectionId == Context.ConnectionId);
            if (game == null)
            {
                // Client without game?
                var clientWithoutGame = clients.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
                if (clientWithoutGame != null)
                {
                    clients.Remove(clientWithoutGame);

                    SendStatsUpdate();
                }
                return null;
            }

            if (game != null)
            {
                games.Remove(game);
            }

            var client = game.Player1.ConnectionId == Context.ConnectionId ? game.Player1 : game.Player2;

            if (client == null) return null;

            clients.Remove(client);
            if (client.Opponent != null)
            {
                SendStatsUpdate();
                return Clients.Client(client.Opponent.ConnectionId).opponentDisconnected(client.Name);
            }
            return null;
        }

        public override Task OnConnected()
        {
            return SendStatsUpdate();
        }

        public Task SendStatsUpdate()
        {
            return Clients.All.refreshAmountOfPlayers(new { totalGamesPlayed = _gamesPlayed, amountOfGames = games.Count, amountOfClients = clients.Count });
        }
        /// <summary>
        /// registering a new client will add the client to the current list of clients and save the connection id which will be used to communicate with the client
        /// </summary>
        /// <param name="data">The player name</param>
        public void RegisterClient(string data)
        {
            lock (_syncRoot)
            {
                var client = clients.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
                if (client == null)
                {
                    client = new Client { ConnectionId = Context.ConnectionId, Name = data };
                    clients.Add(client);
                }

                client.IsPlaying = false;
            }

            SendStatsUpdate();
            Clients.Client(Context.ConnectionId).registerComplete();
        }

        /// <summary>
        /// Play a marker at a given positon
        /// </summary>
        /// <param name="position">The position where to place the marker</param>
        public void Play(int position)
        {
            // Find the game where there is a player1 and player2 and either of them have the current connection id
            var game = games.FirstOrDefault(x => x.Player1.ConnectionId == Context.ConnectionId || x.Player2.ConnectionId == Context.ConnectionId);

            if (game == null || game.IsGameOver) return;

            int marker = 0;

            // Detect if the player connected is player 1 or player 2
            if (game.Player2.ConnectionId == Context.ConnectionId)
            {
                marker = 1;
            }
            var player = marker == 0 ? game.Player1 : game.Player2;

            // If the player is waiting for the opponent but still tried to make a move, just return
            if (player.WaitingForMove) return;

            // Notify both players that a marker has been placed
            Clients.Client(game.Player1.ConnectionId).addMarkerPlacement(new GameInformation { OpponentName = player.Name, MarkerPosition = position, Simbolo = player.Simbolo });
            Clients.Client(game.Player2.ConnectionId).addMarkerPlacement(new GameInformation { OpponentName = player.Name, MarkerPosition = position, Simbolo = player.Simbolo });

            // Place the marker and look for a winner
            if (game.Play(marker, position))
            {
                games.Remove(game);
                _gamesPlayed += 1;
                Clients.Client(game.Player1.ConnectionId).gameOver(player.Name);
                Clients.Client(game.Player2.ConnectionId).gameOver(player.Name);
            }

            // If it's a draw notify the players that the game is over
            if (game.IsGameOver && game.IsDraw)
            {
                games.Remove(game);
                _gamesPlayed += 1;
                Clients.Client(game.Player1.ConnectionId).gameOver("Draw! no winner");
                Clients.Client(game.Player2.ConnectionId).gameOver("Draw! no winner");
            }

            if (!game.IsGameOver)
            {
                player.WaitingForMove = !player.WaitingForMove;
                player.Opponent.WaitingForMove = !player.Opponent.WaitingForMove;

                Clients.Client(player.Opponent.ConnectionId).waitingForMarkerPlacement(player.Name);
            }

            SendStatsUpdate();
        }

        /// <summary>
        /// Mark the client as lookiner for opponent. This will use the current connection id to identify the current client and mark it as ready for battle.
        /// Once two clients are looking for opponents these two will be matched together and a fair dice roll for whos turn it is will be done.
        /// </summary>
        public void FindOpponent()
        {
            var player = clients.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (player == null) return;
            player.LookingForOpponent = true;

            // Look for a random opponent if there's more than one looking for a game
            var opponent = clients.Where(x => x.ConnectionId != Context.ConnectionId && x.LookingForOpponent && !x.IsPlaying).OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            if (opponent == null)
            {
                Clients.Client(Context.ConnectionId).noOpponents();
                return;
            }

            // Set both players as busy
            player.IsPlaying = true;
            player.LookingForOpponent = false;
            player.Simbolo = "X";

            opponent.IsPlaying = true;
            opponent.LookingForOpponent = false;
            opponent.Simbolo = "O";

            player.Opponent = opponent;
            opponent.Opponent = player;

            // Notify both players that a game was found
            Clients.Client(Context.ConnectionId).foundOpponent(opponent.Name, "/Content/Images/TicTacToeX.png");
            Clients.Client(opponent.ConnectionId).foundOpponent(player.Name, "/Content/Images/TicTacToeO.png");

            // Fair dice roll
            if (random.Next(0, 5000) % 2 == 0)
            {
                player.WaitingForMove = false;
                opponent.WaitingForMove = true;

                Clients.Client(player.ConnectionId).waitingForMarkerPlacement(opponent.Name);
                Clients.Client(opponent.ConnectionId).waitingForOpponent(opponent.Name);
            }
            else
            {
                player.WaitingForMove = true;
                opponent.WaitingForMove = false;

                Clients.Client(opponent.ConnectionId).waitingForMarkerPlacement(opponent.Name);
                Clients.Client(player.ConnectionId).waitingForOpponent(opponent.Name);
            }

            lock (_syncRoot)
            {
                games.Add(new TicTacToe { Player1 = player, Player2 = opponent });
            }

            SendStatsUpdate();
        }
    }
}