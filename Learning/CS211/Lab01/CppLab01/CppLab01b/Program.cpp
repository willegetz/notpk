#include <iostream>
#include <fstream>
#include <string>
using namespace std;

	const int studentArraySize = 7;
	int student1[studentArraySize];
	int student2[studentArraySize];
	int student3[studentArraySize];
	const char tab = '\t';

	void ProcessARow(int[]);
	int CalculateMin(int&, int&, int&);
	int CalculateMax(int&, int&, int&);
	int CalculateAverage(int&, int&, int&);


int main()
{
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
	cout << student1[0] << tab << student1[1] << tab << student1[2] << tab << student1[3] << tab << student1[4] << tab << student1[5] << tab << student1[6] << ".0" << endl;
	cout << student2[0] << tab << student2[1] << tab << student2[2] << tab << student2[3] << tab << student2[4] << tab << student2[5] << tab << student2[6] << ".0" << endl;
	cout << student3[0] << tab << student3[1] << tab << student3[2] << tab << student3[3] << tab << student3[4] << tab << student3[5] << tab << student3[6] << ".0" << endl;
	std::cin.get();
}

void ProcessARow(int scoreArray[])
{
	scoreArray[4] = CalculateMin(scoreArray[1], scoreArray[2], scoreArray[3]);
	scoreArray[5] = CalculateMax(scoreArray[1], scoreArray[2], scoreArray[3]);
	scoreArray[6] = CalculateAverage(scoreArray[1], scoreArray[2], scoreArray[3]);
}

int CalculateMin(int& test1, int& test2, int& test3)
{
	if (test2 < test1)
	{
		return test2;
	}

	if (test3 < test1)
	{
		return test3;
	}

	return test1;
	
}

int CalculateMax(int& test1, int& test2, int& test3)
{
	if (test2 > test1)
	{
		return test2;
	}

	if (test3 > test1)
	{
		return test3;
	}

	return test1;
}

int CalculateAverage(int& test1, int& test2, int& test3)
{
	int numberOfTests = 3;
	return (test1 + test2 + test3) / numberOfTests;
}