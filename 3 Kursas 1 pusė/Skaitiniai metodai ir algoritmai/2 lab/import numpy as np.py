import numpy as np
import matplotlib.pyplot as plt
from mpl_toolkits import mplot3d
import math

def Gous(A1):
    ar = "Veina" #Skirtas singuliarumo salygai
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
            print("Lygtis turi begalo daug sprendiniu")
            ar = "Daug"
            x[i,:] = 1
        elif (A1[i,i] == 0 and A1[i,n:n+1] != 0):
            print("Lygtis neturi sprendiniu")
            return None, ar
        else:
            x[i,:]=(A1[i,n:n+1]-A1[i,i+1:n]*x[i+1:n,:])/A1[i,i]

    print(x) 
    return x, ar

def patikr(A, b, x):
    ats = 0
    for i in range(0, n):
        for j in range(0, n):
            ats = ats + A[i, j] * x[j]

        print('Duota reiksme: {0} ir gauta reiksme: {1}'.format(b[i], ats))
        ats = 0
 
#5
print("Gauso metodas: 5 lygtis")
A=np.matrix([[4 , 12,  1,  7],
             [2, 6, 17,  2],
             [2,  1, 5,  1],
             [5,  11,  7, 0]]).astype(float)    
b=(np.matrix([171,75,30,50])).transpose()  

n=(np.shape(A))[0]   
A1=np.hstack((A,b))  

x, ar = Gous(A1) 
if (x is not None):
    patikr(A, b, x)
    if (ar == "Viena"):
        print('Patikrinimas :\n {0}'.format(np.linalg.solve(A, b)))
    else:
        x, residuals, rank, s = np.linalg.lstsq(A, b, rcond=None)
        print('Patikrinimas :\n {0}'.format(x))
print()

#13
ar = "Viena"
print("Gauso metodas: 13 lygtis")
A=np.matrix([[1 , -2,  3,  4],
             [1, 0, -1,  1],
             [2,  -2, 2,  5],
             [0,  -7,  3, 1]]).astype(float)   
b=(np.matrix([11,-4,7,2])).transpose()

n=(np.shape(A))[0]   
A1=np.hstack((A,b))  

x, ar = Gous(A1) 
if (x is not None):
    patikr(A, b, x)
    if (ar == "Viena"):
        print('Patikrinimas :\n {0}'.format(np.linalg.solve(A, b)))
    else:
        x, residuals, rank, s = np.linalg.lstsq(A, b, rcond=None)
        print('Patikrinimas :\n {0}'.format(x))
print()

#19
print("Gauso metodas: 19 lygtis")
A=np.matrix([[3 , 1,  -1,  5],
             [-3, 4, -8,  -1],
             [1,  -3, 7,  6],
             [0,  5,  -9, 4]]).astype(float)       
b=(np.matrix([8,10,11,1])).transpose()  

n=(np.shape(A))[0]   
A1=np.hstack((A,b))  

x, ar = Gous(A1) 
if (x is not None):
    patikr(A, b, x)
    if (ar == "Viena"):
        print('Patikrinimas :\n {0}'.format(np.linalg.solve(A, b)))
    else:
        x, residuals, rank, s = np.linalg.lstsq(A, b, rcond=None)
        print('Patikrinimas :\n {0}'.format(x))
print()




def GZeid(A, b, n):
    P=np.arange(0,n)
    for i in range (0,n):
        
        if (np.diag(A)[i] == 0): #Negali vykti dalyba is 0           
            iii = np.argmax(np.abs(A[0:n, i]))
            
            A[[i, iii], :] = A[[iii, i], :]
            P[[i,iii]]=P[[iii,i]] 
    b=b[P]

    alpha=np.array([1, 1, 1, 10]) 
    Atld=np.diag(1./np.diag(A)).dot(A)-np.diag(alpha)
    btld=np.diag(1./np.diag(A)).dot(b)

    nitmax=1000; eps=1e-12

    x=np.zeros(shape=(n,1)); x1=np.zeros(shape=(n,1))

    for it in range (0,nitmax):
        for i in range (0,n):
            x1[i]=(btld[i]-Atld[i,:].dot(x1))/alpha[i]
            
        if (math.isinf(np.linalg.norm(x)+np.linalg.norm(x1))):
            print("Lygtis neturi sprendiniu arba pasirinkta netinkama alpha reiksme:")
            print(x)
            return None, b

        prec=(np.linalg.norm(x1-x)/(np.linalg.norm(x)+np.linalg.norm(x1)))
        if (prec < eps): 
            return x, b
        x[:]=x1[:]
    print("Metodas diverguoja:")
    print(x)
    return None, b



#5 Zeidelio
print("Gauso-Zeidelio algoritmas: 5 lygtis")
A=np.matrix([[4 , 12,  1,  7],
             [2, 6, 17,  2],
             [2,  1, 5,  1],
             [5,  11,  7, 0]]).astype(float)     
b=np.array([[171],[75],[30],[50]])
n=(np.shape(A))[0] 

x, b = GZeid(A, b, n)
if (x is not None):
    print(x)
    patikr(A, b, x)
    print('Patikrinimas :\n {0}'.format(np.dot(A, x)))
print()   

