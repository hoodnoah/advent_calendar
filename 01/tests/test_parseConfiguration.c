#include <check.h>
#include <stdbool.h>
#include <stdlib.h>

#include "../include/Configuration.h"

START_TEST(parses_first_part_example_correctly)
{
  bool includeLetters = false;
  char *first_configuration = "1abc2";
  char *second_configuration = "pqr3stu8vwx";
  char *third_configuration = "a1b2c3d4e5f";
  char *fourth_configuration = "treb7uchet";

  int first_result = parseConfiguration(first_configuration, includeLetters);
  int second_result = parseConfiguration(second_configuration, includeLetters);
  int third_result = parseConfiguration(third_configuration, includeLetters);
  int fourth_result = parseConfiguration(fourth_configuration, includeLetters);

  ck_assert_int_eq(12, first_result);
  ck_assert_int_eq(38, second_result);
  ck_assert_int_eq(15, third_result);
  ck_assert_int_eq(77, fourth_result);
  ck_assert_int_eq(142, first_result + second_result + third_result + fourth_result);
}

START_TEST(parses_second_part_example_correctly)
{
  bool includeLetters = true;
  char *first_configuration = "two1nine";
  char *second_configuration = "eightwothree";
  char *third_configuration = "abcone2threexyz";
  char *fourth_configuration = "xtwone3four";
  char *fifth_configuration = "4nineeightseven2";
  char *sixth_configuration = "zoneight234";
  char *seventh_configuration = "7pqrstsixteen";

  int first_result = parseConfiguration(first_configuration, includeLetters);
  int second_result = parseConfiguration(second_configuration, includeLetters);
  int third_result = parseConfiguration(third_configuration, includeLetters);
  int fourth_result = parseConfiguration(fourth_configuration, includeLetters);
  int fifth_result = parseConfiguration(fifth_configuration, includeLetters);
  int sixth_result = parseConfiguration(sixth_configuration, includeLetters);
  int seventh_result = parseConfiguration(seventh_configuration, includeLetters);

  ck_assert_int_eq(29, first_result);
  ck_assert_int_eq(83, second_result);
  ck_assert_int_eq(13, third_result);
  ck_assert_int_eq(24, fourth_result);
  ck_assert_int_eq(42, fifth_result);
  ck_assert_int_eq(14, sixth_result);
  ck_assert_int_eq(76, seventh_result);
  ck_assert_int_eq(281, first_result + second_result + third_result + fourth_result + fifth_result + sixth_result + seventh_result);
}

Suite *suite_name(void)
{
  Suite *s;
  TCase *tc_core;

  s = suite_create("Suite Name");

  /* Core test case */
  tc_core = tcase_create("Core");

  tcase_add_test(tc_core, parses_first_part_example_correctly);
  tcase_add_test(tc_core, parses_second_part_example_correctly);
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