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
  - The actual hunger increments and decrements are handles in PlayerBehaviors.cs. The hunger begins at 75 out of 100 units and begins decreasing from the start at    a rate of 1.5 units per second.
  - Eating a villager increases the hunger value by 10 units.
