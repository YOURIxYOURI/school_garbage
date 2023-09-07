from random import randrange

def display_board(baord):
    print("+-------+-------+-------+")
    print("|       |       |       |")
    print("|   "+ board[0][0] +"   |   "+ board[0][1] +"   |   "+ board[0][2] +"   |")
    print("|       |       |       |")
    print("+-------+-------+-------+")
    print("|       |       |       |")
    print("|   "+ board[1][0] +"   |   "+ board[1][1] +"   |   "+ board[1][2] +"   |")
    print("|       |       |       |")
    print("+-------+-------+-------+")
    print("|       |       |       |")
    print("|   "+ board[2][0] +"   |   "+ board[2][1] +"   |   "+ board[2][2] +"   |")
    print("|       |       |       |")
    print("+-------+-------+-------+")

def enter_move(board):
    while True:
        move=input('podaj pole wolne pole od 1 do 9: ')
        if move < '1' or move > '9':
            print('podaj poprawną wartość(1-9)')
            continue
        elif move not in board[0] and move not in board[1] and move not in board[2]:
            print('wybierz wolne pole, to pole jest juz zajete')
            continue
        elif move == '1':
            board[0][0] = 'O'
            break
        elif move == '2':
            board[0][1] = 'O'
            break
        elif move == '3':
            board[0][2] = 'O'
            break
        elif move == '4':
            board[1][0] = 'O'
            break
        elif move == '5':
            board[1][1] = 'O'
            break
        elif move == '6':
            board[1][2] = 'O'
            break
        elif move == '7':
            board[2][0] = 'O'
            break
        elif move == '8':
            board[2][1] = 'O'
            break
        elif move == '9':
            board[2][2] = 'O'
            break
def make_list_of_free_fields(board):
    global freefields
    freefields = []
    for row in range(0,3):
        for column in range(0,3):
            if board[row][column] == 'X' or board[row][column] == 'O':
                pass
            else:
                freefields.append(([row],[column]))

def victory_for(board, sign):
    if board[0][0] == sign and board[0][1] == sign and board[0][2] == sign:
        return True
    elif board[1][0] == sign and board[1][1] == sign and board[1][2] == sign:
        return True
    elif board[2][0] == sign and board[2][1] == sign and board[2][2] == sign:
        return True
    elif board[0][0] == sign and board[1][0] == sign and board[2][0] == sign:
        return True
    elif board[0][1] == sign and board[1][1] == sign and board[2][1] == sign:
        return True
    elif board[0][2] == sign and board[1][2] == sign and board[2][2] == sign:
        return True
    elif board[0][0] == sign and board[1][1] == sign and board[2][2] == sign:
        return True
    elif board[2][0] == sign and board[1][1] == sign and board[0][2] == sign:
        return True
    else:
        return False
 
   
def draw_move(board):
    while True:
        row = randrange(3)
        column = randrange(3)
        if ([row],[column]) not in freefields:
            continue
        else:
            board[row][column] = 'X'
            return

    

board = [['1','2','3'],['4','X','6'],['7','8','9']]
moves = 1
computer = 'X'
player = 'O'

print('witaj w "TICK TACK TOE", tak wygląda nasza plansza ')
display_board(board)
while moves < 9:
    enter_move(board)
    moves += 1
    display_board(board)
    if victory_for(board, player) == True:
        print('GAME OVER wygrał gracz')
        break
    make_list_of_free_fields(board)

    draw_move(board)
    moves += 1 
    display_board(board)
    if victory_for(board, computer) == True:
        print('GAME OVER wygrał komputer')
        break
    make_list_of_free_fields(board)
else: 
    print('REMIS')
print('dziekuje za gre, zagraj jeszcze raz kiedys')

#to jest kólko i krzyzyk PvE 
    
    




