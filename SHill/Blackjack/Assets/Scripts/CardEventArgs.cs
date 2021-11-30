/* Programmer: Stephanie Hill
 * Date Created: 11.27.2021
 * Purpose: Allows classes to get event from another class
 */
using System;

public class CardEventArgs : EventArgs
{
    public int DeckIndex { get; private set; }

    public CardEventArgs(int deckIndex)
    {
        DeckIndex = deckIndex;
    }
}
