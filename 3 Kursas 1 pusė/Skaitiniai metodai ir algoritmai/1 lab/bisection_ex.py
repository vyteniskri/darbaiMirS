import math
import numpy as np;
import matplotlib.pyplot as plt
import sympy as sp
from array import array

# funkcia, kuriai ieškome šaknų f(x)
def fx(x):
  return 0.48*x**5 + 1.71*x**4 - 0.67*x**3 - 4.86*x**2  - 1.33*x + 1.5

"""
x = np.linspace(-12, 12, 100)
y = fx(x)
plt.xlabel('X-axis')
plt.ylabel('Y-axis')
plt.plot(x,y)
plt.grid()

#Grubus įvertis
plt.plot(11.125, 0, markersize=10, marker='+', color = 'green', label = "Grubus įvertis")
plt.plot(-11.125, 0, markersize=10, marker='+', color = 'green')

#Tikslesnis įvertis
plt.plot(-4.181, 0, markersize=5, marker='o', color='red', label = "Tikslesnis įvertis")
plt.plot(4.5625, 0, markersize=5, marker='o', color='red')

plt.legend()
plt.show()


#funkcija g(x)
def gx(x):
  return math.exp(-x) * math.sin(x**2) + 0.001

g = np.vectorize(gx)
x = np.linspace(5, 10, 1000)
y = g(x)
plt.grid()
plt.xlabel('X-axis')
plt.ylabel('Y-axis')
plt.plot(x,y)
plt.show()

"""
#Skenavimo algoritmas 
def scaning(func, From, To, arr1, arr2, postumis):
   li = 0
   while (From < To):
      zenkl1 = func(From)
      zenkl2 = func(From + postumis)
      
      if (np.sign(zenkl1) != np.sign(zenkl2)):
         plt.plot(From, 0, markersize=5, marker='o', color='red')
         plt.plot(From + postumis, 0, markersize=5, marker='o', color='blue')
         arr1.append(From)
         arr2.append(From + postumis)
         li += 1
      From = From + postumis
   print('Total number of intervals: = {0}'.format(li))



# pusiaukirtos metodas
def bisection(func, xFrom, xTo):
    xmid = (xFrom + xTo) / 2
    iter = 0
    while (np.abs(func(xmid)) > 1e-10):
        iter += 1
        if (np.sign(func(xmid)) == np.sign(func(xFrom))):
            xFrom = xmid
        else:
            xTo = xmid
        xmid = (xFrom + xTo) / 2
        #print('x = {0:.20f} f(x) = {1:.20f}'.format(xmid, func(xmid)))
    print('Total iteration: = {0}'.format(iter))
    return xmid

#Spausdina šaknis pusiaukirtos metodu
def printRootsPusiaukirtos(func, arr1, arr2):
   i=0
   while(i < len(arr1)):
      root = bisection(func, arr1[i], arr2[i])
      print("Šaknis: ", root)
      print("Reiksme: ", func(root))
      i += 1

def dfx(x_value):
  x = sp.symbols('x')
  fx = 0.48*x**5 + 1.71*x**4 - 0.67*x**3 - 4.86*x**2  - 1.33*x + 1.5
  return sp.diff(fx, x).subs(x, x_value)

def dgx(x_value):
  x = sp.symbols('x')
  gx = sp.exp(-x) * sp.sin(x**2) + 0.001
  return sp.diff(gx, x).subs(x, x_value)


def Niutono(func, dFunc, xFrom):
   iter = 0
   xi = xFrom
   eps = 1e-8
   
   while np.abs(func(xi)) > eps:
     iter += 1

     xi = xi - 0.5 * (1 / dFunc(xi)) * func(xi)
   #print('Total iteration: = {0}'.format(iter))
   return xi  


def printRootsNiutono(func, dFunc, arr1):
   i=0
   while(i < len(arr1)):
      root = Niutono(func, dFunc, arr1[i])
      print("Šaknis: ", root)
      print("Reiksme: ", func(root))
      i += 1
