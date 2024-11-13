import csv
import math
import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns
from scipy import stats
import numpy as np
from scipy.stats import linregress

def choice_to_number(file_path, number):
    words = []
    words_to_numbers = []
    with open(file_path, newline='') as csvfile:
        csv_reader = csv.reader(csvfile)
        header = next(csv_reader)  # Skip the header row
        for row in csv_reader:
            if row[number] != '':
                words.append(row[number])
                if row[number] == 'yes':
                    words_to_numbers.append(1)
                elif row[number] == 'no':
                    words_to_numbers.append(0)
    return words, words_to_numbers


def mode_to_number(file_path, number):
    words = []
    words_to_numbers = []
    with open(file_path, newline='') as csvfile:
        csv_reader = csv.reader(csvfile)
        header = next(csv_reader)  # Skip the header row
        for row in csv_reader:
            if row[number] != '':
                words.append(row[number])
                if row[number] == 'air':
                    words_to_numbers.append(1)
                elif row[number] == 'train':
                    words_to_numbers.append(2)
                elif row[number] == 'bus':
                    words_to_numbers.append(3)
                elif row[number] == 'car':
                    words_to_numbers.append(4)
    return words, words_to_numbers


def change_column_to_words(data):
    words = []
    for row in data:
        if int(row) == 1:
            words.append("Labai mazai")
        elif int(row) == 2:
            words.append("Mazai")
        elif int(row) == 3:
            words.append("Vidutiniskai")
        elif int(row) == 4:
            words.append("Virs vidurkio")
        elif int(row) == 5:
            words.append("Daug")
        elif int(row) == 6:
            words.append("Labai daug")
    return words

def size_number_to_word(moda):
    to_word = ''
    if int(moda) == 1:
        to_word = "Labai mazai"
    elif int(moda) == 2:
        to_word = "Mazai"
    elif int(moda) == 3:
        to_word = "Vidutiniskai"
    elif int(moda) == 4:
        to_word = "Virs vidurkio"
    elif int(moda) == 5:
        to_word = "Daug"
    elif int(moda) == 6:
        to_word = "Labai daug"
    return to_word
                

def antroji_moda(all_values, moda):
    max_count_antroji_m = 0
    antroji_m = ''
    for value, count in all_values.items():
        if value != moda and count >= max_count_antroji_m:
            max_count_antroji_m = count
            antroji_m = value
    return antroji_m, max_count_antroji_m
            


def find_all_diferent_values_and_size(file_path, number):
    counts = {}
    with open(file_path, newline='') as csvfile:
        csv_reader = csv.reader(csvfile)
        header = next(csv_reader)  # Skip the header row
        for row in csv_reader:
            if row[number] != '':
                value = row[number]
                counts[value] = counts.get(value, 0) + 1
    return counts

def Moda(all_values):
    max_count = 0
    moda = ''
    for value, count in all_values.items():
        if count >= max_count:
            max_count = count
            moda = value
    return moda, max_count

def Moda_proc(moda, number_of_values):
    return moda * 100 / number_of_values

def standartinis_nuokrypis(file_path, number, average):
    sum = 0
    count = 0
    with open(file_path, newline='') as csvfile:
        csv_reader = csv.reader(csvfile)
        header = next(csv_reader)  # Skip the header row
        for row in csv_reader:
            if row[number] != '':
                sum = sum + (int(row[number]) - average)**2
                count += 1
        
        var = sum / (count - 1)
        sd = math.sqrt(var)
        return sd

def median(sorted_algorith):
    index = int(len(sorted_algorith) * 50 / 100)
    med = (sorted_algorith[index] + sorted_algorith[index + 1]) / 2
    return med

def average(file_path, number):
    sum = 0
    count = 0
    with open(file_path, newline='') as csvfile:
        csv_reader = csv.reader(csvfile)
        header = next(csv_reader)  # Skip the header row
        for row in csv_reader:
            if row[number] != '':
                sum = sum + int(row[number])
                count += 1
    return sum/count
        

