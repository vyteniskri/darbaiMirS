D = [2];
E = [1];
l = 0;
virs = 0;
apat1 = 0;
apat2 = 1;
for n = 1:length(D)
    virs = virs + (D(n)-E(n))*D(n)*E(n);
    if D(n) >= 0
        apat1 = apat1 + D(n);
    end
    
    if E(n) ~=0
       apat2 = apat2 * E(n);
       l=l+1;
    end
    
end
if l == 0
    apat2 = 0;
end
U = virs/(apat1 + apat2);
disp(U);
  