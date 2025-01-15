# ProjectAnts
Visualised randomiser experiment.

Experiment contains 3 entities, from which each has different behaviour.

## Entities: 
### Ants:
- Moves randomly in 1 of the 4 directions
- Ant will die after 20 steps, because of an old age
### Bugs:
- Moves randomly in 1 of the 4 directions
- Never dies by age
### Sugar:
- Doesn't move
- Spawns randomly every 5-10 ticks

## Interactions:
### Ant meets Bug:
- Bug dies
### Ant meets Sugar:
- New Ant is produced
### Bug meets Sugar:
- Bug eats Sugar
