CC=clang
CFLAGS=-I.
CHECK_PATH = $(shell brew --prefix check)
TEST_CFLAGS = $(CFLAGS) -I"$(CHECK_PATH)/include" -L"$(CHECK_PATH)/lib"
TEST_LIBS = -lcheck

main:
	mkdir -p ./bin
	$(CC) ./src/main.c -o ./bin/main

configuration.o:
	mkdir -p ./bin
	$(CC) -c ./src/Configuration.c -o ./bin/Configuration.o

test: configuration.o
	mkdir -p ./bin
	$(CC) $(TEST_CFLAGS) ./tests/test_configurationbasic.c ./bin/Configuration.o $(TEST_LIBS) -o ./bin/test
	./bin/test

clean:
	rm -rf ./bin