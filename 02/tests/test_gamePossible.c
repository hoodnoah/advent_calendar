#include <check.h>
#include <stdbool.h>
#include <stdio.h>
#include <stdlib.h>

#include "../include/GamePossible.h"

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

START_TEST(passesFirstPartExample)
{
  BagContents bagContents = {
      .numRedCubes = 12,
      .numGreenCubes = 13,
      .numBlueCubes = 14,
  };

  char example1[] = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
  char example2[] = "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue";
  char example3[] = "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red";
  char example4[] = "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red";
  char example5[] = "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";

  bool expectedResult1 = true;
  bool expectedResult2 = true;
  bool expectedResult3 = false;
  bool expectedResult4 = false;
  bool expectedResult5 = true;

  bool result1 = gamePossible(&bagContents, example1);
  bool result2 = gamePossible(&bagContents, example2);
  bool result3 = gamePossible(&bagContents, example3);
  bool result4 = gamePossible(&bagContents, example4);
  bool result5 = gamePossible(&bagContents, example5);

  ck_assert_int_eq(expectedResult1, result1);
  ck_assert_int_eq(expectedResult2, result2);
  ck_assert_int_eq(expectedResult3, result3);
  ck_assert_int_eq(expectedResult4, result4);
  ck_assert_int_eq(expectedResult5, result5);
}

Suite *suite_name(void)
{
  Suite *s;
  TCase *tc_core;

  s = suite_create("Suite Name");

  /* Core test case */
  tc_core = tcase_create("Core");

  tcase_add_test(tc_core, passesFirstPartExample);
  suite_add_tcase(s, tc_core);

  return s;
}

int main(void)
{
  int number_failed;
  Suite *s;
  SRunner *sr;

  s = suite_name();
  sr = srunner_create(s);

  srunner_run_all(sr, CK_NORMAL);
  number_failed = srunner_ntests_failed(sr);
  srunner_free(sr);

  return (number_failed == 0) ? EXIT_SUCCESS : EXIT_FAILURE;
}