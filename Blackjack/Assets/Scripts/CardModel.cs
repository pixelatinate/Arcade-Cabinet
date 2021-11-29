/* Programmer: Stephanie Hill
 * Date Created: 11.24.2021
 * Purpose: Creates the cards by defining the front and back
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModel : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] faces;
    public Sprite deckBack;
    public int deckIndex; 

    public void ToggleFace(bool showFace)
    {
        if (showFace)
        {
            spriteRenderer.sprite = faces[deckIndex];
        }
        else
        {
            spriteRenderer.sprite = deckBack;
        }
    }

    void Awake()
    {
        spriteRenderer = GetComponent <SpriteRenderer>();
    }

}
