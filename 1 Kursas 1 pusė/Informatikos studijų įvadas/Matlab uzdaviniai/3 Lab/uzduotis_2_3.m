D = [5 -2 -3];
E = [9 0 -3];
[Ats1] = neig_kiek(D);
[Ats2] = neig_kiek(E);
disp(Ats1);
disp(Ats2);

if Ats1 > Ats2
    disp('Masyve D');

else 
    disp('Masyve E');
end