def sort_algorith(file_path, number):
    column = []
    with open(file_path, newline='') as csvfile:
        csv_reader = csv.reader(csvfile)
        header = next(csv_reader)  # Skip the header row
        for row in csv_reader:
            if row[number] != '':
                column.append(int(row[number]))

        sorted_column = sorted(column)
        return sorted_column   

def get_kvartilis(sorted_algorith, dalis):
    index = int(len(sorted_algorith) * dalis / 100)
    return sorted_algorith[index]

def max_value(file_path, number):
    max_v = 0
    with open(file_path, newline='') as csvfile:
        csv_reader = csv.reader(csvfile)
        header = next(csv_reader)  # Skip the header row
        for row in csv_reader:
            if row[number] != '' and int(row[number]) > max_v:
                 max_v = int(row[number])
    return max_v

def min_value(file_path, number):
    min_v = 99999
    with open(file_path, newline='') as csvfile:
        csv_reader = csv.reader(csvfile)
        header = next(csv_reader)  # Skip the header row
        for row in csv_reader:
            if row[number] != '' and int(row[number]) < min_v:
                 min_v = int(row[number])
    return min_v

def count_unique_values(file_path, number):
    unique_value_counts = set()
    with open(file_path, newline='') as csvfile:
        csv_reader = csv.reader(csvfile)
        header = next(csv_reader)  # Skip the header row
        for row in csv_reader:
            if row[number] not in unique_value_counts:
                unique_value_counts.add(row[number])
    return len(unique_value_counts)

def create_csv(file_path, data):
    with open(file_path, 'w', newline='') as csvfile:
        csv_writer = csv.writer(csvfile)
        for row in data:
            csv_writer.writerow(row)

def count_values_in_column(file_path):
    total_values = 0
    with open(file_path, newline ='') as csvfile:
        csv_reader = csv.reader(csvfile)
        header = next(csv_reader)
        for row in csv_reader:
            total_values += 1
    return total_values 

def count_missing_values(file_path, number):
    missing_values = 0
    count = 0
    with open(file_path, newline ='') as csvfile:
        csv_reader = csv.reader(csvfile)
        header = next(csv_reader)
        for row in csv_reader:
            if row[number] == '':
                missing_values += 1
            count += 1
    return missing_values * 100 / count


file_path = 'TravelMode_nekeistas.csv'

# Tolydinis

total_values_in_column = count_values_in_column(file_path)
print("Eiluciu kiekis:", total_values_in_column)

# Trukstamos reiksmes
missing_values5 = count_missing_values(file_path, 4)
print("Trukstamos reiksmes 5 stulp., %:", missing_values5)

missing_values6 = count_missing_values(file_path, 5)
print("Trukstamos reiksmes 6 stulp., %:", missing_values6)

missing_values7 = count_missing_values(file_path, 6)
print("Trukstamos reiksmes 7 stulp., %:", missing_values7)

missing_values8 = count_missing_values(file_path, 7)
print("Trukstamos reiksmes 8 stulp., %:", missing_values8)

missing_values9 = count_missing_values(file_path, 8)
print("Trukstamos reiksmes 9 stulp., %:", missing_values9)

missing_values10 = count_missing_values(file_path, 9)
print("Trukstamos reiksmes 10 stulp., %:", missing_values10)


# Kardinalumas
count_unique5 = count_unique_values(file_path, 4)
print("Kardinalumas 5 stulp.: ", count_unique5)

count_unique6 = count_unique_values(file_path, 5)
print("Kardinalumas 6 stulp.: ", count_unique6)

count_unique7 = count_unique_values(file_path, 6)
print("Kardinalumas 7 stulp.: ", count_unique7)

count_unique8 = count_unique_values(file_path, 7)
print("Kardinalumas 8 stulp.: ", count_unique8)

count_unique9 = count_unique_values(file_path, 8)
print("Kardinalumas 9 stulp.: ", count_unique9)

count_unique10 = count_unique_values(file_path, 9)
print("Kardinalumas 10 stulp.: ", count_unique10)


# Minimali reiksme
min_v5 = min_value(file_path, 4)
print("Minimali reiksme: ", min_v5)

min_v6 = min_value(file_path, 5)
print("Minimali reiksme: ", min_v6)

min_v7 = min_value(file_path, 6)
print("Minimali reiksme: ", min_v7)

