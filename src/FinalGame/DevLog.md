April 10 2023
I was able to set up the movement of the character, and also fixed the bug of the character not
being able to move. I need to fix another bug where the character is being drawn every update.
After that I should be able to start on the player Projectile mechanic.


April 11, 2023
The issue was fixed with the sprite being drawn for every update. In class we fixed the shot
manager for the spaceship so now you can shoot the beam texture.


April 24, 2023
I added the classes that deal with the spawner and the time spawner for the alien sprite. I also
added the score manager class to display the score, lives for now.
I need to fix the collision for the aliens. For now the first alien only intersects with the shot, but
not with the rest of the spawning aliens after that.
After that I need to get working on the part where the aliens don't just spawn in one spot and
should spawn randomly on the top of the screen of the x-axis.
So far no errors for today that need fixing.


April 25, 2023
I edited my code so that the aliens would spawn randomly only at the top of the screen of the
x-axis. I also added an if statement to detect when they reach the bottom of the screen they
would disappear and take a life away from the player.
Still need to figure out how to set up an if statement to detect collision of the beam with all the
aliens spawning.

Question: Where do the aliens get spawned from?

Answer: They are added as components and after put onto the screen.


April 27, 2023
Today Mack helped me out adjusting the collision for my game. Now in the updated version the
ships shots collide with all ghosts that are being spawned in. When they are destroyed they are
added to a list and removed right after. All elements of the base game have been included now.
All I need to do is add the win and lose conditions, or state using enums, and organize some
code after, probably with some enums.

Question: Which class should I put the enums that control the win/lose and the retry states?

Jeff Answer: It should be where you store the score/level code.


April 29, 2023
Added enums to create the state of the game like when they lose everthing should stop appearing, and display the retry screen.
the enums work fine, but my ship and the aliens keep apearing even though I have them set their enable and visibilty set to false.

May 1, 2023
Mack helped with getting the visibilty of the ship and aliens to work. I was setting it to a new ship and alien, instead passing 
it through the score managers parameters so it reads the already set components of the objects. After this I set some more code that
will overwrite the HI-Score with the players score if the player score goes over the set Hi-Score. The last thing I need to fix is
the restart function of the game.

Question: Why is it that the TimedAlienSpawner component doesnt have a visible function to it and only an enabled one?

Question: Is there a better way to make a restart mechanic instead of just using a bool to check this?



