import pandas as pd
import matplotlib.pyplot as plt
import numpy as np
from sklearn.linear_model import LinearRegression


def devide_data(sunspots, n):
    P = [] #ivestis
    T = [] #isvestis

    for i in range(len(sunspots) - n):
        p_values = sunspots[i:i+n].tolist()  # Extract the P values for the current sample as a list
        P.append(p_values)                    # Append the P values
        T.append(sunspots[i + n])
        
    return P, T

def learn_data(P, T):
    Pu = P[:200]
    Tu = T[:200]
    return Pu, Tu

def fit(X, Y, epoch_sk, lr):
    X = np.array(X)
    weight = np.zeros(1 + X.shape[1])
    errors = []
    costsMSE = []
    costsMAD = []
    MSE = 300
    MAD = 300
    for i in range(epoch_sk or MSE < 160):
        output = net_input(weight, X)
        errors = Y - output
        weight[1:] += lr * X.T.dot(errors)
        weight[0] += lr * errors.sum()

        MSE = (errors**2).sum() / len(Y)
        costsMSE.append(MSE)

        MAD = np.median(np.abs(errors))
        costsMAD.append(MAD)

        #print(MSE)
    return weight, MSE, MAD

def net_input(weight, X):
    return np.dot(X, weight[1:]) + weight[0]

# 1 - 3
text_file = "sunspot.txt"
# Read the data from the text file into a DataFrame
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
P, T = devide_data(y, 6)
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
Pu_test, Tu_test = P[200:], T[200:]  
X_train = np.array(Pu)
y_train = np.array(Tu)
model = LinearRegression()
model.fit(X_train, y_train)

w1 = model.coef_[0]
w2 = model.coef_[1]
# w3 = model.coef_[2]
# w4 = model.coef_[3]
# w5 = model.coef_[4]
# w6 = model.coef_[5]
# w7 = model.coef_[6]
# w8 = model.coef_[7]
# w9 = model.coef_[8]
# w10 = model.coef_[9]

b = model.intercept_

#print(f"w1: {w1}, w2: {w2}, w3: {w3}, w4: {w4}, w5: {w5}, w6: {w6}, w7: {w7}, w8: {w8}, w9: {w9}, w10: {w10}, b: {b}")
# print(f"w1: {w1}, w2: {w2}, w3: {w3}, w4: {w4}, w5: {w5}, w6: {w6}, b: {b}")
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

# #10
# Tsu = model.predict(Pu)
# years = np.array(df.iloc[:, 0])
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

# #11
Ts = model.predict(Pu_test)
e = Tu_test - Ts

# plt.plot(years[2:], e)
# plt.xlabel('Metai')
# plt.ylabel('Klaidos dydis')
# plt.title('Prognozavimo klaidų grafikas')
# plt.show()

# #12
# plt.hist(e, bins=30, edgecolor='black')
# plt.xlabel('Klaidos dydis')
# plt.ylabel('Dažnis')
# plt.title('Prognozės klaidų histograma')
# plt.show()

# #13
MSE = np.mean(np.square(e))

MAD = np.median(np.abs(e))

print("Mean Squared Error (MSE):", MSE)
print("Median Absolute Deviation (MAD):", MAD)

#14 - 16
def mse_ver(iterations):
    Pu_test, Tu_test = P[200:], T[200:]
    weight, MSE, MAD = fit(Pu, Tu, iterations, 0.0000001)

    output = net_input(weight, Pu_test)
    errors = Tu_test - output
    MSE = (errors**2).sum() / len(Tu_test)
    MAD = np.median(np.abs(errors))




    # print(f"w1: {weight[1]} w2: {weight[2]} b: {weight[0]} , MSE: {MSE}, MAD: {MAD}")
    # print(f"w1: {weight[1]}, w2: {weight[2]}, w3: {weight[3]}, w4: {weight[4]}, w5: {weight[5]}, w6: {weight[6]}, b: {weight[0]}, MSE: {MSE}, MAD: {MAD}")
    # print(f"w1: {weight[1]}, w2: {weight[2]}, w3: {weight[3]}, w4: {weight[4]}, w5: {weight[5]}, w6: {weight[6]}, w7: {weight[7]}, w8: {weight[8]}, w9: {weight[9]}, w10: {weight[10]}, b: {weight[0]}, MSE: {MSE}, MAD: {MAD}")
    return MSE

allMSE = []
for i in range(2000):
    allMSE.append(mse_ver(i))

plt.plot(range(len(allMSE)), allMSE)
plt.xlabel('Iteracijos')
plt.ylabel('MSE')
plt.title('MSE per iteracijas (n=6)')
plt.grid(True)
plt.show()

min_iteration = np.argmin(allMSE)
min_mse = allMSE[min_iteration]

print(f"Mažiausia MSE vertė: {min_mse}, epocha: {min_iteration}.")