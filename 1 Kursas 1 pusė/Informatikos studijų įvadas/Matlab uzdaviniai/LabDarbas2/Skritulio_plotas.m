x1 = input('A tasko x koordinate: ');
y1 = input('A tasko y koordinate: ');
x2 = input('B tasko x koordinate: ');
y2 = input('B tasko y koordinate: ');
AB = sqrt((x2 - x1)^2 + (y2 - y1)^2);
r = AB/2;
S = pi * r^2;
xc = (x2 + x1)/2;
yc = (y2 + y1)/2;
disp(['Skritulio plotas S=' num2str(S)]);
disp(['skritulio centro koordinates: xc = ' num2str(xc) ', yc= ' num2str(yc)]);

