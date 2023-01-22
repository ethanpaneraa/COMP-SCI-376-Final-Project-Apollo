# COMP-SCI-376-Final-Project-Apollo

Ethan Pineda: COMP_SCI 376: Game Design and Development
Final Project: INSTRUCTIONS
12/3/2022


Instructions set for Apollo


How the game works


In Apollo, you play and control a paddle game object. You move this paddle using your ‘A’ and ‘D’ keys on your keyboard. ‘A’ to go leftwards, ‘D’ to go rightwards. The goal of this game is to launch the ball game object and get it to hit the brick-like game objects that are on the upper portion of the screen. If you can beat all 5 levels, then you win the game! If your ball hits the bottom hand border of the screen, then you lose a life and you must try again. You can only do so so long as you have lives to do so! There are also other bricks that make the game easier/harder! If you get a yellow brick, these bricks need to be hit twice in order to be destroyed and if you hit a green brick, then these bricks need to be hit 3 times before being able to be destroyed. If you hit a brown brick, then all bricks within a certain radius will either be destroyed or will lose a hit point. Good luck and have fun! 


Objects on the Screen:
* You, the player (the gray rectangle on the bottom hand portion of the screen)
   * A start screen telling you the instructions of the game will appear on start of the game
   * As the player, you can move around the screen using your ‘A’ and ‘D’ keys
   * You are able to score as the player when the ball destroys a brick
   * If the ball hits the bottom hand border of the screen, then you will lose a life (you start out with 5 lives)
   * If you to wish to only see the various levels of the game, then you can simply press the left arrow key on your keyboard to automatically start the next level
   * A background sound will continuously play in the background so long as the game is live
   * The player can press the escape key to pause the game
   * The player shouldnt be able to move whenever a game screen is active
   * If the player presses the escape key, the the ball will reset itself to the player and a game pause screen will show up 
   * If the player beats all 5 levels, then a game over screen will show up and the player can press a restart button to restart the game
      * The same screen shows up if the player runs out of lives
* Ball (the white sphere sprite)
   * If the player presses the spacebar, then the ball will launch upwards with a force
   * The ball should follow the center of the player paddle before before launched into the air
   * If the ball goes out of bounds, then the ball will reset back to the player
   * If the ball successfully destroys 36 bricks (the amount of bricks per level), then the next level will automatically start
   * If the ball comes into contact with a brick game object, it will either
      * Destroy the brick game object
      * Take a hit point away from it 
   * Whenever the ball comes into contact with something, a sound will play
   * The ball will go into a random direction at a random velocity whenever it collides with something
   * The ball shouldn’t be able to be launched whenever a game screen is active
* Text Trackers (the white text objects all over the screen)
   * The levels completed tracker should increment whenever the player successfully completes a level
   * The ball velocity should update each time the ball collides with an object. 
   * The lives tracker should increment whenever the balls goes out of bounds
   * The Bricks left tracker should decrement each time a brick game object is destroyed
   * Score will either:
      * Increment if the player successfully destroys a brick (+25)
      * Decrement if the ball falls out of bounds (-100)
* Red Bricks (top hand portion of the screen, the red bricks)
   * If the ball comes into contact with these, then this game object should be destroyed
* Medium health bricks (these should be yellow, spawn after level 1)
   * If the ball comes into contact with these, then this game object loses a hit point
      * The ball needs to come into contact with these twice to destroy it
      * If it gets hit the first time, then it changes color to red
      * If it gets hit a second time, then it gets deleted
* large health bricks (these should be green, spawn after level 2)
   * If the ball comes into contact with these, then this game object loses a hit point
      * The ball needs to come into contact with these trice to destroy it
      * If it gets hit the first time, then it changes color to yellow
      * If it gets a second time, then it changes color to red
      * If it gets hit a third time, then it gets deleted
* Bomb brick (these should be brown. These should spawn every level at somewhat random places)
   * If the ball comes into contact with these, then all bricks in its blast radius will be hit.
      * The bricks will either be destroyed or will lose a hit point# COMP-SCI-376-Final-Project-Apollo

