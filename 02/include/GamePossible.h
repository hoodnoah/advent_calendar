#ifndef GAMEPOSSIBLE_H
#define GAMEPOSSIBLE_H
#endif

#include <stdbool.h>

typedef struct BagContents
{
  unsigned int numRedCubes;
  unsigned int numGreenCubes;
  unsigned int numBlueCubes;
} BagContents;

bool gamePossible(BagContents *bagContents, char *game);