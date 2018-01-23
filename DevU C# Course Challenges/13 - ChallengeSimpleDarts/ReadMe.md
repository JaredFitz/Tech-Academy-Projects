Project Name: ChallengeSimpleDarts

(1) First create a re-usable library called Darts that could be used for
other dart games in the future.  It will contain a single class named Dart.  When
creating a new instance of Dart, you will pass it an instance of the System.Random
class to ensure you get a true random number across the lifetime of the web page's 
lifecycle.  When you call the Throw() method it will simulate the act of throwing a 
dart at a dart board.  

The dart has an equal chance of scoring one through twenty,
or the bullseye (0).  For numbers 1 through 20, the dart has a five percent chance 
of landing in the outer band that represents a double score, and a five percent 
chance of landing in the inner band that represents a triple score.  

For the bullseye (number 0) only has an outer ring and the inner bullseye.  There's
only a five percent chance that the inner bullseye can be hit.

The Throw() method should populate properties representing the score, and whether 
it landed in a double or triple band (or outer / inner bullseye).

(2) In the Web Forms project, you will create a Game class that contains the 
logic for a simple game of darts.  Two players will take turns throwing three
darts per turn.  Their respective scores accumulate after each turn by adding 
the score from each dart to the Player's score.  

The first Player to reach 300 points wins.  

If the dart lands in the double or triple band, multiply the score by 2x or 3x, respectively.  

Display the winner and both player's scores on the web page.

(3) In the Web Forms project create a Score class that contains a static method 
that will calculate the score for a dart throw.  

Each dart can score from 1 to 20, or the bullseye.
If the dart lands in the outer band, multiply the dart's score by two.  
If the dart lands in the inner band, multiply the dart's score by three.  
If the dart lands in the outer bullseye, it is scored as 25.  
If the dart lands in the inner bullseye, it is scored as 50.

Try to keep the classes as short as possible and cohesive.
Try to keep the methods as short as possible ... no more than 6 lines of code.

(These are guidelines ... if you can't do that, no worries.)