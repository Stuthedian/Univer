#include <iostream>
#include <windows.h>
#include <conio.h>
#include <ctime>
using namespace std;

const int variable = 4;
int board[variable][variable] = { 0 };
/*{ { 2,16,32,64 } ,
{ 4,8,4,2048 },
{ 2,4,2,4 },
{ 4,2,4,8 } };*/

bool dorand = true;
bool game = true;


int randblock(int board[][4])
{
	if (dorand)
	{
		int i, j;
		do
		{
			if (board[i = rand() % 4][j = rand() % 4] == 0)
			{
				board[i][j] = ((rand() % 11) ? 2 : 4);//board[i][j] = ( (rand() % 11) == 0 ? 4 : 2)
				break;
			}
			//cout << "i:" << i << '\t' << "j:" << j << endl;
		} while (board[i][j] != 0 );//board[i][j] == 0 && number of empty blocks
		return 0;
	}
	else return 0;
}

void rendering(int board[][4])
{
	cout << endl;
	for (int i = 0; i < 4; i++)
	{
		for (int j = 0; j < 4; j++)
		{
			cout << '\t' << (board[i][j] ?board[i][j] : 0) << ' ';

		}
		cout << endl;
	}
	cout << (dorand ? "true" : "false") << endl;
	/*COORD position = { 0, 0 };
	HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleCursorPosition(hConsole, position);*/
}

void checkkey()
{
	char playkey = _getch();
	void blocksup(int[][4]);
	void blocksdown(int[][4]);
	void blocksleft(int[][4]);
	void blocksright(int[][4]);
	

	switch (playkey)
	{
	case 72:blocksup(board); break;
	case 80:blocksdown(board); break;
	case 75:blocksleft(board); break;
	case 77:blocksright(board); break;
	case 27:exit(0); break;
	default: checkkey();
		/*
			72 Стрелка вверх
			80 Стрелка вниз
			75 Стрелка влево
			77 Стрелка вправо
			*/
	}
}






void main()
{
	int losecondition();
	void wincondition(int[][4]);
	srand(time(NULL));

	randblock(board);
	randblock(board);

	while (game)
	{
		rendering(board);
		checkkey();
		randblock(board);
		wincondition(board);
		losecondition();

	}
	
	system("pause");
}

void blocksup(int board[][4])
{
	int inline checkzeroup(int[][4], int, int);

	dorand = false;

	for (int column = 0; column < 4; column++)
	{
		int row = 0;
		checkzeroup(board, row, column);
		if (board[0][column] == 0) 0;
		else
		{
			if (board[0][column] == board[1][column])
			{
				board[0][column] += board[1][column];
				board[1][column] = 0;
				dorand = true;
			}
			if (board[1][column] == board[2][column] && board[1][column] != 0)
			{
				board[1][column] += board[2][column];
				board[2][column] = 0;
				dorand = true;
			}
			if (board[2][column] == board[3][column] && board[2][column] != 0)
			{
				board[2][column] += board[3][column];
				board[3][column] = 0;
				dorand = true;
			}
			if (board[1][column] == 0 && board[2][column] != 0)
			{
				int temp = board[1][column];
				board[1][column] = board[2][column];
				board[2][column] = temp;
				dorand = true;
			}
			if (board[2][column] == 0 && board[3][column] != 0)
			{
				int temp = board[2][column];
				board[2][column] = board[3][column];
				board[3][column] = temp;
				dorand = true;
			}
		}
	}
}

void blocksdown(int board[][4])
{
	int inline checkzerodown(int[][4], int, int);

	dorand = false;

	for (int column = 0; column < 4; column++)
	{
		int row = 3;

		checkzerodown(board, row, column);
		if (board[3][column] == 0) 0;
		else
		{
			if (board[2][column] == board[3][column])
			{
				board[3][column] += board[2][column];
				board[2][column] = 0;
				dorand = true;
			}
			if (board[1][column] == board[2][column] && board[2][column] != 0)
			{
				board[2][column] += board[1][column];
				board[1][column] = 0;
				dorand = true;
			}
			if (board[0][column] == board[1][column] && board[1][column] != 0)
			{
				board[1][column] += board[0][column];
				board[0][column] = 0;
				dorand = true;
			}
			if (board[2][column] == 0 && board[1][column] != 0)
			{
				int temp = board[2][column];
				board[2][column] = board[1][column];
				board[1][column] = temp;
				dorand = true;
			}
			if (board[1][column] == 0 && board[0][column] != 0)
			{
				int temp = board[1][column];
				board[1][column] = board[0][column];
				board[0][column] = temp;
				dorand = true;
			}
		}
	}
}

