using Laboratorio_2_OOP_201902.Card;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_2_OOP_201902
{
    public class Deck
    {
        private List<Card.Card> cards;
        //private List<CombatCard> combatCards;
        //private List<SpecialCard> SpecialCards;

        public Deck()
        {

        }
        public List<Card.Card> Cards { get => cards; set => cards = value; }

        public void AddCombatCard(CombatCard combatCard)
        {
            cards.Add(combatCard);
        }
        public void AddSpecialCard(SpecialCard specialCard)
        {
            cards.Add(specialCard);
        }
        public void DestroyCombatCard(int cardId)
        {
            cards.Remove(cardId);
        }
        public void DestroySpecialCard(int cardId)
        {
            cards.Remove(cardId);
        }
        public void Shuffle() { 
            throw new NotImplementedException();
        }
    }
}
