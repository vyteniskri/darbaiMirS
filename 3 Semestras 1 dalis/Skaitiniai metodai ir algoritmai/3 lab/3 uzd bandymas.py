import numpy as np
import matplotlib.pyplot as plt


def base(m, x):
    G=np.zeros((len(x),m),dtype=float)
    for i in range(m):
        G[:,i]=np.power(x,i)
    return G

def Gous(A1, n):
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
 
    return x

def Calcutalte(m):
    plt.figure(1)
    plt.grid(True)
  
    nP = 21
    xrange = [1998, 2018]
    X = np.linspace(xrange[0], xrange[1], nP)
    Y = [16.53, 15.67, 15.77, 15.54, 14.82, 15.13, 15.11, 16.76, 17.29, 17.30, 17.41, 19.00, 19.62, 20.72, 21.42, 21.40, 21.83, 21.73, 21.94, 21.51, 21.53]
    plt.plot(X, Y, 'ko', label='Duotoji funkcija', color='black')
    n = len(X)  # tasku skaicius

    # Maziausiu kvadratu metodo lygciu sistema:
    G = base(m, X)
    A_transpose_A = np.dot(G.T, G)
    A_transpose_Y = np.dot(G.T, Y)
    y_T=(np.matrix(A_transpose_Y)).transpose()  
    A1=np.hstack((A_transpose_A,y_T))
    c = Gous(A1, m)

    sss = '{:5.2g}'.format(float(c[0]))
    for i in range(1, m):
        sss += '+{:5.2g}x^{}'.format(float(c[i]), i)
    sss = sss.replace('+  -', '-')
    
    # Aproksimuojanti funkcija:
    nnn = 200  # vaizdavimo tasku skaicius
    xxx = np.linspace(xrange[0], xrange[1], nnn)  # vaizdavimo taskai
    Gv = base(m, xxx)
    fff = np.dot(Gv, c)

    plt.plot(xxx, fff, 'r-')
    plt.legend(['duoti taskai', 'f(x)={}'.format(sss)])
    plt.title(f'aproksimavimas maziausiu kvadratu metodu \n  tasku skaicius {n},  funkciju skaicius  {m}')
    plt.show()


Calcutalte(1)
Calcutalte(2)
Calcutalte(3)
Calcutalte(5)