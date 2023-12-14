# 009-231214: Diodes, Pull up and down resistors

## 전해 콘덴서
- 내압이 적혀져 있음. 25V 인경우 보통 power supply 는 그 반정도로 계산.
- 온도도 적혀져 있음.

## Diode materials & voltage drop
Germanium diodes 0.4V 강하
Sillicon diodes 0.7V 강하

## 정류 다이오드
```
            diode doesn't work when flipped
            ┌─────────┬────┐
            │         │    │
     ┌──────┤         │    ├────resistor  led  ─────┐
     │      └─────────┴────┘                        │
     │                                              │
     │                                              │
+    │                                              │
     │                                              │
                                                    │
power                                               │
     │                                              │
     │                                              │
-    │                                              │
     │                                              │
     └──────────────────────────────────────────────┘
```

## Bridge rectifiers
- works like H bridge with diodes
- KBP207
### 양파 정류회로
```
                                      ┌────────────────────────┐
┌──────────────┐                      │                        │
│              │                      │                        │
│              │                      │                        │
│              │                      │                        │
│              │                      │+     *can change +-  - │
│              │                      ├─────┬─────────┬────────┤
│              │                      │     │         │        │
│            + │     ◄────────────────┼─────┘         │        │
│              │                      │               │        │
│              │                      │               │        │
│     arduino -│◄─────────────────────┼───────────────┘        │
│              │                      │                        │
│              │                      │                        │
└──────────────┘                      │                        │
                                      │                        │
                                      │                        │

                                     resistor        led
```



스위칭 다이오드
제노 다이오드


## Serial Communication
```
    PC
┌────────────┐
│            │
│            │
│            │
│            │
│ ┌────────┐ │                        ┌─────────┐
│ │ COM    │ ├────────────────────────┤         │
│ └────────┘ │      RS232             │         │
│            │                        │ Level   ├────────xxx xxx
└────────────┘                        │converter│        x xxx xx
                                      │MAX3232  │
                                      │         │
                                      └─────────┘

```

## Pull up and down resistors

전기장을 사용하는 스위치들 i.e FET Transistor 은 pull down / pull up 하지 않을 경우 공기중에 있는 전자의 영향을 받기때문에 확실한 0인지 1인지 모를 수 있음. 확실하게 하기 위해서 작은 저항을 사용.

```
 ─────────────────────────────────────────────────────────────────────── +


                                                             V1 =(R1 / R1+R2) * V
                           R1       infinite resistance
                          (the air)

                                         ┌────────────┐
                                         │            │
                                         │            │
                                         │            │
                                   ┌─────┤            │
                                   │     │            │
                                   │     │            │
                                   │     └────────────┘
                                   │

                         R2    10K Ohm                       V2 = (R2 / R1+R2) * V
                                   │
                                   │
                                   │
───────────────────────────────────┴──────────────────────────────────── -

```
- CMOS type switches are controlled by voltage
- Requires a clear + or -
- Without pull up or downn resistors, it's unclear whether it's + or -
- For switch and resistive sensor applications, the typical pull-up resistor value is 1-10 kΩ. If in doubt, a good starting point when using a switch is 4.7 kΩ. Some digital circuits, such as CMOS families, have a small input leakage current, allowing much higher resistance values, from around 10 kΩ up to 1 MΩ.

