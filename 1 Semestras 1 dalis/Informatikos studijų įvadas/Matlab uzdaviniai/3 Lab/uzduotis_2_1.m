z = 1;
for x = 10:2:10
    y = cosd(x^2-1);
    if y > 0
        z = z * y;
    end

end
if z ~= 1
disp(z)
end