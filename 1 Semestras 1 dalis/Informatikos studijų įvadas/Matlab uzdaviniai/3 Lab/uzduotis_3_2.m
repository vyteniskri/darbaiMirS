M = [-10 3 -500 5 15];
maz = min(M);
did = max(M);
for i = 1:length(M)
    if maz == M(i)
        M(i) = -1000;
    end
    if did == M(i)
        M(i) = 1000;
    end
end
disp(M);