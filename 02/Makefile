CC=clang
CFLAGS=-I.
CHECK_PATH = $(shell brew --prefix check)
TEST_CFLAGS = $(CFLAGS) -I"$(CHECK_PATH)/include" -L"$(CHECK_PATH)/lib" -g -O0
TEST_LIBS = -lcheck

run: main
	./bin/main

build_main: gamePossible.o
	mkdir -p ./bin
	cp ./input.txt ./bin/input.txt
	$(CC) ./src/main.c ./bin/GamePossible.o -o ./bin/main.out

run_main: build_main
	./bin/main.out

build_main_debug: debug_gamePossible.o
	mkdir -p ./bin
	cp ./input.txt ./bin/input.txt
	$(CC) ./src/main.c ./bin/GamePossible.o -o ./bin/main.out

gamePossible.o:
	mkdir -p ./bin
	$(CC) -c ./src/GamePossible.c -o ./bin/GamePossible.o

debug_gamePossible.o:
	mkdir -p ./bin
	$(CC) -c ./src/GamePossible.c -o ./bin/GamePossible.o

build_test: debug_gamePossible.o
	mkdir -p ./bin
	cp ./input.txt ./bin/input.txt
	$(CC) $(TEST_CFLAGS) ./tests/test_gamePossible.c ./bin/GamePossible.o $(TEST_LIBS) -o ./bin/test.out

run_test: build_test
	./bin/test.out

clean:
	rm -rf ./bin