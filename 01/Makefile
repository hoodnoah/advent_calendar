CC=clang
CFLAGS=-I.
CHECK_PATH = $(shell brew --prefix check)
TEST_CFLAGS = $(CFLAGS) -I"$(CHECK_PATH)/include" -L"$(CHECK_PATH)/lib"
TEST_LIBS = -lcheck

main:
	mkdir -p ./bin
	$(CC) ./src/main.c -o ./bin/main

test:
	mkdir -p ./bin/tests
	$(CC) $(TEST_CFLAGS) -o ./bin/tests/test_configurationbasic ./tests/test_configurationbasic.c $(TEST_LIBS)
	./bin/tests/test_configurationbasic

echo:
	echo $(brew --prefix check)

clean:
	rm -rf ./bin