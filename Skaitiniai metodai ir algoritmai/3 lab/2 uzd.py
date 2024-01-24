import numpy as np
import matplotlib.pyplot as plt

def Splainu_interpoliacija():
   plt.figure(1), plt.grid(True), plt.axis('equal')
   nP = 21
   xrange = [1998, 2018]
   X = np.linspace(xrange[0], xrange[1], nP)
   Y = [16.53, 15.67, 15.77, 15.54, 14.82, 15.13, 15.11, 16.76, 17.29, 17.30, 17.41, 19.00, 19.62, 20.72, 21.42, 21.40, 21.83, 21.73, 21.94, 21.51, 21.53]
   plt.plot(X, Y, 'ko')

   DDF = splaino_koeficientai(X, Y)
   for iii in range(nP-1):
       nnn = 100
       sss = np.linspace(X[iii], X[iii+1], nnn)
       S = splainas(X[iii:iii+2], Y[iii:iii+2], DDF[iii:iii+2], nnn)
       plt.plot(sss, S, 'r-')

   plt.legend(['duoti taškai', 'Splainai {} intervaluose'.format(nP-1)])
   plt.show()

   return


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
        if (A1[i,i] == 0 and A1[i,n:n+1] == 0):
            x[i,:] = 1
        elif (A1[i,i] == 0 and A1[i,n:n+1] != 0):
            return None
        else:
            x[i,:]=(A1[i,n:n+1]-A1[i,i+1:n]*x[i+1:n,:])/A1[i,i]
 
    return x


def splaino_koeficientai(X, Y):
   n = len(X)
   A = np.zeros((n, n))
   b = np.zeros(n)
   d = X[1:] - X[:-1]
   for i in range(n-2):
       A[i, i:i+3] = [d[i]/6, (d[i]+d[i+1])/3, d[i+1]/6]
       b[i] = (Y[i+2]-Y[i+1])/d[i+1] - (Y[i+1]-Y[i])/d[i]

   A[n-1, 0] = 1
   A[n-1, n-1] = 1

   y_T=(np.matrix(b)).transpose()  
   A1=np.hstack((A,y_T))
   DDF = Gous(A1, n)
   return DDF

def splainas(X, Y, DDF, nnn):
   d = X[1] - X[0]
   sss = np.linspace(X[0], X[1], nnn)
   S = DDF[0]/2*(sss-X[0])**2 + (DDF[1]-DDF[0])/(6*d)*(sss-X[0])**3 + (sss-X[0])*((Y[1]-Y[0])/d-DDF[0]*d/3-DDF[1]*d/6) + Y[0]

   return S

Splainu_interpoliacija()