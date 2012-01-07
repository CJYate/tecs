// This file is part of the materials accompanying the book 
// "The Elements of Computing Systems" by Nisan and Schocken, 
// MIT Press. Book site: www.idc.ac.il/tecs
// File name: projects/05/ComputerRect.tst

load CPU.hdl,
output-file CPURect.out,

output-list time%S1.4.1 ARegister[]%D1.7.1 DRegister[]%D1.7.1 PC[]%D0.4.0;

set instruction %B0000000000000000, tick, output, tock, output;
set instruction %B1111110000010000, tick, output, tock, output;
set instruction %B0000000000010111, tick, output, tock, output;
set instruction %B1110001100000110, tick, output, tock, output;
set instruction %B0000000000010000, tick, output, tock, output;
set instruction %B1110001100001000, tick, output, tock, output;
set instruction %B0100000000000000, tick, output, tock, output;
set instruction %B1110110000010000, tick, output, tock, output;
set instruction %B0000000000010001, tick, output, tock, output;
set instruction %B1110001100001000, tick, output, tock, output;
set instruction %B0000000000010001, tick, output, tock, output;
set instruction %B1111110000100000, tick, output, tock, output;
set instruction %B1110111010001000, tick, output, tock, output;
set instruction %B0000000000010001, tick, output, tock, output;
set instruction %B1111110000010000, tick, output, tock, output;
set instruction %B0000000000100000, tick, output, tock, output;
set instruction %B1110000010010000, tick, output, tock, output;
set instruction %B0000000000010001, tick, output, tock, output;
set instruction %B1110001100001000, tick, output, tock, output;
set instruction %B0000000000010000, tick, output, tock, output;
set instruction %B1111110010011000, tick, output, tock, output;
set instruction %B0000000000001010, tick, output, tock, output;
set instruction %B1110001100000001, tick, output, tock, output;
set instruction %B0000000000010111, tick, output, tock, output;
set instruction %B1110101010000111, tick, output, tock, output;
