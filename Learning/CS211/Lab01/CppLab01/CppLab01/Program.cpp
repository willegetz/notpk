//#include <fstream>
//#include <iostream>
//#include <iomanip>
//using namespace std;
//using std::cout;
//using std::endl;
//
//
//int main() {
//  const char* filename = "..\\..\\Files\\data.txt";
//  std::ifstream inFile(filename);
//
//  // Make sure the file stream is good
//  if(!inFile) {
//    cout << endl << "Failed to open file " << filename;
//    return 1;
//  }
//
//  long n = 0;
//  while(!inFile.eof()) {
//    inFile >> n;
//    cout << std::setw(10) << n;
//  }
//  cout << endl;
//  cin.get();
//  return 0;
//}

#include <iostream>
#include <fstream>
#include <string>
using namespace std;

	const int studentArraySize = 4;
	int student1[studentArraySize];
	int student2[studentArraySize];
	int student3[studentArraySize];

void ProcessARow (int scoreArray[ ]);
//------------------------------------
int main()
{
	const int arraySize = 12;
	int scores[arraySize];
	int count = 0;
	int item;



	ifstream myFile;
	myFile.open("..\\..\\\\Files\\data.txt");
	myFile >> item;
	while(myFile && count < arraySize)
	{
		scores[count] = item; // stick the item in the array
		count++;
		myFile >> item;
	}
	myFile.close();
	ProcessARow(scores);
	std::cin.get();
}

void ProcessARow(int scoreArray[])
{
	student1[0] = scoreArray[0];
	student1[1] = scoreArray[1];
	student1[2] = scoreArray[2];
	student1[3] = scoreArray[3];

	student2[0] = scoreArray[4];
	student2[1] = scoreArray[5];
	student2[2] = scoreArray[6];
	student2[3] = scoreArray[7];

	student3[0] = scoreArray[8];
	student3[1] = scoreArray[9];
	student3[2] = scoreArray[10];
	student3[3] = scoreArray[11];
}
//------------------------------------
//
////// reading a text file
////#include <iostream>
////#include <fstream>
////#include <string>
////using namespace std;
////
////int main () {
////  string line;
////  
////  //the variable of type ifstream:
////  ifstream myfile;
////  myfile.open("C:\\Users\\William\\Documents\\Visual Studio 2010\\NoTPK\\trunk\\Learning\\CS211\\Lab01\\Files\\data.txt");
////  
////  //check to see if the file is opened:
////  if (myfile.is_open())
////  {
////	//while there are still lines in the
////	//file, keep reading:
////	while (! myfile.eof() )
////	{
////	  //place the line from myfile into the
////	  //line variable:
////	  getline (myfile,line);
////
////	  //display the line we gathered:
////	  cout << line << endl;
////	  std::cin.get();
////	}
////
////	//close the stream:
////	myfile.close();
////  }
////
////  else cout << "Unable to open file";
////
////  return 0;
////}