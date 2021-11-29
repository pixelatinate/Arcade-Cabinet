/* Programmer: Stephanie Hill
 * Date Created: 11.24.2021
 * Purpose: Flips cards
 * NOT IMPLEMENTED
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCard : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    CardModel model;

    public AnimationCurve scaleCurve;
    public float duration = 0.5f;
    
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        model = GetComponent<CardModel>();
    }

    public void CardFlip(Sprite startImage, Sprite endImage, int deckIndex)
    {
        StopCoroutine(Flip(startImage, endImage, deckIndex));
        StartCoroutine(Flip(startImage, endImage, deckIndex));
    }

    //Gives the illusion that the cards is flipping by changing scaling the x factor and switching the image
    IEnumerator Flip(Sprite startImage, Sprite endImage, int deckIndex)
    {
        spriteRenderer.sprite = startImage;

        float time = 0f;
        while(time <= 1f)
        {
            float scale = scaleCurve.Evaluate(time);
            time += Time.deltaTime / duration;

            //Scaling the x factor of image to give illusion of flip
            Vector3 localScale = transform.localScale;
            localScale.x = scale;
            transform.localScale = localScale;

            //At halfway point of rotation, switch image from front/back of card to opposite
            if (time >= 0.5)
            {
                spriteRenderer.sprite = endImage;
            }

            yield return new WaitForFixedUpdate();
        }

        if (deckIndex == -1)
        {
            model.ToggleFace(false);
        }
        else
        {
            model.deckIndex = deckIndex;
            model.ToggleFace(true);
        }
    }
}
