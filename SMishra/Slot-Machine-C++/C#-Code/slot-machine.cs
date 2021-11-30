//Author: Katie Nuchols
//Project Final: Slot Machine

using System;

public class Slots{
    int money;
    int bet;
    bool win = false;
    int[] slots = new int[3];
    public bool Play(){
		Random rnd = new Random();
		for(int i = 0; i < 3; i++){
		  int num = rnd.Next(0, 10);
		  slots[i] = num;
		}
		int first = slots[0];
		if(first == slots[1] && first == slots[2]){
		  win = true;
		  money = money + (bet * 2);
		}
		else{
		  win = false;
		  money = money - bet;
		}
		
		return win;
	}
	public int[] GetSlots(){
	    return slots;
	}
	public int setbet(int i){
	  bet = i;
	  return bet;
	}
	public int moneyset(int i){
	  money = i;
	  return money;
	}
	public int checkbalance(){
	  return money;
	}
	static void Main(string[] args){
  Slots s = new Slots();
  string Continue = "Yes";
  Console.WriteLine("How much would you like to start with?");
  int money = Convert.ToInt32(Console.ReadLine());
  s.moneyset(money);
  while(Continue == "Yes"){
    int bet = 0;
    while(bet == 0){
      Console.WriteLine("How much would you like to bet?");
      bet = Convert.ToInt32(Console.ReadLine());
      if(bet > s.checkbalance()){
        Console.WriteLine("This is an invalid amount! You do not have enough.");
        bet = 0;
      }
    }
    s.setbet(bet);
    bool win = s.Play();
    int[] m = s.GetSlots();
    foreach (int i in m) {
      Console.Write("{0} ", i);
    }
    Console.WriteLine("\n");
    if(win == true){
       Console.WriteLine("You Win!");
    }
      else{
        Console.WriteLine("You Lose!");
      }
      money = s.checkbalance();
      Console.WriteLine("Your balance is: $" + money);
      if(money <= 0){
        Console.WriteLine("You are out of Money! You may not play again.");
        return;
      }
      else{
        Console.WriteLine("Do you want to continue? (Yes/No)");
        Continue = Console.ReadLine();
      }
    }
	}
}