def QGavimas(A): 

    Q=np.identity(n)
    for i in range (0,n-1):
        z=A[i:n,i]
        zp=np.zeros(np.shape(z))
        zp[0]=np.linalg.norm(z)

        omega=z-zp
        omega=omega/np.linalg.norm(omega)
        Qi=np.identity(n-i)-2*omega*omega.transpose()
        A[i:n,:]=Qi.dot(A[i:n,:]) #Trikampe matrica

        Q[:,i:n]= Q[:,i:n].dot(Qi) #Ortogonalioji matrica
        
    return Q


def QRAtgalinis(Q, A, b):

    b1=Q.transpose().dot(b)
    x=np.zeros(shape=(n,1))

    for i in range (n-1,-1,-1): 
        if  (A[i,i] == 0 and b1[i,:] == 0):
            print("Lygtis turi begalo daug sprendiniu")
            x[i,:] = 1
        elif (A[i,i] == 0 and b1[i,:] != 0):
            print("Lygtis neturi sprendiniu")
            return 
        else:
            x[i,:]=(b1[i,:]-A[i,i+1:n]*x[i+1:n,:])/A[i,i]
            
    return x

#QR sklaida
print("QR skaidos algoritmas")
A=np.matrix([[5 , 3,  -1,  2],
             [3, 6, -2,  -2],
             [-1,  -2, 4,  -1],
             [2,  -2,  -1, 12]]).astype(float)
Ap = np.copy(A) 

#Laisvuju nariu vektoriai
b1 = np.array([[9],[5],[0],[11]])
b2 = np.array([[26],[0],[20],[44]])
b3 = np.array([[-4.75],[-5],[3.75],[-7.25]])

Q = QGavimas(A)

x = QRAtgalinis(Q, A, b1)
if (x is not None):
    print("Nezinomieji: ")
    print(x)

    print("b1 laisvieji nariai: ")
    patikr(Ap, b1, x)
    #Python tikrinimas
    Qi, Ri = np.linalg.qr(Ap)
    y = np.dot(Qi.transpose(), b1)
    x = np.linalg.solve(Ri, y)
    print('Patikrinimas :\n {0}'.format(x))
    print()

x = QRAtgalinis(Q, A, b2)
if (x is not None):
    print("Nezinomieji: ")
    print(x)

    print("b2 laisvieji nariai: ")
    patikr(Ap, b2, x)
    #Python tikrinimas
    Qi, Ri = np.linalg.qr(Ap)
    y = np.dot(Qi.transpose(), b2)
    x = np.linalg.solve(Ri, y)
    print('Patikrinimas :\n {0}'.format(x))
    print()

x = QRAtgalinis(Q, A, b3)
if (x is not None):
    print("Nezinomieji: ")
    print(x)

    print("b3 laisvieji nariai: ")
    patikr(Ap, b3, x)
    #Python tikrinimas
    Qi, Ri = np.linalg.qr(Ap)
    y = np.dot(Qi.transpose(), b3)
    x = np.linalg.solve(Ri, y)
    print('Patikrinimas :\n {0}'.format(x))
    print()



#2DALIS---------------------------------

def LF(x):
    s=np.matrix( [[x[0]**2 + 10*(np.sin(x[0]) + np.cos(x[1]))**2 - 10], [(x[1] - 3)**2 + x[0] - 8]])
    return s

fig1=plt.figure(1,figsize=plt.figaspect(0.5)) #Abeji pavirseiai
fig2=plt.figure(2,figsize=plt.figaspect(0.5)) #Vienas pavirsius

ax1 = fig1.add_subplot(1, 2, 1, projection='3d')
ax2 = fig1.add_subplot(1, 2, 2, projection='3d')
ax1.set_title('Pavirsius 1')
ax2.set_title('Pavirsius 2')

ax3 = fig2.add_subplot(1, 1, 1, projection='3d')
ax3.set_title('Plokstumu susikirtimai')

ax1.set_xlabel('x')
ax1.set_ylabel('y')
ax1.set_zlabel('f(x, y)')

ax2.set_xlabel('x')
ax2.set_ylabel('y')
ax2.set_zlabel('f(x, y)')

ax3.set_xlabel('x')
ax3.set_ylabel('y')
ax3.set_zlabel('f(x, y)')

plt.draw()

xx=np.linspace(-15,15,50)
yy=np.linspace(-10,10,50)
X, Y = np.meshgrid(xx, yy)
Z=np.zeros(shape=(len(xx),len(yy),2))


for i in range (0,len(xx)):
    for j in range (0,len(yy)):
        Z[i,j,:]=LF([X[i][j],Y[i][j]]).transpose()

surf1 = ax1.plot_surface(X, Y, Z[:,:,0], color='blue', alpha=0.4)
CS11 = ax1.contour(X, Y, Z[:,:,0],[0],colors='b')

surf2 = ax2.plot_surface(X, Y, Z[:,:,1], color='purple',alpha=0.4)
CS12 = ax2.contour(X, Y, Z[:,:,1],[0],colors='g')

CS1 = ax3.contour(X, Y, Z[:,:,0],[0],colors='b')
CS2 = ax3.contour(X, Y, Z[:,:,1],[0],colors='g')

plt.show()

