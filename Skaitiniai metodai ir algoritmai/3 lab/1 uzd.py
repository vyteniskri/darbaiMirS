import numpy as np
import matplotlib.pyplot as plt

def f(x):
    return np.cos(2*x) * (np.sin(2*x) + 1.5) + np.cos(x)

def vien(x, n):
    A=np.zeros((n,n),dtype=float)
    for i in range(n):
        A[:,i]=np.power(x,i)
    return A

def interp(x, n, coeff):
    yyy=np.zeros(x.size,dtype=float)
    for i in range (n): 
        yyy+=np.power(x,i)*coeff[i] 
    return yyy


def Gous(A1, n):
    ar = "Viena" #Skirtas singuliarumo salygai
    for i in range (0,n-1):   
        a, iii = np.max(np.abs(A1[i:n, i])), np.argmax(np.abs(A1[i:n, i])) + i

        if a == 0:
            continue
    
        if iii > i:
            A1[[i, iii], :] = A1[[iii, i], :]

        for j in range (i+1,n): 
            A1[j,i:n+1]=A1[j,i:n+1]-A1[i,i:n+1]*A1[j,i]/A1[i,i]
            A1[j,i]=0  
        

    #Grizimas atgal
    x=np.zeros(shape=(n,1))
    for i in range (n-1,-1,-1): 
        x[i,:]=(A1[i,n:n+1]-A1[i,i+1:n]*x[i+1:n,:])/A1[i,i]
 
    return x, ar



# Intervalas
a, b = -2, 3

# Interpoliavimo taškai pasiskirstę tolygiai
n = 10
x = np.linspace(a, b, n)
y = f(x)

# Interpoliavimo taškai apskaičiuoti naudojant Čiobyševo abscises
n_chebyshev = 10
x_chebyshev = 0.5 * (a + b) + 0.5 * (b - a) * np.cos((2 * np.arange(0, n_chebyshev) + 1) * np.pi / (2 * n_chebyshev))
y_chebyshev = f(x_chebyshev)

#---
T1 = vien(x, n)   
y_T=(np.matrix(y)).transpose()  
A1=np.hstack((T1,y_T))  
coeff1, ar = Gous(A1, n) 
#coeff1 = np.linalg.solve(T1, y)  

T2 = vien(x_chebyshev, n_chebyshev)
y_chebyshev_T=(np.matrix(y_chebyshev)).transpose()  
A2=np.hstack((T2,y_chebyshev_T))  
coeff2, ar = Gous(A2, n_chebyshev) 
#coeff2 = np.linalg.solve(T2, y_chebyshev)  
#---

#---
xxx=np.linspace(a,b,100)
yyy=interp(xxx, n, coeff1)
fig=plt.figure(0)
ax1=fig.add_subplot(1,1,1)
ax1.plot(x, y, label='Duotoji funkcija', color='black')
ax1.plot(x, y,'bo')
ax1.plot(xxx,yyy, label='Interpoliacinė funkcija (tolygiai)', color='blue')
ax1.set_title("Tolygūs taškai")
plt.grid()
plt.legend()
#---

#---
xxx=np.linspace(a,b,100)
yyy=interp(xxx, n_chebyshev, coeff2)
fig=plt.figure(1)
ax2=fig.add_subplot(1,1,1)
ax2.plot(x_chebyshev, y_chebyshev, label='Duotoji funkcija', color='black')
ax2.plot(x_chebyshev, y_chebyshev,'bo')
ax2.plot(xxx,yyy, label='Interpoliacinė funkcija (Čiobyševo)', color='blue')
ax2.set_title("Čiobyševo abscisės taškai")
plt.grid()
plt.legend()
#---

plt.show()

