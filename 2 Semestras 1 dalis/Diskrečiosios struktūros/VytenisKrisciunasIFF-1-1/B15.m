clc; close all; clear all 

%Galima atkomentuoti viršūnių ir briaunų aibes arba sukurti naujus U ir V
V=[1 2 3 4 5 6 7 8];% grafo virsuniu aibe
U={[1 2],[1 5],[1 6],[2 3],[3 4],[3 5],[4 5],[4 7],[5 6],[5 8]};

%V=[1 2 3 4 5 6];
%U={[1 2],[1 6],[2 3],[2 4],[3 4],[3 5],[3 6],[4 5]};

%V=[1 2 3 4];
%U={[1 2],[1 4],[2 3],[3 4]};

%V=[1 2 3 4 5];
%U={[1 2],[1 4],[2 3],[2 5],[3 4],[4 5]};

Vkor=[-1 0; -0.33 1; 0.33 1; 0.33 0; -0.33 0; -0.33 -1; 1 0; 0.33 -1];

arc=0; poz=0; orgraf=0; Fontsize=10; storis=2; spalva='b';
figure(1)
title('Duotasis grafas')
plotGraphVU1(V,U,orgraf,arc,Vkor,poz,Fontsize,storis,spalva)
GAM = UtoGAM(V,U,orgraf);
count = length(V);
atsMas = {};
arrayOfMatrix = {};
index = 1;
for o = 1:10
    for v = 1:count
        for i = 1:length(GAM)
            for j = 1:length(GAM{i})
                
                n = GAM{i}(1);
                GAM{i}(1) = GAM{i}(j);
                GAM{i}(j) = n;
                [struktura, matrix] = PaieskaIGyli(GAM, v, count);
                is = false;
        
                for z = 1:length(arrayOfMatrix)
                    if isequal(arrayOfMatrix{z}, matrix)
                        is = true;
                        break;
                    end
                end
                if is == false
                    arrayOfMatrix{index} = matrix;
                    atsMas{index} = struktura;
                    index = index + 1;
                end      
            end          
        end
    end
end

%Spausdinimas į Command window
fprintf('Dalinių grafų, kurie yra medžiai skaičius: %d\n\n', length(atsMas));
disp('Medžių briaunų aibės:');
for i = 1:length(atsMas)
    for j = 1:length(atsMas{i})
        a = atsMas{i};
         fprintf('[%d %d]', a{j}(1), a{j}(2));
    end
    fprintf('\n');
end

%Pasirinkto medžio grafo spausdinimas (šiuo atvėju - tai 2 medis)
figure(2)
title('Gautasis medžio grafas')
plotGraphVU1(V,atsMas{2},orgraf,arc,Vkor,poz,Fontsize,storis,spalva)

function [struktura, perMatr] = PaieskaIGyli(GAM, v, count)
pastIndexes = zeros(count);

atsMas = zeros(count,count);
placeOfPastIndex = 0;
goBackPerOne = 1;
counter = 0;

while(counter < count - 1)
    Ind = v;
    IsItIn = false;
    for i = 1:length(pastIndexes)
        if pastIndexes(i) == Ind
            IsItIn = true;
            break;
        end
    end
    
    if IsItIn == false
        placeOfPastIndex = placeOfPastIndex + 1;
        pastIndexes(placeOfPastIndex) = Ind;       
    end
    for j = 1:length(GAM{Ind})
        Is = false;
        current = GAM{Ind}(j);
            for z = 1:length(pastIndexes)
                if  pastIndexes(z) == current
                    Is = true;
                    break;
                end
            end
            if Is == false           
                atsMas(Ind, current) = 1;
                v = current;
                goBackPerOne = 1;
                counter = counter + 1;
                break;
            end
    end
    if v == Ind
        v = pastIndexes(placeOfPastIndex - goBackPerOne);
        goBackPerOne = goBackPerOne + 1;
    end
end

perMatr = zeros(count,count);
for i = 1:length(atsMas)
    for j = 1:length(atsMas(i,:))
        if atsMas(i, j) == 1
            atsMas(i, j) = 0;
            perMatr(i, j) = 1;
        end
    end
    atsMas = atsMas.';
    for j = 1:length(atsMas(i,:))
        if atsMas(i, j) == 1
            atsMas(i, j) = 0;
            perMatr(i, j) = 1;
        end
    end
    atsMas = atsMas.';
end

x1 = 1;
for i = 1:length(perMatr)
    for j = 1:length(perMatr(i,:))
            if perMatr(i, j) ~= 0 
                struktura{x1}(1) = i;
                struktura{x1}(2) = j;
                x1 = x1 + 1;
            end
        
    end
end
end