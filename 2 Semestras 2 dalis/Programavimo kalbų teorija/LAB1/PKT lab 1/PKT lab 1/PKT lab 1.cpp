#include <fstream>
#include <iostream>
#include <format>
#include <chrono>
#include <list>
using namespace std;

class Piece
{
public:
	char Name;
	int M, N;

	Piece(char name, int m, int n) : Name(name), M(m), N(n) {}
};

class Pieces
{
private:
	list<Piece> pieces;
	int Number;
public:
	Pieces(int number = 0) : Number(number){}

	void Add(Piece piece)
	{
		pieces.push_back(piece);
	}

	Piece Get(int index)
	{
		list<Piece>::iterator it = pieces.begin();
		advance(it, index);
		return *it;
	}

	int GetNumber()
	{
		return Number;
	}
};

class InOutUtils
{
public:
	static Pieces Read(const string fileName)
	{
		int number, m, n;
		char name;
	
		ifstream file(fileName);
		if (!file.is_open())
		{
			cerr << "Unable to open a file " << fileName << endl;
			return 0;
		}

		file >> number;
		Pieces pieces = Pieces(number);
		for (int i = 0; i < number; i++)
		{
			file >> name >> m >> n;
			Piece piece = Piece(name, m, n);
			pieces.Add(piece);
		}
		file.close();
		return pieces;
	}

	static void Write(const string fileName, list<int> totalCounts)
	{
		ofstream file(fileName);
		if (!file.is_open())
		{
			cerr << "Unable to open a file " << fileName << endl;
			return;
		}
		
		for (int count : totalCounts)
		{
			file << count << endl;
			
		}
		file.close();
	}
};

class TaskUtils
{
public:
	static list<int> Calculate(Pieces pieces)
	{
		list<int> totalCounts;
		
		for (int i = 0; i < pieces.GetNumber(); i++)
		{
			Piece piece = pieces.Get(i);
			if (piece.Name == 'r' || piece.Name == 'Q')
			{
				totalCounts.push_back(piece.M);
			}
			else if (piece.Name == 'K')
			{
				int m = piece.M / 2 + piece.M % 2;
				int n = piece.N / 2 + piece.N % 2;
				totalCounts.push_back(m * n);
			}
			else
			{
				int m1 = piece.M / 2 + piece.M % 2;
				int m2 = piece.M / 2;
				int n1 = piece.N / 2 + piece.N % 2;
				int n2 = piece.N / 2;
				int rezult = m1 * n1 + m2 * n2;
				totalCounts.push_back(rezult);
			}
			
		}
		return totalCounts;
	}
};

int main()
{
	typedef chrono::high_resolution_clock Time;
	typedef chrono::duration<float> duration;

	auto start = Time::now();

	Pieces pieces = InOutUtils::Read("inputFile.txt");

	list<int> totalCounts = TaskUtils::Calculate(pieces);

	InOutUtils::Write("Rezults.txt", totalCounts);

	auto stop = Time::now();
	
	duration totalTime = chrono::duration_cast<chrono::microseconds>(stop - start);
	cout << "Duration: " << totalTime.count() << " ms." <<endl;
	return 0;
}