# Basis of Neural Networks in Visual Basic .NET
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- Visual Basic .NET
## Topics
- Artificial Intelligence
- Neural Network
## Updated
- 09/08/2015
## Description

<h1>Scope</h1>
<p><a href="http://social.technet.microsoft.com/wiki/contents/articles/32140.basis-of-neural-networks-in-visual-basic-net.aspx" target="_blank">In this article</a> (hopefully, the first of a small series), we'll see how to implement a neural network in&nbsp;<strong>Visual
 Basic .NET</strong>, i.e. a model capable of processing input data and adjust its internal mechanics to learn how to produce a desired result. We'll see more on this later. The present article will focus on generic definitions about neural networks and their
 behaviours, offering a simple implementation for the reader to test. In the final paragraph, we will code a small network capable of swapping two variables.&nbsp;</p>
<h1>Introduction</h1>
<h2><a name="A_first_definition"></a>A first definition</h2>
<p><span>The term &quot;neural network&quot; is typically used as a reference to a network or circuit constituted by neurons. We can differentiate two types of neural networks: a) biological and b) artificial. Obviously, speaking about software development, we are here
 referring to artificial ones, but those kind of implementations get their basic model and inspiration from their natural counterparts, so it can be useful to briefly consider the functioning of what we intend when we speak of biological neural networks.&nbsp;</span><br>
<br>
</p>
<h2><a name="Natural_neural_networks"></a>Natural neural networks</h2>
<p><span>Those are networks constituted by biological neurons, and they are typical of living creatures. The neurons/cells are interconnected into the peripheral nervous system or in the central one. In neurosciences, groups of neurons are identified by the
 physiological function they perform.&nbsp;</span><br>
<br>
</p>
<h2><a name="Artificial_neural_networks"></a>Artificial neural networks</h2>
<p><span>Artificial networks are mathematical models, which could be implemented through an electronic medium, which mime the functioning of a biological network. Simply speaking, we will have a set of artificial neurons apt to solve a particular problem in
 the field of artificial intelligence. Like a natural one, an artificial network could &quot;learn&quot;, through time and trial, the nature of a problem, becoming more and more efficient in solving it.&nbsp;</span><br>
<br>
</p>
<h2><a name="Neurons"></a>Neurons</h2>
<p><span>After this simple premise, it should be obvious that in a network, being it natural or artificial, the entity known as &quot;neuron&quot; has a paramount importance, because it receive inputs, and is somewhat responsible of a correct data processing, which end
 in a result. Think about our brain: it's a wonderful supercomputer composed by 86*10^9 neurons (more or less). An amazing number of entities which constantly exchange and store informations, running on 10^14 synapses. Like we've said, artificial models are
 trying to capture and reproduce the basic functioning of a neuron, which is based on 3 main parts:</span></p>
<ul>
<li>Soma, or cellular body </li><li>Axon, the neuron output line </li><li>Dendrite, the neuron input line, which receives the data from other axons through synapses
</li></ul>
<p><span>The soma executes a weighted sum of the input signals, checking if they exceed a certain limit. If they do, the neuron activates itself (resulting in a potential action), staying in a state of quiet otherwise. An artificial model tries to mimic those
 subparts, with the target of creating an array of interconnected entities capable of adjusting itself on the basis of received inputs, costantly checking the produced results against an expected situation.&nbsp;</span></p>
<p><span style="font-size:small">Continue reading at:&nbsp;<a href="http://social.technet.microsoft.com/wiki/contents/articles/32140.basis-of-neural-networks-in-visual-basic-net.aspx" target="_blank">Basis of Neural Networks in Visual Basic .NET</a></span></p>
<p><img id="142326" src="142326-run01.png" alt="" width="869" height="478"></p>
