#include <iostream>
#include <fstream>
#include <string>
using namespace std;

	const int arraySize = 10;
	const char tab = '\t';
	
	int arrayA[arraySize];
	int arrayB[arraySize];
	int modulo5Array[arraySize];


	void ReverseCopyOneArrayToAnother(int[], int[]);
	void PrintArrayToScreen(int[]);
	int MeetingCriteriaE(int[]);
	// Split F and G up into two methods.
	// New method for G will return the indices for meeting G's criteria.
	int MeetingCriteriaFAndG(int[]);
	double GetArrayMean(int[]);
	int GetArrayMin(int[]);

int main()
{
	ifstream dataFromFile;
	
	int criteriaE = 0; //Find the number of elements in array A that are >= 80 and <=100.
	int criteriaF = 0; //Find the number of the elements in array A in which their contents are divisible by 5
	int criteriaG = 0; //Find the index of the elements in array A in which their contents are divisible by 5.
	double arrayMean = 0;
	int arrayMin = 0; //Find the minimum number in array A.
	bool numberExists = false; // setup for criteria j

	dataFromFile.open("..\\..\\\\Files\\data1.txt");
	
	while(!dataFromFile.eof())
	{
		dataFromFile >> arrayA[0];
		dataFromFile >> arrayA[1];
		dataFromFile >> arrayA[2];
		dataFromFile >> arrayA[3];
		dataFromFile >> arrayA[4];
		dataFromFile >> arrayA[5];
		dataFromFile >> arrayA[6];
		dataFromFile >> arrayA[7];
		dataFromFile >> arrayA[8];
		dataFromFile >> arrayA[9];
	}

	ReverseCopyOneArrayToAnother(arrayA, arrayB);
	PrintArrayToScreen(arrayA);
	PrintArrayToScreen(arrayB);
	cin.get();

	criteriaE = MeetingCriteriaE(arrayA);
	criteriaF = MeetingCriteriaFAndG(arrayA);
	arrayMean = GetArrayMean(arrayA);
	arrayMin = GetArrayMin(arrayA);

	return 0;
}

void ReverseCopyOneArrayToAnother(int firstArray[], int secondArray[])
{
	int count = 0;
	for (int i = 0; i < arraySize; i++)
	{
		secondArray[i] = firstArray[(arraySize - 1) - i];
	}
}

void PrintArrayToScreen(int arrayToPrint[])
{
	cout << arrayToPrint[0] << tab << arrayToPrint[1] << tab << arrayToPrint[2] << tab << arrayToPrint[3] << tab << arrayToPrint[4] << tab << arrayToPrint[5] << tab << arrayToPrint[6] << tab << arrayToPrint[7] << tab << arrayToPrint[8] << tab << arrayToPrint[9] << endl;
}

int MeetingCriteriaE(int arrayToCheck[])
{
	int elementsMeetingCriteriaE = 0;
	int elementToCheck = 0;

	for (int i = 0; i < arraySize; i++)
	{
		elementToCheck = arrayToCheck[i];

		if (elementToCheck >= 80 && elementToCheck <= 100)
		{
			elementsMeetingCriteriaE++;
		}
	}

	return elementsMeetingCriteriaE;
}

int MeetingCriteriaFAndG(int arrayToCheck[])
{
	int elementsMeetingCriteriaF = 0;
	int modulo5Index = 0;

	for (int i = 0; i < arraySize; i++)
	{
		int elementToCheck = arrayToCheck[i];
		if (elementToCheck % 5 == 0)
		{
			elementsMeetingCriteriaF++;
			
			modulo5Array[modulo5Index] = i;
			modulo5Index++;
		}
	}

	return elementsMeetingCriteriaF;
}

double GetArrayMean(int arrayToCheck[])
{
	int arraySum = 0;
	for (int i = 0; i < arraySize; i++)
	{
		arraySum += arrayToCheck[i];
	}
	
	return arraySum / arraySize;
}

int GetArrayMin(int arrayToCheck[])
{
	int potentialMin = arrayToCheck[0];

	for (int i = 1; i < arraySize; i++)
	{
		if (arrayToCheck[i] < potentialMin)
		{
			potentialMin = arrayToCheck[i];
		}
	}

	return potentialMin;
}