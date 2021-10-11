// lab5.cpp
// This lab displays a slot machine game
// Swasti Mishra
// 02/07/20
// Professor: Dr. Dunn
// TA: Gregory Croisdale

#include <iostream> 
#include <random>
#include <limits>
#include <vector>
// libraries required 

using namespace std ;

int main() {

int seed ;
int money = 1000 ;
vector <int> userBets ;
int currentBet = 0 ;
int slots[2] ;

//	do { 
//		if( !cin ) {
//			cin.clear() ; 
//			cin.ignore(numeric_limits<streamsize>::max(), '\n') ;
//		}
		// clears error flags if user didn't input an integer
		cout << "Input a seed: " ;
		cin >> seed ;
		cout << "\nYour money: $" << money << '\n' ;
		cout << "Place a bet: $" ;
		cin >> currentBet ;
		// user interactions
	
		userBets.push_back( currentBet ) ;
		// inserts the user's bets into the vector 

		default_random_engine rng(seed) ;
		uniform_int_distribution<int> range(2,7) ;
		// creates random number generator 

		for( int i = 0 ; i<= 2 ; i++ ){
			slots[i] = range(rng) ;
			cout << range(rng) << " " ;
		}
		cout <<	"\n" ;
		// prints random values that were generated
		
		if ( slots[0] == slots[2] ) {
		cout << currentBet*2 ;
		}

//	 while( !cin || betNum < money || betNum > 0 )
		
	




return 0 ;
}

