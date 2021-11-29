/* Programmer: Stephanie Hill
 * Date Created: 11.27.2021
 * Purpose: Controls the game
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameMaster : MonoBehaviour
{
    int dealersFirstCard = -1;
    public DeckModel player;
    public DeckModel dealer;
    public DeckModel deck;
    public Button holdButton;
    public Button hitButton;
    public Button playAgainButton;
    public GameObject playButton;
    public Text winnerText;
    public Text titleText;
    public Text directionsText;
    public Image directionsBox;
    
    #region Public Methods

    //Allows player to 'hit' until reaching 21, then starts the dealer's turn
    public void Hit()
    {
        player.Push(deck.Pop());
        
        if (player.HandValue()>21)
        {
            //player is bust
            hitButton.interactable = false;
            holdButton.interactable = false;
            StartCoroutine(DealersTurn());
        }  
    }

    //If player holds, starts the dealer's turn
    public void Hold()
    {     
        StartCoroutine(DealersTurn());
    }
    
    //Starts the game after the player selects the Play button
    public void Play()
    {
        directionsBox.enabled = false;
        directionsText.enabled = false;
        titleText.enabled = false;
        playButton.SetActive(false);

        StartGame();
    }

    //Starts new game if Play Again Button is selected
    public void PlayAgain()
    {
        playAgainButton.interactable = false;

        player.GetComponent<ShowDeck>().Clear();
        dealer.GetComponent<ShowDeck>().Clear();

        deck.GetComponent<ShowDeck>().Clear();
        deck.ShuffleDeck();

        winnerText.text = "";

        hitButton.interactable = true;
        holdButton.interactable = true;

        dealersFirstCard = -1;

        StartGame();
    }
    #endregion

    #region Unity messages
    //At start displays directions
    void Start()
    {
        directionsBox.enabled = true;
    }
    #endregion

    //Gives dealer and player their first 2 cards
    void StartGame()
    {
        for(int i = 0; i < 2; i++)
        {
            player.Push(deck.Pop());
            HitDealer();
        }
    }

    //Removes card from deck and adds to dealer hand
    void HitDealer()
    {
        int card = deck.Pop();
        if (dealersFirstCard<0)
        {
            dealersFirstCard = card;
        }
        dealer.Push(card);

        //Forces only the first card to be visable
        if (dealer.NumCards >= 2)
        {
            ShowDeck view = dealer.GetComponent<ShowDeck>();
            view.Toggle(card, true);
        }  
    }

    IEnumerator DealersTurn()
    {
        //Once it's the dealer's turn, player can no longer interact with hit/hold buttons
        hitButton.interactable = false;
        holdButton.interactable = false;

        //Forces only the first card to be visable
        ShowDeck view = dealer.GetComponent<ShowDeck>();
        view.Toggle(dealersFirstCard, true);
        view.ShowCards();
        yield return new WaitForSeconds(1f);
        
        //Dealear continues to hit until 17
        while ((dealer.HandValue() < 17) && (player.HandValue() <= 21))
        {
            HitDealer();
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("Dealer Value = " + dealer.HandValue());
        Debug.Log("Player Value = " + player.HandValue());
        //Tells player if they won or lost
        if (player.HandValue() > 21 || ((dealer.HandValue() >= player.HandValue()) && dealer.HandValue() <= 21))
            winnerText.text = "You lose.";
        else if (dealer.HandValue() > 21 || (player.HandValue() <= 21 && (player.HandValue() > dealer.HandValue())))
            winnerText.text = "You win!";
        else
            winnerText.text = "It's a draw.";

        yield return new WaitForSeconds(1f);
        playAgainButton.interactable = true;
    }    
}
