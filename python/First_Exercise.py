import random

def IsPasswordValid(password,length=12):
    if(len(password)<length):
        return False
    isThereCapital=False
    isThereSmall=False
    isThereSpecialChar=False
    isThereNumric=False
    for char in password:
        if(char>='A'and char<='Z'):
            isThereCapital=True
        elif(char>='a'and char<='z') :   
            isThereSmall=True
        elif(char in ['#','$','!','@']):
            isThereSpecialChar=True
        elif(char>='0'and char<='9'):
            isThereNumric=True    
    return isThereSpecialChar and isThereSmall and  isThereCapital and isThereNumric     
def GeneratePassword(number=12):
    charsCapital=[chr(i) for i in range(ord('A'), ord('Z') + 1)]
    charsSmall=[chr(i) for i in range(ord('a'), ord('z') + 1)]
    charsNumric=[chr(i) for i in range(ord('0'), ord('9') + 1)]
    charsSpecial=['@','#','!','%','$']
    allChars=charsCapital+charsCapital+charsSmall+charsNumric+charsSpecial
    password=""
    while(not IsPasswordValid(password,number)):
        password="".join( random.choices(allChars,weights=None,k=number))
    return password
            
            
pasword=GeneratePassword()
print(pasword)
print(IsPasswordValid(pasword,12))