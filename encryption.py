import random


class Encryption:

    def __init__(self):
        self.encrypting()

    def encr(self, result: str, line: str):
        j = 0
        for i in line:
            if i == ' ':
                result += ' '
            else:
                result += alphabet[(alphabet.index(i) + steps[j]) % len(alphabet)]
                j += 1
        print(result)
        return result

    def decr(self, steps: list, result: str):
        line = ""
        j = 0
        for i in result:
            if i == ' ':
                line += ' '
            else:
                line += alphabet[(alphabet.index(i) - steps[j]) % len(alphabet)]
                j += 1
        print(line)

    def encrypting(self):
        global alphabet, steps
        alphabet = "QWERTYUIOPASDFGHJKLZXCVBNMЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮqwertyuiopasdfghjklzxcvbnmйцукенгшщзхъфывапролджэячсмитьбю1234567890!?№;%:*()@#$^&[].,/\\_+=-"
        result = ""
        line = input()
        print(line)
        steps = []
        for i in range(len(line)):
            steps.append(random.randint(1, len(alphabet)))
        self.decr(steps, self.encr(result, line))


if __name__ == '__main__':
    start = Encryption()