min_v8 = min_value(file_path, 7)
print("Minimali reiksme: ", min_v8)

min_v9 = min_value(file_path, 8)
print("Minimali reiksme: ", min_v9)

min_v10 = min_value(file_path, 9)
print("Minimali reiksme: ", min_v10)


# Maksimali reiksme
max_v5 = max_value(file_path, 4)
print("Maksimali reiksme: ", max_v5)

max_v6 = max_value(file_path, 5)
print("Maksimali reiksme: ", max_v6)

max_v7 = max_value(file_path, 6)
print("Maksimali reiksme: ", max_v7)

max_v8 = max_value(file_path, 7)
print("Maksimali reiksme: ", max_v8)

max_v9 = max_value(file_path, 8)
print("Maksimali reiksme: ", max_v9)

max_v10 = max_value(file_path, 9)
print("Maksimali reiksme: ", max_v10)


# 1 Kvartilis
sort_alg5 = sort_algorith(file_path, 4)
Pirmas_kvartilis5 = get_kvartilis(sort_alg5, 25)
print("1 Kvartilis: ", Pirmas_kvartilis5)

sort_alg6 = sort_algorith(file_path, 5)
Pirmas_kvartilis6 = get_kvartilis(sort_alg6, 25)
print("1 Kvartilis: ", Pirmas_kvartilis6)

sort_alg7 = sort_algorith(file_path, 6)
Pirmas_kvartilis7 = get_kvartilis(sort_alg7, 25)
print("1 Kvartilis: ", Pirmas_kvartilis7)

sort_alg8 = sort_algorith(file_path, 7)
Pirmas_kvartilis8 = get_kvartilis(sort_alg8, 25)
print("1 Kvartilis: ", Pirmas_kvartilis8)

sort_alg9 = sort_algorith(file_path, 8)
Pirmas_kvartilis9 = get_kvartilis(sort_alg9, 25)
print("1 Kvartilis: ", Pirmas_kvartilis9)

sort_alg10 = sort_algorith(file_path, 9)
Pirmas_kvartilis10 = get_kvartilis(sort_alg10, 25)
print("1 Kvartilis: ", Pirmas_kvartilis10)


# 3 kvartilis
sort_alg5 = sort_algorith(file_path, 4)
Trecias_kvartilis5 = get_kvartilis(sort_alg5, 75)
print("3 Kvartilis: ", Trecias_kvartilis5)

sort_alg6 = sort_algorith(file_path, 5)
Trecias_kvartilis6 = get_kvartilis(sort_alg6, 75)
print("3 Kvartilis: ", Trecias_kvartilis6)

sort_alg7 = sort_algorith(file_path, 6)
Trecias_kvartilis7 = get_kvartilis(sort_alg7, 75)
print("3 Kvartilis: ", Trecias_kvartilis7)

sort_alg8 = sort_algorith(file_path, 7)
Trecias_kvartilis8 = get_kvartilis(sort_alg8, 75)
print("3 Kvartilis: ", Trecias_kvartilis8)

sort_alg9 = sort_algorith(file_path, 8)
Trecias_kvartilis9 = get_kvartilis(sort_alg9, 75)
print("3 Kvartilis: ", Trecias_kvartilis9)

sort_alg10 = sort_algorith(file_path, 9)
Trecias_kvartilis10 = get_kvartilis(sort_alg10, 75)
print("3 Kvartilis: ", Trecias_kvartilis10)


# Vidurkis
vidurk5 = average(file_path, 4)
print("Vidurkis: ", vidurk5)

vidurk6 = average(file_path, 5)
print("Vidurkis: ", vidurk6)

vidurk7 = average(file_path, 6)
print("Vidurkis: ", vidurk7)

vidurk8 = average(file_path, 7)
print("Vidurkis: ", vidurk8)

vidurk9 = average(file_path, 8)
print("Vidurkis: ", vidurk9)

vidurk10 = average(file_path, 9)
print("Vidurkis: ", vidurk10)


# Mediana
med5 = median(sort_alg5)
print("Mediana: ", med5)

med6 = median(sort_alg6)
print("Mediana: ", med6)

