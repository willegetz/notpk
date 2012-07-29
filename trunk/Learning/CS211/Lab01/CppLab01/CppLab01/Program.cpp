#include <iostream>
#include <fstream>
#include <string>
using namespace std;

	const int studentArraySize = 7;
	int student1[studentArraySize];
	int student2[studentArraySize];
	int student3[studentArraySize];

	void ProcessARow(int[]);

int main()
{
	const int arraySize = 12;
	int studentScores[arraySize];
	int testArray[4];
	"\"
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