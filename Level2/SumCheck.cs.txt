using System;

class Solution{
	// method for the recusive sum
	public static int recursiveSum(int n){
		if (n==1){
			return 1;
		}
		return (n+recursiveSum(n-1));
	}
	// method for the formal sum
	public static int formalSum(int n){
		return n*(n+1)/2;
	}
	static void Main(string[] args){
		// Prompt the user to enter a number
		Console.Write("Enter a number: ");
		int n = int.Parse(Console.ReadLine());
		
		Console.WriteLine("The Recusive sum of the numbers "+recursiveSum(n));
		Console.WriteLine("The formal sum of the numbers "+formalSum(n));
		
		// output the compare of both the results
		if(recursiveSum(n)==formalSum(n)){
			Console.WriteLine("Both results are equal");
		}
		else{
			Console.WriteLine("Both are not equal");
		}
	}
}