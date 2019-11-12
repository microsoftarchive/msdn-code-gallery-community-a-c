using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_BlackJack_cs
{
    class Program
    {


        static string[] deck;
        static Random r = new Random();

        private struct value
        {
            public string cardName;
            public int cardValue;
            public value(string cn, int cv)
            {
                this.cardName = cn;
                this.cardValue = cv;
            }
        }

        static List<value> values = new List<value>();

        static int gamesPlayed;
        static int youWon;
        static int dealerWon;

        static decimal balance = 100m;
        static decimal bet;

        static void Main(string[] args)
        {

            string[] hearts = Enumerable.Range(2, 9).Select(x => x.ToString() + (Char)3).ToArray();
            hearts = hearts.Concat(new string[] {
	                            "J" + (Char)3,
	                            "Q" + (Char)3,
	                            "K" + (Char)3,
	                            "A" + (Char)3
                            }).ToArray();

            string[] diamonds = Enumerable.Range(2, 9).Select(x => x.ToString() + (Char)4).ToArray();
            diamonds = diamonds.Concat(new string[] {
	                            "J" + (Char)4,
	                            "Q" + (Char)4,
	                            "K" + (Char)4,
	                            "A" + (Char)4
                            }).ToArray();

            string[] clubs = Enumerable.Range(2, 9).Select(x => x.ToString() + (Char)5).ToArray();
            clubs = clubs.Concat(new string[] {
	                            "J" + (Char)5,
	                            "Q" + (Char)5,
	                            "K" + (Char)5,
	                            "A" + (Char)5
                            }).ToArray();

            string[] spades = Enumerable.Range(2, 9).Select(x => x.ToString() + (Char)6).ToArray();
            spades = spades.Concat(new string[] {
	                            "J" + (Char)6,
	                            "Q" + (Char)6,
	                            "K" + (Char)6,
	                            "A" + (Char)6
                            }).ToArray();

            values.Add(new value("2", 2));
            values.Add(new value("3", 3));
            values.Add(new value("4", 4));
            values.Add(new value("5", 5));
            values.Add(new value("6", 6));
            values.Add(new value("7", 7));
            values.Add(new value("8", 8));
            values.Add(new value("9", 9));
            values.Add(new value("10", 10));
            values.Add(new value("J", 10));
            values.Add(new value("Q", 10));
            values.Add(new value("K", 10));
            values.Add(new value("A", 11));

            string playAgain = null;


            do
            {
                playAgain = balance > 0 ? playAHand() : "n";


                if (playAgain.ToLower() == "y")
                {
                    deck = hearts.Concat(diamonds).Concat(clubs).Concat(spades).ToArray();
                    shuffle();

                    string[] dealersHand = deal(2);
                    string[] playersHand = deal(2);

                    int dealerScore = dealersHand.Sum(c => values.First(v => val(c) > 0 ? val(c).ToString() == v.cardName : c.StartsWith(v.cardName)).cardValue);
                    if (dealerScore == 22)
                        dealerScore = 12;
                    int playerScore = playersHand.Sum(c => values.First(v => val(c) > 0 ? val(c).ToString() == v.cardName : c.StartsWith(v.cardName)).cardValue);
                    if (playerScore == 22)
                        playerScore = 12;

                    showCards("Your hand: ", playersHand);

                    Console.WriteLine();

                    if (playerScore == 21 & !(dealerScore == 21))
                    {
                        Console.WriteLine("BlackJack! You win.");
                        Console.WriteLine();
                        showCards("Dealer's hand: ", dealersHand);
                        updateStats("user");
                    }
                    else if (playerScore == 21 & dealerScore == 21)
                    {
                        showCards("Dealer's hand: ", dealersHand);
                        Console.WriteLine("It's a draw. No one wins.");
                        updateStats("draw");
                    }
                    else if ((!(playerScore == 21) & !(dealerScore == 21)) || (!(playerScore == 21) & dealerScore == 21))
                    {
                        playGame("user", playerScore, dealerScore, playersHand, dealersHand);
                    }
                }
                Console.WriteLine();
            } while (playAgain.ToLower() == "y");

            Console.ReadLine();
        }

        private static int val(string c)
        {
            string faceValue = c.Replace(((Char)3).ToString(), "").Replace(((Char)4).ToString(), "").Replace(((Char)5).ToString(), "").Replace(((Char)6).ToString(), "");
            int value;
            Int32.TryParse(faceValue, out value);
            return value;
        }

        private static string playAHand()
        {
            Console.WriteLine("Play a hand? (y/n)");
            string response = Console.ReadLine();
            if (response.ToLower() == "y")
            {
                Console.Clear();
                Console.WriteLine("Hands played: {0}", gamesPlayed);
                Console.WriteLine("You won: {0}, Dealer won: {1}", youWon, dealerWon);
                Console.WriteLine("Balance: {0:c2}", balance);

                if (balance == 0)
                {
                    Console.WriteLine("Zero balance");
                    return "n";
                }

                do
                {
                    Console.WriteLine("How much would you like to bet?");
                    if (decimal.TryParse(Console.ReadLine(), out bet) && bet <= balance && bet > 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Bet: {0:c2}", bet);
                        break; // TODO: might not be correct. Was : Exit Do
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid bet");
                    }
                } while (true);
            }
            return response;
        }

        private static void playGame(string player, int score1, int score2, string[] hand1, string[] hand2)
        {
            string response = "";
            if (player == "user")
            {
                Console.WriteLine("Twist? (y/n)");
                response = Console.ReadLine();
                Console.WriteLine();
            }
            else
            {
                response = "y";
            }

            if (response.ToLower() == "y")
            {
                hand1 = hand1.Concat(deal(1)).ToArray();

                if (player == "user")
                {
                    showCards("Your hand: ", hand1);
                    Console.WriteLine();
                }

                score1 = hand1.Sum(c => values.First(v => val(c) > 0 ? val(c).ToString() == v.cardName : c.StartsWith(v.cardName)).cardValue);

                if (player == "user")
                {
                    if (score1 > 21 & !(score1 - (hand1.Count(c => c.StartsWith("A")) * 10) <= 21))
                    {
                        showCards("Dealer's hand: ", player == "user" ? hand2 : hand1);
                        Console.WriteLine();
                        updateStats(winner(player, hand1, hand2));
                    }
                    else if (score1 > 21 & (score1 - (hand1.Count(c => c.StartsWith("A")) * 10) <= 21))
                    {
                        int count = 0;
                        while (count < hand1.Count(c => c.StartsWith("A")) & score1 > 21)
                        {
                            count += 1;
                            score1 -= 10;
                        }
                        if (score1 < 21)
                        {
                            playGame("user", score1, score2, hand1, hand2);
                        }
                        else
                        {
                            showCards("Dealer's hand: ", hand2);
                            updateStats(winner(player, hand1, hand2));
                        }
                    }
                    else if (score1 < 21)
                    {
                        playGame("user", score1, score2, hand1, hand2);
                    }
                    else if (score1 == 21)
                    {
                        playGame("dealer", score2, score1, hand2, hand1);
                    }
                }
                else
                {
                    if (score1 < 17)
                    {
                        playGame("dealer", score1, score2, hand1, hand2);
                    }
                    else
                    {
                        if (score1 < 20)
                        {
                            if (r.Next(0, 4) == 1)
                            {
                                playGame("dealer", score1, score2, hand1, hand2);
                            }
                            else
                            {
                                showCards("Dealer's hand: ", hand1);
                                updateStats(winner(player, hand1, hand2));
                            }
                        }
                        else if (score1 > 21 & (score1 - (hand1.Count(c => c.StartsWith("A")) * 10) <= 21))
                        {
                            int count = 0;
                            while (count < hand1.Count(c => c.StartsWith("A")) & score1 > 21)
                            {
                                count += 1;
                                score1 -= 10;
                            }
                            if (score1 < 21)
                            {
                                playGame("dealer", score1, score2, hand1, hand2);
                            }
                            else
                            {
                                showCards("Dealer's hand: ", hand1);
                                updateStats(winner(player, hand1, hand2));
                            }
                        }
                        else
                        {
                            showCards("Dealer's hand: ", hand1);
                            updateStats(winner(player, hand1, hand2));
                        }
                    }
                }
            }
            else
            {
                if (score2 < 17)
                {
                    playGame("dealer", score2, score1, hand2, hand1);
                }
                else
                {
                    if (score2 < 20)
                    {
                        if (r.Next(0, 4) == 1)
                        {
                            playGame("dealer", score2, score1, hand2, hand1);
                        }
                        else
                        {
                            showCards("Dealer's hand: ", hand2);
                            updateStats(winner(player, hand1, hand2));
                        }
                    }
                    else
                    {
                        showCards("Dealer's hand: ", hand2);
                        updateStats(winner(player, hand1, hand2));
                    }
                }
            }
        }

        private static string winner(string player, string[] hand1, string[] hand2)
        {
            int score1 = hand1.Sum(c => values.First(v => val(c) > 0 ? val(c).ToString() == v.cardName : c.StartsWith(v.cardName)).cardValue);

            int count = 0;
            while (count < hand1.Count(c => c.StartsWith("A")) & score1 > 21)
            {
                count += 1;
                score1 -= 10;
            }

            int score2 = hand2.Sum(c => values.First(v => val(c) > 0 ? val(c).ToString() == v.cardName : c.StartsWith(v.cardName)).cardValue);

            count = 0;
            while (count < hand2.Count(c => c.StartsWith("A")) & score2 > 21)
            {
                count += 1;
                score2 -= 10;
            }

            if (player == "user")
            {
                if (score1 <= 21 && score2 <= 21)
                {
                    if (score1 > score2)
                    {
                        Console.WriteLine("You win.");
                        return "user";
                    }
                    else if (score2 > score1)
                    {
                        Console.WriteLine("Dealer wins.");
                        return "dealer";
                        //draw
                    }
                    else
                    {
                        Console.WriteLine("No one wins.");
                        return "draw";
                    }
                }
                else
                {
                    if (score1 > 21)
                    {
                        Console.WriteLine("You bust. Dealer wins.");
                        return "dealer";
                        //score2 > 21
                    }
                    else
                    {
                        Console.WriteLine("Dealer bust. You win.");
                        return "user";
                    }
                }
                //"dealer"
            }
            else
            {
                if (score1 <= 21 && score2 <= 21)
                {
                    if (score2 > score1)
                    {
                        Console.WriteLine("You win.");
                        return "user";
                    }
                    else if (score1 > score2)
                    {
                        Console.WriteLine("Dealer wins.");
                        return "dealer";
                        //draw
                    }
                    else
                    {
                        Console.WriteLine("No one wins.");
                        return "draw";
                    }
                }
                else
                {
                    if (score2 > 21)
                    {
                        Console.WriteLine("You bust. Dealer wins.");
                        return "dealer";
                        //score1 > 21
                    }
                    else
                    {
                        Console.WriteLine("Dealer bust. You win.");
                        return "user";
                    }
                }
            }

        }

        private static void shuffle()
        {
            deck = deck.OrderBy(x => r.NextDouble()).ToArray();
        }

        private static string[] deal(int count)
        {
            string[] a = deck.Take(count).ToArray();
            deck = deck.Except(a).ToArray();
            return a;
        }

        private static void showCards(string label, string[] cards)
        {
            Console.Write(label);

            char[] reds = { (Char)3, (Char)4 };

            for (int x = 0; x <= cards.GetUpperBound(0); x++)
            {
                Console.ForegroundColor = reds.Any(s => cards[x].Contains(s)) ? ConsoleColor.Red : ConsoleColor.Gray;
                Console.Write(cards[x] + " ");
            }

            int cardSum = cards.Sum(c => values.First(v => val(c) > 0 ? val(c).ToString() == v.cardName : c.StartsWith(v.cardName)).cardValue);

            int count = 0;
            while (count < cards.Count(c => c.StartsWith("A")) & cardSum > 21)
            {
                count += 1;
                cardSum -= 10;
            }

            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("({0})", cardSum);
            Console.WriteLine();
        }

        private static void updateStats(string winner)
        {
            gamesPlayed += 1;
            youWon += winner == "user" ? 1 : 0;
            dealerWon += winner == "dealer" ? 1 : 0;
            balance += winner == "user" ? bet : winner == "dealer" ? -bet : 0;
        }


    }
}
