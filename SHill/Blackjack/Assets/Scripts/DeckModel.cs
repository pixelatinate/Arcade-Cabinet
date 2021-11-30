/* Programmer: Stephanie Hill
 * Date Created: 11.26.2021
 * Purpose: Controls the creation and scoring of the deck
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckModel : MonoBehaviour
{
    List<int> cards;
    public bool isDeck;

    public bool HasCards
    {
        get 
        {
            if (cards != null && cards.Count > 0)
                return true;
            else
                return false;
        }
    }

    public event CardEventHandler CardRemoved;
    public event CardEventHandler CardAdded;

    public int NumCards
    {
        get 
        {
            if (cards == null)
                return 0;
            else
                return cards.Count;
        }
    }

    public IEnumerable<int> GetCards()
    {
        foreach (int i in cards)
            yield return i;
    }    

    //Removes cards list
    public int Pop()
    {
        int temp = cards[0];
        cards.RemoveAt(0);

        if (CardRemoved != null)
            CardRemoved(this, new CardEventArgs(temp));

        return temp;
    }

    //Adds cards to list
    public void Push(int card)
    {
        cards.Add(card);
        if (CardAdded != null)
            CardAdded(this, new CardEventArgs(card));
    }

    //Calculates the value of cards in hand
    public int HandValue()
    {
        int total = 0;

        foreach (int card in GetCards())
        {
            int cardRank = card % 13;
            //Cards 2-10
            if (cardRank > 0 && cardRank < 10)
                cardRank += 1;
            //Face cards
            else if (cardRank >= 10)
                cardRank = 10;
            //Aces
            else
            {
                if ((total + 11) > 21)
                    cardRank = 1;
                else
                    cardRank = 11;
            }

            total += cardRank;
        }
        return total;
    }

    //Shuffles a list of cards (the deck) using a variation of the Fisher-Yates shuffle algorithm
    public void ShuffleDeck()
    {
        cards.Clear();
      
        //Adds 52 ints that represent the deck into the list
        for(int i=0; i<52; i++)
        {
            cards.Add(i);
        }

        //Shuffles the deck starting at end of list and interchanging positions with another card 
        int n = cards.Count;
        while(n>1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            int temp = cards[k];
            cards[k] = cards[n];
            cards[n] = temp;
        }
    }

    //Empty's the deck for re-shuffling if player wants to play again
    public void Reset()
    {
        cards.Clear();
    }

    //Awake is called before Start() so this ensures that the deck is created immediatly
    void Awake()
    {
        cards = new List<int>();

        if(isDeck)
            ShuffleDeck();
    }
}
