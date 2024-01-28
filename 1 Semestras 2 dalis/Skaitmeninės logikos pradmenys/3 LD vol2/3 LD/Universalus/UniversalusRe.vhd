-- VHDL model created from schematic UniversalusRe.sch -- Apr 24 20:48:36 2022

library IEEE;
use IEEE.std_logic_1164.all;
library xp2;
use xp2.components.all;

entity UNIVERSALUSRE is
      Port (      Q0 : Out   std_logic;
                  Q1 : Out   std_logic;
                  Q2 : Out   std_logic;
                  Q3 : Out   std_logic;
                  Q4 : Out   std_logic;
                  Q5 : Out   std_logic;
                  Q6 : Out   std_logic;
                 Rst : In    std_logic;
                 Clk : In    std_logic;
                  A0 : In    std_logic;
                  A1 : In    std_logic;
                  D0 : In    std_logic;
                  D1 : In    std_logic;
                  D2 : In    std_logic;
                  D3 : In    std_logic;
                  D4 : In    std_logic;
                  D5 : In    std_logic;
                  D6 : In    std_logic;
                  DL : In    std_logic;
                  DR : In    std_logic );

end UNIVERSALUSRE;

architecture SCHEMATIC of UNIVERSALUSRE is

   SIGNAL gnd : std_logic := '0';
   SIGNAL vcc : std_logic := '1';

   signal Q6_DUMMY : std_logic;
   signal Q5_DUMMY : std_logic;
   signal Q4_DUMMY : std_logic;
   signal Q3_DUMMY : std_logic;
   signal Q2_DUMMY : std_logic;
   signal Q1_DUMMY : std_logic;
   signal Q0_DUMMY : std_logic;
   signal      N_1 : std_logic;
   signal      N_2 : std_logic;
   signal      N_3 : std_logic;
   signal      N_4 : std_logic;
   signal      N_5 : std_logic;
   signal      N_6 : std_logic;
   signal      N_7 : std_logic;

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

   I1 : mux41
      Port Map ( D0=>Q3_DUMMY, D1=>Q2_DUMMY, D2=>Q4_DUMMY, D3=>D3,
                 SD1=>A0, SD2=>A1, Z=>N_1 );
   I2 : mux41
      Port Map ( D0=>Q0_DUMMY, D1=>DL, D2=>Q1_DUMMY, D3=>D0, SD1=>A0,
                 SD2=>A1, Z=>N_2 );
   I3 : mux41
      Port Map ( D0=>Q1_DUMMY, D1=>Q0_DUMMY, D2=>Q2_DUMMY, D3=>D1,
                 SD1=>A0, SD2=>A1, Z=>N_3 );
   I4 : mux41
      Port Map ( D0=>Q2_DUMMY, D1=>Q1_DUMMY, D2=>Q3_DUMMY, D3=>D2,
                 SD1=>A0, SD2=>A1, Z=>N_4 );
   I5 : mux41
      Port Map ( D0=>Q4_DUMMY, D1=>Q3_DUMMY, D2=>Q5_DUMMY, D3=>D4,
                 SD1=>A0, SD2=>A1, Z=>N_5 );
   I6 : mux41
      Port Map ( D0=>Q5_DUMMY, D1=>Q4_DUMMY, D2=>Q6_DUMMY, D3=>D5,
                 SD1=>A0, SD2=>A1, Z=>N_6 );
   I7 : mux41
      Port Map ( D0=>Q6_DUMMY, D1=>Q5_DUMMY, D2=>DR, D3=>D6, SD1=>A0,
                 SD2=>A1, Z=>N_7 );
   I8 : fd1s3dx
      Port Map ( CD=>Rst, CK=>Clk, D=>N_1, Q=>Q3_DUMMY );
   I9 : fd1s3dx
      Port Map ( CD=>Rst, CK=>Clk, D=>N_2, Q=>Q0_DUMMY );
   I10 : fd1s3dx
      Port Map ( CD=>Rst, CK=>Clk, D=>N_3, Q=>Q1_DUMMY );
   I11 : fd1s3dx
      Port Map ( CD=>Rst, CK=>Clk, D=>N_4, Q=>Q2_DUMMY );
   I12 : fd1s3dx
      Port Map ( CD=>Rst, CK=>Clk, D=>N_5, Q=>Q4_DUMMY );
   I13 : fd1s3dx
      Port Map ( CD=>Rst, CK=>Clk, D=>N_6, Q=>Q5_DUMMY );
   I14 : fd1s3dx
      Port Map ( CD=>Rst, CK=>Clk, D=>N_7, Q=>Q6_DUMMY );

end SCHEMATIC;
