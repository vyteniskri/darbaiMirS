x0 = 1;
hx = 1;
xn = 4;
for x = x0:hx:xn
    a = sin(x)^2;
    b = cos(x);
    if a < b
        y = log(a - b);
    elseif a > b
        y = log(a + b);
    else 
        y = a;
    end
    disp([x, y]);
end
 
