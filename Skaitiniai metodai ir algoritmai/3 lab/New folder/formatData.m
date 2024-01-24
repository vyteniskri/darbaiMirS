clear all; close all; clc;

% Nusiskaitome duomenis
S = shaperead('ne_10m_admin_0_countries.shp')

id = -1; % konkre�ios �alies ID
for i = 1:size(S,1)
    if strcmp(S(i).NAME_EN,'Lithuania')
        id = i;
        break; 
    end
end
if (id == -1)
    'tokios �alies n�ra, pasitikrinkite pavadinim�'
end
% nupie�iame �alies kont�r� pagal duotus ta�kus
figure(1); grid on; hold on;
title(S(id).NAME_EN);
plot(S(id).X, S(id).Y);

% S(id).X, S(id).Y - ta�kai, kuriuos galima naudoti �alies kont�ro
% vaizdavimui (pvz. i�sivesti juos � txt ar csv fail�)

csvwrite('X.txt',S(id).X)
csvwrite('Y.txt',S(id).Y)