"""
#Šaknų atskyrimo intervalai f(x) funkcijai (skenavimo žingsnis - 0.1)
x = np.linspace(-5, 5, 100)
y = fx(x)
plt.plot(x,y)
my_listStart2 = []
my_listEnd2 = []
scaning(fx, -4.181, 4.5625, my_listStart2, my_listEnd2, 0.1)
plt.ylim([-50000, 50000])
plt.xlim([-5, 5])
plt.xlabel('X-axis')
plt.ylabel('Y-axis')
plt.grid()
plt.show()
print('Nuo: {0}  iki {1}'.format(my_listStart2, my_listEnd2))
printRootsPusiaukirtos(fx, my_listStart2, my_listEnd2)
print("")
printRootsNiutono(fx, dfx, my_listStart2)

#Šaknų atskyrimo intervalai g(x) funkcijai (skenavimo žingsnis - 0.01)
g = np.vectorize(gx)
x = np.linspace(5, 10, 1000)
y = g(x)
plt.plot(x,y)
my_listStart3 = []
my_listEnd3 = []
scaning(g, 5, 10, my_listStart3, my_listEnd3, 0.01)
plt.ylim([-0.011, 0.011])
plt.xlim([5, 7])
plt.grid()
plt.xlabel('X-axis')
plt.ylabel('Y-axis')
plt.show()
print('Nuo: {0}  iki {1}'.format(my_listStart3, my_listEnd3))
printRootsPusiaukirtos(g, my_listStart3, my_listEnd3)
print("")
printRootsNiutono(g, dgx, my_listStart3)
"""


#2 DALIS

def fx(x):
   return 2 * np.cos(x) - 47 * np.cos(2*x) + 2 # -6 ir 0


def df1(x):
  return 2 * (-np.sin(x)) + 94 * np.sin(2*x)

def df2(x):
  return 2 * (-np.cos(x)) + 188 * np.cos(2*x)

def df3(x):
  return  2 * (np.sin(x)) - 376 * np.sin(2*x)

def df4(x):
  return 2 * (np.cos(x)) - 752 * np.cos(2*x)

def df5(x):
  return 2 * (-np.sin(x)) + 1504 * np.sin(2*x)



def ts3(x, x0):
  return fx(x0) + (x-x0)*df1(x0) + (np.power((x-x0), 2) / 2 ) *df2(x0) + (np.power((x-x0), 3) / (3*2)) *df3(x0)

def ts4(x, x0):
  return fx(x0) + (x-x0)*df1(x0) + (np.power((x-x0), 2) / 2 ) *df2(x0) + (np.power((x-x0), 3) / (3*2)) *df3(x0) + (np.power((x-x0), 4) / (4*3*2)) *df4(x0)

def ts5(x, x0):
  return fx(x0) + (x-x0)*df1(x0) + (np.power((x-x0), 2) / 2 ) *df2(x0) + (np.power((x-x0), 3) / (3*2)) *df3(x0) + (np.power((x-x0), 4) / (4*3*2)) *df4(x0) + (np.power((x-x0), 5) / (5*4*3*2)) *df5(x0)


dx= 0.1
x=np.arange(-6, 0+dx, dx)
y = fx(x)

#3 Teiloro eilute
plt.xlim([-6, 0]); plt.ylim([-100, 100])

x0 = -3; # vidurio taskas

tsy3 = ts3(x, x0)

plt.xlabel('X-axis')
plt.ylabel('Y-axis')
plt.plot(x, y, 'b',  linewidth=3.0) # pagrindine funkcija
plt.plot(x, tsy3, 'r', 1) # 3 order
plt.plot(x0, fx(x0), 'or') # vidurio tasko atvaizdavimas

plt.legend(['Duota funcija: f(x)', '3 Teiloro eilute', 'Vidurio taskas'])
plt.grid()
plt.show()

#4 Teiloro eilute
plt.xlim([-6, 0]); plt.ylim([-100, 100])

x0 = -3; # vidurio taskas

tsy4 = ts4(x, x0)

plt.xlabel('X-axis')
plt.ylabel('Y-axis')
plt.plot(x, y, 'b',  linewidth=3.0) # pagrindine funkcija
plt.plot(x, tsy4, 'r', 1) # 4 order
plt.plot(x0, fx(x0), 'or') # vidurio tasko atvaizdavimas

plt.legend(['Duota funcija: f(x)', '4 Teiloro eilute', 'Vidurio taskas'])
plt.grid()
plt.show()

#5 Teiloro eilute
plt.xlim([-6, 0]); plt.ylim([-100, 100])

x0 = -3; # vidurio taskas

tsy5 = ts5(x, x0)

plt.xlabel('X-axis')
plt.ylabel('Y-axis')
plt.plot(x, y, 'b',  linewidth=3.0) # pagrindine funkcija
plt.plot(x, tsy5, 'r', 1) # 5 order
plt.plot(x0, fx(x0), 'or') # vidurio tasko atvaizdavimas

plt.legend(['Duota funcija: f(x)', '5 Teiloro eilute', 'Vidurio taskas'])
plt.grid()
plt.show()

#Pradinės funkcijos šaknys
def hSaknys(h_Saknys, Artiniai):  
   i = 0
   while(i < len(Artiniai)):
      root = Niutono(fx, df1, Artiniai[i])
      h_Saknys.append(root)
      print(root)
      i += 1

