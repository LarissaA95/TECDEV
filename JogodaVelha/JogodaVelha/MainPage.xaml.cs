using System;
using static System.Net.Mime.MediaTypeNames;

namespace JogodaVelha
{
    public partial class MainPage : ContentPage
    {

            bool jogadorX = true; // true = X, false = O
            int jogadas = 0;

            public MainPage()
            {
                InitializeComponent();
            }

            private void Button_Clicked(object sender, EventArgs e)
            {
                Button btn = (Button)sender;

                // Impede sobrescrever jogadas
                if (!string.IsNullOrEmpty(btn.Text))
                    return;

                // Marca o símbolo
                btn.Text = jogadorX ? "X" : "O";
                jogadas++;

                // Verifica se alguém venceu
                if (VerificarVitoria())
                {
                    DisplayAlert("Fim de jogo", $"Jogador {(jogadorX ? "X" : "O")} venceu!", "OK");
                    Reiniciar();
                    return;
                }

                // Verifica empate
                if (jogadas == 9)
                {
                    DisplayAlert("Empate", "Nenhum vencedor!", "OK");
                    Reiniciar();
                    return;
                }

                // Alterna jogador
                jogadorX = !jogadorX;
            }

            private bool VerificarVitoria()
            {
                string[,] tabuleiro = new string[3, 3]
                {
                { btn10.Text, btn11.Text, btn12.Text },
                { btn20.Text, btn21.Text, btn22.Text },
                { btn30.Text, btn31.Text, btn32.Text }
                };

                // Linhas
                for (int i = 0; i < 3; i++)
                {
                    if (!string.IsNullOrEmpty(tabuleiro[i, 0]) &&
                        tabuleiro[i, 0] == tabuleiro[i, 1] &&
                        tabuleiro[i, 1] == tabuleiro[i, 2])
                        return true;
                }

                // Colunas
                for (int i = 0; i < 3; i++)
                {
                    if (!string.IsNullOrEmpty(tabuleiro[0, i]) &&
                        tabuleiro[0, i] == tabuleiro[1, i] &&
                        tabuleiro[1, i] == tabuleiro[2, i])
                        return true;
                }

                // Diagonais
                if (!string.IsNullOrEmpty(tabuleiro[0, 0]) &&
                    tabuleiro[0, 0] == tabuleiro[1, 1] &&
                    tabuleiro[1, 1] == tabuleiro[2, 2])
                    return true;

                if (!string.IsNullOrEmpty(tabuleiro[0, 2]) &&
                    tabuleiro[0, 2] == tabuleiro[1, 1] &&
                    tabuleiro[1, 1] == tabuleiro[2, 0])
                    return true;

                return false;
            }

            private void Reiniciar_Clicked(object sender, EventArgs e)
            {
                Reiniciar();
            }

            private void Reiniciar()
            {
                btn10.Text = btn11.Text = btn12.Text =
                btn20.Text = btn21.Text = btn22.Text =
                btn30.Text = btn31.Text = btn32.Text = "";

                jogadas = 0;
                jogadorX = true;
            }
        }
    }


