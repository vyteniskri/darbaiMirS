package main

import (
	"crypto/sha1"
	"encoding/json"
	"fmt"
	"os"
	"strconv"
	"strings"
	"sync"
	"unicode"
)

type Student struct {
	Name  string  `json:"name"`
	Year  int     `json:"year"`
	Grade float64 `json:"grade"`
	Hash  string
}

func (s *Student) Calculate() {
	dataToHash := s.Name + strconv.Itoa(s.Year) + strconv.FormatFloat(s.Grade, 'f', -1, 64)

	hashBytes := sha1.Sum([]byte(dataToHash))

	hashChars := make([]byte, 2*sha1.Size)
	for i, b := range hashBytes {
		copy(hashChars[i*2:], fmt.Sprintf("%02x", b))
	}

	s.Hash = string(hashChars)
}

func main() {
	var students []Student
	var Count int

	//filePath1 := "IFF-1-1_KrisciunasVytenis_L1_dat_1.json" //Visi tinka
	filePath2 := "IFF-1-1_KrisciunasVytenis_L1_dat_2.json" //Dalis tinka
	//filePath3 := "IFF-1-1_KrisciunasVytenis_L1_dat_3.json" //Nei vienas netinka

	jsonData, err := os.ReadFile(filePath2)
	if err != nil {
		fmt.Println("Error reading file:", err)
		return
	}

	var jsonMap map[string]interface{}
	err = json.Unmarshal(jsonData, &jsonMap)
	if err != nil {
		fmt.Println("Error unmarshaling JSON:", err)
		return
	}

	studentsJson := jsonMap["students"].([]interface{})
	Count = len(studentsJson)

	for _, studentJson := range studentsJson {
		studentData := studentJson.(map[string]interface{})
		student := Student{
			Name:  studentData["name"].(string),
			Year:  int(studentData["year"].(float64)),
			Grade: float64(studentData["grade"].(float64)),
		}
		students = append(students, student)
	}

	// fmt.Println("Count:", Count)
	// fmt.Println("Students:")
	// for i, student := range students {
	// 	fmt.Printf("Student %d:\n", i+1)
	// 	fmt.Printf("  Name: %s\n", student.Name)
	// 	fmt.Printf("  Year: %d\n", student.Year)
	// 	fmt.Printf("  Grade: %.2f\n", student.Grade)
	// }

	dataChannel1 := make(chan Student)
	dataChannel2 := make(chan Student)

	resultChannel := make(chan Student)

	sendRezults := make(chan []Student)

	var wg sync.WaitGroup

	for i := 0; i < 4; i++ {
		wg.Add(1)
		go WorkerProcess(dataChannel2, resultChannel, &wg)
	}

	//Irasineja elementus i duomenu proceso masyva
	go func() {
		for _, student := range students {
			dataChannel1 <- student

		}
		close(dataChannel1)
	}()

	wg.Add(1)
	go DataManagerProcess(dataChannel1, dataChannel2, &wg, Count)

	go RezultProcess(resultChannel, sendRezults)

	wg.Wait()
	close(resultChannel)

	//Per kanala grazinami rezultatai
	RezultArray := <-sendRezults

	fmt.Println("Rezultatu kiekis:", len(RezultArray))
	for _, student := range RezultArray {
		fmt.Printf("  Hash: %s\n", student.Hash)
	}

	//------Spausinimas i faila
	rezultFile := "IFF-1-1_KrisciunasVytenis_L1b_rez.txt"

	writer, err := os.Create(rezultFile)
	if err != nil {
		fmt.Println("Error creating file:", err)
		return
	}
	defer writer.Close()

	//Pradiniai duomenys
	writer.WriteString(fmt.Sprintf("%78s\n", "Pradiniai duomenys"))
	writer.WriteString(strings.Repeat("-", 141) + "\n")
	writer.WriteString(fmt.Sprintf("%30s | %30s | %30s | %40s |\n", "Name", "Year", "Grade", "Hash"))
	writer.WriteString(strings.Repeat("-", 141) + "\n")

	for _, student := range students {
		writer.WriteString(fmt.Sprintf("%30s | %30s | %30s | %40s |\n", student.Name, strconv.Itoa(student.Year), fmt.Sprintf("%.2f", student.Grade), student.Hash))
	}

	//Rezultatai
	writer.WriteString("\n\n")
	writer.WriteString(fmt.Sprintf("%78s\n", "Rezultatai"))
	writer.WriteString(strings.Repeat("-", 141) + "\n")
	writer.WriteString(fmt.Sprintf("%30s | %30s | %30s | %40s |\n", "Name", "Year", "Grade", "Hash"))
	writer.WriteString(strings.Repeat("-", 141) + "\n")

	for _, student := range RezultArray {
		if student.Name != "" {
			writer.WriteString(fmt.Sprintf("%30s | %30s | %30s | %40s |\n", student.Name, strconv.Itoa(student.Year), fmt.Sprintf("%.2f", student.Grade), student.Hash))
		}
	}

}

// Rezultatu procesas
func RezultProcess(resultChannel <-chan Student, sendRezults chan<- []Student) {

	var controller []Student
	index := 0

	for {
		data, ok := <-resultChannel

		if ok {
			firstSymbol := rune(data.Hash[0])

			if index == 0 {
				controller = []Student{data}
				index++
			} else {
				for i := 0; i < index; i++ {
					currentStudentFirstS := rune(controller[i].Hash[0])

					if firstSymbol <= currentStudentFirstS {
						controller = append(controller[:i], append([]Student{data}, controller[i:]...)...)
						index++
						break
					} else if i+1 == index && firstSymbol >= currentStudentFirstS {
						controller = append(controller, data)
						index++
						break
					} else if i+1 != index && firstSymbol >= currentStudentFirstS && firstSymbol <= rune(controller[i+1].Hash[0]) {
						controller = append(controller[:i+1], append([]Student{data}, controller[i+1:]...)...)
						index++
						break
					}
				}
			}

		} else {
			sendRezults <- controller
			return
		}

	}

}

// Darbiniai procesai
func WorkerProcess(dataChannel <-chan Student, resultChannel chan<- Student, wg *sync.WaitGroup) {
	defer wg.Done()

	for {
		data, ok := <-dataChannel
		if !ok {
			return
		}
		data.Calculate()
		if unicode.IsLetter(rune(data.Hash[0])) {
			resultChannel <- data

		}
	}

}

// Duomenu procesas
func DataManagerProcess(dataChannel1 <-chan Student, dataChannel2 chan<- Student, wg *sync.WaitGroup, Count int) {
	defer wg.Done()
	var controller []Student
	i := Count

	for {

		if len(controller) != Count/2 {
			message, ok := <-dataChannel1

			if ok {
				controller = append(controller, message)
			}
			if i == 0 {
				close(dataChannel2)
				return
			}
		}

		if len(controller) > 0 {

			dataChannel2 <- controller[len(controller)-1]
			controller = controller[:len(controller)-1]
			i--
		}

	}

}
