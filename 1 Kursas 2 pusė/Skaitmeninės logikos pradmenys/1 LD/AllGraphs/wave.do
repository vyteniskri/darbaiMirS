onerror {resume}
quietly virtual signal -install /schema_1 { (context /schema_1 )(F & E & D & C & B & A )} buss
quietly virtual signal -install /schema_1 { (context /schema_1 )(A & B & C & D & E & F )} buss1
quietly WaveActivateNextPane {} 0
add wave -noupdate /schema_1/F
add wave -noupdate /schema_1/E
add wave -noupdate /schema_1/D
add wave -noupdate /schema_1/C
add wave -noupdate /schema_1/B
add wave -noupdate /schema_1/A
add wave -noupdate -radix unsigned /schema_1/buss1
add wave -noupdate /schema_1/Out1
add wave -noupdate /schema_1/Out2
add wave -noupdate /schema_1/Out3
TreeUpdate [SetDefaultTree]
WaveRestoreCursors {{Cursor 1} {1329 ps} 0}
quietly wave cursor active 1
configure wave -namecolwidth 150
configure wave -valuecolwidth 100
configure wave -justifyvalue left
configure wave -signalnamewidth 0
configure wave -snapdistance 10
configure wave -datasetprefix 0
configure wave -rowmargin 4
configure wave -childrowmargin 2
configure wave -gridoffset 0
configure wave -gridperiod 1
configure wave -griddelta 40
configure wave -timeline 0
configure wave -timelineunits ps
update
WaveRestoreZoom {0 ps} {1614 ps}
