-- VHDL model created from schematic UniversalusPLIS.sch -- Apr 24 20:48:36 2022

library IEEE;
use IEEE.std_logic_1164.all;
library xp2;
use xp2.components.all;

entity UNIVERSALUSPLIS is
      Port (      A0 : In    std_logic;
                  A1 : In    std_logic;
                 Rst : In    std_logic;
                 Clk : In    std_logic;
                  DR : In    std_logic;
                  DL : In    std_logic;
                  Q6 : Out   std_logic;
                  Q5 : Out   std_logic;
                  Q4 : Out   std_logic;
                  Q3 : Out   std_logic;
                  Q0 : Out   std_logic;
                  Q1 : Out   std_logic;
                  Q2 : Out   std_logic );

end UNIVERSALUSPLIS;

architecture SCHEMATIC of UNIVERSALUSPLIS is

   SIGNAL gnd : std_logic := '0';
   SIGNAL vcc : std_logic := '1';

   signal      N_8 : std_logic;
   signal      N_9 : std_logic;
   signal     N_11 : std_logic;
   signal     N_12 : std_logic;
   signal     N_13 : std_logic;
   signal     N_14 : std_logic;
   signal     N_15 : std_logic;
   signal     N_16 : std_logic;
   signal     N_17 : std_logic;
   signal     N_18 : std_logic;
   signal     N_19 : std_logic;
   signal     N_20 : std_logic;
   signal     N_21 : std_logic;
   signal     N_22 : std_logic;
   signal      N_1 : std_logic;
   signal      N_2 : std_logic;
   signal      N_3 : std_logic;
   signal      N_4 : std_logic;
   signal      N_5 : std_logic;
   signal      N_6 : std_logic;
   signal      N_7 : std_logic;

   component inv
      Port (       A : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component vlo
      Port (       Z : Out   std_logic );
   end component;

   component vhi
      Port (       Z : Out   std_logic );
   end component;

   component mux41
      Port (      D0 : In    std_logic;
                  D1 : In    std_logic;
                  D2 : In    std_logic;
                  D3 : In    std_logic;
                 SD1 : In    std_logic;
                 SD2 : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component fd1s3dx
      Port (      CD : In    std_logic;
                  CK : In    std_logic;
                   D : In    std_logic;
                   Q : Out   std_logic );
   end component;

begin

   I21 : inv
      Port Map ( A=>N_15, Z=>Q6 );
   I15 : inv
      Port Map ( A=>N_8, Z=>Q0 );
   I16 : inv
      Port Map ( A=>N_9, Z=>Q1 );
   I17 : inv
      Port Map ( A=>N_11, Z=>Q2 );
   I18 : inv
      Port Map ( A=>N_12, Z=>Q3 );
   I19 : inv
      Port Map ( A=>N_13, Z=>Q4 );
   I20 : inv
      Port Map ( A=>N_14, Z=>Q5 );
   I22 : vlo
      Port Map ( Z=>N_22 );
   I23 : vlo
      Port Map ( Z=>N_21 );
   I24 : vlo
      Port Map ( Z=>N_19 );
   I25 : vhi
      Port Map ( Z=>N_16 );
   I26 : vhi
      Port Map ( Z=>N_17 );
   I27 : vhi
      Port Map ( Z=>N_20 );
   I28 : vhi
      Port Map ( Z=>N_18 );
   I1 : mux41
      Port Map ( D0=>N_12, D1=>N_11, D2=>N_13, D3=>N_21, SD1=>A0,
                 SD2=>A1, Z=>N_6 );
   I2 : mux41
      Port Map ( D0=>N_8, D1=>DL, D2=>N_9, D3=>N_16, SD1=>A0, SD2=>A1,
                 Z=>N_1 );
   I3 : mux41
      Port Map ( D0=>N_9, D1=>N_8, D2=>N_11, D3=>N_22, SD1=>A0, SD2=>A1,
                 Z=>N_2 );
   I4 : mux41
      Port Map ( D0=>N_11, D1=>N_9, D2=>N_12, D3=>N_17, SD1=>A0, SD2=>A1,
                 Z=>N_3 );
   I5 : mux41
      Port Map ( D0=>N_13, D1=>N_12, D2=>N_14, D3=>N_20, SD1=>A0,
                 SD2=>A1, Z=>N_4 );
   I6 : mux41
      Port Map ( D0=>N_14, D1=>N_13, D2=>N_15, D3=>N_19, SD1=>A0,
                 SD2=>A1, Z=>N_5 );
   I7 : mux41
      Port Map ( D0=>N_15, D1=>N_14, D2=>DR, D3=>N_18, SD1=>A0, SD2=>A1,
                 Z=>N_7 );
   I8 : fd1s3dx
      Port Map ( CD=>Rst, CK=>Clk, D=>N_6, Q=>N_12 );
   I9 : fd1s3dx
      Port Map ( CD=>Rst, CK=>Clk, D=>N_1, Q=>N_8 );
   I10 : fd1s3dx
      Port Map ( CD=>Rst, CK=>Clk, D=>N_2, Q=>N_9 );
   I11 : fd1s3dx
      Port Map ( CD=>Rst, CK=>Clk, D=>N_3, Q=>N_11 );
   I12 : fd1s3dx
      Port Map ( CD=>Rst, CK=>Clk, D=>N_4, Q=>N_13 );
   I13 : fd1s3dx
      Port Map ( CD=>Rst, CK=>Clk, D=>N_5, Q=>N_14 );
   I14 : fd1s3dx
      Port Map ( CD=>Rst, CK=>Clk, D=>N_7, Q=>N_15 );

end SCHEMATIC;
