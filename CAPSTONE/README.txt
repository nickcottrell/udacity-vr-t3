
_________                        __                        
\_   ___ \_____  ______  _______/  |_  ____   ____   ____  
/    \  \/\__  \ \____ \/  ___/\   __\/  _ \ /    \_/ __ \ 
\     \____/ __ \|  |_> >___ \  |  | (  <_> )   |  \  ___/ 
 \______  (____  /   __/____  > |__|  \____/|___|  /\___  >
        \/     \/|__|       \/                   \/     \/ 

This project is part of [Udacity](https://www.udacity.com "Udacity - Be in demand")'s [VR Developer Nanodegree](https://www.udacity.com/course/vr-developer-nanodegree--nd017).


Versions:
- Unity 2017.2.0f3
- GVR Unity SDK v1.70.0



                                                                           
-__ /\                |\                -__ /\\                   ,        
  || \,          _     \\                 ||  \\  '         _    ||        
 /|| /    _-_   < \,  / \\ '\\/\\        /||__|| \\ ,._-_  < \, =||=  _-_  
 \||/-   || \\  /-|| || ||  || ;'        \||__|| ||  ||    /-||  ||  || \\ 
  ||  \  ||/   (( || || ||  ||/           ||  |, ||  ||   (( ||  ||  ||/   
_---_-|, \\,/   \/\\  \\/   |/          _-||-_/  \\  \\,   \/\\  \\, \\,/  
                           (              ||                               
                            -_-                                            
    __                 
  ,-||-,               
 ('|||  )              
(( |||--)) \\/\\  _-_  
(( |||--)) || || || \\ 
 ( / |  )  || || ||/   
  -____-   \\ \\ \\,/  


//Pre-Planning Document
https://docs.google.com/document/d/1J_o5f7n78lpi9g0bUU_B5bpQAE94Tdsj972vwhxiL9M/edit?usp=sharing


//Emotion
The main emotion for this project is 'fear' but not too scary… not the horror genre. So the mood in the 'lobby' should be dark and mysterious. The riddles will challenge the user to go on different adventures that will require them to face their fears. But overall the experience should be creepy fun!


//Walkthrough

https://youtu.be/HdBydmF54qY


//Achievements

https://youtu.be/2d8d5qjDygg


Fundamentals
- Animation (100) - Contains several animations. Examples include, the map, keys, flags, coins, locks, and door at the end.
- Lighting (100) - mix of realtime and baked lighting. Used culling feature to set specific dynamic lights to light certain animated objects that were not part of the baked elements.
- Locomotion (100) - used a waypoint system to navigate to discrete locations via point and click.
- Video Player (100x2) - depending on the which objects the user has picked up, different videos play in the lobby, each containing a riddle for the next step.

Completeness
- Reward System (250) - points and key pickup system UI. The score is accessible at all times via the Status Panel.
- Diegetic UI (250) - core interactions like moving and picking up don't overly rely on text to explain (although there are a few on-boarding messages per insights from user testing). When I did my user tests, everyone figured out how to move around on their own without me explaining it. They also intuitively knew how to click on objects to pick them up.
- Alternative Story Line (250) - If you collect all 3 coins and beat the game, you get a different video at the end.
- 3D Modelling (250) - i created the models for both the waypoint and for the locks in the lobby. I used Maya to create the 3D art.

Challenges
User Tesing (250x2) - I conducted 7 user interviews. I used google forms to collect and chart the info I received and made a list of changes/insights. From there I implemented a series of changes to improve the experience based on user feedback.

Testing Insights:
- broad range of users from teenagers to older adults over 60.
- half the people had tried VR at least once while the other half had never tried it.
- point-and-click is easy to learn and most people understood it just fine.
- people in general thought the experience was fun and intuitive, but needed some instructions at the beginning.
- map page could be more clear/obvious with the graphics and affordance; most people understood the concept of the lock.
- everyone generally got the concept of the waypoint/footprints. Some people had an issue with the collision on the footprints
- split on how people understood the goal of the level.
- everyone felt comfortable with no nausea.
- everyone felt comfortable with the graphics.
- everyone wanted to play it again.

Action Items from Testing:
DONE add some light instruction notifications to help with on-boarding.
DONE fix collision on the waypoints
DONE make the map page more obvious
DONE add more instructions to notifications -- keep the sequencing in mind
DONE provide more time for beginners (especially the first level)
DONE use HUD panel to reinforce the action item.
NOT DOING make the video riddle twice as long in duration


//Asset Store Elements
https://assetstore.unity.com/packages/3d/environments/historic/polygon-pirates-pack-92579
https://assetstore.unity.com/packages/3d/props/low-poly-pirate-pack-props-89765
https://assetstore.unity.com/packages/3d/low-poly-mobile-pirate-models-66539
https://assetstore.unity.com/packages/3d/environments/fantasy/low-poly-fantasy-loot-basic-89231
https://assetstore.unity.com/packages/audio/music/pirate-music-pack-52962

