a = 5;
b = 6;
c = 7;
x = [9 5 0 -2 3];
for n = 1:length(x)
    if sin(x(n)) < cos(x(n))
        y = a*x(n)^2+b*x(n)+c;
    else 
        y = a*x(n)+b+c;
    end
    disp(y);
end