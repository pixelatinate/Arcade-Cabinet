// mlab5.cpp
// 

#include <iostream> 
#include <random>
using namespace std ;

int main() {

	int seed ;
	int my_array[25] ;
	int arrayVal ;
	int sum = 0 ;

	cout << "Enter a seed: " ;
	cin >> seed ;
	
	default_random_engine rng[seed] ;
	uniform_int_distribution<int> rand_int(-10 , 10) ;
	for (arrayVal = 1 ; arrayVal <= 25 ; arrayVal++ ) {
		sum = sum + arrayVal ;
	}

	cout << "Sum of array = " << sum << " ." ;
	cout << '\n' ;

	return 0 ;
}