int  checkzeroup(int board[][4], int frow, int fcolumn)
{
	if (board[frow][fcolumn] == 0)
		if (frow == variable - 1)
			return 0;
		else 
		{
			checkzeroup(board, frow + 1, fcolumn);
			return 0;
		}
	else if (board[frow][fcolumn] != 0 && frow != 0 && board[frow - 1][fcolumn] == 0)
	{
		int temp = board[frow][fcolumn];
		board[frow][fcolumn] = board[frow - 1][fcolumn];
		board[frow - 1][fcolumn] = temp;
		dorand = true;
		checkzeroup(board, frow - 1, fcolumn);
		return 0;
	}
	else if (board[frow][fcolumn] != 0 && frow >= 0 && frow < variable - 1)
	{
		checkzeroup(board, frow + 1, fcolumn);
		return 0;
	}
	else return 0;
}

void blocksleft(int board[][4])
{
	int inline checkzeroleft(int[][4], int, int);
	dorand = false;

	for (int row = 0; row < 4; row++)
	{
		int column = 0;
		checkzeroleft(board,row,column);
		if (board[row][0] == 0) 0;
		else
		{
			if (board[row][0] == board[row][1])
			{
				board[row][0] += board[row][1];
				board[row][1] = 0;
				dorand = true;

			}
			if (board[row][1] == board[row][2] && board[row][1] != 0)
			{
				board[row][1] += board[row][2];
				board[row][2] = 0;
				dorand = true;
			}
			if (board[row][2] == board[row][3] && board[row][2] != 0)
			{
				board[row][2] += board[row][3];
				board[row][3] = 0;
				dorand = true;
			}
			if (board[row][1] == 0 && board[row][2] != 0)
			{
				int temp = board[row][1];
				board[row][1] = board[row][2];
				board[row][2] = temp;
				dorand = true;
			}
			if (board[row][2] == 0 && board[row][3] != 0)
			{
				int temp = board[row][2];
				board[row][2] = board[row][3];
				board[row][3] = temp;
				dorand = true;
			}
		}
	}
	
}

void blocksright(int board[][4])
{
	int inline checkzeroright(int[][4], int, int);
	dorand = false;

	for (int row = 0; row < 4; row++)
	{
		int column = 3;
		checkzeroright(board, row, column);
		if (board[row][3] == 0) 0;
		else
		{
			if (board[row][3] == board[row][2])
			{
				board[row][3] += board[row][2];
				board[row][2] = 0;
				dorand = true;

			}
			if (board[row][2] == board[row][1] && board[row][2] != 0)
			{
				board[row][2] += board[row][1];
				board[row][1] = 0;
				dorand = true;
			}
			if (board[row][1] == board[row][0] && board[row][1] != 0)
			{
				board[row][1] += board[row][0];
				board[row][0] = 0;
				dorand = true;
			}
			if (board[row][2] == 0 && board[row][1] != 0)
			{
				int temp = board[row][2];
				board[row][2] = board[row][1];
				board[row][1] = temp;
				dorand = true;
			}
			if (board[row][1] == 0 && board[row][0] != 0)
			{
				int temp = board[row][1];
				board[row][1] = board[row][0];
				board[row][0] = temp;
				dorand = true;
			}
		}
	}

	

}

int checkzeroright(int board[][4], int frow, int fcolumn)
{
	if (board[frow][fcolumn] == 0)
		if (fcolumn == 0)
			return 0;
		else 
		{
			checkzeroright(board, frow, fcolumn - 1);
			return 0;
		}
	else if (board[frow][fcolumn] != 0 && fcolumn != 3 && board[frow][fcolumn + 1] == 0)
	{
		int temp = board[frow][fcolumn];
		board[frow][fcolumn] = board[frow][fcolumn + 1];
		board[frow][fcolumn + 1] = temp;
		dorand = true;
		checkzeroright(board, frow, fcolumn + 1);
		return 0;
	}
	else if (board[frow][fcolumn] != 0 && fcolumn > 0 && fcolumn <= 3)
	{
		checkzeroright(board, frow, fcolumn - 1);
		return 0;
	}
	else return 0;
}