med7 = median(sort_alg7)
print("Mediana: ", med7)

med8 = median(sort_alg8)
print("Mediana: ", med8)

med9 = median(sort_alg9)
print("Mediana: ", med9)

med10 = median(sort_alg10)
print("Mediana: ", med10)


# Standartinis nuokrypis
sd5 = standartinis_nuokrypis(file_path, 4, vidurk5)
print("Standartinis nuokrypis: ", sd5)

sd6 = standartinis_nuokrypis(file_path, 5, vidurk6)
print("Standartinis nuokrypis: ", sd6)

sd7 = standartinis_nuokrypis(file_path, 6, vidurk7)
print("Standartinis nuokrypis: ", sd7)

sd8 = standartinis_nuokrypis(file_path, 7, vidurk8)
print("Standartinis nuokrypis: ", sd8)

sd9 = standartinis_nuokrypis(file_path, 8, vidurk9)
print("Standartinis nuokrypis: ", sd9)

sd10 = standartinis_nuokrypis(file_path, 9, vidurk10)
print("Standartinis nuokrypis: ", sd10)



print('')
# Kategorinis

# Trukstamos reiksmes
missing_values3 = count_missing_values(file_path, 2)
print("Trukstamos reiksmes 3 stulp., %:", missing_values3)

missing_values4 = count_missing_values(file_path, 3)
print("Trukstamos reiksmes 4 stulp., %:", missing_values4)


# Kardinalumas
count_unique3 = count_unique_values(file_path, 2)
print("Kardinalumas 3 stulp.: ", count_unique3)

count_unique4 = count_unique_values(file_path, 3)
print("Kardinalumas 4 stulp.: ", count_unique4)


# Moda
found_all3 = find_all_diferent_values_and_size(file_path, 2)
for value, count in found_all3.items():
    print(f"{value}: {count}")
moda3, daznumas3 = Moda(found_all3)
print("Moda: 3 stulp.", moda3)

found_all4 = find_all_diferent_values_and_size(file_path, 3)
for value, count in found_all4.items():
    print(f"{value}: {count}")
moda4, daznumas4 = Moda(found_all4)
print("Moda: 4 stulp.", moda4)


# Modos daznumas
print("Modos daznumas: 3 stulp.", daznumas3)

print("Modos daznumas: 4 stulp.", daznumas4)


# Moda %
mod_proc3 = Moda_proc(daznumas3, total_values_in_column)
print("Moda, % 3 stulp.", mod_proc3)

mod_proc4 = Moda_proc(daznumas4, total_values_in_column)
print("Moda, % 4 stulp.", mod_proc4)


# 2-oji moda
antroji_m3, antroji_m_daznumas3 = antroji_moda(found_all3, moda3)
print("Antroji moda: 3 stulp.", antroji_m3)

antroji_m4, antroji_m_daznumas4 = antroji_moda(found_all4, moda4)
print("Antroji moda: 4 stulp.", antroji_m4)


# 2-osios modos daznumas
print("Antrosios modos daznumas: 3 stulp.", antroji_m_daznumas3)

print("Antrosios modos daznumas: 4 stulp.", antroji_m_daznumas4)


# 2-oji moda, %
antroji_mod_proc3 = Moda_proc(antroji_m_daznumas3, total_values_in_column)
print("Antroji moda, % 3 stulp.", antroji_mod_proc3)

antroji_mod_proc4 = Moda_proc(antroji_m_daznumas4, total_values_in_column)
print("Antroji moda, % 4 stulp.", antroji_mod_proc4)



