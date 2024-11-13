function [d] =  neig_kiek(masyvas)
l = 0;
for i = 1:1:length(masyvas)
    if masyvas(i) < 0
        l = l + 1;
    end
end
d = l;