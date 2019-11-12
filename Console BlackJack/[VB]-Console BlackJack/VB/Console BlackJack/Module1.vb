Module Module1

    Dim deck() As String
    Dim r As New Random

    Private Structure value
        Dim cardName As String
        Dim cardValue As Integer
        Public Sub New(ByVal cn As String, ByVal cv As Integer)
            Me.cardName = cn
            Me.cardValue = cv
        End Sub
    End Structure

    Dim values As New List(Of value)

    Dim gamesPlayed As Integer
    Dim youWon As Integer
    Dim dealerWon As Integer

    Dim balance As Decimal = 100D
    Dim bet As Decimal

    Sub Main()

        Dim hearts() As String = Enumerable.Range(2, 9).Select(Function(x) x.ToString & Chr(3)).ToArray
        hearts = hearts.Concat(New String() {"J" & Chr(3), "Q" & Chr(3), "K" & Chr(3), "A" & Chr(3)}).ToArray

        Dim diamonds() As String = Enumerable.Range(2, 9).Select(Function(x) x.ToString & Chr(4)).ToArray
        diamonds = diamonds.Concat(New String() {"J" & Chr(4), "Q" & Chr(4), "K" & Chr(4), "A" & Chr(4)}).ToArray

        Dim clubs() As String = Enumerable.Range(2, 9).Select(Function(x) x.ToString & Chr(5)).ToArray
        clubs = clubs.Concat(New String() {"J" & Chr(5), "Q" & Chr(5), "K" & Chr(5), "A" & Chr(5)}).ToArray

        Dim spades() As String = Enumerable.Range(2, 9).Select(Function(x) x.ToString & Chr(6)).ToArray
        spades = spades.Concat(New String() {"J" & Chr(6), "Q" & Chr(6), "K" & Chr(6), "A" & Chr(6)}).ToArray

        values.Add(New value("2", 2))
        values.Add(New value("3", 3))
        values.Add(New value("4", 4))
        values.Add(New value("5", 5))
        values.Add(New value("6", 6))
        values.Add(New value("7", 7))
        values.Add(New value("8", 8))
        values.Add(New value("9", 9))
        values.Add(New value("10", 10))
        values.Add(New value("J", 10))
        values.Add(New value("Q", 10))
        values.Add(New value("K", 10))
        values.Add(New value("A", 11))

        Dim playAgain As String


        Do
            playAgain = If(balance > 0, playAHand(), "n")

            If playAgain.ToLower = "y" Then

                deck = hearts.Concat(diamonds).Concat(clubs).Concat(spades).ToArray
                shuffle()

                Dim dealersHand() As String = deal(2)
                Dim playersHand() As String = deal(2)

                Dim dealerScore As Integer = dealersHand.Sum(Function(c) values.First(Function(v) If(Val(c) > 0, Val(c).ToString = v.cardName, c.StartsWith(v.cardName))).cardValue)
                If dealerScore = 22 Then dealerScore = 12
                Dim playerScore As Integer = playersHand.Sum(Function(c) values.First(Function(v) If(Val(c) > 0, Val(c).ToString = v.cardName, c.StartsWith(v.cardName))).cardValue)
                If playerScore = 22 Then playerScore = 12

                showCards("Your hand: ", playersHand)

                Console.WriteLine()

                If playerScore = 21 And Not dealerScore = 21 Then
                    Console.WriteLine("BlackJack! You win.")
                    Console.WriteLine()
                    showCards("Dealer's hand: ", dealersHand)
                    updateStats("user")
                ElseIf playerScore = 21 And dealerScore = 21 Then
                    showCards("Dealer's hand: ", dealersHand)
                    Console.WriteLine("It's a draw. No one wins.")
                    updateStats("draw")
                ElseIf (Not playerScore = 21 And Not dealerScore = 21) OrElse (Not playerScore = 21 And dealerScore = 21) Then
                    playGame("user", playerScore, dealerScore, playersHand, dealersHand)
                End If
            End If
            Console.WriteLine()
        Loop While playAgain.ToLower = "y"

        Console.ReadLine()
    End Sub

    Private Function playAHand() As String
        Console.WriteLine("Play a hand? (y/n)")
        Dim response As String = Console.ReadLine
        If response.ToLower = "y" Then
            Console.Clear()
            Console.WriteLine("Hands played: {0}", gamesPlayed)
            Console.WriteLine("You won: {0}, Dealer won: {1}", youWon, dealerWon)
            Console.WriteLine("Balance: {0:c2}", balance)

            If balance = 0 Then
                Console.WriteLine("Zero balance")
                Return "n"
            End If

            Do
                Console.WriteLine("How much would you like to bet?")
                If Decimal.TryParse(Console.ReadLine, bet) AndAlso bet <= balance AndAlso bet > 0 Then
                    Console.WriteLine()
                    Console.WriteLine("Bet: {0:c2}", bet)
                    Exit Do
                Else
                    Console.WriteLine()
                    Console.WriteLine("Invalid bet")
                End If
            Loop
        End If
        Return response
    End Function

    Private Sub playGame(ByVal player As String, ByVal score1 As Integer, ByVal score2 As Integer, ByVal hand1() As String, ByVal hand2() As String)
        Dim response As String = ""
        If player = "user" Then
            Console.WriteLine("Twist? (y/n)")
            response = Console.ReadLine
            Console.WriteLine()
        Else
            response = "y"
        End If
        If response.ToLower = "y" Then

            hand1 = hand1.Concat(deal(1)).ToArray

            If player = "user" Then
                showCards("Your hand: ", hand1)
                Console.WriteLine()
            End If

            score1 = hand1.Sum(Function(c) values.First(Function(v) If(Val(c) > 0, Val(c).ToString = v.cardName, c.StartsWith(v.cardName))).cardValue)

            If player = "user" Then
                If score1 > 21 And Not (score1 - (hand1.Count(Function(c) c.StartsWith("A")) * 10) <= 21) Then
                    showCards("Dealer's hand: ", If(player = "user", hand2, hand1))
                    Console.WriteLine()
                    updateStats(winner(player, hand1, hand2))
                ElseIf score1 > 21 And (score1 - (hand1.Count(Function(c) c.StartsWith("A")) * 10) <= 21) Then
                    Dim count As Integer = 0
                    While count < hand1.Count(Function(c) c.StartsWith("A")) And score1 > 21
                        count += 1
                        score1 -= 10
                    End While
                    If score1 < 21 Then
                        playGame("user", score1, score2, hand1, hand2)
                    Else
                        showCards("Dealer's hand: ", hand2)
                        updateStats(winner(player, hand1, hand2))
                    End If
                ElseIf score1 < 21 Then
                    playGame("user", score1, score2, hand1, hand2)
                ElseIf score1 = 21 Then
                    playGame("dealer", score2, score1, hand2, hand1)
                End If
            Else
                If score1 < 17 Then
                    playGame("dealer", score1, score2, hand1, hand2)
                Else
                    If score1 < 20 Then
                        If r.Next(0, 4) = 1 Then
                            playGame("dealer", score1, score2, hand1, hand2)
                        Else
                            showCards("Dealer's hand: ", hand1)
                            updateStats(winner(player, hand1, hand2))
                        End If
                    ElseIf score1 > 21 And (score1 - (hand1.Count(Function(c) c.StartsWith("A")) * 10) <= 21) Then
                        Dim count As Integer = 0
                        While count < hand1.Count(Function(c) c.StartsWith("A")) And score1 > 21
                            count += 1
                            score1 -= 10
                        End While
                        If score1 < 21 Then
                            playGame("dealer", score1, score2, hand1, hand2)
                        Else
                            showCards("Dealer's hand: ", hand1)
                            updateStats(winner(player, hand1, hand2))
                        End If
                    Else
                        showCards("Dealer's hand: ", hand1)
                        updateStats(winner(player, hand1, hand2))
                    End If
                End If
            End If
        Else
            If score2 < 17 Then
                playGame("dealer", score2, score1, hand2, hand1)
            Else
                If score2 < 20 Then
                    If r.Next(0, 4) = 1 Then
                        playGame("dealer", score2, score1, hand2, hand1)
                    Else
                        showCards("Dealer's hand: ", hand2)
                        updateStats(winner(player, hand1, hand2))
                    End If
                Else
                    showCards("Dealer's hand: ", hand2)
                    updateStats(winner(player, hand1, hand2))
                End If
            End If
        End If
    End Sub

    Private Function winner(ByVal player As String, ByVal hand1() As String, ByVal hand2() As String) As String
        Dim score1 As Integer = hand1.Sum(Function(c) values.First(Function(v) If(Val(c) > 0, Val(c).ToString = v.cardName, c.StartsWith(v.cardName))).cardValue)
        Dim count As Integer = 0
        While count < hand1.Count(Function(c) c.StartsWith("A")) And score1 > 21
            count += 1
            score1 -= 10
        End While

        Dim score2 As Integer = hand2.Sum(Function(c) values.First(Function(v) If(Val(c) > 0, Val(c).ToString = v.cardName, c.StartsWith(v.cardName))).cardValue)
        count = 0
        While count < hand2.Count(Function(c) c.StartsWith("A")) And score2 > 21
            count += 1
            score2 -= 10
        End While

        If player = "user" Then
            If score1 <= 21 AndAlso score2 <= 21 Then
                If score1 > score2 Then
                    Console.WriteLine("You win.")
                    Return "user"
                ElseIf score2 > score1 Then
                    Console.WriteLine("Dealer wins.")
                    Return "dealer"
                Else 'draw
                    Console.WriteLine("No one wins.")
                    Return "draw"
                End If
            Else
                If score1 > 21 Then
                    Console.WriteLine("You bust. Dealer wins.")
                    Return "dealer"
                Else 'score2 > 21
                    Console.WriteLine("Dealer bust. You win.")
                    Return "user"
                End If
            End If
        Else '"dealer"
            If score1 <= 21 AndAlso score2 <= 21 Then
                If score2 > score1 Then
                    Console.WriteLine("You win.")
                    Return "user"
                ElseIf score1 > score2 Then
                    Console.WriteLine("Dealer wins.")
                    Return "dealer"
                Else 'draw
                    Console.WriteLine("No one wins.")
                    Return "draw"
                End If
            Else
                If score2 > 21 Then
                    Console.WriteLine("You bust. Dealer wins.")
                    Return "dealer"
                Else 'score1 > 21
                    Console.WriteLine("Dealer bust. You win.")
                    Return "user"
                End If
            End If
        End If

    End Function

    Private Sub shuffle()
        deck = deck.OrderBy(Function(x) r.NextDouble).ToArray
    End Sub

    Private Function deal(ByVal count As Integer) As String()
        Dim a() As String = deck.Take(count).ToArray
        deck = deck.Except(a).ToArray
        Return a
    End Function

    Private Sub showCards(ByVal label As String, ByVal cards() As String)
        Console.Write(label)

        Dim reds() As String = {Chr(3), Chr(4)}
        For x As Integer = 0 To cards.GetUpperBound(0)
            Console.ForegroundColor = If(reds.Any(Function(s) cards(x).Contains(s)), ConsoleColor.Red, ConsoleColor.Gray)
            Console.Write(cards(x) & " ")
        Next x

        Dim cardSum As Integer = cards.Sum(Function(c) values.First(Function(v) If(Val(c) > 0, Val(c).ToString = v.cardName, c.StartsWith(v.cardName))).cardValue)
        Dim count As Integer = 0
        While count < cards.Count(Function(c) c.StartsWith("A")) And cardSum > 21
            count += 1
            cardSum -= 10
        End While

        Console.ForegroundColor = ConsoleColor.White

        Console.Write("({0})", cardSum)
        Console.WriteLine(vbCrLf)
    End Sub

    Private Sub updateStats(ByVal winner As String)
        gamesPlayed += 1
        youWon += If(winner = "user", 1, 0)
        dealerWon += If(winner = "dealer", 1, 0)
        balance += If(winner = "user", bet, If(winner = "dealer", -bet, 0))
    End Sub

End Module
