function [c, d, z] = sav_funcdz(x, y)
c = sqrt(x^2+1);
d = sqrt(y^2+1);
if c > d, a = x; b = d; end
if c <= d, a = y; b = c; end
z = a + b - c - d;