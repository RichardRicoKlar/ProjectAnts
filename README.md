# Project Ants
Visualised randomiser experiment/simulation. Currently in progress of coding, but idea's below.

Experiment contains a board of random size with 3 types of entities, from which each has different behaviour.
There can be random numbers of each entity, there aren't limitations.

## Entities: 
### Ants:
- Moves randomly in 1 of the 4 directions
- Ant will die after _AntLifeTime_ ticks, because of an old age :(
### Bugs:
- Moves randomly in 1 of the 4 directions
- Never dies by age
### Sugar:
- Doesn't move
- Spawns randomly every 5-10 ticks * _SugarSpawnRate_
- Will decay and turn into Bug after _SugarDecayTime_ ticks

## Interactions:
### Ant meets Bug:
- Bug dies
- Ant prolong own life by _BugLiveValue_ ticks
### Ant meets Sugar:
- Ant eats sugar
- Ant prolongs own life by _SugarLifeValue_ ticks
- New Ant is produced
### Bug meets Sugar:
- Bug eats Sugar -> New Bug is born
### Ant meets Ant:
- Woohoo! - New Ant is born
### Bug meets Bug:
- Nice! - New Bug is born
### Sugar haven't been eaten for too long
- Sugar have turned into Bug

## What's the point of all of this?
Good question. There isn't any obvious point. It's just an experiement, a simulation, which should always leave different results.
In a core and terms of statistics however, I'd belive that ants should always eventually dominate the board, however this has proved me wrong. Once the sugars start turning into Bugs, then it's going quick :)

## How to run the simulation?
Easy. Clone the repository and start ProjectAnts.Console. No need of any NuGet packages etc.
You may amend some settings in ExperimentDefaults.cs:
 - _Board_ - (x,y) - size of the board, x for horizontal size, y for vertical size. (default is 15 by 15)
 - _SugarsStarted_ - How many Sugars will be spawned at the start of the simulation. (default is 3)
 - _SugarSpawnRate_ - Multiplier of Sugars spawn speed - 5ticks-10ticks * _[SugarSpawnRate]_ (default is 1)
 - _SugarLifeValue_ - How much extra life ticks Sugar provides when eaten by an Ant. (default is 20)
 - _SugarDecayTime_ - How many ticks before Sugar rots and turns into Bug. (default is 50)
 - _AntsStarted_ - How many Ants will be spawned at the start of the simulation. (default is 5)
 - _AntLifeTime_ - How many ticks will individual Ant life for before dying by an old age. (default is 25)
 - _BugStarted_ - How many Bugs will be spawned at the start of the simulation. (default is 1)
 - _BugLifeValue_ - How much extra life ticks Bug provides when eaten by an Ant. {default is 10)

## Conclusions
Simulation can conclude in 3 results:
 - Ants have died and none is left on a board
 - Ants have dominated over 90% of the board
 - Bugs have dominated over 90% of the board
 
## What to do if I find a problem?
Also bit tricky question. Feel free to raise an issue, but in reality, I don't really care :)
