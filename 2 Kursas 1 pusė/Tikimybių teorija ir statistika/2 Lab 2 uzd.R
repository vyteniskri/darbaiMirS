x = duomenys$variantas_72_x
y = duomenys$variantas_72_y

#2.1
# k = 1.622, b = 7.085, lygtis y = 1.622 * x + 7.085 
plot(x,y)
lm(y~x)
k = 1.622 
b = 7.085 
lines(x, k*x +b)

#2.2
#Tikrinsiu reikšmę 10
#Gautas atsakymas iš tiesės lygties: 23.305 yra labai panašus į spėjamą atsakymą: 23.30998 
yReg =  k * 10 + b
yReg
predict(lm(y~x), data.frame(x=10))

#2.3
#Nurodyta p-value reikšmė yra daug mažesnė už duotą reikšmingumo lygmenį 0.05
#Nulinę hipotezę, kad tiesinės lygties krypties koeficientas lygus nuliui atmentame, todėl galime pereiti prie alternatyviosios hipotezės
summary(lm(y~x))

#2.4
#Tiesinė regresijos determinacijos koeficinetas lygus 0.9798
#Šis koeficientas yra labai arti 1, todėl tiesinės regresijos modelis yra tinkamas šiems duomenims
summary(lm(y~x))

#2.5
#Iš histogramos galima matyti, kad liekanų skirstinys primena normalųjį skirstinį
#Iš grafiko galima matyti, kad skirstinys yra homoskedatiškas.
e = y - k*x - b
plot(e)
hist(e)

#2.6
#P-value = 0.4009 reikšmė yra didesnė už 𝛼 = 0.01, todėl neatmetame statistinės hipotezės, jog regresijos liekanų skirstinys yra normalusis.
library(MASS)
fitdistr(e, 'normal')
ks.test(e, 'pnorm', 0, 0.0299946010 )