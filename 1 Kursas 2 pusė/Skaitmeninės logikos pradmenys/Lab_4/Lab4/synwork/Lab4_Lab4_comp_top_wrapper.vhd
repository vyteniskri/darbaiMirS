--
-- Synopsys
-- Vhdl wrapper for top level design, written on Tue May 17 01:13:11 2022
--
library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;

entity wrapper_for_CNT10 is
   port (
      CLK : in std_logic;
      RST : in std_logic;
      CNT_CMD : in std_logic;
      CNT_C : out std_logic;
      CNT_O : out std_logic_vector(3 downto 0)
   );
end wrapper_for_CNT10;

architecture rtl of wrapper_for_CNT10 is

component CNT10
 port (
   CLK : in std_logic;
   RST : in std_logic;
   CNT_CMD : in std_logic;
   CNT_C : out std_logic;
   CNT_O : out std_logic_vector (3 downto 0)
 );
end component;

signal tmp_CLK : std_logic;
signal tmp_RST : std_logic;
signal tmp_CNT_CMD : std_logic;
signal tmp_CNT_C : std_logic;
signal tmp_CNT_O : std_logic_vector (3 downto 0);

begin

tmp_CLK <= CLK;

tmp_RST <= RST;

tmp_CNT_CMD <= CNT_CMD;

CNT_C <= tmp_CNT_C;

CNT_O <= tmp_CNT_O;



u1:   CNT10 port map (
		CLK => tmp_CLK,
		RST => tmp_RST,
		CNT_CMD => tmp_CNT_CMD,
		CNT_C => tmp_CNT_C,
		CNT_O => tmp_CNT_O
       );
end rtl;
