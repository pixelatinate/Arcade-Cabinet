/* Programmer: Stephanie Hill
 * Date Created: 11.26.2021
 * Purpose: Script for testing deck 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDealer : MonoBehaviour
{
    public DeckModel deck;
    public DeckModel playerHand;

    void OnGUI()
    {
        if (GUI.Button(new Rect(10,10,256,28), "Hit Me!"))
        {
            playerHand.Push(deck.Pop());
        }
    }
}
