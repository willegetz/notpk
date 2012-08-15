#include <iostream>
#include <fstream>
#include <sstream>
#include <string>
#include <vector>

	const char tab = '\t';

	std::vector<int> ProcessARow(std::string);

int main()
{
	std::vector<int> student1V;
	std::vector<int> student2V;
	std::vector<int> student3V;
	std::string studentLine;

	std::ifstream classScores;
	classScores.open("..\\..\\Files\\data.txt");
	while(!classScores.eof())
	{
		std::getline(classScores, studentLine);
		student1V = ProcessARow(studentLine);

		std::getline(classScores, studentLine);
		student2V = ProcessARow(studentLine);

		std::getline(classScores, studentLine);
		student3V = ProcessARow(studentLine);
	}
	classScores.close();
	std::cout << "Std Id\tA1\tA2\tA3\tMin\tMax\tAverage" << std::endl;
	std::cout << "-------------------------------------------------------" << std::endl;
	std::cout << student1V[0] << tab << student1V[1] << tab << student1V[2] << tab << student1V[3] << tab << student1V[4] << tab << student1V[5] << tab << student1V[6] << ".0" << std::endl;
	std::cout << student2V[0] << tab << student2V[1] << tab << student2V[2] << tab << student2V[3] << tab << student2V[4] << tab << student2V[5] << tab << student2V[6] << ".0" << std::endl;
	std::cout << student3V[0] << tab << student3V[1] << tab << student3V[2] << tab << student3V[3] << tab << student3V[4] << tab << student3V[5] << tab << student3V[6] << ".0" << std::endl;
	std::cin.get();
}

std::vector<int> ProcessARow(std::string lineInput)
{
	std::stringstream ss(lineInput);
	std::vector<int> temp;
	std::string item;
	while(std::getline(ss, item, tab))
	{
		temp.push_back(atoi(item.c_str()));
	}
	
	int numberOfTests = 3;
	int minScore = temp[1];
	int maxScore = temp[1];
	int sumOfScores = temp[1];
	int averageScore = 0;

	for (int i = 2; i <= numberOfTests; i++)
	{
		if (temp[i] < minScore)
		{
			minScore = temp[i];
		}
		else if (temp[i] > maxScore)
		{
			maxScore = temp[i];
		}

		sumOfScores = sumOfScores + temp[i];
	}
	
	averageScore = sumOfScores / numberOfTests;

	temp.push_back(minScore);
	temp.push_back(maxScore);
	temp.push_back(averageScore);
	return temp;
}