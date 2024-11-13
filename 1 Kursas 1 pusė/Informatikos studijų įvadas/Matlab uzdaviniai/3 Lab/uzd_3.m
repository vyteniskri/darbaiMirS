Y = [-2 -6 0 6 -10 -4];
b = 1;
d = 3;
j = 1;
sand = 1;
k = 0;
sum = 0;
for i = 1:length(Y)
    if i < b || i > d
        X(j) = Y(i);
        j = j + 1;
    end
end

for i = 1:length(X)
    if X(i) ~= 0
        sand = sand * X(i);
    end
    if X(i) < 0
        sum = sum + X(i);
        k = k + 1;
    end
end

vid = sum / k;

disp(X);
disp(sand);
disp(vid);
        