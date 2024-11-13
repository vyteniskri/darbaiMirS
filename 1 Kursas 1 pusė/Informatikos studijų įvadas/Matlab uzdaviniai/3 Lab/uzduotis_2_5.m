X = [-2 -10 5 0];
j = 1;
k = 0;
for i = 1:length(X)
    if X(i) < 0
        Y(j) = X(i);
        j = j + 1;
    end
end
[vid] = vidurkis(Y);

for i = 1:length(Y)
    if Y(i) > vid
        k = k + 1;
    end
end
Y(1) = k;
disp(Y);

