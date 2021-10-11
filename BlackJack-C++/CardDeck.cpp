// Black Jack Lab
// COSC140
// This lab plays Black Jack with you!
// Swasti Mishra
// 02/23/21
// Trish Nguyen, Katie Nuchols

# include "CardDeck.h"
# include <algorithm>
# include <iostream>
# include <vector>
# include <bits/stdc++.h>

using namespace std ;

int cardsUsed = 0 ;
int moveCount = 0 ;
int playerSum = 0 ;
int dealerSum = 0 ;
int handRead = 0 ;
int playerWins = 0 ;
int dealerWins = 0 ;
bool WinLoss = false ;
vector <int> playerHand ;
vector <int> dealerHand ;
// variables and vectors

CardDeck::CardDeck(){
    ptr = new int [ size ] ;
    for ( int i = 0 ; i < size ; i++ ){
        ptr[ i ] = 0 ;
    }
}
// constructor

CardDeck::~CardDeck(){
    delete[] ptr ; 
}
// destructor

int CardDeck::getSize(){
    return size ;
}
// gets the size of the deck

void CardDeck::shuffle(){
    srand( time ( NULL ) ) ;
    random_shuffle( &deck[ 0 ], &deck[ 52 ] ) ;
}
// shuffles the cards

void CardDeck::gameReset(){
    playerHand.clear() ;
    playerSum = 0 ;
    dealerHand.clear() ;
    dealerSum = 0 ;
    moveCount = 0 ;
}
// resets the game by clearing both player's hands,
//      their sums, and the number of moves

void CardDeck::cardAssign(){
    for ( int i = 0 ; i < ( 32 ) ; i++){
        int j = ( i % 8 ) + 2 ;
        deck[ i ] = j ;
    }
    // normal suited cards

    for ( int i = 32 ; i < 48 ; i++ ){
        deck[ i ] = 10 ;
    }
    // face cards and tens

    for ( int i = 48 ; i < 52 ; i++ ){
        deck[ i ] = 11 ;
    }
    // aces

}
// assigns values to cards in the deck

void CardDeck::Deal(){
    
    if  ( moveCount == 0 ){
        cout << "Your hand: " << deck[ cardsUsed ] ;
        playerHand.push_back( deck[ cardsUsed ]) ;
        cardsUsed++ ;

        cout << " and " << deck[ cardsUsed ] << ".\n";
        playerHand.push_back( deck[ cardsUsed ]) ;
        cardsUsed++ ;

        cout << "Dealer's hand: " << deck[ cardsUsed ] << " and another card.\n" ;
        dealerHand.push_back( deck[ cardsUsed ]) ;
        dealerHand.push_back( deck[ cardsUsed ]) ;
        cardsUsed + 2 ;
        
        moveCount++ ;
    }
    // unique moveset for the first deal of a game because you get two cards, not one
    
    else {
        playerHand.push_back( deck[ cardsUsed ]) ;
        cardsUsed++ ;

        cout << "Your hand:" ;
        
        for ( handRead = 0 ; handRead < ( playerHand.size() - 1 ) ; handRead++ ){
            cout << " " << playerHand.at( handRead ) ;
            cout << " and" ;
        }

        cout << " " << playerHand.at( handRead ) ;
        cout << ".\n" ;
        // prints your hand, for reference

        if ( dealerSum < 17 ){
            dealerHand.push_back( deck[ cardsUsed ]) ;
            cardsUsed++ ;
        }
        // the dealer's moves
    }
    // for the deals that follow the first
}
// deals cards

void CardDeck::play(){
    
    string choice ;

    cardAssign() ;
    
    cout << "\nLet's Play BLACKJACK!\n" ;
    cout << "---------------------\n" ;

    shuffle() ;
    cout << "\nShuffle Print: " ;
    for ( int i = 0 ; i < 52 ; i++ ){
        cout << deck[ i ] << " " ;
    }
    cout << "\n" ;
    // not related to the game, just prints shuffled cards
    

    Deal() ;
    // runs setup for a game
    
    while ( WinLoss == false ) {
    // this line stops the while hit loop from running until the core gets dumped

        if ( playerSum < 21 ){
            cout << "\nEnter 'Hit' or 'Stand': " ;
            cin >> choice ; 
        }

        while ( (choice == "Hit" || choice == "hit" || choice == "h" || choice == "H" ) && ( WinLoss == false ) ){
            moveCount++ ;
            Deal() ;
            playerSum = accumulate( playerHand.begin() , playerHand.end(), 0 ) ;
            dealerSum = accumulate( dealerHand.begin() , dealerHand.end(), 0 ) ;
            
            if ( playerSum > 21 ) {
                cout << "\nSum of your hand: " << playerSum << "\n";
                cout << "Sum of the dealer's hand: " << dealerSum << "\n" ;
                cout << "BUST!\n" ;
                dealerWins++ ;
                WinLoss = true ;
                gameReset() ;
            }
            // when the player busts

            if ( dealerSum > 21 ){
                cout << "\nSum of your hand: " << playerSum << "\n";
                cout << "Sum of the dealer's hand: " << dealerSum << "\n" ;
                cout << "YOU WIN!\n" ;
                playerWins++ ;
                WinLoss = true ;
                gameReset() ;
            }
            // when the dealer busts
            
        }
        // manages hits

        if ( choice == "Stand" || choice == "stand" || choice == "s" || choice == "S"){
            playerSum = accumulate( playerHand.begin() , playerHand.end(), 0 ) ;
            dealerSum = accumulate( dealerHand.begin() , dealerHand.end(), 0 ) ;
            cout << "\nSum of your hand: " << playerSum << "\n";
            cout << "Sum of the dealer's hand: " << dealerSum << "\n" ;
            // prints sums for proof
            
            if ( dealerSum > 21 ){
                cout << "\nSum of your hand: " << playerSum << "\n";
                cout << "Sum of the dealer's hand: " << dealerSum << "\n" ;
                cout << "YOU WIN!\n" ;
                playerWins++ ;
                WinLoss = true ;
                gameReset() ;
            }
            // when the dealer busts
            
            if ( dealerSum == playerSum ){
                cout << "PUSH!\n" ;
                WinLoss = true ;
                gameReset() ;
            }
            // handles ties

            if ( playerSum > dealerSum || playerSum == 21 ){
                cout << "YOU WIN!\n" ;
                playerWins++ ;
                WinLoss = true ;
                gameReset() ;
            }
            if ( dealerSum > playerSum || dealerSum == 21 ){
                cout << "DEALER WINS!\n" ;
                dealerWins++ ; 
                WinLoss = true ;
                gameReset() ;
            }
            // handles who wins
        }
        // handles stands 

        if ( cardsUsed >= 37 ){
            CardDeck * deck;
            deck = new CardDeck;
            cardAssign() ;
            shuffle() ;
            cardsUsed = 0 ;
        }
        // creates a new deck when the first runs out. I'm fairly 
        //  sure this loop is why I get this weird, inconsistent 
        //  error where the deal function will run too many times
        //  but it's a minor error and I can't figure it out.

        cout << "\nPlay Again? ('Q' to stop, 'P' to continue. ): " ;
        cin >> choice ;

        while ( choice == "p" || choice == "P" ){
            WinLoss = false ;
            gameReset() ;
            play() ;
        }
        // sets the game up to play again

        while ( choice == "q" || choice == "Q" ){
            cout << "Player Wins: " << playerWins << "\n" ; 
            cout << "Dealer Wins: " << dealerWins << "\n" ; 
            exit(EXIT_SUCCESS) ;
        }
        // exits the program

    }
    
}