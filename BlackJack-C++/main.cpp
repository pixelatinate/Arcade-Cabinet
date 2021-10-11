// Black Jack Lab
// COSC140
// This lab plays Black Jack with you!
// Swasti Mishra
// 02/23/21
// Trish Nguyen, Katie Nuchols

# include "CardDeck.h"    // class definition for CardDeck used below

int main() {
  CardDeck CD ;           // renames CardDeck
  CardDeck * deck;        // pointer to a single CardDeck object
  deck = new CardDeck;    // creates a new object

  CD.play() ;             // plays the game
  CD.~CardDeck() ;        // destructs class when complete
  return 0 ;
}