-- VHDL model created from schematic Schema_1.sch -- Feb 21 22:07:52 2022

library IEEE;
use IEEE.std_logic_1164.all;
library xp2;
use xp2.components.all;

entity SCHEMA_1 is
      Port (       F : In    std_logic;
                   E : In    std_logic;
                   D : In    std_logic;
                   C : In    std_logic;
                   B : In    std_logic;
                   A : In    std_logic;
                Out1 : Out   std_logic;
                Out2 : Out   std_logic;
                Out3 : Out   std_logic );

end SCHEMA_1;

architecture SCHEMATIC of SCHEMA_1 is

   SIGNAL gnd : std_logic := '0';
   SIGNAL vcc : std_logic := '1';

   signal     N_87 : std_logic;
   signal     N_88 : std_logic;
   signal     N_89 : std_logic;
   signal     N_90 : std_logic;
   signal     N_91 : std_logic;
   signal     N_92 : std_logic;
   signal     N_93 : std_logic;
   signal     N_94 : std_logic;
   signal     N_95 : std_logic;
   signal     N_96 : std_logic;
   signal     N_97 : std_logic;
   signal     N_98 : std_logic;
   signal     N_99 : std_logic;
   signal    N_100 : std_logic;
   signal    N_101 : std_logic;
   signal    N_102 : std_logic;
   signal    N_103 : std_logic;
   signal    N_104 : std_logic;
   signal    N_105 : std_logic;
   signal    N_106 : std_logic;
   signal    N_107 : std_logic;
   signal    N_108 : std_logic;
   signal     N_61 : std_logic;
   signal     N_62 : std_logic;
   signal     N_63 : std_logic;
   signal     N_64 : std_logic;
   signal     N_65 : std_logic;
   signal     N_66 : std_logic;
   signal     N_67 : std_logic;
   signal     N_68 : std_logic;
   signal     N_69 : std_logic;
   signal     N_70 : std_logic;
   signal     N_71 : std_logic;
   signal     N_72 : std_logic;
   signal     N_73 : std_logic;
   signal     N_74 : std_logic;
   signal     N_75 : std_logic;
   signal     N_76 : std_logic;
   signal     N_77 : std_logic;
   signal     N_78 : std_logic;
   signal     N_79 : std_logic;
   signal     N_80 : std_logic;
   signal     N_81 : std_logic;
   signal     N_82 : std_logic;
   signal     N_83 : std_logic;
   signal     N_84 : std_logic;
   signal     N_85 : std_logic;
   signal     N_86 : std_logic;
   signal     N_27 : std_logic;
   signal     N_28 : std_logic;
   signal     N_29 : std_logic;
   signal     N_30 : std_logic;
   signal     N_31 : std_logic;
   signal     N_32 : std_logic;
   signal     N_33 : std_logic;
   signal     N_34 : std_logic;
   signal     N_35 : std_logic;
   signal     N_36 : std_logic;
   signal     N_37 : std_logic;
   signal     N_38 : std_logic;
   signal     N_39 : std_logic;
   signal     N_40 : std_logic;
   signal     N_41 : std_logic;
   signal     N_42 : std_logic;
   signal     N_43 : std_logic;
   signal     N_44 : std_logic;
   signal     N_45 : std_logic;
   signal     N_46 : std_logic;
   signal     N_47 : std_logic;
   signal     N_48 : std_logic;
   signal     N_49 : std_logic;
   signal     N_50 : std_logic;
   signal     N_51 : std_logic;
   signal     N_52 : std_logic;

   component mux41
      Port (      D0 : In    std_logic;
                  D1 : In    std_logic;
                  D2 : In    std_logic;
                  D3 : In    std_logic;
                 SD1 : In    std_logic;
                 SD2 : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component nd5
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   C : In    std_logic;
                   D : In    std_logic;
                   E : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component nd4
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   C : In    std_logic;
                   D : In    std_logic;
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

   component and5
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   C : In    std_logic;
                   D : In    std_logic;
                   E : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component or5
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   C : In    std_logic;
                   D : In    std_logic;
                   E : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component or3
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   C : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component and4
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   C : In    std_logic;
                   D : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component inv
      Port (       A : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component and3
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   C : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component and2
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component or2
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   Z : Out   std_logic );
   end component;

begin

   I61 : mux41
      Port Map ( D0=>N_105, D1=>N_98, D2=>N_97, D3=>N_96, SD1=>D, SD2=>A,
                 Z=>Out3 );
   I34 : nd5
      Port Map ( A=>N_81, B=>N_72, C=>N_71, D=>N_70, E=>N_62, Z=>Out2 );
   I35 : nd5
      Port Map ( A=>N_63, B=>A, C=>B, D=>N_61, E=>F, Z=>N_62 );
   I36 : nd4
      Port Map ( A=>N_80, B=>N_86, C=>D, D=>N_76, Z=>N_78 );
   I37 : nd4
      Port Map ( A=>B, B=>C, C=>N_61, D=>E, Z=>N_79 );
   I38 : nd3
      Port Map ( A=>N_67, B=>N_80, C=>N_61, Z=>N_70 );
   I39 : nd3
      Port Map ( A=>N_86, B=>N_66, C=>F, Z=>N_68 );
   I40 : nd3
      Port Map ( A=>A, B=>E, C=>N_76, Z=>N_69 );
   I41 : nd3
      Port Map ( A=>N_73, B=>A, C=>C, Z=>N_71 );
   I42 : nd3
      Port Map ( A=>N_80, B=>N_61, C=>E, Z=>N_74 );
   I43 : nd3
      Port Map ( A=>B, B=>D, C=>N_76, Z=>N_75 );
   I44 : nd3
      Port Map ( A=>N_83, B=>N_82, C=>N_80, Z=>N_81 );
   I45 : nd3
      Port Map ( A=>C, B=>D, C=>E, Z=>N_84 );
   I46 : nd2
      Port Map ( A=>N_65, B=>N_64, Z=>N_63 );
   I47 : nd2
      Port Map ( A=>C, B=>N_66, Z=>N_64 );
   I48 : nd2
      Port Map ( A=>N_86, B=>E, Z=>N_65 );
   I49 : nd2
      Port Map ( A=>N_69, B=>N_68, Z=>N_67 );
   I50 : nd2
      Port Map ( A=>N_85, B=>N_84, Z=>N_83 );
   I51 : nd2
      Port Map ( A=>N_77, B=>N_82, Z=>N_72 );
   I52 : nd2
      Port Map ( A=>N_75, B=>N_74, Z=>N_73 );
   I53 : nd2
      Port Map ( A=>N_79, B=>N_78, Z=>N_77 );
   I54 : nd2
      Port Map ( A=>N_86, B=>N_61, Z=>N_85 );
   I7 : and5
      Port Map ( A=>N_44, B=>A, C=>B, D=>N_31, E=>F, Z=>N_52 );
   I8 : or5
      Port Map ( A=>N_51, B=>N_49, C=>N_27, D=>N_50, E=>N_52, Z=>Out1 );
   I62 : or3
      Port Map ( A=>N_99, B=>N_95, C=>N_91, Z=>N_94 );
   I9 : and4
      Port Map ( A=>B, B=>C, C=>N_31, D=>E, Z=>N_36 );
   I10 : and4
      Port Map ( A=>N_29, B=>N_30, C=>D, D=>N_33, Z=>N_37 );
   I63 : inv
      Port Map ( A=>B, Z=>N_108 );
   I64 : inv
      Port Map ( A=>C, Z=>N_107 );
   I65 : inv
      Port Map ( A=>E, Z=>N_92 );
   I66 : inv
      Port Map ( A=>F, Z=>N_103 );
   I55 : inv
      Port Map ( A=>A, Z=>N_82 );
   I56 : inv
      Port Map ( A=>B, Z=>N_80 );
   I57 : inv
      Port Map ( A=>C, Z=>N_86 );
   I58 : inv
      Port Map ( A=>D, Z=>N_61 );
   I59 : inv
      Port Map ( A=>E, Z=>N_66 );
   I60 : inv
      Port Map ( A=>F, Z=>N_76 );
   I11 : inv
      Port Map ( A=>A, Z=>N_28 );
   I12 : inv
      Port Map ( A=>B, Z=>N_29 );
   I13 : inv
      Port Map ( A=>C, Z=>N_30 );
   I14 : inv
      Port Map ( A=>D, Z=>N_31 );
   I15 : inv
      Port Map ( A=>E, Z=>N_32 );
   I16 : inv
      Port Map ( A=>F, Z=>N_33 );
   I67 : and3
      Port Map ( A=>B, B=>C, C=>E, Z=>N_104 );
   I68 : and3
      Port Map ( A=>N_107, B=>N_92, C=>F, Z=>N_91 );
   I69 : and3
      Port Map ( A=>N_89, B=>B, C=>F, Z=>N_87 );
   I70 : and3
      Port Map ( A=>B, B=>C, C=>N_103, Z=>N_96 );
   I17 : and3
      Port Map ( A=>C, B=>D, C=>E, Z=>N_35 );
   I18 : and3
      Port Map ( A=>N_45, B=>N_28, C=>N_29, Z=>N_51 );
   I19 : and3
      Port Map ( A=>B, B=>D, C=>N_33, Z=>N_38 );
   I20 : and3
      Port Map ( A=>N_29, B=>N_31, C=>E, Z=>N_39 );
   I21 : and3
      Port Map ( A=>N_47, B=>A, C=>C, Z=>N_27 );
   I22 : and3
      Port Map ( A=>N_48, B=>N_29, C=>N_31, Z=>N_50 );
   I23 : and3
      Port Map ( A=>N_30, B=>N_32, C=>F, Z=>N_41 );
   I24 : and3
      Port Map ( A=>A, B=>E, C=>N_33, Z=>N_40 );
   I71 : and2
      Port Map ( A=>N_108, B=>N_107, Z=>N_106 );
   I72 : and2
      Port Map ( A=>N_107, B=>N_103, Z=>N_102 );
   I73 : and2
      Port Map ( A=>C, B=>E, Z=>N_100 );
   I74 : and2
      Port Map ( A=>N_101, B=>N_108, Z=>N_98 );
   I75 : and2
      Port Map ( A=>C, B=>E, Z=>N_99 );
   I76 : and2
      Port Map ( A=>E, B=>N_103, Z=>N_95 );
   I77 : and2
      Port Map ( A=>N_94, B=>N_108, Z=>N_93 );
   I78 : and2
      Port Map ( A=>C, B=>N_92, Z=>N_90 );
   I79 : and2
      Port Map ( A=>N_107, B=>E, Z=>N_88 );
   I25 : and2
      Port Map ( A=>C, B=>N_32, Z=>N_43 );
   I26 : and2
      Port Map ( A=>N_30, B=>E, Z=>N_42 );
   I27 : and2
      Port Map ( A=>N_30, B=>N_31, Z=>N_34 );
   I28 : and2
      Port Map ( A=>N_46, B=>N_28, Z=>N_49 );
   I80 : or2
      Port Map ( A=>N_106, B=>N_104, Z=>N_105 );
   I81 : or2
      Port Map ( A=>N_102, B=>N_100, Z=>N_101 );
   I82 : or2
      Port Map ( A=>N_90, B=>N_88, Z=>N_89 );
   I83 : or2
      Port Map ( A=>N_93, B=>N_87, Z=>N_97 );
   I29 : or2
      Port Map ( A=>N_42, B=>N_43, Z=>N_44 );
   I30 : or2
      Port Map ( A=>N_34, B=>N_35, Z=>N_45 );
   I31 : or2
      Port Map ( A=>N_36, B=>N_37, Z=>N_46 );
   I32 : or2
      Port Map ( A=>N_38, B=>N_39, Z=>N_47 );
   I33 : or2
      Port Map ( A=>N_40, B=>N_41, Z=>N_48 );

end SCHEMATIC;
