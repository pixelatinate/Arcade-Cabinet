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
	vector <int> userMoney ;
	vector <int> userBets ;
	int currentBet = 0 ;
	int slots[2] ;
	// announce variables
	
	do {
		if( !cin ) {
			cin.clear() ;
			cin.ignore(numeric_limits<streamsize>::max(), '\n') ;
		}	
		cout << "Input a seed: " ;	
		cin >> seed ;	
	} while ( !cin ) ;
	// error checking for non-integer user value	
	
	default_random_engine rng(seed) ;
	uniform_int_distribution<int> range(2,7) ;
	// creates random number generator 
	
	do {
		cout << "\nYour money: $" << money << '\n' ;
		do {
			if( !cin ) {
				cin.clear() ;
				cin.ignore(numeric_limits<streamsize>::max(), '\n') ;
			}	
			cout << "Place a bet: $" ;
			cin >> currentBet ;
		} while ( !cin || currentBet > money ) ;
		// error checking for non-integer user value
		
		if ( !(currentBet == 0) ) {
			if ( currentBet <= 0 ) {
				userBets.push_back( 0 ) ;
				break ;
			// breaks the user out of the loop immediately if they put in 0
			}		

			userBets.push_back( currentBet ) ;
			// inserts the user's bets into the vector 
		
			for( int i = 0 ; i<= 2 ; i++ ){
				slots[i] = range(rng) ;
				cout << slots[i] << " " ;
			// assigns values to slots
			}		

			cout <<	"\n" ;
			// prints random values that were generated
	
			if ( (slots[0] == slots[2]) && (slots[1] == slots[2]) && (slots[0] == slots[1]) ) {
				money = money - currentBet ;
				cout << "You won $" << currentBet*5 << "!\n" ;
				userMoney.push_back( currentBet*5 ) ;
				money = money + currentBet*5 ;
			// value generated when the user wins all slots
			}	

			else if ( (slots[0] == slots[2]) || (slots[1] == slots[2]) || (slots[0] == slots[1]) ) {
				money = money - currentBet ;
				cout << "You won $" << currentBet*2 << "!\n" ;
				userMoney.push_back( currentBet*2 ) ;
				money = money + currentBet*2 ;
			// value generated when the user wins 2 slots
			}	
	
			else if ( (slots[0] == 7) && (slots[1] == 7) && (slots[2] == 7) ) {
				money = money - currentBet ;
				cout << "JACKPOT! You won $" << currentBet*10 << "!\n" ;
				userMoney.push_back( currentBet*10 ) ;
				money = money + currentBet*10 ;
			// value generated when the user wins the jackpot
			}

			else { 
				cout << "You didn't win.\n" ;
				userMoney.push_back( 0 ) ;
				money = money - currentBet ;
			// statement generated with the user doesn't win	
			}

			if  ( money == 0 ) {
				cout << "\nYou are out of money!\n" ;
				break ;
			// breaks the user out when they lose big time lol !	
			}		
		}	

	} while ( !(currentBet == 0) ) ;
	// closes betting loops
		
	if ( (currentBet <= 0) ) {
		userBets.push_back( 0 ) ;
		cout << "\n" ;
	// inserts a zero into the bets vector
	
		if ( userBets.at(0) == 0 ) {
			cout << "\nYou walked away without playing.\n" ;
			return 1 ;
		// for the guy who doesn't want to play :(
		}

		int numero = userMoney.size() ;
		for ( int i = 0 ; i < numero ; i++ ) {
			cout << "You wagered $" << userBets.at(i) << " and won $" << userMoney.at(i) << ".\n" ;
		// lists a history of the users wagers and winnings 
		}	

		int maxValue = userBets.at(0) ;
		int minValue = userBets.at(0) ;
		// declares variables for use in the history paragraph
	
		int numero1 = userBets.size() ;
		for ( int i = 0 ; i < numero1 ; i++ ) {
			if ( userBets.at(i) >= maxValue ){
				maxValue = userBets.at(i) ;
			}	
			if ( userBets.at(i) > 0 && userBets.at(i) <= minValue ) {
				minValue = userBets.at(i) ;
			}
		}
		// determines the max and min bets

		int maxValue_money = userMoney.at(0) ;
		int minValue_money = userMoney.at(0) ;
		// declares variables for use in history paragraph, this time for winnings

		int numero2 = userMoney.size() ;
		for ( int i = 0 ; i < numero2 ; i++ ) {
			if ( userMoney.at(i) >= maxValue_money ) {
				maxValue_money = userMoney.at(i) ; 
			}
			if ( userMoney.at(i) > 0 && userMoney.at(i) <= minValue_money && minValue_money > 0 ) {
				minValue_money = userMoney.at(i) ;
			}
		}
		// determines the max and min winnings

		cout << "\nYour smallest wager was $" << minValue << ".\n" ;
		cout << "Your largest wager was $" << maxValue << ".\n" ;
		cout << "Your smallest winnings was $" << minValue_money << ".\n" ;
		cout << "Your largest winnings was $" << maxValue_money << ".\n" ;
		// prints history statements
	}
return 0 ;
}

