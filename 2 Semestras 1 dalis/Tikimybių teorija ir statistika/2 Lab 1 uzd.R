attach(duomenys)
x = duomenys$variantas_72_x
y = duomenys$variantas_72_y

#1.1
#Kintamieji x ir y yra stipriai priklausomi, jų taškai sudaro vis augančią tiesę
plot(x,y)

#1.2
#Labai stipri teigiama tiesinė koreliacija
cor(x,y, method = 'pearson')

#1.3
#p-value reikšmė yra daug mažesnė už standartinį reikšmingumo lygmenį 0.05
#Nulinę hipotezę, kad Pirsono koreliacijos koficiantas lygus nuliui reikėtų atmesti ir pereiti prie alternatyviosios hipotezės
cor.test(x, y)

#1.4
#Priklausomybė tarp rangų yra ganėtinai didelė, tačiau taškai rangų grafe yra labiau išsisklaidę nei kintamųjų grafe
plot(rank(x), rank(y))

#1.5
#Labai stipri teigiama tiesinė koreliacija
cor(x, y, method = 'spearman')

#1.6
#p-value reikšmė yra daug mažesnė už standartinį reikšmingumo lygmenį 0.05
#Nulinę hipotezę, kad Spirmeno koreliacijos koficiantas lygus nuliui reikėtų atmesti ir pereiti prie alternatyviosios hipotezės
cor.test(x, y, method = 'spearman')

