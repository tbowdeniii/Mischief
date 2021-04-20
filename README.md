# Mischief

Mischief is a 2D platformer made for LSU's CSC 4263: Video Game Design course. The game's premise is that the player takes control of Mischief, a dragon who's lost its castle because the local villagers are unhappy with the dragon's misbehaviors. In the first level, the player must complete the main quest (collect fruit for the villagers) and balance the hunger and karma meters in an effort to achieve the minimum required score to complete the level and get the castle back. The player's hunger bar begins to fall as soon as the level begins, and the only means of satiating this hunger is to eat villagers. However, the player must be cautious when consuming villagers, for, if caught, the player's karma will decrease. The player gains karma by completing side quests for the villagers. As previously mentioned, the player must achieve at least a certain score to pass the first level. 

The second level takes place in Mischief's castle after the villagers granted him permission to return. The goal shifts from satisfying villagers to surviving. For this level, the only visible UI elements are the hunger bar and number of lives. The player must avoid traps in the castle and reach the end of the level before the hunger bar reaches empty. After completing this level, the game ends.

I was responsible for designing and implementing the UI, score system, and multiple  other game mechanics. 

I'll only be uploading game files that I worked on and describe the thought process and implementation behind each concept. 

## Hunger and Karma System

Concept: The hunger and karma system provides a set of unique constraints placed on the player because they are tasked with helping the villagers with tasks while also managing hunger by eating them. 

UI & Implementation: 
- UI Elements
  - The icons placed next to the hunger and karma bars were made by me using GIMP.
  - The hunger bar is a slider with values from 0-100.
  - The karma bar is a green/red meter. The green portion is a slider that goes from 0-100. The red portion is just a red image that fills the entire bar. The green
    portion is layered above the red portion so that it covers more of the red portion on karma increase and slides back to reveal more of the red portion on karma
    decrease.
- Implementation
  - The value of the player's hunger and karma meters are tracked through variables stored within the script PlayerBehaviors.cs. The eat() method adds to the 
    player’s hunger meter, and the changeKarma() method adds or subtracts a certain value passed through from the user’s Karma Meter. 
  - HungerBar_Script.cs was used to receive and evaluate the hunger and karma values received from the eat() and changeKarma() methods in PlayerBehaviors.cs.
  - Hunger Logistics
    - The actual hunger increments and decrements are handles in PlayerBehaviors.cs. The hunger begins at 75 out of 100 units and begins decreasing from the start
      at a rate of 1.5 units per second.
    - Eating a villager increases the hunger value by 10 units.
  - Karma Logistics
    - Karma starts at 0 and has two possible increments/decrements to its value
    - Possible changes to karma:
      - Side Quest Completion: +10 karma units
      - Caught Eating Villager: -15 karma units 
## Score System

Concept: 
- The idea behind the scoring system is to have multiple factors contributing to the overall score that will be used to determine if a user passed the level or not.
- The two factors used to determine overall score were the amount of fruit collected (main quest) and the karma value. 
- The raw values of fruit collected and karma had to be weighted so that their impact on the score correctly reflected their respective importance to the overall
  game.
  - Fruit Score Value: (Number of Fruit Collected) * 10
  - Karma Score Value: ( (Karma Value) * 3)
- The score is initialized at zero so negative changes in karma can be reflected by a negative score. Before we decided to initialize the score to zero, it was set   to initialize at 150, the karma meter initializes with a value of 50, so its score value (50 * 3). However, having the score start at zero and go up or down from   there seemed to represent the changes in karma better.
- The minimum required score for level completion is approximately (max possible level score)/3. So for level 1, the maximum possible score is 200, and the minimum   required score is 60.
- Possible increments/decrements to the score:
  - Fruit Collection: +10 score
  - Karma Increase (Side Quest Completion): +30 score
  - Karma Decrease (Caught Eating Villager): -45 score
  
  Implementation: 
  - ScoreManager.cs holds the methods responsible for updating and displaying the score. 
  - PlayerPrefs variables were used to keep track of the score throughout level changes. 
  - The function updateScore(int scoreVal) takes the parameter scoreVal and adds it to the current score. This function also updates the PlayerPrefs variable for
    score.
