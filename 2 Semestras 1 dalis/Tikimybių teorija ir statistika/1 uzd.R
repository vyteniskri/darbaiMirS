attach(duomenys1) 
x = duomenys1$Variantas_72

#1.1
#Imties dydis
n = length(x)
n

#Minimumas
Min_x = min(x)
Min_x

#Maksimumas
Max_x = max(x)
Max_x

#Imties plotis
delta = Max_x - Min_x
delta

#Kvartiliai  
quantile(x, type = 2)
quantile(x,0.25, type=2)
quantile(x,0.50, type=2)
quantile(x,0.75, type=2)
quantile(x,1, type=2)

#Kvartilių skirtumas
IQR(x, type = 2)

#Empirinis vidurkis
mean(x)

#Dispersija (nepaslinktoji)
var(x)

#Standartinis nuokrypis
sd(x)

#1.2
#Tai tolygusis skirstinys
library(UsingR)
hist(x)
boxplot(x, horizontal = TRUE) 

#1.3
#Taškiniai įverčiai jau rasti minimumas - Min_x, o maksimumas - Max_x
Min_x 
Max_x

#1.4
#Suderinamumo hipotezė α = 0.01, todėl p-value > α, hipotezės, kad duomenys pasiskirstę tolygiai nereikėtų atmesti.
ks.test(x, 'punif',Min_x, Max_x)