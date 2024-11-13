S = load('duomenys.txt');
j = 1;
z = 1;
for i = 1:length(S)
    if S(i) > 0
        T(j) = S(i);
        j = j + 1;
    else
        M(z) = S(i);
        z = z + 1;
    end
end
disp(S)
disp(T);
disp(M);

for i = 1: length(S)
  
        S(i) = S(i)*(-1);

end
disp(S);

for i = 1:length(T)
    
    if rem(i,2) == 0
        T(i) = T(i) * 2;
        
    end
end
disp(T);
        
