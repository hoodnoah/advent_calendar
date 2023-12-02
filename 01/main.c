#include <stdio.h>
#include <ctype.h>
#include <stdlib.h>
#include <string.h>

struct digit_word
{
  const char *word;
  const size_t word_length;
  const char *digit;
};

struct digit_word digit_words[10] = {
    {"zero", 4, "0"},
    {"one", 3, "1"},
    {"two", 3, "2"},
    {"three", 5, "3"},
    {"four", 4, "4"},
    {"five", 4, "5"},
    {"six", 3, "6"},
    {"seven", 5, "7"},
    {"eight", 5, "8"},
    {"nine", 4, "9"},
};

ssize_t locate_digit_word(char *buffer, struct digit_word *word)
{
  ssize_t index = 0;
  while ((buffer)[index] != '\0')
  {
    if (strncmp(&(buffer)[index], word->word, word->word_length) == 0)
    {
      return index;
    }
    index += 1;
  }

  return -1;
}

void replace_digit_word(char *buffer, ssize_t digit_word_index, struct digit_word *word)
{
  // digit_word_index represents the first character of the word. So replace that first letter with the digit.
  buffer[digit_word_index] = word->digit[0];

  // // Now shift the rest of the string left to remove the remaining characters of the word
  // size_t advance_index = digit_word_index + word->word_length;
  // size_t current_index = digit_word_index + 1;

  // while (buffer[advance_index] != '\0')
  // {
  //   buffer[current_index] = buffer[advance_index];

  //   advance_index++;
  //   current_index++;
  // }

  // // Now move the null pointer
  // buffer[current_index] = '\0';
}

// algorithm:
// Find each occurrence of a string-digit in the input, and replace it with its digit counterpart.
// Repeat until no more string-digits are found.
void replace_digit_words(char *buffer, struct digit_word *words, int num_words)
{
  for (int i = 0; i < num_words; i++)
  {
    struct digit_word word = (words)[i];
    ssize_t location = locate_digit_word(buffer, &word);
    if (location != -1)
    {
      replace_digit_word(buffer, location, &word);
    }
  }
}

ssize_t read_line(FILE *file, char **buffer, size_t *buffer_size)
{
  ssize_t bytes_read = getline(buffer, buffer_size, file);

  return bytes_read;
}

int parse_calibration_value(char *input)
{
  char digits[2];

  int index = 0;
  while (input[index] != '\0')
  {
    if (isdigit((int)input[index]))
    {
      if (!digits[0])
      {
        digits[0] = input[index];
        digits[1] = input[index];
      }
      else
      {
        digits[1] = input[index];
      }
    }
    index += 1;
  }

  return atoi(digits);
}

int main()
{
  const char *filename = "input.txt";
  FILE *file = fopen(filename, "r");

  if (!file)
  {
    printf("Could not open file %s", filename);
    return 1;
  }

  char *line_buffer = NULL;
  size_t line_buffer_size = 0;

  int non_replace_sum = 0;
  int replace_sum = 0;

  while (read_line(file, &line_buffer, &line_buffer_size) != -1)
  {
    int non_replace_calibration_value = parse_calibration_value(line_buffer);
    replace_digit_words(line_buffer, digit_words, 10);
    int replace_calibration_value = parse_calibration_value(line_buffer);

    non_replace_sum += non_replace_calibration_value;
    replace_sum += replace_calibration_value;
  }

  printf("Sum w/out replacement: %i\n", non_replace_sum);
  printf("Sum w/ replacement   : %i\n", replace_sum);

  free(line_buffer);
  fclose(file);

  return 0;
}