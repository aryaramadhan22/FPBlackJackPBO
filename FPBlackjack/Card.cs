using System;
using System.Drawing;
using System.Reflection;
using System.Resources;
using FPBlackjack.Properties;

namespace FPBlackjack
{
    public class Card
    {
        public int Value { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public Card(string suit, string rank)
        {
            Name = $"{rank} of {suit}";
            if (rank == "Jack" || rank == "Queen" || rank == "King") Value = 10;
            else if (rank == "Ace") Value = 11;
            else Value = int.Parse(rank);

            string shortRank = rank;
            if (rank == "Jack") shortRank = "J";
            else if (rank == "Queen") shortRank = "Q";
            else if (rank == "King") shortRank = "K";
            else if (rank == "Ace") shortRank = "A";

            Image = $"card{suit}{shortRank}";
        }

        public Image GetImage()
        {
            return (Image)Properties.Resources.ResourceManager.GetObject(Image);
        }
    }
}