#Teiloro funkcija
def Taylor(f, N):
    x, f, fp = sp.symbols(('x','f','fp'))
    f = 2 * sp.cos(x) - 47 * sp.cos(2*x) + 2 #Turima funkcija

    fp = f.subs(x, -3) #Pirmasis TE narys

    for i in range(1, N):
        f=f.diff(x)
        fp = fp + f.subs(x, -3)/math.factorial(i)*(x+3)**i
        i += 1
        N += 1
    return fp

#Šaknų lyginimas pagal 1e-4 tikslumą
def SaknuPanasumas(saknis, mas):
   x, fp = sp.symbols(('x','fp'))
   f_prad = 2 * sp.cos(x) - 47 * sp.cos(2*x) + 2 #Pradine funkcija, kuri nekis
   
   i = 2
   fp = Taylor(f_prad, 1)
   mas.append(0)
   fp = Taylor(f_prad, 2)
   mas.append(np.abs(saknis - Niutono(sp.lambdify(x, fp, modules=['numpy']), sp.lambdify(x, fp.diff(x), modules=['numpy']), saknis)))
   while (np.abs(saknis - Niutono(sp.lambdify(x, fp, modules=['numpy']), sp.lambdify(x, fp.diff(x), modules=['numpy']), saknis)) >= 1e-4):
      i += 1
      fp = Taylor(f_prad, i)
      mas.append(np.abs(saknis - Niutono(sp.lambdify(x, fp, modules=['numpy']), sp.lambdify(x, fp.diff(x), modules=['numpy']), saknis)))
   return i, fp

#Gaunamas bendras šaknų kiekis prilausantis nuo TE eilių
def GetSaknysTEskaiciu(masTE, SaknuSk):

   i = 0
   z = 0
   while (i < len(masTE)):
      j = 0
      
      if (i + 1 < len(masTE)):
          while (j <= (masTE[i + 1] - 1) - masTE[i]):
            SaknuSk.append(i)
            
            z += 1
            j += 1
      i += 1
   SaknuSk.append(i - 1)


VisiTESkaiciai = []
Artiniai = [-5.5, -4, -2.5, -0.5]
h_Saknys = []
hSaknys(h_Saknys, Artiniai)

mas = [] #Nereikalingas
maximum = 0
for saknis in h_Saknys:
   SkaiciusTE, Daugianaris = SaknuPanasumas(saknis, mas)
   VisiTESkaiciai.append(SkaiciusTE)
   print(SkaiciusTE)
   if SkaiciusTE > maximum:
      maximum = SkaiciusTE
      DidziausiasDaugianaris = Daugianaris

print("TE nariu skaicius: ", maximum)
print("TE daugianario pavidalas: ", DidziausiasDaugianaris)

#Grafiko h(x) ir N-tosios Teiloro eilutes braizymas
x = sp.symbols('x')
dx= 0.1
f_prad = 2 * sp.cos(x) - 47 * sp.cos(2*x) + 2 
xvalue=np.arange(-6, 0+dx, dx)
y_vals = [DidziausiasDaugianaris.subs(x, val) for val in xvalue]
y_vals_f_prad = [f_prad.subs(x, val) for val in xvalue]

plt.plot(xvalue, y_vals, 'b')
plt.plot(xvalue, y_vals_f_prad,  'g', 1)
plt.legend(['N Teiloro eilute', 'Duota funcija: f(x)'])
plt.ylim(-100, 100)
plt.xlim(-6, 0)
for saknis in h_Saknys:
      plt.axvline(x=saknis, color='r', linestyle='--')
plt.title('Pagal tiksluma sudarytas daugianario grafikas')
plt.grid()
plt.show()

#4. a dalis
saknuSk = [] 
VisiTESkaiciai = VisiTESkaiciai + [0]
VisiTESkaiciai.sort()
GetSaknysTEskaiciu(VisiTESkaiciai, saknuSk) #Gražinamas saknuSk masyvas
y_values = np.linspace(0, 4, 100)
plt.figure()
plt.plot(range(0, maximum + 1), saknuSk, marker='o', label='tikslumai')
plt.xlabel('ox-TE eilė')
plt.ylabel('oy – šaknų skaičius')
plt.grid(True)
plt.show()

#4. b dalis
i = 1
for saknis in h_Saknys:
   tikslumuMas = []
   SkaiciusTE, daugianaris = SaknuPanasumas(saknis, tikslumuMas)
 

   # Atskiras grafikas kiekvienai šakniai
   plt.figure()
   plt.plot(range(1, SkaiciusTE + 1), tikslumuMas, marker='o', label='tikslumai')
   plt.xlabel('TE nariai')
   plt.ylabel('Tikslumo įvertis')
   plt.title('{0} - Saknis'.format(i))
   plt.grid(True)
   i += 1
plt.show()

