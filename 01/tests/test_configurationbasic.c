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

Suite *suite_name(void)
{
  Suite *s;
  TCase *tc_core;

  s = suite_create("Suite Name");

  /* Core test case */
  tc_core = tcase_create("Core");

  tcase_add_test(tc_core, parses_first_configuration_correctly);
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