Imports System.Text

Public Class NeuralNet
    Shared r As New Random

    Public Class Dendrite
        Dim _weight As Double

        Property Weight As Double
            Get
                Return _weight
            End Get
            Set(value As Double)
                _weight = value
            End Set
        End Property

        Public Sub New()
            Me.Weight = r.NextDouble()
        End Sub
    End Class

    Public Class Neuron
        Dim _dendrites As New List(Of Dendrite)
        Dim _dendriteCount As Integer
        Dim _bias As Double
        Dim _value As Double
        Dim _delta As Double

        Public Property Dendrites As List(Of Dendrite)
            Get
                Return _dendrites
            End Get
            Set(value As List(Of Dendrite))
                _dendrites = value
            End Set
        End Property

        Public Property Bias As Double
            Get
                Return _bias
            End Get
            Set(value As Double)
                _bias = value
            End Set
        End Property

        Public Property Value As Double
            Get
                Return _value
            End Get
            Set(value As Double)
                _value = value
            End Set
        End Property

        Public Property Delta As Double
            Get
                Return _delta
            End Get
            Set(value As Double)
                _delta = value
            End Set
        End Property

        Public ReadOnly Property DendriteCount As Integer
            Get
                Return _dendrites.Count
            End Get
        End Property

        Public Sub New()
            Me.Bias = r.NextDouble()
        End Sub
    End Class

    Public Class Layer
        Dim _neurons As New List(Of Neuron)
        Dim _neuronCount As Integer

        Public Property Neurons As List(Of Neuron)
            Get
                Return _neurons
            End Get
            Set(value As List(Of Neuron))
                _neurons = value
            End Set
        End Property

        Public ReadOnly Property NeuronCount As Integer
            Get
                Return _neurons.Count
            End Get
        End Property

        Public Sub New(neuronNum As Integer)
            _neuronCount = neuronNum
        End Sub
    End Class

    Public Class NeuralNetwork
        Dim _layers As New List(Of Layer)
        Dim _learningRate As Double

        Public Property Layers As List(Of Layer)
            Get
                Return _layers
            End Get
            Set(value As List(Of Layer))
                _layers = value
            End Set
        End Property

        Public Property LearningRate As Double
            Get
                Return _learningRate
            End Get
            Set(value As Double)
                _learningRate = value
            End Set
        End Property

        Public ReadOnly Property LayerCount As Integer
            Get
                Return _layers.Count
            End Get
        End Property

        Sub New(LearningRate As Double, nLayers As List(Of Integer))
            If nLayers.Count < 2 Then Exit Sub

            Me.LearningRate = LearningRate

            For ii As Integer = 0 To nLayers.Count - 1

                Dim l As Layer = New Layer(nLayers(ii) - 1)
                Me.Layers.Add(l)

                For jj As Integer = 0 To nLayers(ii) - 1
                    l.Neurons.Add(New Neuron())
                Next

                For Each n As Neuron In l.Neurons
                    If ii = 0 Then n.Bias = 0

                    If ii > 0 Then
                        For k As Integer = 0 To nLayers(ii - 1) - 1
                            n.Dendrites.Add(New Dendrite)
                        Next
                    End If

                Next

            Next
        End Sub

        Function Execute(inputs As List(Of Double)) As List(Of Double)
            If inputs.Count <> Me.Layers(0).NeuronCount Then
                Return Nothing
            End If

            For ii As Integer = 0 To Me.LayerCount - 1
                Dim curLayer As Layer = Me.Layers(ii)

                For jj As Integer = 0 To curLayer.NeuronCount - 1
                    Dim curNeuron As Neuron = curLayer.Neurons(jj)

                    If ii = 0 Then
                        curNeuron.Value = inputs(jj)
                    Else
                        curNeuron.Value = 0
                        For k = 0 To Me.Layers(ii - 1).NeuronCount - 1
                            curNeuron.Value = curNeuron.Value + Me.Layers(ii - 1).Neurons(k).Value * curNeuron.Dendrites(k).Weight
                        Next k

                        curNeuron.Value = Sigmoid(curNeuron.Value + curNeuron.Bias)
                    End If

                Next
            Next

            Dim outputs As New List(Of Double)
            Dim la As Layer = Me.Layers(Me.LayerCount - 1)
            For ii As Integer = 0 To la.NeuronCount - 1
                outputs.Add(la.Neurons(ii).Value)
            Next

            Return outputs
        End Function

        Private Function Sigmoid(Value As Double) As Double
            Return 1 / (1 + Math.Exp(Value * -1))
        End Function

        Public Overrides Function ToString() As String
            Dim nstr As New StringBuilder()

            For Each l As Layer In Me.Layers
                nstr.AppendLine("--+-- Layer")
                nstr.AppendLine("  |   Neurons: " & l.NeuronCount)

                For Each n As Neuron In l.Neurons

                    nstr.AppendLine("  |--+-- Neuron")
                    nstr.AppendLine("  |  |   Bias: " & n.Bias)
                    nstr.AppendLine("  |  |   Delta: " & n.Delta)
                    nstr.AppendLine("  |  |   Value: " & n.Value)
                    nstr.AppendLine("  |  |   Dendrites: " & n.DendriteCount)

                    For Each d As Dendrite In n.Dendrites
                        nstr.AppendLine("  |  |--+-- Dendrite")
                        nstr.AppendLine("  |  |  |   Weight: " & d.Weight)
                    Next

                Next
            Next

            nstr.Append("====== EONN ======")
            Return nstr.ToString
        End Function

        Public Function Train(inputs As List(Of Double), outputs As List(Of Double)) As Boolean
            If inputs.Count <> Me.Layers(0).NeuronCount Or outputs.Count <> Me.Layers(Me.LayerCount - 1).NeuronCount Then
                Return False
            End If

            Execute(inputs)

            For ii = 0 To Me.Layers(Me.LayerCount - 1).NeuronCount - 1
                Dim curNeuron As Neuron = Me.Layers(Me.LayerCount - 1).Neurons(ii)

                curNeuron.Delta = curNeuron.Value * (1 - curNeuron.Value) * (outputs(ii) - curNeuron.Value)

                For jj = Me.LayerCount - 2 To 1 Step -1
                    For kk = 0 To Me.Layers(jj).NeuronCount - 1
                        Dim iNeuron As Neuron = Me.Layers(jj).Neurons(kk)

                        iNeuron.Delta = iNeuron.Value *
                                        (1 - iNeuron.Value) * Me.Layers(jj + 1).Neurons(ii).Dendrites(kk).Weight *
                                        Me.Layers(jj + 1).Neurons(ii).Delta
                    Next kk
                Next jj
            Next ii


            For ii = Me.LayerCount - 1 To 0 Step -1
                For jj = 0 To Me.Layers(ii).NeuronCount - 1
                    Dim iNeuron As Neuron = Me.Layers(ii).Neurons(jj)
                    iNeuron.Bias = iNeuron.Bias + (Me.LearningRate * iNeuron.Delta)

                    For kk = 0 To iNeuron.DendriteCount - 1
                        iNeuron.Dendrites(kk).Weight = iNeuron.Dendrites(kk).Weight + (Me.LearningRate * Me.Layers(ii - 1).Neurons(kk).Value * iNeuron.Delta)
                    Next kk
                Next jj
            Next ii

            Return True
        End Function

        Public Sub Draw(ByVal hDC As Graphics, ByVal startX As Integer, ByVal startY As Integer, ByVal scale As Integer, ByVal hspace As Integer, ByVal vspace As Integer, ByVal iColor As Color, ByVal hColor As Color, ByVal oColor As Color)
            Dim i As Integer
            Dim k As Integer
            Dim j As Integer

            Dim x As Integer
            Dim y As Integer

            hDC.Clear(Color.White)
            For i = 0 To Me.LayerCount - 1
                x = startX - hspace * (Me.Layers(i).NeuronCount / 2)
                y = startY - (vspace * i)

                For k = 0 To Me.Layers(i).NeuronCount - 1
                    Dim b As SolidBrush
                    Dim p As Pen
                    Select Case i
                        Case 0
                            b = New SolidBrush(iColor)
                            p = New Pen(iColor)
                            hDC.DrawEllipse(p, x, y, scale, scale)
                            hDC.FillEllipse(b, x, y, scale, scale)
                        Case Me.LayerCount - 1
                            b = New SolidBrush(oColor)
                            p = New Pen(oColor)
                            hDC.DrawEllipse(p, x, y, scale, scale)
                            hDC.FillEllipse(b, x, y, scale, scale)
                        Case Else
                            b = New SolidBrush(hColor)
                            p = New Pen(hColor)
                            hDC.DrawEllipse(p, x, y, scale, scale)
                            hDC.FillEllipse(b, x, y, scale, scale)
                    End Select
                    b.Dispose()
                    p.Dispose()

                    If i > 0 Then
                        Dim denX1 As Integer = x + (scale / 2)
                        Dim denY1 As Integer = y + scale
                        Dim denX2 As Integer = (startX - hspace * (Me.Layers(i - 1).NeuronCount / 2)) + (scale / 2)
                        Dim denY2 As Integer = y + vspace
                        For j = 0 To Me.Layers(i).Neurons(k).DendriteCount - 1
                            hDC.DrawLine(Pens.Black, denX1, denY1, denX2, denY2)
                            denX2 = denX2 + hspace
                        Next
                    End If
                    x = x + hspace

                Next
            Next
        End Sub

    End Class
End Class
