#include <iostream>
#include <fstream>
#include <string>
#include <vector>
using namespace std;

// TODO 'Add' function
// TODO 'Delete' function
// TODO 'Print' function

int main()
{
	vector<string> v;
	ifstream dataFile;
	string commandOperation;
	// TODO bring in data.txt
	dataFile.open("..\\..\\Lab02\\Lab02\\Files\\data.txt");

	while (!dataFile.eof())
	{
		// TODO Read in the first line and split on the tabs
		getline(dataFile, commandOperation);
		// TODO Switch based on the first index
		//		Add will have two additional items: What to add and which index to add it to
		//		Delete will have what index to delete
		//		Print will simply print the vector v so far
	}
}




//TODO verify whether or not add/delete functions can be performed on the index indicated
