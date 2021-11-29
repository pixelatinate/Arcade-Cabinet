/* Programmer: Stephanie Hill
 * Date Created: 11.27.2021
 * Purpose: Class that allows us to interact with face up/down mechanics 
 */
using UnityEngine;

public class CardView
{
    public GameObject Card { get; private set; }
    public bool ShowFace { get; set; }

    public CardView(GameObject card)
    {
        Card = card;
        ShowFace = false;
    }
}


