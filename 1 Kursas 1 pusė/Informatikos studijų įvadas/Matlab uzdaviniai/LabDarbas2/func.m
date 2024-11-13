function [M] = func(x, y)
if x > 0 && y > 0, M = 1; end 
if x < 0 && y > 0, M = 2; end
if x < 0 && y < 0, M = 3; end
if x > 0 && y < 0, M = 4; end