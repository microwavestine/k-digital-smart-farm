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

전기장을 사용하는 스위치들 i.e FET Transistor 은 pull down / pull up 하지 않을 경우 공기중에 있는 전자의 영향을 받기때문에 확실한 0인지 1인지 모를 수 있음. 정전기나 순간적인 전압 변화에 의해 HIGH 에서 LOW 로 왔다갔다 할 수 있음. 확실하게 하기 위해서 작은 저항을 사용.

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

### Arduino UNO's Digital Pin INPUT_PULLUP
- 스위치와 연결된 핀을 INPUT 으로 설정하고 읽으면 스위치가 열린 상태에 있울때 핀이 플로팅 되어 예기치 못한 결과가 발생할 수 있다. 그러므로 스위치가 열려있을 때 LOW 또는 HIGH 상태를 보장하려면 풀다운 또는 풀업 저항을 사용해야 한다.
- 풀다운 저항을 사용할 경우 스위치가 열렸을때 LOW, 닫히면 HIGH
- 풀업 저항을 사용할 경우 스위치가 열렸을때 HIGH, 닫히면 LOW
- Atmega MCU 에는 외부 풀업 저향을 연결하는 대신에 10K 옴의 내부 풀업 저항 (내부적으로 전원에 연결되는 저항)이 있는데, 이것을 사용하려면 핀모드를 INPUT_PULLUP 으로 설정하면 된다.

Source: 아두이노 C 프로그래밍, 권상홍 저, 2017.


