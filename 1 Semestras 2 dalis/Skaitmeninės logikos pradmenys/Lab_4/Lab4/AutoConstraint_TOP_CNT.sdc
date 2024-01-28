
#Begin clock constraint
define_clock -name {TOP_CNT|CLK_I} {p:TOP_CNT|CLK_I} -period 1000.000 -clockgroup Autoconstr_clkgroup_0 -rise 0.000 -fall 500.000 -route 0.000 
#End clock constraint

#Begin clock constraint
define_clock -name {CNT10|CNT_C_derived_clock} {n:CNT10|CNT_C_derived_clock} -period 1000.000 -clockgroup Autoconstr_clkgroup_0 -rise 0.000 -fall 500.000 -route 0.000 
#End clock constraint
