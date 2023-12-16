#include <stdbool.h>

#include "../include/GamePossible.h"

typedef struct Game
{
  BagContents resultContents;
  unsigned int gameID;
} Game;

Game parseGame(char *game)
{
  Game result = {
      .resultContents = {
          .numRedCubes = 0,
          .numGreenCubes = 0,
          .numBlueCubes = 0,
      },
      .gameID = 0,
  };

  return result;
}

bool gamePossible(BagContents *bagContents, char *game)
{
  return false;
}