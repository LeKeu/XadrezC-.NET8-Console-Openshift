// See https://aka.ms/new-console-template for more information
using Xadrez.Domain.Application.UseCases;
using Xadrez.Domain.Core.Models.Tabuleiro;

Console.WriteLine("Hello, World!");
Tabuleiro tab = new(5, 5);

tab.ColocarPeca(peca, new Posicao(0, 0));

Tela.ImprimirTabuleiro(tab);
