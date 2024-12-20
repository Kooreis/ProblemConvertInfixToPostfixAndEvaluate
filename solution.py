class Conversion:
    def __init__(self, capacity):
        self.top = -1
        self.capacity = capacity
        self.array = []
        self.precedence = {'+':1, '-':1, '*':2, '/':2, '^':3}
        self.result = []
        self.operators = set(['+', '-', '*', '/', '(', ')', '^'])