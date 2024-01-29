r = input('iveskite krastine: r= ');
[Str] = trik(r, r, sqrt(2*r^2));
[Sst] = stac(r, r);
[Ssk] = skritulio(r);
S = Ssk - Str - 0.75 * Sst;
disp('figuros plotas= ');
disp(S);