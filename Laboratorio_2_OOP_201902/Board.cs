using Laboratorio_2_OOP_201902.Card;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_2_OOP_201902
{
    public class Board
    {
        //Constantes
        private const int DEFAULT_NUMBER_OF_PLAYERS = 2;

        //Atributos
        private Dictionary<string, List<Card.Card>>[] playerCards;
        private SpecialCard[] captainCards;
        private List<SpecialCard> weatherCards;

        //Propiedades
        public Dictionary<string, List<Card.Card>>[] PlayerCards
        {
            get
            {
                return playerCards;
            }

            set
            {
                playerCards = value;
            }
        }
        public List<SpecialCard> WeatherCards
        {
            get
            {
                return this.weatherCards;
            }
        }


        //Constructor
        public Board()
        {
            this.weatherCards = new List<SpecialCard>();
            this.playerCards = new Dictionary<string, List<Card.Card>>[
                DEFAULT_NUMBER_OF_PLAYERS]; //Inicializa el arreglo de diccionarios.
            this.playerCards[0] = new Dictionary<string, List<Card.Card>>(); //Inicializa los diccionarios.
            this.playerCards[1] = new Dictionary<string, List<Card.Card>>(); //Inicializa los diccionarios.
        }



        //Metodos
        public void AddCard(Card.Card card, int playerId = -1, string buffType = null)
        {
            if (card.GetType().Name == nameof(CombatCard))
            {
                if (playerId == 0 || playerId == 1)
                {
                    if (playerCards[playerId].ContainsKey(card.Type))
                    {
                        playerCards[playerId][card.Type].Add(card);
                    }
                    else
                    {
                        playerCards[playerId].Add(card.Type, new List<Card.Card>() { card });
                    }
                }

                else
                {
                    throw new IndexOutOfRangeException("No player id given");
                }
            }
            else
            {
                if (card.GetType().Name == nameof(SpecialCard))
                {
                    if (playerId == 0 || playerId == 1)
                    {
                        if (playerCards[playerId].ContainsKey(card.Type))
                        {
                            throw new IndexOutOfRangeException($"There is a {card.Type} already on the board");
                        }
                        else
                        {
                            playerCards[playerId].Add(card.Type, new List<Card.Card>() { card });
                        }
                    }

                    else
                    {
                        throw new IndexOutOfRangeException("No player id given");
                    }
                }

            }
        }
        public void DestroyCards()
        {
            List<Card.Card>[] captainCards = new List<Card.Card>[DEFAULT_NUMBER_OF_PLAYERS]
            {
                new List<Card.Card>(playerCards[0]["captain"]),
                new List<Card.Card>(playerCards[1]["captain"])
            };
            playerCards[0].Remove();
        }

       
        //public int[] GetMeleeAttackPoints()
        //{
        //    //Debe sumar todos los puntos de ataque de las cartas melee y retornar los valores por jugador.
        //    int[] totalAttack = new int[] { 0, 0 };
        //    for (int i=0; i < 2; i++)
        //    {
        //        foreach (CombatCard meleeCard in meleeCards[i])
        //        {
        //            totalAttack[i] += meleeCard.AttackPoints;
        //        }
        //    }
        //    return totalAttack;

        //}
        //public int[] GetRangeAttackPoints()
        //{
        //    //Debe sumar todos los puntos de ataque de las cartas range y retornar los valores por jugador.
        //    int[] totalAttack = new int[] { 0, 0 };
        //    for (int i = 0; i < 2; i++)
        //    {
        //        foreach (CombatCard rangeCard in rangeCards[i])
        //        {
        //            totalAttack[i] += rangeCard.AttackPoints;
        //        }
        //    }
        //    return totalAttack;
        //}
        //public int[] GetLongRangeAttackPoints()
        //{
        //    //Debe sumar todos los puntos de ataque de las cartas longRange y retornar los valores por jugador.
        //    int[] totalAttack = new int[] { 0, 0 };
        //    for (int i = 0; i < 2; i++)
        //    {
        //        foreach (CombatCard longRangeCard in longRangeCards[i])
        //        {
        //            totalAttack[i] += longRangeCard.AttackPoints;
        //        }
        //    }
        //    return totalAttack;
    }
}
