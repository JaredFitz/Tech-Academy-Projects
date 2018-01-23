REQUIREMENTS
============

1.  You will start by creating a new class named Dice.  The Dice class will have one property: int Sides, and method called Roll().  The Roll() method will use the Sides property as the maximum value used by the Random.Next() method.  The Roll() method will return the random number to the caller.  Hint: you cannot create a new instance of the Random class inside of the Roll() method otherwise you'll have that same problem we've fought before.  You must create a new instance of the Random class *outside* of the Roll() method.

2.  In the Default class' Page_Load method, you will create a new instance of the Dice class and pass it as an input parameter to the Character class' Attack method.  The Attack method will set the Sides property, then will call the Dice class' Roll() method and use the return value as the return value of the Attack method as well.

3.  You will re-write the logic in the Page_Load method to check and see if the hero gets an attack bonus or if the monster gets an attack bonus.  In either case, you should perform the bonus attack and make the appropriate changes to the other character's health using the Defend method.

4.  You will create a while loop (a.k.a, the battle loop) and only break out of it once one character's health is less than zero.  Inside the while loop, the monster should attack the hero, then the hero should attack the monster.

5.  You will create a helper method in the Default class called displayResult() which accepts two input parameters, opponent1 and opponent2.  Depending on their health, determine the winner and print out a winning message using both their names.  If they both have health less than or equal to zero, then print out a message that they both died.

