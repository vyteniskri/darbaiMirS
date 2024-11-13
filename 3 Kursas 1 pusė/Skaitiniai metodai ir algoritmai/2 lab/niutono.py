from tkinter import *
import numpy as np
from numpy import *
import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import Axes3D
import math
from scipy.optimize import fsolve


#--------Randama RGB spalva
def jetColormapValueToRGB(value) :           
            N = 5;   # jet colormap vartoja 5 spalvu kubo virsunes
            #jetColors = [[0, 0, 1 ],[0, 1, 1 ], [0, 1, 0 ],[1, 1, 0 ],[1, 0, 0]];
            jetColors = [[0, 0, 1 ],[0, 1, 1 ], [0, 1, 0 ],[1, 0, 1 ],[1, 0, 0]];
            if (value < 0) | (value > 1): 
                #print("***** jetColormapValueToRGB:   value not in range [0,1]")
                return None

            for  i in range (0, N-1) :
                a = 1.0*i / (N - 1);  b = 1.0*(i+1) / (N - 1);  #print(a); print(b);
                if (value >= a) & (value <= b) :
                      rr = (value - a) / (b - a);  rgb=[];
                      for j in range (0,3) :  rgb.append(double(jetColors[i][j] * (1 - rr) + jetColors[i + 1][j] * rr));
                      break
            return rgb


#------Jakobino matrica
def numerical_jacobi(f,x,dx):
    n=np.size(f(x))
    m=np.size(x)
    J=np.matrix(np.zeros((n,m),dtype=float))
    x1=np.matrix(x)
    for j in range (m): 
        x1[j]=x[j]+dx
        J[:,j]=(f(x1)-f(x))/dx
        x1[j]=x[j]
    return J

#--------Pradine funkcija
def f(x):
    return np.vstack((x[0]**2 + 10*(np.sin(x[0]) + np.cos(x[1]))**2 - 10, (x[1] - 3)**2 + x[0] - 8))

def flat_f(x):
    return f(x).flatten()

#----------Netuno metodas
def Newton(xx):

    alpha = 0.5
    eps = 1e-5
    itmax = 200
    x=np.matrix([[xx[0]],[xx[1]]],dtype=float) #Pradiniai artiniai
    ff = f(x)
    dff = numerical_jacobi(f,x,eps)

    for iii in range(itmax):
        dff = numerical_jacobi(f,x,eps) 

        deltax = -np.linalg.solve(dff, ff)
        x1 = x + alpha * deltax       
        ff1 = f(x1)

        tikslumas = np.linalg.norm(deltax) / (np.linalg.norm(x) + np.linalg.norm(deltax))

        #print(f'\n iteracija {iii+1}  tikslumas {tikslumas}')
        if tikslumas < eps:
            #print(f'\n sprendinys x = {x}')
            return x

        elif iii == itmax - 1:
            #print(f'\n ****tikslumas nepasiektas. Paskutinis artinys x = {x}')
            return None

        x = x1
        ff = ff1


xx=np.linspace(-10,10,25)
yy=np.linspace(-10,10,25)
X, Y = np.meshgrid(xx, yy)
Z=np.zeros(shape=(len(xx),len(yy),2))
Z1=np.zeros(shape=(len(xx),len(yy),2))

fig1=plt.figure(1,figsize=plt.figaspect(0.5))
ax = fig1.add_subplot(1, 1, 1, projection='3d')
ax.set_xlabel('x1')
ax.set_ylabel('x2')
ax.set_zlabel('Z1(x1, x2)')


solutions = []
AllRoots = []
pradArt = []
colors = []
#-------------Skirtas nupaisyti funkcijas
for i in range (0,len(xx)):
    for j in range (0,len(yy)):
        initial_guess = [X[i][j], Y[i][j]]
        Z1[i,j,:]=f(initial_guess).transpose()


#------------Skirtas tasku sudejimui tinklelyje
for i in range (0,len(xx)):
    for j in range (0,len(yy)):

        initial_guess = [X[i][j], Y[i][j]]
        solution = Newton(initial_guess)

        if (solution is None):
            continue

        is_fsolv = False
        is_close = False
        for existing_solution in solutions:
            if np.linalg.norm(existing_solution - solution) < math.exp(-4):
                is_close = True
                break

        if not is_close:
            AllRoots.append(solution)
            pradArt.append(initial_guess)
            print('Sprendinyas: {0}'.format(solution))
            print('Pradinis artinys: {0}'.format(initial_guess)) 
            print('Gautu sprendiniu patikrinimas: {0} '.format(fsolve(flat_f, solution)))
    
        
        l = 0.1
        for s in AllRoots:
            if np.linalg.norm(s - solution) < math.exp(-4):
                ax.scatter(initial_guess[0], initial_guess[1], f(initial_guess).transpose(), c=jetColormapValueToRGB(l))
            l = l + 0.2

        solutions.append(solution)

#------------Rastu saknu pavaizdavimas
i = 0.1
for sol in AllRoots:
    ax.scatter(sol[0], sol[1], f(sol).transpose(), c=jetColormapValueToRGB(i), marker='*', s=100)
    i = i + 0.2


CS1 = ax.contour(X, Y, Z1[:,:,0],[0],colors='black')
CS2 = ax.contour(X, Y, Z1[:,:,1],[0],colors='black')

ax.view_init(elev=90, azim=0)
plt.show()
