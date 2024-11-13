import numpy as np
import json
import time
import matplotlib.pyplot as plt
from multiprocessing import Pool, Queue, Lock, Array, Process, Manager, Pipe, Value

def taskuIsidestymas(data):
    areaLim = 10
    fig=plt.figure(0)
    ax=fig.add_subplot(1,1,1)
    ax.set_xlabel('x')
    ax.set_ylabel('y')
    plt.xlim([-areaLim-2, areaLim+2])
    plt.ylim([-areaLim-2, areaLim+2])
    plt.plot([-areaLim, -areaLim, areaLim, areaLim, -areaLim], [-areaLim, areaLim, areaLim, -areaLim, -areaLim],'--k') 
    ax.scatter(*zip(*data['exsisting_stores']), c='red', marker='o', label='Pradines parduotuves')
    ax.scatter(*zip(*data['new_stores']), c='blue', marker='o', label='Naujos parduotuves')
    plt.show()


def readData(fileName):
    print(f"Reading data from {fileName}")
    with open("Data/"+ fileName, 'r') as f:
        data = json.load(f)
    print(f"Data read successfully.")
    print(f"City size: {data['city_size_x']}, {data['city_size_y']}")
    print(f"Exsisting stores: {len(data['exsisting_stores'])}")
    print(f"New stores: {len(data['new_stores'])}")
    return data


#Gradiantas (nenaudojamas)
def dTF(x,y,h):
     n=len(x)
     gradx=np.zeros(n,dtype=float)
     grady=np.zeros(n,dtype=float)

     for i in range (n):
       
       x1=np.array(x)
       y1=np.array(y)

       x1[i]=x1[i]+h
       y1[i]=y1[i]+h

       gradx[i]=(objective_function(x1,y)-objective_function(x,y))/h #h - argumentu prieaugis
       grady[i]=(objective_function(x,y1)-objective_function(x,y))/h

       L=np.linalg.norm([gradx,grady])
       gradx=gradx/L 
       grady=grady/L
     return gradx,grady


# Funkcija apskaičiuojanti kainą tarp dviejų parduotuvių
def C(x1, y1, x2, y2):
    return np.exp(-0.3 * ((x1 - x2)**2 + (y1 - y2)**2))

# Funkcija apskaičiuojanti kainą naujos parduotuvės vietoje
def CP(x1, y1):
    return (x1**4 + y1**4) / 1000 + (np.sin(x1) + np.cos(y1)) / 5 + 0.4

# Tikslo funkcija - suma visų parduotuvių kainų
def objective_function(x, y, existing_stores):
    total_cost = 0
    
    # Sąnaudos dėl parduotuvių vietų
    for i in range(len(x)):
        total_cost += CP(x[i], y[i])
        
    
    # Sąnaudos dėl atstumų
    for i in range(len(x)):
        for x2, y2 in existing_stores:
            total_cost += C(x[i], y[i], x2, y2)

    for i in range(len(x)):
        for j in range(len(x)):
            total_cost += C(x[i], y[i], x[j], y[j])
            
    return total_cost

#Gradiantas
def dTF(args):
     x, y, h, exsisting_stores, i, f0 = args
     gradx = np.zeros_like(x)
     grady = np.zeros_like(y)

     x1=np.array(x)
     y1=np.array(y)

     x1[i]=x1[i]+h
     y1[i]=y1[i]+h

     gradx[i]=(objective_function(x1,y,  exsisting_stores)-f0)/h #h - argumentu prieaugis
     grady[i]=(objective_function(x,y1,  exsisting_stores)-f0)/h

     return gradx[i], grady[i]
    

def parallel_dTF(x, y, h, existing_stores, process_count, objF):
    f0 = objF
    with Pool(process_count) as pool:  
        rez = pool.map(dTF, [(x, y, h, existing_stores, i, f0) for i in range(len(x))])

    x_gradients, y_gradients = zip(*rez)
    return np.array(x_gradients), np.array(y_gradients)


