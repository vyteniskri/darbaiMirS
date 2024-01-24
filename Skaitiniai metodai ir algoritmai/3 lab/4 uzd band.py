import numpy as np
import matplotlib.pyplot as plt
from scipy.interpolate import interp1d
import shapefile
from shapely import geometry


def coordinates():
  shape = shapefile.Reader("ne_10m_admin_0_countries.shp")

  #id = 157
  feature = shape.shapeRecords()[157]

  largestAreaID = 0
  if feature.shape.__geo_interface__['type'] == 'MultiPolygon': 
    area = 0
    for i in range(len(feature.shape.__geo_interface__['coordinates'])):
      points = feature.shape.__geo_interface__['coordinates'][i][0]
      polygon = geometry.Polygon(points)
      if polygon.area > area:
        area = polygon.area
        largestAreaID = i

    xxyy = feature.shape.__geo_interface__['coordinates'][largestAreaID][0]
  else:
    xxyy = feature.shape.__geo_interface__['coordinates'][0]

  
  xy = list(zip(*xxyy))
  X = xy[0]
  Y = xy[1]
  return X, Y

def haar_scaling(x, j, k, a, b): #Funkcijai
    eps = 1e-9
    xtld = (x - a) / (b - a)
    xx = 2**j * xtld - k
    h = 2**(j/2) * (np.sign(xx + eps) - np.sign(xx - 1 - eps)) / (2 * (b - a))
    return h

def haar_wavelet(x, j, k, a, b): #Bangelei
    eps = 1e-9
    xtld = (x - a) / (b - a)
    xx = 2**j * xtld - k
    h = 2**(j/2) * (np.sign(xx + eps) - 2 * np.sign(xx - 0.5) + np.sign(xx - 1 - eps)) / (2 * (b - a))
    return h

def haar_wavelet_approximation(SX, SY, n, m): #Aproksimavimas smulkiausiame mastelyje
    a, b = min(SX), max(SX)
    nnn = 2**n
    smooth = (b - a) * SY * 2**(-n/2)

    details = []
    for i in range(1, m + 1):
        smooth1 = (smooth[0::2] + smooth[1::2]) / np.sqrt(2)
        detail = (smooth[0::2] - smooth[1::2]) / np.sqrt(2)
        details.append(detail)
        smooth = smooth1

    return smooth, details

def main():
    plt.figure(1)
    plt.axis('equal')
    plt.grid(True)

    # Reading data from files
    n = 10
    nnn = 2**n
    SX, SY = coordinates()

    # Parameterization
    t = np.cumsum(np.linalg.norm(np.diff(np.column_stack((SX, SY)), axis=0), axis=1))
    t = np.concatenate(([0], t))
    t1 = np.linspace(min(t), max(t), nnn)
    SX = interp1d(t, SX, kind='linear', fill_value='extrapolate')(t1)
    SY = interp1d(t, SY, kind='linear', fill_value='extrapolate')(t1)
    t = t1

    plt.plot(SX, SY, 'c')
    plt.plot(SX, SY, 'k.')
    plt.title(f'Duota funkcija, tasku skaicius 2^{n}')

    xmin, xmax = min(SX), max(SX)
    ymin, ymax = min(SY), max(SY)

    m = 6
    smoothx, detailsx = haar_wavelet_approximation(t, SX, n, m)
    smoothy, detailsy = haar_wavelet_approximation(t, SY, n, m)

    smoothx, smoothy

    # Function reconstruction
    hx = np.zeros(nnn)
    hy = np.zeros(nnn)

    for k in range(2**(n-m)):
        hx += smoothx[k] * haar_scaling(t, n-m, k, min(t), max(t))
        hy += smoothy[k] * haar_scaling(t, n-m, k, min(t), max(t))

    leg = [f'Suglodinta funkcija, detalumo lygmuo {n-m}']
    plt.figure(2)
    plt.subplot(m+1, 1, 1)
    plt.axis('equal')
    plt.axis([xmin, xmax, ymin, ymax])
    plt.grid(True)
    plt.plot(hx, hy, '.', linewidth=2)
    plt.title(f'Lygyje 0 suglodinta funkcija')

    for i in range(m):
        h1x = np.zeros(nnn)
        h1y = np.zeros(nnn)

        for k in range(2**(n-m+i)):
            h1x += detailsx[m-i-1][k] * haar_wavelet(t, n-m+i, k, min(t), max(t))
            h1y += detailsy[m-i-1][k] * haar_wavelet(t, n-m+i, k, min(t), max(t))

        hx += h1x
        hy += h1y

        plt.figure(2)
        plt.subplot(m+1, 1, i+2)
        plt.axis('equal')
        plt.axis([xmin, xmax, ymin, ymax])
        plt.grid(True)
        plt.plot(hx, hy, linewidth=2)
        plt.title(f'Lygyje {i+1} suglodinta funkcija')

    plt.show()


main()