data1 = [
    ['Atributo pavadinimas', 'Kiekis (Eiluciu sk.)', 'Trukstamos reiksmes, %', 'Kardinalumas', 'Minimali reiksme', 'Maksimali reiksme', '1-asis kvartilis', '3-asis kvartilis', 'Vidurkis', 'Mediana', 'Standartitnis nuokrypis'],
    ['wait', total_values_in_column, missing_values5, count_unique5, min_v5, max_v5, Pirmas_kvartilis5, Trecias_kvartilis5, vidurk5, med5, sd5],
    ['vcost', total_values_in_column, missing_values6, count_unique6, min_v6, max_v6, Pirmas_kvartilis6, Trecias_kvartilis6, vidurk6, med6, sd6],
    ['travel', total_values_in_column, missing_values7, count_unique7, min_v7, max_v7, Pirmas_kvartilis7, Trecias_kvartilis7, vidurk7, med7, sd7],
    ['gcost', total_values_in_column, missing_values8, count_unique8, min_v8, max_v8, Pirmas_kvartilis8, Trecias_kvartilis8, vidurk8, med8, sd8],
    ['income', total_values_in_column, missing_values9, count_unique9, min_v9, max_v9, Pirmas_kvartilis9, Trecias_kvartilis9, vidurk9, med9, sd9],
    ['size', total_values_in_column, missing_values10, count_unique10, min_v10, max_v10, Pirmas_kvartilis10, Trecias_kvartilis10, vidurk10, med10, sd10]
]
tolydinis_path = 'tolydinis.csv'
create_csv(tolydinis_path, data1)


data2 = [
    ['Atributo pavadinimas', 'Kiekis (Eiluciu sk.)', 'Trukstamos reiksmes, %', 'Kardinalumas', 'Moda', 'Modos daznumas', 'Moda, %', '2-oji moda', '2-osios modos daznumas', '2-oji moda, %'],
    ['mode', total_values_in_column, missing_values3, count_unique3, moda3, daznumas3, mod_proc3, antroji_m3, antroji_m_daznumas3, antroji_mod_proc3],
    ['choise', total_values_in_column, missing_values4, count_unique4, moda4, daznumas4, mod_proc4, antroji_m4, antroji_m_daznumas4, antroji_mod_proc4]
]
kategorinis_path = 'kategorinis.csv'
create_csv(kategorinis_path, data2)



#-------- HISTOGRAMOS (4 punktas)

#Tolydinis
df = pd.read_csv(file_path)
'''
column_name = 'wait'
plt.hist(df[column_name], bins=23, color='blue', edgecolor='black')
plt.xlabel('Values')
plt.ylabel('Frequency')
plt.title('Histograma: ' + column_name)
plt.show()

column_name = 'vcost'
plt.hist(df[column_name], bins=23, color='blue', edgecolor='black')
plt.xlabel('Values')
plt.ylabel('Frequency')
plt.title('Histograma: ' + column_name)
plt.show()

column_name = 'travel'
plt.hist(df[column_name], bins=23, color='blue', edgecolor='black')
plt.xlabel('Values')
plt.ylabel('Frequency')
plt.title('Histograma: ' + column_name)
plt.show()

column_name = 'gcost'
plt.hist(df[column_name], bins=23, color='blue', edgecolor='black')
plt.xlabel('Values')
plt.ylabel('Frequency')
plt.title('Histograma: ' + column_name)
plt.show()

column_name = 'income'
plt.hist(df[column_name], bins=23, color='blue', edgecolor='black')
plt.xlabel('Values')
plt.ylabel('Frequency')
plt.title('Histograma: ' + column_name)
plt.show()
'''

# 5 punktas

# Moda
found_all10 = find_all_diferent_values_and_size(file_path, 9)
for value, count in found_all10.items():
    print(f"{value}: {count}")
moda10, daznumas10 = Moda(found_all10)

column_of_size_in_word1 = size_number_to_word(moda10)
print("Moda: 10 stulp.", column_of_size_in_word1)


# Modos daznumas
print("Modos daznumas: 10 stulp.", daznumas10)


# Moda %
mod_proc10 = Moda_proc(daznumas10, total_values_in_column)
print("Moda, % 10 stulp.", mod_proc10)


# 2-oji moda
antroji_m10, antroji_m_daznumas10 = antroji_moda(found_all10, moda10)
column_of_size_in_word2 = size_number_to_word(antroji_m10)
print("Antroji moda: 10 stulp.", column_of_size_in_word2)


# 2-osios modos daznumas
print("Antrosios modos daznumas: 10 stulp.", antroji_m_daznumas10)


# 2-oji moda, %
antroji_mod_proc10 = Moda_proc(antroji_m_daznumas10, total_values_in_column)
print("Antroji moda, % 10 stulp.", antroji_mod_proc10)



