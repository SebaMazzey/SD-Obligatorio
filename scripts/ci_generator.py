import random
import hashlib

CUSTOM_CI = ['12345678', '50530247']
CI_QUANTITY = 100
MIN_CI = 100000
MAX_CI = 9999999
OUT_FILE = "./insert_users.sql"
HASHED = True

####################################################################################

def getCheckDigit(ci):
    size = len(ci)
    if size == 6:
        factores = [9, 8, 7, 6, 3, 4]
    elif size == 7:
        factores = [2, 9, 8, 7, 6, 3, 4]
    else:
        raise Exception("Invalid CI range: " + size)

    sum = 0
    for i in range(0, size):
        sum += factores[i] * int(ci[i])

    return str((10 - (sum % 10)) % 10)


def generateCISequence(quantity, customCIs=[]):
    ciSet = {int(ci[:-1]): ci for ci in customCIs}
    while len(ciSet) < quantity:
        newCi = random.randint(MIN_CI, MAX_CI)
        if newCi not in ciSet:
            ciSet[newCi] = str(newCi) + getCheckDigit(str(newCi))
    return list(ciSet.values())


def printAsSQLInsert(list, hashed=True, saveToFile=False):
    if not list:
        raise Exception("Empty CI list")

    def formatter(str): return str if not hashed else hashlib.sha256(
        str.encode('utf-8')).hexdigest()

    sql = "INSERT INTO Users (CI) VALUES ('%s')" % formatter(list.pop())
    for elem in list:
        sql += ", ('%s')" % formatter(elem)
    sql += ";"
    if saveToFile:
        print(sql)
    else:
        f = open(OUT_FILE, "w")
        f.write(sql)
        f.close()


ciList = generateCISequence(CI_QUANTITY, CUSTOM_CI)
printAsSQLInsert(ciList, hashed=HASHED)