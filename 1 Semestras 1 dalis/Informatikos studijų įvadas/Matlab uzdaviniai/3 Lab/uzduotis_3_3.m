for i = 1:5
    UGIAI(i) = input('Ugis: ');
end

did = max(UGIAI);
k = 0;
for i = 1:length(UGIAI)
    if did == UGIAI(i)
        k = k + 1;
    end
end
disp(k);