int checkzeroleft(int board[][4], int frow, int fcolumn)
{
	if (board[frow][fcolumn] == 0)
		if (fcolumn == 3)
			return 0;
		else 
		{
			checkzeroleft(board, frow, fcolumn + 1);
			return 0;
		}
	else if (board[frow][fcolumn] != 0 && fcolumn != 0 && board[frow][fcolumn - 1] == 0)
	{
		int temp = board[frow][fcolumn];
		board[frow][fcolumn] = board[frow][fcolumn - 1];
		board[frow][fcolumn - 1] = temp;
		dorand = true;
		checkzeroleft(board, frow, fcolumn - 1);
		return 0;
	}
	else if (board[frow][fcolumn] != 0 && fcolumn >= 0 && fcolumn < 3)
	{
		checkzeroleft(board, frow, fcolumn + 1);
		return 0;
	}
	else return 0;
}

int  checkzerodown(int board[][4], int frow, int fcolumn)
{


	if (board[frow][fcolumn] == 0)
		if (frow == 0)
			return 0;
		else 
		{ 
			checkzerodown(board, frow - 1, fcolumn); 
			return 0;
		}
	else if (board[frow][fcolumn] != 0 && frow != 3 && board[frow + 1][fcolumn] == 0)
	{
		int temp = board[frow][fcolumn];
		board[frow][fcolumn] = board[frow + 1][fcolumn];
		board[frow + 1][fcolumn] = temp;
		dorand = true;
		checkzerodown(board, frow + 1, fcolumn);
		return 0;
	}
	else if (board[frow][fcolumn] != 0 && frow > 0 && frow <= variable - 1)
	{
		checkzerodown(board, frow - 1, fcolumn);
		return 0;
	}
	else return 0;

}

	int losecondition()
{
	void blocksupemu(int[][4]);
	void blocksdownemu(int[][4]);
	void blocksleftemu(int[][4]);
	void blocksrightemu(int[][4]);
	
	if (game == false) return 0;
		blocksupemu(board);
		blocksdownemu(board);
		blocksleftemu(board);
		blocksrightemu(board);

		if (dorand == false)
		{
			cout << "game over ,pendejo" << endl;
			game = false;
		}
		else 0;
		
		COORD position = { 0, 0 };
		HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
		SetConsoleCursorPosition(hConsole, position);
		return 0;
}

	void blocksupemu(int board[][4])
	{
		int inline checkzeroupemu(int[][4], int, int);


		for (int column = 0; column < 4; column++)
		{
			int row = 0;
			checkzeroupemu(board, row, column);
			if (board[0][column] == 0) 0;
			else if (dorand == true) break;
			else
			{
				if (board[0][column] == board[1][column])
				{
					dorand = true;
					break;
				}
				if (board[1][column] == board[2][column] && board[1][column] != 0)
				{
					dorand = true;
					break;
				}
				if (board[2][column] == board[3][column] && board[2][column] != 0)
				{
					dorand = true;
					break;
				}
				if (board[1][column] == 0 && board[2][column] != 0)
				{
					dorand = true;
					break;
				}
				if (board[2][column] == 0 && board[3][column] != 0)
				{
					dorand = true;
				}
			}
		}
	}

	int  checkzeroupemu(int board[][4], int frow, int fcolumn)
	{
		if (board[frow][fcolumn] == 0)
			if (frow == 3)
				return 0;
			else
			{
				checkzeroupemu(board, frow + 1, fcolumn);
				return 0;
			}
		else if (board[frow][fcolumn] != 0 && frow != 0 && board[frow - 1][fcolumn] == 0)
		{
			dorand = true;
			//checkzeroupemu(board, frow + 1, fcolumn);
			return 0;
		}
		else if (board[frow][fcolumn] != 0 && frow >= 0 && frow < variable - 1)
		{
			checkzeroupemu(board, frow + 1, fcolumn);
			return 0;
		}
		else return 0;
	}

	void blocksdownemu(int board[][4])
	{
		int inline checkzerodownemu(int[][4],int, int);

	

		for (int column = 0; column < 4; column++)
		{
			int row = 3;

			checkzerodownemu( board,row, column);
			if (board[3][column] == 0) 0;
			else if (dorand == true) break;
			else
			{
				if (board[2][column] == board[3][column])
				{
					dorand = true;
					break;
				}
				if (board[1][column] == board[2][column] && board[2][column] != 0)
				{
					dorand = true;
					break;
				}
				if (board[0][column] == board[1][column] && board[1][column] != 0)
				{
					dorand = true;
					break;
				}
				if (board[2][column] == 0 && board[1][column] != 0)
				{
					dorand = true;
					break;
				}
				if (board[1][column] == 0 && board[0][column] != 0)
				{
					dorand = true;
					break;
				}
			}
		}
	}

	int  checkzerodownemu(int board[][4], int frow, int fcolumn)
	{
		if (board[frow][fcolumn] == 0)
			if (frow == 0)
				return 0;
			else
			{
				checkzerodownemu(board,frow - 1, fcolumn);
				return 0;
			}
		else if (board[frow][fcolumn] != 0 && frow != 3 && board[frow + 1][fcolumn] == 0)
		{
			dorand = true;
			checkzerodownemu(board, frow - 1, fcolumn);
			return 0;
		}
		else if (board[frow][fcolumn] != 0 && frow > 0 && frow <= variable - 1)
		{
			checkzerodownemu(board, frow - 1, fcolumn);
			return 0;
		}
		else return 0;

	}

	void blocksleftemu(int board[][4])
	{
		int inline checkzeroleftemu(int[][4], int, int);
		

		for (int row = 0; row < 4; row++)
		{
			int column = 0;
			checkzeroleftemu(board, row, column);
			if (board[row][0] == 0) 0;
			else if (dorand == true) break;
			else
			{
				if (board[row][0] == board[row][1])
				{
					dorand = true;
					break;
				}
				if (board[row][1] == board[row][2] && board[row][1] != 0)
				{
					dorand = true;
					break;
				}
				if (board[row][2] == board[row][3] && board[row][2] != 0)
				{
					dorand = true;
					break;
				}
				if (board[row][1] == 0 && board[row][2] != 0)
				{
					dorand = true;
					break;
				}
				if (board[row][2] == 0 && board[row][3] != 0)
				{
					dorand = true;
					break;
				}
			}
		}

	}

	int checkzeroleftemu(int board[][4], int frow, int fcolumn)
	{
		if (board[frow][fcolumn] == 0)
			if (fcolumn == 3)
				return 0;
			else
			{
				checkzeroleftemu(board, frow, fcolumn + 1);
				return 0;
			}
		else if (board[frow][fcolumn] != 0 && fcolumn != 0 && board[frow][fcolumn - 1] == 0)
		{
			dorand = true;
			checkzeroleftemu(board, frow, fcolumn + 1);
			return 0;
		}
		else if (board[frow][fcolumn] != 0 && fcolumn >= 0 && fcolumn < 3)
		{
			checkzeroleftemu(board, frow, fcolumn + 1);
			return 0;
		}
		else return 0;
	}

	void blocksrightemu(int board[][4])
	{
		int inline checkzerorightemu(int[][4], int, int);
		

		for (int row = 0; row < 4; row++)
		{
			int column = 3;
			checkzerorightemu(board, row, column);
			if (board[row][3] == 0) 0;
			else if (dorand == true) break;
			else
			{
				if (board[row][3] == board[row][2])
				{
					dorand = true;
					break;

				}
				if (board[row][2] == board[row][1] && board[row][2] != 0)
				{
					dorand = true;
					break;
				}
				if (board[row][1] == board[row][0] && board[row][1] != 0)
				{
					dorand = true;
					break;
				}
				if (board[row][2] == 0 && board[row][1] != 0)
				{
					dorand = true;
					break;
				}
				if (board[row][1] == 0 && board[row][0] != 0)
				{
					dorand = true;
					break;
				}
			}
		}



	}

	int checkzerorightemu(int board[][4], int frow, int fcolumn)
	{
		if (board[frow][fcolumn] == 0)
			if (fcolumn == 0)
				return 0;
			else
			{
				checkzerorightemu(board, frow, fcolumn - 1);
				return 0;
			}
		else if (board[frow][fcolumn] != 0 && fcolumn != 3 && board[frow][fcolumn + 1] == 0)
		{
			dorand = true;
			checkzerorightemu(board, frow, fcolumn - 1);
			return 0;
		}
		else if (board[frow][fcolumn] != 0 && fcolumn > 0 && fcolumn <= 3)
		{
			checkzerorightemu(board, frow, fcolumn - 1);
			return 0;
		}
		else return 0;
	}

	void wincondition(int board[][4])
	{
		for (int row = 0; row < 4; row++)
			for (int column = 0; column < 4; column++)
			{
				if (board[row][column] == 2048)
				{
					cout << "You won!"<<endl;
					cout << "Continue  the game?[y/n]" << endl;
					char choice = _getch();
					switch (choice)
					{
					case 'y': case 'Y':case 'н':case'Н':game = true; break;
					case 'n': case 'N':case 'т':case'Т':game = false; break;
					}

				}
			}
	}

