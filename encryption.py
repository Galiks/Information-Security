import random
import codecs
import fleep


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
        stopSymbol = '$'
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
        text = text.split()

        self.encryption(endFile, masForBit, specSymbolForOne, specSymbolForZero, text, stopSymbol)

        self.decryption(specSymbolForOne, specSymbolForZero, stopSymbol)

    def decryption(self, specSymbolForOne, specSymbolForZero, stopSymbol):
        endFile = codecs.open("endFile.txt", 'r', 'utf_8_sig')
        test = endFile.read()

        result2 = ""
        for i in range(len(test)):
            if test[i] != stopSymbol:
                if test[i] == specSymbolForOne:
                    result2 += "1"
                elif test[i] == specSymbolForZero:
                    result2 += "0"
            else:
                break

        print('Результат дешифрования: ', self.text_from_bits(result2))

    def encryption(self, endFile, masForBit, specSymbolForOne, specSymbolForZero, text, stopSymbol):
        result = ""
        for i in range(len(masForBit)):

            # исключающее или XOR
            if (int(masForBit[i]) & 1) == 1:
                result += text[i] + specSymbolForOne
            elif (int(masForBit[i]) & 1) == 0:
                result += text[i] + specSymbolForZero

        result += stopSymbol

        for i in range(len(masForBit), len(text)):
            result += text[i] + ' '
        endFile.write(result)

    def text_to_bits(self, text, encoding='utf-8', errors='surrogatepass'):
        bits = bin(int.from_bytes(text.encode(encoding, errors), 'big'))[2:]
        return bits.zfill(8 * ((len(bits) + 7) // 8))

    def text_from_bits(self, bits, encoding='utf-8', errors='surrogatepass'):
        n = int(bits, 2)
        return n.to_bytes((n.bit_length() + 7) // 8, 'big').decode(encoding, errors) or '\0'


class Signature:

    def __init__(self):
        signatureDictionary = self.setSignatureDictionary()
<<<<<<< HEAD
        signatureForOffice = '50 4B 03 04 14 00 06 00 08 00 00 00 21 00'
        print("!!!")
        file = open("E:\Документы\Принципы права.docx", "rb")
        test = file.read(32)
        test2 = " ".join(['{:02X}'.format(byte) for byte in test])
        print(test2)
        print("!!!")
        file = open("E:\Документы\First Summary (Airbnb).docx", "rb")
        test = file.read(32)
        test2 = " ".join(['{:02X}'.format(byte) for byte in test])
        print(test2)
        print("!!!")
        file = open("E:\Документы\qwerty.docx", "rb")
        test = file.read(32)
        test2 = " ".join(['{:02X}'.format(byte) for byte in test])
        print(test2)
        print("!!!")
        file = open("E:\Download\Dogovor.docx", "rb")
        test = file.read(32)
        test2 = " ".join(['{:02X}'.format(byte) for byte in test])
        print(test2)
        # file = open("E:\Документы\Принципы права.pptx", "rb")
        # test = file.read(32)
        # print(test)
        # test2 = " ".join(['{:02X}'.format(byte) for byte in test])
        # print(test2)
        # file = open("E:\Документы\Тестовая.pptx", "rb")
        # test = file.read(32)
        # print(test)
        # test2 = " ".join(['{:02X}'.format(byte) for byte in test])
        # print(test2)
        # file = open("E:\Документы\Тестовая2.pptx", "rb")
        # test = file.read(32)
        # print(test)
        # test2 = " ".join(['{:02X}'.format(byte) for byte in test])
        # print(test2)
        # for i in signatureDictionary.keys():
        #     if i in test2:
        #         print(signatureDictionary.get(i))
        if signatureForOffice in test2:
            print('OfficeFile')
=======
        file = open("E:\Загрузки\schedule_do_441.xls", "rb")
        test = file.read()
        print(test)
        test2 = " ".join(['{:02X}'.format(byte) for byte in test])
        print(test2)
        for i in signatureDictionary.keys():
            if i in str(test):
                print(signatureDictionary.get(i))
>>>>>>> e858ba3d3f9bc7deff01331e58e280a36b8acee7

    def setSignatureDictionary(self):
        signatureDictionary = {'49 44 33': 'mp3',
                               '25 50 44 46': 'pdf',
                               '89 50 4E 47 0D 0A 1A 0A': 'png',
                               '52 61 72 21 1A 07': 'rar',
                               '37 7A BC AF 27 1C': '7z',
                               'FF D8 FF DB': 'jpg',
                               '46 4F 52': 'txt',
                               '58 54': 'txt',
                               '01 00 00 20 05 00 00 13 00 08 02 5B 43': 'docx',
                               '01 00 00 20 05 00 00 13 00 08 02 5B 43': 'docx',
                               'D0 CF 11 E0 A1 B1 1A E1': 'xls',
<<<<<<< HEAD
                               '00 00 13 00 08 02 5B 43': 'pptx'
=======
                                'Excel': 'xls'
>>>>>>> e858ba3d3f9bc7deff01331e58e280a36b8acee7
                               }
        return signatureDictionary


if __name__ == '__main__':
<<<<<<< HEAD
    # print('Стеганография')
    # start2 = Steganography()
    # print('Определение сигнатуры')
    # start3 = Signature()
    with open("E:\Документы\Принципы права.pptx", "rb") as file:
        info = fleep.get(file.read(128))

    print(info.type)  # prints ['raster-image']
    print(info.extension)  # prints ['png']
    print(info.mime)  # prints ['image/png']
=======
    print('Определение сигнатуры')
    start3 = Signature()

    # with open("E:\Загрузки\Задание.docx", "rb") as file:
    #     info = fleep.get(file.read(128))
    #
    # print(info.type)  # prints ['raster-image']
    # print(info.extension)  # prints ['png']
    # print(info.mime)  # prints ['image/png']
>>>>>>> e858ba3d3f9bc7deff01331e58e280a36b8acee7
