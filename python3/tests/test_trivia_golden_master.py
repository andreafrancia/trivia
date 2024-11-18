import os.path
from tkinter.ttk import Label

import trivia
import random


class TestTriviaGoldenMaster:
    def test(self, capsys):
        for seed in range(0, 100):
            random.seed(seed)
            trivia.main()

        captured = capsys.readouterr()
        maybe_write_reference(captured.out)
        write_file("output.txt", captured.out)

        assert captured.out == read_file("reference.txt")

    def test_category(self):
        game = trivia.Game()
        game.add("pippo")

        assert game._current_category == "Pop"
        game.roll(1)
        assert game._current_category == "Science"
        game.roll(1)
        assert game._current_category == "Sports"
        game.roll(1)
        assert game._current_category == "Rock"

    def test_category3(self):
        result = []
        for i in range(0, 20):
            assert self.current_category_at(i) == ['Pop', 'Science', 'Sports', 'Rock'] [i%4]


    def test_category2(self):
        result = []
        for i in range(0, 20):
            result += [(i, self.current_category_at(i))]

        assert result == [(0, 'Pop'),
                          (1, 'Science'),
                          (2, 'Sports'),
                          (3, 'Rock'),
                          (4, 'Pop'),
                          (5, 'Science'),
                          (6, 'Sports'),
                          (7, 'Rock'),
                          (8, 'Pop'),
                          (9, 'Science'),
                          (10, 'Sports'),
                          (11, 'Rock'),
                          (12, 'Pop'),
                          (13, 'Science'),
                          (14, 'Sports'),
                          (15, 'Rock'),
                          (16, 'Pop'),
                          (17, 'Science'),
                          (18, 'Sports'),
                          (19, 'Rock')]

    def current_category_at(self, position):
        game = trivia.Game()
        game.add("pippo")
        game.roll(position)
        return game._current_category


def maybe_write_reference(content: str):
    if not os.path.exists("reference.txt"):
        write_file("reference.txt", content)


def write_file(path: str, content: str):
    with open(path, "w") as f:
        f.write(content)


def read_file(path: str):
    with open(path, "r") as f:
        return f.read()
