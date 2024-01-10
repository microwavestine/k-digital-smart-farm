# 002 - Basics

# 전기 기초
- Ohm's Law V = IR
- 도선의 저항은 0 Ohm 으로 가정한다.
- 온도에 따라 저항이 약간 달라진다.

Given
- 5V Power
- 2V Diode
- 225 Ohm Resistance (3V)
I = V/R = 3 / 225 = 0.01 Amp flowing through resistance

- P = VI(t)
- Therefore P = 2V * 0.01 Amp for the diode

# Basic Knowledge
- \r\n = CRLF = 0D0A
	- Carriage Return; returns cursor to front then move to new line
	- 0x0D 0x0A is often seen in networking at end of packet etc
- In C switch statements, numbers are accepted for parameters by standard because it's a primitive value and string is a (array) class in C.
- Any values beside 0 is treated as true in C.
- Bipolar junction transistor is the first transistor and made with Gallium
- further developed into (MOS)FET (field effect transistor) with n and p channels.
- You can't run motors without relays and transistors (or any semiconducting materials), or the board will burn
- AC 220V 60 hz is standard in South Korea
	- generator has a turbine that turns to generate electricity
	- the generator turbine turns 60 times per second = 60 Hz

# 논리 회로
- Quad NAND/NOR/AND... Gate = 4 logics in one chip
- XOR = 1 & 0 = true. 1 & 1 or 0 & 0 is false.
- 74hc00 (high speed cmos) vs tcd 100 ls (transistor)

