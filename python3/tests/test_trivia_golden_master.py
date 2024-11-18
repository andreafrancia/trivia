import os.path

import trivia
import random


class TestTriviaGoldenMaster:
    def test(self, capsys):
        for seed in range(0,100):
            random.seed(seed)
            trivia.main()

        captured = capsys.readouterr()
        maybe_write_reference(captured.out)
        write_file("output.txt", captured.out)

        assert captured.out == read_file("reference.txt")


def maybe_write_reference(content: str):
    if not os.path.exists("reference.txt"):
        write_file("reference.txt", content)


def write_file(path: str, content: str):
    with open(path, "w") as f:
        f.write(content)


def read_file(path: str):
    with open(path, "r") as f:
        return f.read()
