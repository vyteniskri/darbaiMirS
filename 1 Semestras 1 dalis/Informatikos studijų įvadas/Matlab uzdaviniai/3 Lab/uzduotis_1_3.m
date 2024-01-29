Y = [5 6 7 8 4];
j = 0;
a = 5;
for i = 1:length(Y)
    if Y(i) > a
        j = j + 1;
        C(j) = Y(i);
    end
   
end
disp(C);    