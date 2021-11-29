/* Programmer: Stephanie Hill
 * Date Created: 11.24.2021
 * Purpose: Script for testing Flip Card
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugChangeCard : MonoBehaviour
{
    FlipCard flipper;
    CardModel cardModel;
    int deckIndex = 0;

    public GameObject card;

    void Awake()
    {
        cardModel = card.GetComponent<CardModel>();
        flipper = card.GetComponent<FlipCard>();
    }

    //When press temp button card flips
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 20), "Hit me!"))
        {
            
            if (deckIndex == cardModel.faces.Length)
            {
                deckIndex = 0;
                flipper.CardFlip(cardModel.faces[cardModel.faces.Length-1], cardModel.deckBack, -1); 
            }
            else
            {
                if(deckIndex > 0)
                {
                    flipper.CardFlip(cardModel.faces[deckIndex - 1], cardModel.faces[deckIndex], deckIndex);
                }
                else
                {
                    flipper.CardFlip(cardModel.deckBack, cardModel.faces[deckIndex], deckIndex);
                }
                deckIndex++;
            }
        }
    }  
}
