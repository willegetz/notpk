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

	const int studentArraySize = 7;
	int student1[studentArraySize]; // Student Id, test 1, test 2, test 3, min, max, average
	int student2[studentArraySize];
	int student3[studentArraySize];

	void ProcessARow(int[]);

//------------------------------------
int main()
{
	const int arraySize = 12;
	int studentScores[arraySize];
	int testArray[4];

	ifstream classScores;
	classScores.open("..\\..\\\\Files\\data.txt");
	while(!classScores.eof())
	{
		classScores >> student1[0];
		classScores >> student1[1];
		classScores >> student1[2];
		classScores >> student1[3];
		ProcessARow(student1);

		classScores >> student2[0];
		classScores >> student2[1];
		classScores >> student2[2];
		classScores >> student2[3];
		ProcessARow(student2);

		classScores >> student3[0];
		classScores >> student3[1];
		classScores >> student3[2];
		classScores >> student3[3];
		ProcessARow(student3);
	}
	classScores.close();
	cout << "Std Id\tA1\tA2\tA3\tMin\tMax\tAverage" << endl;
	cout << "-------------------------------------------------------" << endl;
	cout << student1[0] << "\t" << student1[1] << "\t" << student1[2] << "\t" << student1[3] << "\t" << student1[4] << "\t" << student1[5] << "\t" << student1[6] << ".0" << endl;
	cout << student2[0] << "\t" << student2[1] << "\t" << student2[2] << "\t" << student2[3] << "\t" << student2[4] << "\t" << student2[5] << "\t" << student2[6] << ".0" << endl;
	cout << student3[0] << "\t" << student3[1] << "\t" << student3[2] << "\t" << student3[3] << "\t" << student3[4] << "\t" << student3[5] << "\t" << student3[6] << ".0" << endl;
	std::cin.get();
}

void ProcessARow(int scoreArray[])
{
	int numberOfTests = 3;
	int minScore = scoreArray[1];
	int maxScore = scoreArray[1];
	int sumOfScores = scoreArray[1];
	int averageScore = 0;

	for (int i = 2; i <= numberOfTests; i++)
	{
		if (scoreArray[i] < minScore)
		{
			minScore = scoreArray[i];
		}
		else if (scoreArray[i] > maxScore)
		{
			maxScore = scoreArray[i];
		}

		sumOfScores = sumOfScores + scoreArray[i];
	}
	
	averageScore = sumOfScores / numberOfTests;

	scoreArray[4] = minScore;
	scoreArray[5] = maxScore;
	scoreArray[6] = averageScore;
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