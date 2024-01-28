-- VHDL model created from schematic AntrLD.sch -- Mar 28 18:18:00 2022

library IEEE;
use IEEE.std_logic_1164.all;
library xp2;
use xp2.components.all;

entity ANTRLD is
      Port (    Q_JK : Out   std_logic;
               nQ_JK : Out   std_logic;
                  x1 : In    std_logic;
                  x2 : In    std_logic;
                  x3 : In    std_logic;
                  x4 : In    std_logic;
                 res : In    std_logic;
              ENABLE : In    std_logic;
             Q_JK_Slave : Out   std_logic;
             nQ_JK_Slave : Out   std_logic;
                Qdin : Out   std_logic );

end ANTRLD;

architecture SCHEMATIC of ANTRLD is

   SIGNAL gnd : std_logic := '0';
   SIGNAL vcc : std_logic := '1';

   signal     N_26 : std_logic;
   signal     N_27 : std_logic;
   signal Qdin_DUMMY : std_logic;
   signal     N_15 : std_logic;
   signal     N_16 : std_logic;
   signal     N_18 : std_logic;
   signal     N_19 : std_logic;
   signal     N_20 : std_logic;
   signal     N_21 : std_logic;
   signal     N_22 : std_logic;
   signal     N_23 : std_logic;
   signal     N_24 : std_logic;
   signal     N_25 : std_logic;
   signal nQ_JK_Master : std_logic;
   signal nQ_JK_Slave_DUMMY : std_logic;
   signal Q_JK_Slave_DUMMY : std_logic;
   signal Q_JK_Master : std_logic;
   signal      N_9 : std_logic;
   signal     N_10 : std_logic;
   signal     N_11 : std_logic;
   signal     N_12 : std_logic;
   signal        K : std_logic;
   signal        J : std_logic;
   signal     N_13 : std_logic;
   signal     N_14 : std_logic;
   signal nQ_JK_DUMMY : std_logic;
   signal        C : std_logic;
   signal Q_JK_DUMMY : std_logic;
   signal      N_1 : std_logic;
   signal      N_3 : std_logic;
   signal      N_4 : std_logic;
   signal      N_5 : std_logic;
   signal      N_6 : std_logic;
   signal      N_7 : std_logic;
   signal      N_8 : std_logic;

   component xnor2
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component nd4
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   C : In    std_logic;
                   D : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component xor2
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component or2
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component and2
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component nd3
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   C : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component nd2
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component inv
      Port (       A : In    std_logic;
                   Z : Out   std_logic );
   end component;

begin

   Q_JK <= Q_JK_DUMMY;
   nQ_JK <= nQ_JK_DUMMY;
   Q_JK_Slave <= Q_JK_Slave_DUMMY;
   nQ_JK_Slave <= nQ_JK_Slave_DUMMY;
   Qdin <= Qdin_DUMMY;

   I37 : xnor2
      Port Map ( A=>N_5, B=>N_4, Z=>K );
   I24 : nd4
      Port Map ( A=>N_20, B=>res, C=>N_18, D=>Qdin_DUMMY, Z=>N_24 );
   I25 : nd4
      Port Map ( A=>N_20, B=>res, C=>N_15, D=>N_25, Z=>N_23 );
   I40 : xor2
      Port Map ( A=>N_26, B=>N_4, Z=>N_18 );
   I38 : or2
      Port Map ( A=>x2, B=>N_27, Z=>N_26 );
   I39 : or2
      Port Map ( A=>x2, B=>N_27, Z=>N_5 );
   I27 : or2
      Port Map ( A=>N_16, B=>x4, Z=>N_15 );
   I3 : or2
      Port Map ( A=>N_8, B=>x4, Z=>J );
   I29 : and2
      Port Map ( A=>x2, B=>x3, Z=>N_16 );
   I30 : and2
      Port Map ( A=>N_23, B=>N_24, Z=>N_19 );
   I14 : and2
      Port Map ( A=>ENABLE, B=>K, Z=>N_14 );
   I15 : and2
      Port Map ( A=>ENABLE, B=>J, Z=>N_13 );
   I4 : and2
      Port Map ( A=>x2, B=>x3, Z=>N_8 );
   I31 : nd3
      Port Map ( A=>N_22, B=>res, C=>C, Z=>N_21 );
   I32 : nd3
      Port Map ( A=>N_21, B=>C, C=>N_19, Z=>N_20 );
   I33 : nd3
      Port Map ( A=>Qdin_DUMMY, B=>N_20, C=>res, Z=>N_25 );
   I16 : nd3
      Port Map ( A=>Q_JK_Slave_DUMMY, B=>N_10, C=>res,
                 Z=>nQ_JK_Slave_DUMMY );
   I17 : nd3
      Port Map ( A=>Q_JK_Master, B=>N_9, C=>res, Z=>nQ_JK_Master );
   I18 : nd3
      Port Map ( A=>C, B=>K, C=>Q_JK_Slave_DUMMY, Z=>N_9 );
   I19 : nd3
      Port Map ( A=>nQ_JK_Slave_DUMMY, B=>J, C=>C, Z=>N_11 );
   I5 : nd3
      Port Map ( A=>Q_JK_DUMMY, B=>N_6, C=>res, Z=>nQ_JK_DUMMY );
   I6 : nd3
      Port Map ( A=>N_13, B=>C, C=>nQ_JK_DUMMY, Z=>N_7 );
   I7 : nd3
      Port Map ( A=>Q_JK_DUMMY, B=>C, C=>N_14, Z=>N_6 );
   I34 : nd2
      Port Map ( A=>N_19, B=>N_21, Z=>N_22 );
   I35 : nd2
      Port Map ( A=>N_21, B=>N_25, Z=>Qdin_DUMMY );
   I20 : nd2
      Port Map ( A=>N_12, B=>nQ_JK_Slave_DUMMY, Z=>Q_JK_Slave_DUMMY );
   I21 : nd2
      Port Map ( A=>Q_JK_Master, B=>x1, Z=>N_12 );
   I22 : nd2
      Port Map ( A=>x1, B=>nQ_JK_Master, Z=>N_10 );
   I23 : nd2
      Port Map ( A=>N_11, B=>nQ_JK_Master, Z=>Q_JK_Master );
   I8 : nd2
      Port Map ( A=>N_7, B=>nQ_JK_DUMMY, Z=>Q_JK_DUMMY );
   I9 : inv
      Port Map ( A=>res, Z=>N_1 );
   I10 : inv
      Port Map ( A=>x4, Z=>N_4 );
   I11 : inv
      Port Map ( A=>x3, Z=>N_27 );
   I12 : inv
      Port Map ( A=>x2, Z=>N_3 );
   I13 : inv
      Port Map ( A=>x1, Z=>C );

end SCHEMATIC;
