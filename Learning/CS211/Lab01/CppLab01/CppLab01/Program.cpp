#include <iostream>
#include <fstream>
#include <string>
using namespace std;

void test (char str[ ]);
//------------------------------------
int main()
{
	const int arraySize = 100;
	int scores[arraySize];
	int count = 0;
	string line;

	ifstream myFile;
	int item;
	myFile.open("C:\Documents and Settings\wgetz\Learning\CS211\Lab01\Files\data.txt");
		while(!myFile.eof())
		{
			getline(myFile,line);
			cout << line <<endl;
		}
		myFile.close();
		std::cin.get();
		//while (myFile && count < arraySize)
	//{
		
	//}
	//cout << scores;
	
}
//------------------------------------