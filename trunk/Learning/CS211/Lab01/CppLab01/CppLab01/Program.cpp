#include <iostream>
#include <fstream>
#include <sstream>
#include <string>
#include <vector>

	const char tab = '\t';
	const std::string header = "Std Id\tA1\tA2\tA3\tMin\tMax\tAverage";
	const std::string divider = "-------------------------------------------------------";

	void ProcessARow(std::string, std::vector<int>&);
	void CalculateScoreMetrics(std::vector<int>&);
	void DisplayScores(std::vector<int>);

int main()
{
	std::vector<int> student1;
	std::vector<int> student2;
	std::vector<int> student3;
	std::string studentScoreLine;

	std::ifstream classScores;
	classScores.open("..\\..\\Files\\data.txt");
	while(!classScores.eof())
	{
		std::getline(classScores, studentScoreLine);
		ProcessARow(studentScoreLine, student1);

		std::getline(classScores, studentScoreLine);
		ProcessARow(studentScoreLine, student2);

		std::getline(classScores, studentScoreLine);
		ProcessARow(studentScoreLine, student3);
	}
	classScores.close();
	
	std::cout << header  << std::endl;
	std::cout << divider << std::endl;
	
	DisplayScores(student1);
	DisplayScores(student2);
	DisplayScores(student3);

	std::cin.get();
}

void ProcessARow(std::string scoreLine, std::vector<int>& scores)
{
	std::stringstream ss(scoreLine);
	std::string score;
	while(std::getline(ss, score, tab))
	{
		scores.push_back(atoi(score.c_str()));
	}

	CalculateScoreMetrics(scores);
}

void CalculateScoreMetrics(std::vector<int>& scores)
{
	int numberOfTests = 3;
	int minScore = scores[1];
	int maxScore = scores[1];
	int sumOfScores = scores[1];
	int averageScore = 0;

	for (int i = 2; i <= numberOfTests; i++)
	{
		if (scores[i] < minScore)
		{
			minScore = scores[i];
		}
		else if (scores[i] > maxScore)
		{
			maxScore = scores[i];
		}

		sumOfScores = sumOfScores + scores[i];
	}
	
	averageScore = sumOfScores / numberOfTests;

	scores.push_back(minScore);
	scores.push_back(maxScore);
	scores.push_back(averageScore);
}

void DisplayScores(std::vector<int> scores)
{
	int size = scores.size() - 1;
	for (int i = 0; i < (size); i++)
	{
		std::cout << scores[i] << tab;
	}
	std::cout << scores[size] << ".0" << std::endl;
}