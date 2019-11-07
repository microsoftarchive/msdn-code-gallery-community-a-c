#language: pt-BR

 Funcionalidade: Visitar a documentação do SpecFlow 
				 Para que facilite a tomada de decisão na hora de utilizar o SpecFlow
				 Eu, como usuário				 
				 Desejo conhecer a documentação oficial. 				 

@mytag
	Cenário: Visualizar a configuração padrão do SpecFlow
	Dado que eu entrei na tela inicial do site SpecFlow
	E cliquei no item "Documentation", no menu horizontal do topo 
	Quando eu clicar em "Configuration" 
	Então devo ser levado para a página  de demonstração da configuração padrão do SpecFlow 
	E deve ser exibido um alert dizendo "Olá mundo, sou o Watin". 
