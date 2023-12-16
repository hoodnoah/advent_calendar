#include <stdio.h>
#include <stdlib.h>

#include "../include/Configuration.h"

// Reads a line of a given file
void readFileLine(FILE *file, char **line)
{
  size_t len = 0;
  ssize_t read;

  read = getline(line, &len, file);
  if (read == -1)
  {
    line = NULL;
  }
}

int main(void)
{

  FILE *inputFile = fopen("./input.txt", "r");
  char *line = NULL;

  int part1Result = 0;
  int part2Result = 0;

  while (line == NULL || line[0] != '\0')
  {
    readFileLine(inputFile, &line);
    part1Result += parseConfiguration(line, false);
    part2Result += parseConfiguration(line, true);
  }

  printf("Part 1 Result: %d\n", part1Result);
  printf("Part 2 Result: %d\n", part2Result);

  fclose(inputFile);
  free(line);

  return 0;
}