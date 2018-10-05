import random
import codecs


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
        print('Зашифрованное сообщение: ', result)
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
        print('Дешифрованное сообщение: ', line)

    def encrypting(self):
        global alphabet, steps
        alphabet = "QWERTYUIOPASDFGHJKLZXCVBNMЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮqwertyuiopasdfghjklzxcvbnmйцукенгшщзхъфывапролджэячсмитьбю1234567890!?№;%:*()@#$^&[].,/\\_+=-"
        print('Алфавит: ', alphabet)
        result = ""
        line = input()
        print('Входная строка, заданная пользователем', line)
        steps = []
        for i in range(len(line)):
            steps.append(random.randint(1, len(alphabet)))
        self.decr(steps, self.encr(result, line))


class Steganography:

    def __init__(self):
        # инициализация переменных
        masForBit = ""
        startFile = codecs.open("startFile.txt", 'r', 'utf_8_sig')
        textFile = codecs.open("fileWithText.txt", 'r', 'utf_8_sig')
        endFile = codecs.open("endFile.txt", 'w+', 'utf_8_sig')
        letter = startFile.read()
        text = textFile.read()
        specSymbolForZero = self.text_from_bits(str(100000))
        specSymbolForOne = self.text_from_bits(str(1111111))
        print('Входная строка, заданная пользователем: ', letter)
        for item in letter:
            masForBit += self.text_to_bits(item)
        lenMasOfBit = len(masForBit)
        text = text.split()

        self.encryption(endFile, lenMasOfBit, masForBit, specSymbolForOne, specSymbolForZero, text)

        self.decryption(lenMasOfBit, specSymbolForOne, specSymbolForZero, text)

    def decryption(self, lenMasOfBit, specSymbolForOne, specSymbolForZero, text):
        endFile = codecs.open("endFile.txt", 'r', 'utf_8_sig')
        test = endFile.read()
        result2 = ""
        for i in range(len(text)):
            if test[i] == specSymbolForOne:
                result2 += "1"
            elif test[i] == specSymbolForZero:
                result2 += "0"
        print('Результат дешифрования: ', self.text_from_bits(result2[:lenMasOfBit]))

    def encryption(self, endFile, lenMasOfBit, masForBit, specSymbolForOne, specSymbolForZero, text):
        result = ""
        for i in range(lenMasOfBit):

            if (int(masForBit[i]) & 1) == 1:
                result += text[i] + specSymbolForOne
            elif (int(masForBit[i]) & 1) == 0:
                result += text[i] + specSymbolForZero
        for i in range(lenMasOfBit, len(text)):
            result += text[i] + ' '
        endFile.write(result)

    def text_to_bits(self, text, encoding='utf-8', errors='surrogatepass'):
        bits = bin(int.from_bytes(text.encode(encoding, errors), 'big'))[2:]
        return bits.zfill(8 * ((len(bits) + 7) // 8))

    def text_from_bits(self, bits, encoding='utf-8', errors='surrogatepass'):
        n = int(bits, 2)
        return n.to_bytes((n.bit_length() + 7) // 8, 'big').decode(encoding, errors) or '\0'


if __name__ == '__main__':
    # print('Шифр Цезаря')
    # start1 = Encryption()
    # print()
    print('Стеганография')
    start2 = Steganography()