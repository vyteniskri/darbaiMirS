--
-- Synopsys
-- Vhdl wrapper for top level design, written on Mon Feb 21 22:08:01 2022
--
library ieee;
use ieee.std_logic_1164.all;
library xp2;
use xp2.components.all;
library work;
use work.components.all;

entity wrapper_for_SCHEMA_1 is
   port (
      F : in std_logic;
      E : in std_logic;
      D : in std_logic;
      C : in std_logic;
      B : in std_logic;
      A : in std_logic;
      Out1 : out std_logic;
      Out2 : out std_logic;
      Out3 : out std_logic
   );
end wrapper_for_SCHEMA_1;

architecture schematic of wrapper_for_SCHEMA_1 is

component SCHEMA_1
 port (
   F : in std_logic;
   E : in std_logic;
   D : in std_logic;
   C : in std_logic;
   B : in std_logic;
   A : in std_logic;
   Out1 : out std_logic;
   Out2 : out std_logic;
   Out3 : out std_logic
 );
end component;

signal tmp_F : std_logic;
signal tmp_E : std_logic;
signal tmp_D : std_logic;
signal tmp_C : std_logic;
signal tmp_B : std_logic;
signal tmp_A : std_logic;
signal tmp_Out1 : std_logic;
signal tmp_Out2 : std_logic;
signal tmp_Out3 : std_logic;

begin

tmp_F <= F;

tmp_E <= E;

tmp_D <= D;

tmp_C <= C;

tmp_B <= B;

tmp_A <= A;

Out1 <= tmp_Out1;

Out2 <= tmp_Out2;

Out3 <= tmp_Out3;



u1:   SCHEMA_1 port map (
		F => tmp_F,
		E => tmp_E,
		D => tmp_D,
		C => tmp_C,
		B => tmp_B,
		A => tmp_A,
		Out1 => tmp_Out1,
		Out2 => tmp_Out2,
		Out3 => tmp_Out3
       );
end schematic;
