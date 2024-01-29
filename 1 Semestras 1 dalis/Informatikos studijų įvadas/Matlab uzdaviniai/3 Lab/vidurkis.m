function [vid] = vidurkis(masyvas)
sum = 0;
k = 0;
for i = 1:length(masyvas)
    sum = sum + masyvas(i);
    k = k + 1;
end
vid = sum / k;