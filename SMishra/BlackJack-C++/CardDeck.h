// Black Jack Lab
// COSC140
// This lab plays Black Jack with you!
// Swasti Mishra
// 02/23/21
// Trish Nguyen, Katie Nuchols

# include <iostream>
# include <vector> 

using namespace std ;

class CardDeck {
    
    public:
    CardDeck() ;
    // constructor

    ~CardDeck() ;
    // destructor

    CardDeck( const CardDeck& ) = default ;
    CardDeck& operator = ( const CardDeck ) ;
    // assignment operator
    
    int getSize() ;
    // gets the size of the deck

    void shuffle() ;
    // shuffles the cards

    void gameReset() ;
    // resets the game conditions without having to
    //      exit the

    void cardAssign() ;
    // assigns values to cards in the deck

    void Deal() ;
    // deals cards

    void play() ;
    // plays the game. we considered just putting
    //      all of the code in the main function,
    //      but that felt wrong.

    private: 
    int deck[ 52 ] = { 0 };
    // an array for the cards

    int size = 52 ;
    // size of the deck

    int *ptr ;
};
