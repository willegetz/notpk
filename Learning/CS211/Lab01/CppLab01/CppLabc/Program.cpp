#include <iostream>
#include <fstream>
#include <string>
#include <vector>
using namespace std;

	const int arraySize = 10;
	const char tab = '\t';
	
	int arrayA[arraySize];
	int arrayB[arraySize];
	vector<int> modulo5Array;
	bool numberExists = false;

	void ReverseCopyOneArrayToAnother(int[], int[]);
	void PrintArrayToScreen(int[]);
	int MeetingCriteriaE(int[]);
	int MeetingCriteriaFAndG(int[]);
	int GetArrayMean(int[]);
	int GetArrayMin(int[]);
	void SearchIntArray();
	bool ArraySearch(int);
	string DisplayNumberExists(bool, int);
	void PrintVectorToScreen(vector<int>);

int main()
{
	ifstream dataFromFile;
	
	int criteriaE = 0; //Find the number of elements in array A that are >= 80 and <=100.
	int criteriaF = 0; //Find the number of the elements in array A in which their contents are divisible by 5
	double arrayMean = 0;
	int arrayMin = 0; //Find the minimum number in array A.
	bool numberExists = false; // setup for criteria j

	dataFromFile.open("..\\..\\Files\\data1.txt");
	
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
	cout << "The numbers in 'arrayA' are:" << endl;
	PrintArrayToScreen(arrayA);

	cout << "The numbers in 'arrayB' are:" << endl;
	PrintArrayToScreen(arrayB);
	cin.get();
	
	criteriaE = MeetingCriteriaE(arrayA);
	cout << "\nThere are '" << criteriaE << "' numbers that are >= 80 and <= 100 in the array." << endl;

	criteriaF = MeetingCriteriaFAndG(arrayA);
	cout << "\nThere are '" << criteriaF << "' numbers where their Mod5 is 0." << endl;
	cout << "\nThe indices of  those number are:" << endl;
	PrintVectorToScreen(modulo5Array);


	arrayMean = GetArrayMean(arrayA);
	cout << "\nThe mean of the array is '" << arrayMean << "'." << endl;

	arrayMin = GetArrayMin(arrayA);
	cout << "\nThe minimum value in  the array is '" << arrayMin << "'." << endl;

	SearchIntArray();

	return 0;
}

void ReverseCopyOneArrayToAnother(int firstArray[], int secondArray[])
{
	int count = 0;
	for (int i = 0; i < arraySize; i++)
	{
		secondArray[i] = firstArray[(arraySize - 1) - i];
	}
	cout << "\n";
}

void PrintArrayToScreen(int arrayToPrint[])
{
	for (int i = 0; i < arraySize; i++)
	{
		cout << arrayToPrint[i] << tab;
	}
	cout << "\n";
}

void PrintVectorToScreen(vector<int> vectorToPrint)
{
	for (int i = 0; i < (int) vectorToPrint.size(); i++)
	{
		cout << vectorToPrint[i] << tab;
	}
	cout << "\n";
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

	for (int i = 0; i < arraySize; i++)
	{
		int elementToCheck = arrayToCheck[i];
		if (elementToCheck % 5 == 0)
		{
			elementsMeetingCriteriaF++;
			modulo5Array.push_back(i);
		}
	}

	return elementsMeetingCriteriaF;
}

int GetArrayMean(int arrayToCheck[])
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

void SearchIntArray()
{
	int numberToSearchFor = 0;
	string userEntry;
	string continueSearch;

	cout << "\nWould you like to search for a number? (Yes or No)" << endl;
	cin >> continueSearch;
	
	if (continueSearch == "Yes")
	{
		do
		{
			cout << "\nPlease enter a number: ";
			cin >> userEntry;

			if (atoi(userEntry.c_str()))
			{
				numberToSearchFor = atoi(userEntry.c_str());
				numberExists = ArraySearch(numberToSearchFor);
				continueSearch = DisplayNumberExists(numberExists, numberToSearchFor);
			}
			else
			{
				cout << "\n'" << userEntry << "'" << " is not a valid number." << endl;
				cout << "Would you like to search again? (Yes or No)" << endl;
				cin >> continueSearch;
			}

		} while (continueSearch == "Yes");
		cout << "Good bye" << endl;
		cin.get();
		return;
	}
	else
	{
		cout << "Good bye" << endl;
		cin.get();
	}
}

bool ArraySearch(int numberToSearch)
{
	for (int i = 0; i < arraySize; i++)
	{
		if (arrayA[i] == numberToSearch)
		{
			return true;
		}
	}
	return false;
}

string DisplayNumberExists(bool itExists, int numberSearchedFor)
{
	string userInput;

	if (itExists)
	{
		cout << "\nThe number '" << numberSearchedFor << "' exists in the array." << endl;
		cout << "Would you like to search for another number? (Yes or No)" << endl;
		cin >> userInput;
		return userInput;
	}
	else
	{
		cout << "\nThe number '" << numberSearchedFor << "' does not exist in the array." << endl;
		cout << "Would you like to search for another number? (Yes or No)" << endl;
		cin >> userInput;
		return userInput;
	}
}