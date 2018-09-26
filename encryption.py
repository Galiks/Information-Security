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


class Steganography:

    def __init__(self):
        # инициализация переменных
        line = "usual text"
        lineLength = len(line)
        startFile = open("startFile.txt", 'r')
        endFile = open("endFile.txt", 'w+')
        letter = startFile.read()
        array = self.text_to_bits(letter)
        specSymbolForZero = self.text_from_bits(str(100000))
        specSymbolForOne = self.text_from_bits(str(1111111))
        line = self.encryption(array, endFile, line, specSymbolForOne, specSymbolForZero)
        # декодирование
        self.decryption(line, lineLength, specSymbolForOne, specSymbolForZero)

    def decryption(self, line, lineLength, specSymbolForOne, specSymbolForZero):
        result = ""
        for i in range(lineLength, len(line)):
            if line[i] == specSymbolForZero:
                result += "0"
            elif line[i] == specSymbolForOne:
                result += "1"
        print(self.text_from_bits(result))

    def encryption(self, array, endFile, line, specSymbolForOne, specSymbolForZero):
        for item in array:
            for i in item:
                if (int(i) & 1) == 1:
                    line += specSymbolForOne
                else:
                    line += specSymbolForZero
        endFile.write(line)
        return line

    def text_to_bits(self, text, encoding='utf-8', errors='surrogatepass'):
        bits = bin(int.from_bytes(text.encode(encoding, errors), 'big'))[2:]
        return bits.zfill(8 * ((len(bits) + 7) // 8))

    def text_from_bits(self, bits, encoding='utf-8', errors='surrogatepass'):
        n = int(bits, 2)
        return n.to_bytes((n.bit_length() + 7) // 8, 'big').decode(encoding, errors) or '\0'


if __name__ == '__main__':
    start1 = Encryption()
    start2 = Steganography()
