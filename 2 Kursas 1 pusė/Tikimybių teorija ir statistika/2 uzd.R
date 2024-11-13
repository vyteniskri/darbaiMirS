attach(duomenys2)
x = duomenys2$Variantas_72

#2.1Histograma, stačiakampė diagrama ir kvantilinis grafikas
hist(x) 
boxplot(x,horizontal=TRUE)
qqnorm(x)
qqline(x)

#2.2
#Vidurkis
mean(x) 
#Paslinktosios dispersijos skaičiavimas
n = length(x)
n
sigma2 = ((n-1)/n)*var(x)
sigma2

#2.3
#γ = 0.99, α =  1 - γ, α = 0.01
library(OneTwoSamples)
# Vidurkio pasikliautinieji intervalai μ(a ir b)
interval_estimate1(x, alpha = 0.01)
#Dispersijos pasikliautinieji intervalai μ(a ir b)
interval_var1(x,alpha=0.01)

#2.4 μ0= 8, α = 0.1, kadangi gaunama α < p_value hipotezės - vidurkio ligybės skaičiui neatmetame
mean_test1(x,mu=8,side=1)