-- VHDL model created from schematic SpecializuotiasRe.sch -- May 03 00:58:49 2022

library IEEE;
use IEEE.std_logic_1164.all;
library xp2;
use xp2.components.all;

entity SPECIALIZUOTIASRE is
      Port (     Clk : In    std_logic;
                  A0 : In    std_logic;
                  A1 : In    std_logic;
                  Q0 : Out   std_logic;
                  Q1 : Out   std_logic;
                  Q2 : Out   std_logic;
                  Q3 : Out   std_logic;
                  Q4 : Out   std_logic;
                  Q5 : Out   std_logic;
                  Q6 : Out   std_logic;
                  D0 : In    std_logic;
                  D1 : In    std_logic;
                  D2 : In    std_logic;
                  D3 : In    std_logic;
                  D4 : In    std_logic;
                  D5 : In    std_logic;
                  D6 : In    std_logic;
                 Rst : In    std_logic );

end SPECIALIZUOTIASRE;

architecture SCHEMATIC of SPECIALIZUOTIASRE is

   SIGNAL gnd : std_logic := '0';
   SIGNAL vcc : std_logic := '1';

   signal     N_10 : std_logic;
   signal Q6_DUMMY : std_logic;
   signal Q5_DUMMY : std_logic;
   signal Q4_DUMMY : std_logic;
   signal Q3_DUMMY : std_logic;
   signal Q2_DUMMY : std_logic;
   signal Q1_DUMMY : std_logic;
   signal Q0_DUMMY : std_logic;
   signal      N_2 : std_logic;
   signal      N_3 : std_logic;
   signal      N_4 : std_logic;
   signal      N_5 : std_logic;
   signal      N_6 : std_logic;
   signal      N_7 : std_logic;
   signal      N_8 : std_logic;

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

   Q0 <= Q0_DUMMY;
   Q1 <= Q1_DUMMY;
   Q2 <= Q2_DUMMY;
   Q3 <= Q3_DUMMY;
   Q4 <= Q4_DUMMY;
   Q5 <= Q5_DUMMY;
   Q6 <= Q6_DUMMY;

   I27 : vhi
      Port Map ( Z=>N_10 );
   I15 : mux41
      Port Map ( D0=>D0, D1=>N_10, D2=>Q5_DUMMY, D3=>Q6_DUMMY, SD1=>A0,
                 SD2=>A1, Z=>N_4 );
   I16 : mux41
      Port Map ( D0=>D1, D1=>Q0_DUMMY, D2=>Q6_DUMMY, D3=>Q6_DUMMY,
                 SD1=>A0, SD2=>A1, Z=>N_5 );
   I17 : mux41
      Port Map ( D0=>D2, D1=>Q1_DUMMY, D2=>Q0_DUMMY, D3=>Q0_DUMMY,
                 SD1=>A0, SD2=>A1, Z=>N_8 );
   I18 : mux41
      Port Map ( D0=>D3, D1=>Q2_DUMMY, D2=>Q1_DUMMY, D3=>Q1_DUMMY,
                 SD1=>A0, SD2=>A1, Z=>N_2 );
   I19 : mux41
      Port Map ( D0=>D4, D1=>Q3_DUMMY, D2=>Q2_DUMMY, D3=>Q2_DUMMY,
                 SD1=>A0, SD2=>A1, Z=>N_3 );
   I20 : mux41
      Port Map ( D0=>D5, D1=>Q4_DUMMY, D2=>Q3_DUMMY, D3=>Q3_DUMMY,
                 SD1=>A0, SD2=>A1, Z=>N_6 );
   I7 : mux41
      Port Map ( D0=>D6, D1=>Q5_DUMMY, D2=>Q4_DUMMY, D3=>Q6_DUMMY,
                 SD1=>A0, SD2=>A1, Z=>N_7 );
   I21 : fd1s3dx
      Port Map ( CD=>Rst, CK=>Clk, D=>N_4, Q=>Q0_DUMMY );
   I22 : fd1s3dx
      Port Map ( CD=>Rst, CK=>Clk, D=>N_5, Q=>Q1_DUMMY );
   I23 : fd1s3dx
      Port Map ( CD=>Rst, CK=>Clk, D=>N_8, Q=>Q2_DUMMY );
   I24 : fd1s3dx
      Port Map ( CD=>Rst, CK=>Clk, D=>N_2, Q=>Q3_DUMMY );
   I25 : fd1s3dx
      Port Map ( CD=>Rst, CK=>Clk, D=>N_3, Q=>Q4_DUMMY );
   I26 : fd1s3dx
      Port Map ( CD=>Rst, CK=>Clk, D=>N_6, Q=>Q5_DUMMY );
   I14 : fd1s3dx
      Port Map ( CD=>Rst, CK=>Clk, D=>N_7, Q=>Q6_DUMMY );

end SCHEMATIC;
