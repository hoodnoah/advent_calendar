#include <stdio.h>
#include <ctype.h>
#include <stdlib.h>

ssize_t read_line(FILE *file, char **buffer, size_t buffer_size)
{
  ssize_t bytes_read = getline(buffer, &buffer_size, file);

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
  size_t line_buffer_initial_size = 0;

  int sum = 0;

  while (read_line(file, &line_buffer, line_buffer_initial_size) != -1)
  {
    int calibration_value = parse_calibration_value(line_buffer);

    sum += calibration_value;
  }

  printf("Sum: %d\n", sum);

  free(line_buffer);
  fclose(file);

  return 0;
}