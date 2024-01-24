import matplotlib.pyplot as plt
import shapefile
from shapely import geometry

shape = shapefile.Reader("c:/Users/Labas/Desktop/3 semestras 1 puse/Skaitiniai metodai ir algoritmai/3 lab/New folder/ne_10m_admin_0_countries.shp")

id = -1
for i in range(len(shape)):
  feature = shape.shapeRecords()[i]
  if feature.record.NAME_EN == "Panama":
    id = i
    break 

if id == -1:
  print("Tokios šalies nėra")
else:
  print("id: " + str(id) )

#id = 157
feature = shape.shapeRecords()[157]
print(feature.record.NAME_EN)
largestAreaID = 0
if feature.shape.__geo_interface__['type'] == 'MultiPolygon': 
  print(len(feature.shape.__geo_interface__['coordinates']))
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
print(Y)
X = xy[0]
Y = xy[1]
plt.plot(X,Y, 'bo-')

#print(shape)
#plt.show()
