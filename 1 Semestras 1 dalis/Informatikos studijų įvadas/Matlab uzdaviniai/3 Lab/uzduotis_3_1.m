X = [-2 -10 5 18];
maz = min(X);
did = max(X);
sk = did - maz;
X(length(X)) = sk;
disp(X);
