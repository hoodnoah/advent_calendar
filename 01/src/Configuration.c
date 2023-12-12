#include <stdlib.h>
#include <ctype.h>

#include "../include/Configuration.h"

typedef struct ConfigurationValue
{
  char value;
  size_t position;
} ConfigurationValue;

int parseConfigurationBasic(char *configuration)
{
  ConfigurationValue left = {'0', -1};
  ConfigurationValue right = {'0', -1};

  size_t index = 0;
  while (configuration[index] != '\0')
  {
    if (isdigit(configuration[index]))
    {
      if (left.position == -1)
      {
        left.position = index;
        left.value = configuration[index];
        right.position = index;
        right.value = configuration[index];
      }
      else
      {
        if (right.position < index)
        {
          right.position = index;
          right.value = configuration[index];
        }
      }
    }

    index++;
  }

  char concatenated[2] = {left.value, right.value};
  int result = atoi(concatenated);

  return result;
}