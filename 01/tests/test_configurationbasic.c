#include <stdlib.h>
#include <check.h>
#include "../include/Configuration.h"

START_TEST(parses_first_configuration_correctly)
{
  char *first_configuration = "1abc2";
  int expected = 12;
  int actual = parseConfigurationBasic(first_configuration);

  ck_assert_int_eq(expected, actual);
}
END_TEST

START_TEST(parses_first_part_example_correctly)
{
  char *first_configuration = "1abc2";
  char *second_configuration = "pqr3stu8vwx";
  char *third_configuration = "a1b2c3d4e5f";
  char *fourth_configuration = "treb7uchet";

  int first_result = parseConfigurationBasic(first_configuration);
  int second_result = parseConfigurationBasic(second_configuration);
  int third_result = parseConfigurationBasic(third_configuration);
  int fourth_result = parseConfigurationBasic(fourth_configuration);

  ck_assert_int_eq(12, first_result);
  ck_assert_int_eq(38, second_result);
  ck_assert_int_eq(15, third_result);
  ck_assert_int_eq(77, fourth_result);
  ck_assert_int_eq(142, first_result + second_result + third_result + fourth_result);
}

Suite *suite_name(void)
{
  Suite *s;
  TCase *tc_core;

  s = suite_create("Suite Name");

  /* Core test case */
  tc_core = tcase_create("Core");

  tcase_add_test(tc_core, parses_first_configuration_correctly);
  tcase_add_test(tc_core, parses_first_part_example_correctly);
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