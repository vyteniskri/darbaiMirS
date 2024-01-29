A = load('duomenys_1.txt');
B = load('duomenys_2.txt');
failas=fopen('rezultatai_1.txt', 'w');
k = 1;
for i = 1:length(A)
    for j = 1:length(B)
        if A(i) == B(j)
            C(k) = A(i);
            k = k +1;
            break;
        end
    end
end
[vid] = vidurkis(C);

for i = 1:length(C)
    fprintf(failas,'%d', C(i));
    fprintf(failas,'\n');
end
fprintf(failas,'%d', vid); 
fclose(failas);