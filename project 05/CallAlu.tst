// This file is part of the materials accompanying the book 
// "The Elements of Computing Systems" by Nisan and Schocken, 
// MIT Press. Book site: www.idc.ac.il/tecs
// File name: projects/05/CPU.tst

load CallAlu.hdl,
output-file CallAlu.out,
compare-to CallAlu.cmp,
output-list A%B0.16.0 D%B0.16.0 M%B0.16.0 function%B0.7.0 jumpCode%B0.3.0 aluOut%B0.16.0 doJump;      

set A 12345;
set D 0;
set M 0;
set function %B0001100;
set jumpCode %B001;
tick, tock, output;
