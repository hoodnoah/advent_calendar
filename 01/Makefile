CC=clang
CFLAGS=-I.
CHECK_PATH = $(shell brew --prefix check)
TEST_CFLAGS = $(CFLAGS) -I"$(CHECK_PATH)/include" -L"$(CHECK_PATH)/lib" -g -O0
TEST_LIBS = -lcheck

main:
	mkdir -p ./bin
	cp ./input.txt ./bin/input.txt
	$(CC) ./src/main.c -o ./bin/main

configuration.o:
	mkdir -p ./bin
	$(CC) -c ./src/Configuration.c -o ./bin/Configuration.o

test_configuration.o:
	mkdir -p ./bin
	$(CC) ${TEST_CFLAGS} -c ./src/Configuration.c -o ./bin/Configuration.o

test: test_configuration.o
	mkdir -p ./bin
	$(CC) $(TEST_CFLAGS) ./tests/test_parseConfiguration.c ./bin/Configuration.o $(TEST_LIBS) -o ./bin/test
	./bin/test

build_test: test_configuration.o
	mkdir -p ./bin
	cp ./input.txt ./bin/input.txt
	$(CC) $(TEST_CFLAGS) ./tests/test_parseConfiguration.c ./bin/Configuration.o $(TEST_LIBS) -o ./bin/test

clean:
	rm -rf ./bin