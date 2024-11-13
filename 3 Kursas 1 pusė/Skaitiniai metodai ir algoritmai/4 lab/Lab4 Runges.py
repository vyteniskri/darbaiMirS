import numpy as np
import matplotlib.pyplot as plt
from scipy.integrate import solve_ivp

g = 9.8 #laisvo kritimo pagreitis

m1 = 0.4 #pirmojo mase
m2 = 0.8 #antrojo mase
v0 = 50 #pradinis greitis
ks = 0.001 #abeju kunu koeficinetas
ts = 2 #laikas iki kurio juda abu kunai

k1 = 0.02 #pirmo kuno koeficinetas
k2 = 0.02 #antro kuno koeficinetas
tmax = 10 #maksimalus laikas

def dvdt(t, v1, v2):
    if t <= ts:
        v1 = (-g*(m1 + m2) - np.sign(v1)*ks*v1**2)/(m1+m2)
        v2 = v1
        
    else:
        v1 = (-g*m1 - np.sign(v1)*k1*v1**2)/m1
        v2 = (-g*m2 - np.sign(v2)*k2*v2**2)/m2
        
    return v1, v2

def calculate(deltat):
    v1 = 0
    v2 = 0
    t1 = 0
    t2 = 0

    v = v0
    t = 0
    times = []
    speeds1 = []
    speeds2 = []
    while (t <= tmax):
        if t <= ts:
            v += deltat * dvdt(t, v, 0)[0]
            func1 = v + (deltat / 2) * dvdt(t, v, 0)[0]
            func2 = v + (deltat / 2) * dvdt(t + (deltat / 2), func1, 0)[0]
            func3 = v + deltat * dvdt(t + (deltat / 2), func2, 0)[0]
            finalFunc = v + (deltat / 6) * (dvdt(t, v, 0)[0] + (2 * dvdt(t + (deltat / 2), func1, 0)[0]) + (2 * dvdt(t + (deltat / 2), func2, 0)[0]) + dvdt(t + deltat, func3, 0)[0])
            finalFunc1 = finalFunc
            finalFunc2 = finalFunc
            v1 = v
            v2 = v
        else:
            v1 += deltat * dvdt(t, v1, 0)[0]
            v2 += deltat * dvdt(t, 0, v2)[1]
            func11 = v1 + (deltat / 2) * dvdt(t, v1, 0)[0]
            func12 = v2 + (deltat / 2) * dvdt(t, 0, v2)[1]
            func21 = v1 + (deltat / 2) * dvdt(t + (deltat / 2), func11, 0)[0]
            func22 = v2 + (deltat / 2) * dvdt(t + (deltat / 2), 0, func12)[1]
            func31 = v1 + deltat * dvdt(t + (deltat / 2), func21, 0)[0]
            func32 = v2 + deltat * dvdt(t + (deltat / 2), 0, func22)[1]
            finalFunc1 = v1 + (deltat / 6) * (dvdt(t, v1, 0)[0] + (2 * dvdt(t + (deltat / 2), func11, 0)[0]) + (2 * dvdt(t + (deltat / 2), func21, 0)[0]) + dvdt(t + deltat, func31, 0)[0])
            finalFunc2 = v2 + (deltat / 6) * (dvdt(t, 0, v2)[1] + (2 * dvdt(t + (deltat / 2), 0, func12)[1]) + (2 * dvdt(t + (deltat / 2), 0, func22)[1]) + dvdt(t + deltat, 0, func32)[1])
           
            if finalFunc1 <= 0 and t1 == 0:
                t1 = t
                print(f"Pirmas objektas pasieks auksciausia taska po: {t1} sec.")
            if finalFunc2 <= 0 and t2 == 0:
                t2 = t
                print(f"Antras objektas pasieks auksciausia taska po: {t2} sec.")
        speeds1.append(finalFunc1)
        speeds2.append(finalFunc2)
        times.append(t)
        t += deltat

   # Plot the results
   # plt.plot(times, speeds1, label="Objektas 1")
   # plt.plot(times, speeds2, label="Objektas 2")
   # plt.xlabel("Laikas (s)")
   # plt.ylabel("Greitis (m/s)")
   # plt.legend()
   # plt.show() 
    return times, speeds1, speeds2

def zingsnioKeitimas(prad, galas, step):
    zingsniai = []
    pirmoObjgr = []
    antroObjgr = []
    
    for deltat in np.arange(prad, galas, step):
        times, v1, v2 = calculate(deltat)
        zingsniai.append(times)
        pirmoObjgr.append(v1)
        antroObjgr.append(v2)
        
    for i in range(len(zingsniai)):
        plt.plot(zingsniai[i], pirmoObjgr[i], label=f"Pirmas objektas - Δt, iteracija {i}, zingsnis {prad + i * step}")
        plt.plot(zingsniai[i], antroObjgr[i], label=f"Antras objektas - Δt, iteracija {i}, zingsnis {prad + i * step} ")
        

    plt.xlabel("Laikas")
    plt.ylabel("Greitis")
    plt.legend()
    plt.show()


def system(t, y):
    v1, v2 = y
    if t <= ts:
        dv1dt = (-g * (m1 + m2) - np.sign(v1) * ks * v1 ** 2) / (m1 + m2)
        dv2dt = (-g * (m1 + m2) - np.sign(v2) * ks * v2 ** 2) / (m1 + m2)
    else:
        dv1dt = (-g * m1 - np.sign(v1) * k1 * v1 ** 2) / m1
        dv2dt = (-g * m2 - np.sign(v2) * k2 * v2 ** 2) / m2
    return [dv1dt, dv2dt]

def calculate_with_solve_ivp(dz):
    y0 = [v0, v0]  # pradiniai greičiai
    t_span = (0, tmax)
    t_eval = np.arange(0, tmax, dz)  # Šis sąrašas yra jūsų norimas žingsnių dydis

    sol = solve_ivp(system, t_span, y0, t_eval=t_eval, method='RK45')

    return sol.t, sol.y[0], sol.y[1]

def compare_methods(deltat):
    times_euler, speeds1_euler, speeds2_euler = calculate(deltat)
    times_solve_ivp, speeds1_solve_ivp, speeds2_solve_ivp = calculate_with_solve_ivp(deltat)

    plt.plot(times_euler, speeds1_euler, label="Mano objektas 1")
    plt.plot(times_euler, speeds2_euler, label="Mano objektas 2")
    plt.plot(times_solve_ivp, speeds1_solve_ivp, label="solve_ivp objektas 1")
    plt.plot(times_solve_ivp, speeds2_solve_ivp, label="solve_ivp objektas 2")

    plt.xlabel("Laikas (s)")
    plt.ylabel("Greitis (m/s)")
    plt.legend()
    plt.show()

#zingsnioKeitimas(0.05, 0.1, 0.01) #3 salyga
zingsnioKeitimas(1, 2, 0.1) #4 salyga
#calculate(0.01)
#compare_methods(0.01)
