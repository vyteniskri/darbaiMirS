import pandas as pd
import matplotlib.pyplot as plt
import numpy as np
from sklearn.linear_model import LinearRegression

def devide_data(sunspots, n):
    P = [] #ivestis
    T = [] #isvestis

    for i in range(len(sunspots) - n):
        p_values = sunspots[i:i+n].tolist() 
        P.append(p_values)                   
        T.append(sunspots[i + n])
        
    return P, T

def learn_data(P, T):
    Pu = P[:200]
    Tu = T[:200]
    return Pu, Tu

# 1 - 3
text_file = "sunspot.txt"
df = pd.read_csv(text_file, delimiter='\t', header=None)
print(df)

# 4
x = df.iloc[:, 0] #Metai
y = df.iloc[:, 1] #Sunspots
# plt.plot(x, y)
# plt.xlabel('Metai')  
# plt.ylabel('Saulės dėmių skaičius')
# plt.title('Saulės dėmių skaičius kiekvienais metais') 
# plt.show()


# 5
P, T = devide_data(y, 2)
# print(P)
# print(T)

# 6
# fig = plt.figure()
# ax = fig.add_subplot(111, projection='3d')

x = [p[0] for p in P]  # Pirmoji P value 
y = [p[1] for p in P]  # Antroji P value 
z = T                  # Isvestys

# ax.scatter(x, y, z, marker='o')

# ax.set_xlabel('Pirmosios įvestys')
# ax.set_ylabel('Antrosios įvestys')
# ax.set_zlabel('Išvestys')
# plt.title('Įvesties ir išvesties duomenys')

# plt.show()

#7
Pu, Tu = learn_data(P, T)

#8 - 9
X_train = np.array(Pu)
y_train = np.array(Tu)
model = LinearRegression()
model.fit(X_train, y_train)

w1 = model.coef_[0]
w2 = model.coef_[1]

b = model.intercept_

print(f"w1: {w1}, w2: {w2}, b: {b}")


# xx, yy = np.meshgrid(np.linspace(min(x), max(x)), np.linspace(min(y), max(y)))
# zz = w1*xx + w2*yy + b
# fig = plt.figure()
# ax = fig.add_subplot(111, projection='3d')

# ax.scatter(x, y, z, color='r', label='Data points')

# ax.plot_surface(xx, yy, zz, alpha=0.5, cmap='viridis')

# ax.set_xlabel('Pirmosios įvestys')
# ax.set_ylabel('Antrosios įvestys')
# ax.set_zlabel('Išvestys')
# ax.set_title('Plokštumos vaizdavimas')

# plt.show()

#10
# Tsu = model.predict(Pu)
years = np.array(df.iloc[:, 0])
# plt.plot(years[:200], Tu, label='Tikros išvestys')
# plt.plot(years[:200], Tsu, label='Nuspėjamos išvestys')
# plt.xlabel('Metai')
# plt.ylabel('Saulės dėmių skaičius')
# plt.title('Prognozavimo ir Mokymo duomenys')
# plt.legend()
# plt.show()

# Pu_test, Tu_test = P[200:], T[200:]  
# Tsu_test = model.predict(Pu_test)
# plt.plot(years[202:], Tu_test, label='Tikros išvestys')
# plt.plot(years[202:], Tsu_test, label='Nuspėjamos išvestys')
# plt.xlabel('Metai')
# plt.ylabel('Saulės dėmių skaičius')
# plt.title('Prognozavimo ir Testavimo duomenys')
# plt.legend()
# plt.show()

#11
Ts = model.predict(P)
e = T - Ts

plt.plot(years[2:], e)
plt.xlabel('Metai')
plt.ylabel('Klaidos dydis')
plt.title('Prognozavimo klaidų grafikas')
plt.show()

#12
plt.hist(e, bins=30, edgecolor='black')
plt.xlabel('Klaidos dydis')
plt.ylabel('Dažnis')
plt.title('Prognozės klaidų histograma')
plt.show()

#13
MSE = np.mean(np.square(e))

MAD = np.median(np.abs(e))

print("Mean Squared Error (MSE):", MSE)
print("Median Absolute Deviation (MAD):", MAD)