X = [5 -2 -10 150 0];
sum = 0;
j = 0;
did = max(X);
for i = 1:length(X)
    if X(i) > 0
        sum = sum + X(i);
        j = j + 1;
    end
end
vid = sum / j;

for i = 1:length(X)
    if did == X(i)
        X(i) = vid;
    end
end
disp(X);