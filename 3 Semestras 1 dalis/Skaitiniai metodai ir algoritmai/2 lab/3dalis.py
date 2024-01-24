import numpy as np
import matplotlib.pyplot as plt

existing_stores = [(1, 2), (3, 4), (5, 6)]

# Funkcija apskaičiuojanti kainą tarp dviejų parduotuvių
def C(x1, y1, x2, y2):
    return np.exp(-0.3 * ((x1 - x2)**2 + (y1 - y2)**2))

# Funkcija apskaičiuojanti kainą naujos parduotuvės vietoje
def CP(x1, y1):
    return (x1**4 + y1**4) / 1000 + (np.sin(x1) + np.cos(y1)) / 5 + 0.4


# Tikslo funkcija - suma visų parduotuvių kainų
def objective_function(x, y):
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

TaskuSkaicius = 3
areaLim = 10
new_stores = [(8, 6), (9, 1), (4, 3), (9, 9)]
x = [float(x) for x, y in new_stores]
y = [float(y) for x, y in new_stores]

fig=plt.figure(0)
ax=fig.add_subplot(1,1,1)
ax.set_xlabel('x')
ax.set_ylabel('y')
plt.xlim([-areaLim-2, areaLim+2])
plt.ylim([-areaLim-2, areaLim+2])
plt.plot([-areaLim, -areaLim, areaLim, areaLim, -areaLim], [-areaLim, areaLim, areaLim, -areaLim, -areaLim],'--k') 
ax.scatter(*zip(*existing_stores), c='red', marker='o', label='Pradines parduotuves')


#Gradiantas
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

TFValues = []
Iterations = []

#Vyksta optimizavimas (greičiausias nusileidimas)
step=0.01*TaskuSkaicius
print('pradine funkcijos reiksme',objective_function(x, y))
TFmin=1e10
gradx,grady=dTF(x,y,0.001)
for j in range (1250):
  x=x-step*gradx
  y=y-step*grady
  tf=objective_function(x,y)

  #---Grafikui
  TFValues.append(tf)
  Iterations.append(j)
  #---
  
  if TFmin  > tf: 
    TFmin=tf
    
  else: 
    x=x+step*gradx
    y=y+step*grady 
    gradx, grady=dTF(x,y,0.001)


print('minimizuota funkcijos reiksme',objective_function(x,y))

#Pradiniai ir galutiniai taskai
print('Pradine tasku konfiguracija: {0}'.format(new_stores))
print('Gauta tasku konfiguracija x:{0} ir y:{1}'.format(x, y))

ax.plot(x,y,'bo', label='Naujos parduotuves')
plt.axis('equal')  
plt.legend()
plt.grid()

#Iteraciju / tikslo funkcijos grafikas
fig=plt.figure(1)
ax1=fig.add_subplot(1,1,1)
ax1.plot(Iterations, TFValues)
ax1.set_xlabel('x - iteraciju skaicius')
ax1.set_ylabel('y - tikslo funkcijos reiksmes')

plt.grid()
plt.show()