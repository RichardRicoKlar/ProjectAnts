# Project Ants
Visualised randomiser experiment. Currently in progress of coding, but idea's there.

Experiment contains a board of random size with 3 types of entities, from which each has different behaviour.
There can be random numbers of each entity, there aren't limitations.

## Entities: 
### Ants:
- Moves randomly in 1 of the 4 directions
- Ant will die after 20 steps, because of an old age :(
### Bugs:
- Moves randomly in 1 of the 4 directions
- Never dies by age
### Sugar:
- Doesn't move
- Spawns randomly every 5-10 ticks
- Stays until eaten, nom nom :P

## Interactions:
### Ant meets Bug:
- Bug dies
### Ant meets Sugar:
- Ant eats sugar and prolongs own life by 20 ticks
- New Ant is produced
### Bug meets Sugar:
- Bug eats Sugar - no further effect

## What's the point of all of this?
Good question. There isn't any obvious point. It's just an experiement, which should always leave different results.
In a core and terms of statistics however, the ants should always eventually dominate the board.

## What to do if I find a problem?
Also bit tricky question. Feel free to raise an issue, but in reality, I don't really care :)