data_be_size_1 = [
    ['Atributo pavadinimas', 'Kiekis (Eiluciu sk.)', 'Trukstamos reiksmes, %', 'Kardinalumas', 'Minimali reiksme', 'Maksimali reiksme', '1-asis kvartilis', '3-asis kvartilis', 'Vidurkis', 'Mediana', 'Standartitnis nuokrypis'],
    ['wait', total_values_in_column, missing_values5, count_unique5, min_v5, max_v5, Pirmas_kvartilis5, Trecias_kvartilis5, vidurk5, med5, sd5],
    ['vcost', total_values_in_column, missing_values6, count_unique6, min_v6, max_v6, Pirmas_kvartilis6, Trecias_kvartilis6, vidurk6, med6, sd6],
    ['travel', total_values_in_column, missing_values7, count_unique7, min_v7, max_v7, Pirmas_kvartilis7, Trecias_kvartilis7, vidurk7, med7, sd7],
    ['gcost', total_values_in_column, missing_values8, count_unique8, min_v8, max_v8, Pirmas_kvartilis8, Trecias_kvartilis8, vidurk8, med8, sd8],
    ['income', total_values_in_column, missing_values9, count_unique9, min_v9, max_v9, Pirmas_kvartilis9, Trecias_kvartilis9, vidurk9, med9, sd9],
]
tolydinis_path_be_size = 'tolydinis_be_size.csv'
create_csv(tolydinis_path_be_size, data_be_size_1)

data_su_size_2 = [
    ['Atributo pavadinimas', 'Kiekis (Eiluciu sk.)', 'Trukstamos reiksmes, %', 'Kardinalumas', 'Moda', 'Modos daznumas', 'Moda, %', '2-oji moda', '2-osios modos daznumas', '2-oji moda, %'],
    ['mode', total_values_in_column, missing_values3, count_unique3, moda3, daznumas3, mod_proc3, antroji_m3, antroji_m_daznumas3, antroji_mod_proc3],
    ['choise', total_values_in_column, missing_values4, count_unique4, moda4, daznumas4, mod_proc4, antroji_m4, antroji_m_daznumas4, antroji_mod_proc4],
    ['size', total_values_in_column, missing_values10, count_unique10, column_of_size_in_word1, daznumas10, mod_proc10, column_of_size_in_word2, antroji_m_daznumas10, antroji_mod_proc10]
]
kategorinis_su_size_path = 'kategorinis_su_size.csv'
create_csv(kategorinis_su_size_path, data_su_size_2)

# 7 Scater plot diagram
'''
df = pd.read_csv(file_path)
x_column = 'vcost'
y_column = 'travel'
plt.scatter(df[x_column], df[y_column])
plt.xlabel('vcost')
plt.ylabel('travel')
plt.title('Scatter Plot')
plt.show() 
'''

# vcost ir travel rysiam atvaizduoti
'''
df = pd.read_csv(file_path)
x_column = 'vcost'
y_column = 'travel'
transport_options = df['mode'].unique()
colors = ['red', 'blue', 'green', 'orange']  
markers = ['o', 's', '^', 'D'] 
transport_mapping = {option: (color, marker) for option, color, marker in zip(transport_options, colors, markers)}

# Create scatter plot with points differentiated by transportation options
for option, group in df.groupby('mode'):
    color, marker = transport_mapping[option]
    plt.scatter(group[x_column], group[y_column], label=option, color=color, marker=marker)
plt.xlabel('vcost')
plt.ylabel('travel')
plt.title('Scatter Plot')
plt.legend(title='Mode')
plt.show()
'''

# wait ir vcost rysiam atvaizduoti
'''
df = pd.read_csv(file_path)
x_column = 'wait'
y_column = 'vcost'
plt.scatter(df[x_column], df[y_column])
plt.xlabel(x_column)
plt.ylabel(y_column)
plt.title('Scatter Plot')

slope, intercept, r_value, p_value, std_err = linregress(df[x_column], df[y_column])
x_values = df[x_column]
plt.plot(x_values, slope * x_values + intercept, color='red', label='Linear Regression Line')
plt.show()
'''

