X = [-12 5 6 8 -5 0];
b = 2;
d = 5;
j = 1;

for i = b:d
    A(j) = X(i);
    j = j + 1;
end
maz = min(A);
for i = 1:length(A)
    if maz == A(i)
        k = i;
        break;
    end
end
disp(k);