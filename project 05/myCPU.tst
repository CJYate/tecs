// This file is part of the materials accompanying the book 
// "The Elements of Computing Systems" by Nisan and Schocken, 
// MIT Press. Book site: www.idc.ac.il/tecs
// File name: projects/05/CPU.tst

load CPU.hdl,
output-file myCPU.out,
compare-to CPU.cmp,
output-list time%S0.4.0 inM%D0.6.0 instruction%B0.16.0 reset%B2.1.2 outM%D1.6.0 writeM%B3.1.3 addressM%D0.5.0 pc%D0.5.0 DRegister[]%D1.6.1;

set instruction %B0011000000111001, // @12345
tick, output, tock, output;

set instruction %B1110001100000001, // D; JGT
tick, output, tock, output;

set instruction %B0000000000000011, // @3
tick, output, tock, output;

set instruction %B1110101010000111, // 0;jmp
tick, output, tock, output;

set reset 1;
tick, output, tock, output;
