--
-- Synopsys
-- Vhdl wrapper for top level design, written on Mon Mar 28 18:18:07 2022
--
library ieee;
use ieee.std_logic_1164.all;
library xp2;
use xp2.components.all;
library work;
use work.components.all;

entity wrapper_for_ANTRLD is
   port (
      Q_JK : out std_logic;
      nQ_JK : out std_logic;
      x1 : in std_logic;
      x2 : in std_logic;
      x3 : in std_logic;
      x4 : in std_logic;
      res : in std_logic;
      ENABLE : in std_logic;
      Q_JK_Slave : out std_logic;
      nQ_JK_Slave : out std_logic;
      Qdin : out std_logic
   );
end wrapper_for_ANTRLD;

architecture schematic of wrapper_for_ANTRLD is

component ANTRLD
 port (
   Q_JK : out std_logic;
   nQ_JK : out std_logic;
   x1 : in std_logic;
   x2 : in std_logic;
   x3 : in std_logic;
   x4 : in std_logic;
   res : in std_logic;
   ENABLE : in std_logic;
   Q_JK_Slave : out std_logic;
   nQ_JK_Slave : out std_logic;
   Qdin : out std_logic
 );
end component;

signal tmp_Q_JK : std_logic;
signal tmp_nQ_JK : std_logic;
signal tmp_x1 : std_logic;
signal tmp_x2 : std_logic;
signal tmp_x3 : std_logic;
signal tmp_x4 : std_logic;
signal tmp_res : std_logic;
signal tmp_ENABLE : std_logic;
signal tmp_Q_JK_Slave : std_logic;
signal tmp_nQ_JK_Slave : std_logic;
signal tmp_Qdin : std_logic;

begin

Q_JK <= tmp_Q_JK;

nQ_JK <= tmp_nQ_JK;

tmp_x1 <= x1;

tmp_x2 <= x2;

tmp_x3 <= x3;

tmp_x4 <= x4;

tmp_res <= res;

tmp_ENABLE <= ENABLE;

Q_JK_Slave <= tmp_Q_JK_Slave;

nQ_JK_Slave <= tmp_nQ_JK_Slave;

Qdin <= tmp_Qdin;



u1:   ANTRLD port map (
		Q_JK => tmp_Q_JK,
		nQ_JK => tmp_nQ_JK,
		x1 => tmp_x1,
		x2 => tmp_x2,
		x3 => tmp_x3,
		x4 => tmp_x4,
		res => tmp_res,
		ENABLE => tmp_ENABLE,
		Q_JK_Slave => tmp_Q_JK_Slave,
		nQ_JK_Slave => tmp_nQ_JK_Slave,
		Qdin => tmp_Qdin
       );
end schematic;
