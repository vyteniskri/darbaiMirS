﻿#include "cuda_runtime.h"
#include "device_launch_parameters.h"
#include <string>
#include <fstream>
#include <iostream>
#include <vector>
#include <stdio.h>
#include <nlohmann/json.hpp>

using json = nlohmann::json;
using namespace std;

struct Student {
    char name[50];
    int year;
    float grade;
};

struct Result {
    char data[80]; 
};

vector<Student> readFile(const string& filename) {
    ifstream file(filename);
    if (!file.is_open()) {
		cout << "Could not open file: " << filename << endl;
        exit(EXIT_FAILURE);
	}

    json jsonData;
    file >> jsonData;
    file.close();

    vector<Student> students;
    for (const auto& studentData : jsonData["students"]) {
        Student student;
        strcpy(student.name, studentData["name"].get<string>().c_str());
        student.year = studentData["year"].get<int>();
        student.grade = studentData["grade"].get<float>();
        students.push_back(student);
    }
    
    return students;
}

//void printResults(const Result* results, int size) {
//    int counter = 0;
//    for (int i = 0; i < size; i++) {
//        if (results[i].data[0] != '\0') {
//            std::cout << results[i].data << std::endl;
//            counter++;
//        }
//    }
//    std::cout << "Number of results: " << counter << std::endl;
//}

void writeResultsToFile(const Result* results, int size, string filename) {
	ofstream file(filename);
	if (!file.is_open()) {
		cout << "Failas neatsidaro: " << filename << endl;
		exit(EXIT_FAILURE);
	}

	int counter = 0;
	for (int i = 0; i < size; i++) {
		if (results[i].data[0] != '\0') {
			file << results[i].data << endl;
			counter++;
		}
	}
    file << "Rezultatu skaicius: " << counter;
	file.close();

}

void writeResultsToConsole(const Result* results, int size) {
    
    int counter = 0;
    for (int i = 0; i < size; i++) {
        if (results[i].data[0] != '\0') {
            cout << results[i].data << endl;
            counter++;
        }
    }

    cout << "Rezultatu skaicius: " << counter << endl;
}

//void checkCudaDevice() {
//    int deviceCount;
//    cudaGetDeviceCount(&deviceCount);
//
//    if (deviceCount == 0) {
//		std::cout << "There is no CUDA device" << std::endl;
//		exit(EXIT_FAILURE);
//	}
//
//    for (int i = 0; i < deviceCount; ++i) {
//        cudaDeviceProp deviceProp;
//        cudaGetDeviceProperties(&deviceProp, i);
//        std::cout << "Device " << i << ": " << deviceProp.name << std::endl;
//    }
//}


__global__ void filterAndSortStudents(Student* students, int size, Result* results, int resultsSize) {
    int index = blockIdx.x * blockDim.x + threadIdx.x;

    if (index < size) {
        if (students[index].name[0] > 'P') {

            Result result;

            // Copy name to result.data
            const char* namePtr = students[index].name;
            char* resultPtr = result.data;
            while (*namePtr != '\0') {
				*resultPtr = *namePtr;
				++namePtr;
				++resultPtr;
			}

            *resultPtr = '-';
            ++resultPtr;

            int year = students[index].year;
            *resultPtr = '0' + year;
            ++resultPtr;
            
            
            char grade;
            if (students[index].grade <= 1.6) grade = 'F';
            else if (students[index].grade <= 3.2) grade = 'E';
            else if (students[index].grade <= 4.8) grade = 'D';
            else if (students[index].grade <= 6.4) grade = 'C';
            else if (students[index].grade <= 8) grade = 'B';
            else grade = 'A';

            *resultPtr = grade;
            ++resultPtr;

         
            
            int resultIndex = index % resultsSize;
            
            while (atomicCAS((int*)&results[resultIndex].data[0], 0, 1) != 0) {
                resultIndex = (resultIndex + 1) % resultsSize;
            }

            results[resultIndex] = result;
        }
    }
}

int main() {
   
    //checkCudaDevice();

    string outputFile = "IFF-1-1_KrisciunasVytenis_L1b_rez.txt";
   
    string inputFile1 = "IFF-1-1_KrisciunasVytenis_L1_dat_1.json"; //Tinka visi
    string inputFile2 = "IFF-1-1_KrisciunasVytenis_L1_dat_2.json"; //Nei vienas netinka
    string inputFile3 = "IFF-1-1_KrisciunasVytenis_L1_dat_3.json"; //Tinka dalis
   
    vector<Student> students = readFile(inputFile1);
    const int dataSize = students.size();
    cout << "Pradiniu duomenu kiekis: " << dataSize << endl;

    Student* deviceStudents;
    Result* hostResults = new Result[dataSize];
    Result* deviceResults;

    
    const int threadsPerBlock = 32 * 2;
    const int blocksPerGrid = (dataSize + threadsPerBlock - 1) / threadsPerBlock;

    
    cudaMalloc((void**)&deviceStudents, dataSize * sizeof(Student));
    cudaMalloc((void**)&deviceResults, dataSize * sizeof(Result));

    
    cudaMemcpy(deviceStudents, students.data(), dataSize * sizeof(Student), cudaMemcpyHostToDevice);

    
    memset(hostResults, 0, dataSize * sizeof(Result));

    
    cudaMemcpy(deviceResults, hostResults, dataSize * sizeof(Result), cudaMemcpyHostToDevice);

   
    filterAndSortStudents<<<blocksPerGrid, threadsPerBlock>>>(deviceStudents, dataSize, deviceResults, dataSize);
    cudaDeviceSynchronize(); // Add synchronization to ensure the kernel is finished before copying data back

    // Copy data from device to host
    cudaMemcpy(hostResults, deviceResults, dataSize * sizeof(Result), cudaMemcpyDeviceToHost);

    // Print results
    writeResultsToFile(hostResults, dataSize, outputFile);

    // Ask to write to console
    writeResultsToConsole(hostResults, dataSize);

    // Free memory on GPU and host
    cudaFree(deviceStudents);
    cudaFree(deviceResults);

    return 0;
}
