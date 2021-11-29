/* Programmer: Stephanie Hill
 * Date Created: 11.24.2021
 * Purpose: Controls display of Deck on screen
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DeckModel))]
public class ShowDeck : MonoBehaviour
{
    DeckModel deck;
    Dictionary<int, CardView> dealtCards;
    
    //int lastCount;

    public Vector3 start;
    public float cardOffset;
    public bool showCard = true;
    public bool reverseStack = false;
    public GameObject cardPrefab;

    //Changes whether a dealt card is face up or down
    public void Toggle(int card, bool showFace)
    {
        dealtCards[card].ShowFace = showFace;
    }

    //Empties the deck and dealtCards lists
    public void Clear()
    {
        deck.Reset();
        foreach(CardView view in dealtCards.Values)
        {
            Destroy(view.Card);
        }
        dealtCards.Clear();
    }


    void Awake()
    {
        dealtCards = new Dictionary<int, CardView>();
        deck = GetComponent<DeckModel>();
        ShowCards();

        deck.CardRemoved += deck_CardRemoved;
        deck.CardAdded += deck_CardAdded;
    }

    void deck_CardAdded(object sender, CardEventArgs e)
    {
        float curr = cardOffset * deck.NumCards;
        Vector3 temp = start + new Vector3(curr, 0f);
        AddCard(temp, e.DeckIndex, deck.NumCards);
    }

    //Removes card from deck when it is added elsewhere
    void deck_CardRemoved(object sender, CardEventArgs e)
    {
        if (dealtCards.ContainsKey(e.DeckIndex))
        {
            Destroy(dealtCards[e.DeckIndex].Card); //removes the entity from the board
            dealtCards.Remove(e.DeckIndex); //removes the index
        }
            
    }

    public void ShowCards()
    {
        int numCards = 0;

        if (deck.HasCards)
        {
            foreach (int i in deck.GetCards())
            {
                float curr = cardOffset * numCards;
                Vector3 temp = start + new Vector3(curr, 0f);
                AddCard(temp, i, numCards);
                numCards++;
            }
        }
    }

    //Controls how deck is displayed 
    void AddCard(Vector3 position, int deckIndex, int positionIndex)
    {
        if (dealtCards.ContainsKey(deckIndex))
        {
            if (!showCard)
            {
                CardModel model = dealtCards[deckIndex].Card.GetComponent<CardModel>();
                model.ToggleFace(dealtCards[deckIndex].ShowFace);
            }
            return;
        }

        GameObject cardCopy = (GameObject)Instantiate(cardPrefab);
        cardCopy.transform.position = position;

        CardModel cardModel = cardCopy.GetComponent<CardModel>();
        cardModel.deckIndex = deckIndex;
        cardModel.ToggleFace(showCard);
    

        SpriteRenderer spriteRenderer = cardCopy.GetComponent<SpriteRenderer>();
        if (reverseStack)
            spriteRenderer.sortingOrder = 51 - positionIndex;
        else
            spriteRenderer.sortingOrder = positionIndex;  //51-cardCount  will switch order laid down

        dealtCards.Add(deckIndex, new CardView(cardCopy));

        //Debug.Log("Hand Value = " + deck.HandValue());
    }
    
    void Update()
    {
        ShowCards();
    }
    
}
