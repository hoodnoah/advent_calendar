#include <ctype.h>
#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

#include "../include/Configuration.h"

typedef struct ConfigurationValue
{
  char value;
  size_t position;
} ConfigurationValue;

typedef struct DigitWord
{
  char *word;
  size_t wordLength;
  char value;
} DigitWord;

const DigitWord digitWords[] = {
    {"zero", 4, '0'},
    {"one", 3, '1'},
    {"two", 3, '2'},
    {"three", 5, '3'},
    {"four", 4, '4'},
    {"five", 4, '5'},
    {"six", 3, '6'},
    {"seven", 5, '7'},
    {"eight", 5, '8'},
    {"nine", 4, '9'},
};

// Determines if a given digit word is present from the first character
// of the input string.
bool isDigitWord(char *inString, DigitWord *digitWord)
{
  for (size_t i = 0; i < digitWord->wordLength; i++)
  {
    if (inString[i] == '\0' || inString[i] != digitWord->word[i])
    {
      return false;
    }
  }

  return true;
}

// Determines if any of the digit words are present from the first character
// of the input string.
int atDigitWord(char *inString)
{
  int result = -1;

  for (size_t i = 0; i < 10; i++)
  {
    DigitWord currentDigitWord = digitWords[i];
    if (isDigitWord(inString, &currentDigitWord))
    {
      return atoi(&currentDigitWord.value);
    }
  }

  return -1;
}

void updateLeftConfigValue(ConfigurationValue *left, size_t position, char value)
{
  if (left->position == -1 || left->position > position)
  {
    left->position = position;
    left->value = value;
  }
}

void updateRightConfigValue(ConfigurationValue *right, size_t position, char value)
{
  if (right->position == -1 || right->position < position)
  {
    right->position = position;
    right->value = value;
  }
}

int parseConfiguration(char *configuration, bool includeLetters)
{
  ConfigurationValue left = {'0', -1};
  ConfigurationValue right = {'0', -1};

  size_t index = 0;
  while (configuration[index] != '\0')
  {
    char currentChar = configuration[index];

    if (isdigit(currentChar))
    {
      updateLeftConfigValue(&left, index, currentChar);
      updateRightConfigValue(&right, index, currentChar);
    }
    else if (includeLetters)
    {
      int digitWordValue = atDigitWord(&configuration[index]);
      if (digitWordValue != -1)
      {
        updateLeftConfigValue(&left, index, '0' + digitWordValue);
        updateRightConfigValue(&right, index, '0' + digitWordValue);
      }
    }

    index++;
  }

  char concatenated[] = {left.value, right.value};
  return atoi(concatenated);
}