def main(process_count, step, iterations_Count, data):

    start_time = time.time() # Timer start
    x = [float(coords[0]) for coords in data['new_stores']]
    y = [float(coords[1]) for coords in data['new_stores']]

    oldObj = objective_function(x, y, data['exsisting_stores'])
    #Vyksta optimizavimas (greičiausias nusileidimas)
    print('pradine funkcijos reiksme', oldObj)

    TFValues = []
    Iterations = []

    gradx, grady = parallel_dTF(x, y, 0.001, data['exsisting_stores'], process_count, oldObj)
    for j in range (iterations_Count):
 
        x = x - step * gradx
        y = y - step * grady
        tf=objective_function(x,y, data['exsisting_stores'])

        #---Grafikui
        TFValues.append(tf)
        Iterations.append(j)
        #---

        if oldObj  > tf: 
            oldObj=tf
    
        else: 
            x=x+step*gradx
            y=y+step*grady 
            gradx, grady = parallel_dTF(x, y, 0.001, data['exsisting_stores'], process_count, oldObj)

    #Iteraciju / tikslo funkcijos grafikas
    #fig=plt.figure(1)
    #ax1=fig.add_subplot(1,1,1)
    #ax1.plot(Iterations, TFValues)
    #ax1.set_xlabel('x - iteraciju skaicius')
    #ax1.set_ylabel('y - tikslo funkcijos reiksmes')
    #plt.grid()
    #plt.show()

    end_time = time.time() #Timer end
    elapsed_time = end_time - start_time
    elapsed_time_in_seconds = elapsed_time
    return oldObj, elapsed_time_in_seconds

def test(process_count, step, iterations_Count, fileName):
    process_Amount = []
    time_Array = []
    data = readData(fileName) #Nuskaitomi failo duomenys
    #taskuIsidestymas(data)
    vidTime = 0
    for processes in range(1, process_count + 1):
        OptimValue, timeElapsed = main(processes, step, iterations_Count, data)
        process_Amount.append(processes)
        time_Array.append(timeElapsed)
        print(f"Naudotas procesu kiekis: {processes} ir gauta optimizuota reiksme: {OptimValue}")
        vidTime += timeElapsed

    print(f"Vidutinis vykdymo laikas: {vidTime/process_count} s.")
    plt.figure()
    plt.plot(process_Amount, time_Array, marker='o')
    plt.xlabel('Procesu skaicius')
    plt.ylabel('Laikas sekundemis')
    plt.title(f'Vykdymo laiko kitimo priklausomybe nuo procesu kiekio \n Iteracijos: {iterations_Count} Esami taškai:{len(data['exsisting_stores'])}  Nauji taškai: {len(data['new_stores'])}')
    plt.show()

if __name__ == "__main__":
    #test(procesuKiekis, zingsnis, iteracijuSkaicius, failoPavadinimas)

    #test(8, 0.01, 100, "exsisting3_new3.json") #beveik tiese
    #test(8, 0.01, 100, "exsisting10_new20.json") #beveik tiese
    #test(8, 0.01, 100, "exsisting20_new20.json") #beveik tiese
    #test(8, 0.01, 100, "exsisting12_new47.json") #Parabole
    #test(8, 0.01, 100, "exsisting10_new50.json") #Parabole
    #test(8, 0.01, 100, "exsisting60_new60.json") #Parabole
    #test(8, 0.01, 100, "exsisting100_new100.json") #Hiperboles desine puse
    #test(8, 0.01, 100, "exsisting120_new120.json") #Hiperboles desine puse

    test(8, 0.01, 200, "exsisting3_new3.json") #beveik tiese
    test(8, 0.01, 200, "exsisting10_new20.json") #beveik tiese
    test(8, 0.01, 200, "exsisting20_new20.json") #beveik tiese
    test(8, 0.01, 200, "exsisting12_new47.json") #Parabole
    test(8, 0.01, 200, "exsisting10_new50.json") #Parabole
    test(8, 0.01, 200, "exsisting60_new60.json") #Parabole
    test(8, 0.01, 200, "exsisting100_new100.json") #Hiperboles desine puse
    test(8, 0.01, 200, "exsisting120_new120.json") #Hiperboles desine puse