# Scater plot matrix
'''
df = pd.read_csv(file_path)
column_to_exclude = ['rownames', 'individual', 'size']
df_excluded = df.drop(columns=column_to_exclude)
sns.pairplot(df_excluded)
plt.show()
'''



# mode, choice ir size
'''
subset_df = df[(df['choice'] == 'yes') & (df['size'] == 2)]
plt.hist(subset_df['mode'], bins=4, color='blue', edgecolor='black')
#plt.hist(df[df['choice'] == 'yes']['mode'], bins=4, color='blue', edgecolor='black')
plt.xlabel('Mode')
plt.ylabel('Dažnis')
plt.title(f'Transporto priemonės pasirinkimo diagrama pagal asmenų kiekį, kiekis - Mažai')
plt.show()
'''

# Kategoriniai ir tolydiniai duomenys 
'''
# Bar plot
plt.hist(df[df['mode'] == 'car']['vcost'], bins=8, color='blue', edgecolor='black')
plt.xlabel('Vehicle cost')
plt.ylabel('Dažnis')
plt.title(f'Transporto priemonės kainos priklausomybė nuo transporto priemonės pasirinkimo, transportas - lėktuvas')
plt.show()
'''

# Box plot
'''
grouped_data = [group[1]['vcost'].tolist() for group in df.groupby('mode')]
plt.boxplot(grouped_data, labels=df['mode'].unique())
plt.xlabel('Mode')
plt.ylabel('Vehicle cost')
plt.title(f'Transporto priemonės kainos priklausomybė nuo transporto priemonės pasirinkimo')
plt.show()
'''

'''
row_name = 'air'
df_mode = df[df['mode'] == row_name]
z_scores = stats.zscore(df_mode['vcost'])
threshold = 1
df_mode_cleaned = df_mode[(abs(z_scores) < threshold)]
plt.boxplot(df_mode_cleaned['vcost'], labels=[row_name])
plt.xlabel('Mode')
plt.ylabel('Vehicle cost')
plt.show()
min_value = df_mode_cleaned['vcost'].min()
max_value = df_mode_cleaned['vcost'].max()
print("Minimum Value:", min_value)
print("Maximum Value:", max_value)
'''

# Korevariacija
'''
columns_kovariacija = df.select_dtypes(include=['float64', 'int64'])
kovariacijos_matrix = columns_kovariacija.cov()
columns_to_exclude = ['rownames', 'individual', 'size']
df_excluded = kovariacijos_matrix.drop(columns=columns_to_exclude, index=columns_to_exclude)
mask = np.triu(np.ones(df_excluded.shape)).astype(bool)
df_excluded_upper = df_excluded.mask(mask)
df_excluded_upper.to_csv('kovariacijos_matrica.csv')
'''

# Koreliacija
'''
columns_koreliacija = df.select_dtypes(include=['float64', 'int64'])
koreliacijos_matrix = columns_koreliacija.corr()
columns_to_exclude = ['rownames', 'individual', 'size']
df_excluded = koreliacijos_matrix.drop(columns=columns_to_exclude, index=columns_to_exclude)
mask = np.triu(np.ones(df_excluded.shape)).astype(bool)
df_excluded_upper = df_excluded.mask(mask)
sns.heatmap(df_excluded_upper, cmap='coolwarm', annot=True, fmt=".2f", linewidths=.5)
plt.title('Koreliacijos matrica')
plt.show()
'''

# 9 reiksmiu normalizavimas
'''
columns_to_normalize = ['wait', 'vcost', 'travel', 'gcost', 'income']

for column in columns_to_normalize:
    min_val = df[column].min()
    max_val = df[column].max()
    df[column] = (df[column] - min_val) / (max_val - min_val)

df.to_csv('Normalizuoti_duomenys.csv', index=False)
'''

# Vertimas tolydiniais
'''
# Mode
mode_words, mode_converted = mode_to_number(file_path, 2)

for mode, number in zip(mode_words, mode_converted):
    print(f'Mode: {mode}, number: {number}')
'''
# Choice
choice_words, choice_converted = choice_to_number(file_path, 3)

for choice, number in zip(choice_words, choice_converted):
    print(f'Choice: {choice}, number: {number}')
