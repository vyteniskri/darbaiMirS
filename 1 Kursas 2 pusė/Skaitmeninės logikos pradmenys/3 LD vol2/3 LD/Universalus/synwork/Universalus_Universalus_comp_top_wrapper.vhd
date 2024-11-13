--
-- Synopsys
-- Vhdl wrapper for top level design, written on Tue May  3 00:59:21 2022
--
library ieee;
use ieee.std_logic_1164.all;
library xp2;
use xp2.components.all;
library work;
use work.components.all;

entity wrapper_for_SPECIALIZUOTIASRE is
   port (
      Clk : in std_logic;
      A0 : in std_logic;
      A1 : in std_logic;
      Q0 : out std_logic;
      Q1 : out std_logic;
      Q2 : out std_logic;
      Q3 : out std_logic;
      Q4 : out std_logic;
      Q5 : out std_logic;
      Q6 : out std_logic;
      D0 : in std_logic;
      D1 : in std_logic;
      D2 : in std_logic;
      D3 : in std_logic;
      D4 : in std_logic;
      D5 : in std_logic;
      D6 : in std_logic;
      Rst : in std_logic
   );
end wrapper_for_SPECIALIZUOTIASRE;

architecture schematic of wrapper_for_SPECIALIZUOTIASRE is

component SPECIALIZUOTIASRE
 port (
   Clk : in std_logic;
   A0 : in std_logic;
   A1 : in std_logic;
   Q0 : out std_logic;
   Q1 : out std_logic;
   Q2 : out std_logic;
   Q3 : out std_logic;
   Q4 : out std_logic;
   Q5 : out std_logic;
   Q6 : out std_logic;
   D0 : in std_logic;
   D1 : in std_logic;
   D2 : in std_logic;
   D3 : in std_logic;
   D4 : in std_logic;
   D5 : in std_logic;
   D6 : in std_logic;
   Rst : in std_logic
 );
end component;

signal tmp_Clk : std_logic;
signal tmp_A0 : std_logic;
signal tmp_A1 : std_logic;
signal tmp_Q0 : std_logic;
signal tmp_Q1 : std_logic;
signal tmp_Q2 : std_logic;
signal tmp_Q3 : std_logic;
signal tmp_Q4 : std_logic;
signal tmp_Q5 : std_logic;
signal tmp_Q6 : std_logic;
signal tmp_D0 : std_logic;
signal tmp_D1 : std_logic;
signal tmp_D2 : std_logic;
signal tmp_D3 : std_logic;
signal tmp_D4 : std_logic;
signal tmp_D5 : std_logic;
signal tmp_D6 : std_logic;
signal tmp_Rst : std_logic;

begin

tmp_Clk <= Clk;

tmp_A0 <= A0;

tmp_A1 <= A1;

Q0 <= tmp_Q0;

Q1 <= tmp_Q1;

Q2 <= tmp_Q2;

Q3 <= tmp_Q3;

Q4 <= tmp_Q4;

Q5 <= tmp_Q5;

Q6 <= tmp_Q6;

tmp_D0 <= D0;

tmp_D1 <= D1;

tmp_D2 <= D2;

tmp_D3 <= D3;

tmp_D4 <= D4;

tmp_D5 <= D5;

tmp_D6 <= D6;

tmp_Rst <= Rst;



u1:   SPECIALIZUOTIASRE port map (
		Clk => tmp_Clk,
		A0 => tmp_A0,
		A1 => tmp_A1,
		Q0 => tmp_Q0,
		Q1 => tmp_Q1,
		Q2 => tmp_Q2,
		Q3 => tmp_Q3,
		Q4 => tmp_Q4,
		Q5 => tmp_Q5,
		Q6 => tmp_Q6,
		D0 => tmp_D0,
		D1 => tmp_D1,
		D2 => tmp_D2,
		D3 => tmp_D3,
		D4 => tmp_D4,
		D5 => tmp_D5,
		D6 => tmp_D6,
		Rst => tmp_Rst
       );
end schematic;
