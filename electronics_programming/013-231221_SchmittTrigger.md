# 013-231221

## 슈미트 트리거 Schmitt Trigger
https://cafe.naver.com/eljet/42
- In electronics, a Schmitt trigger is a comparator circuit with hysteresis implemented by applying positive feedback to the noninverting input of a comparator or differential amplifier. It is an active circuit which converts an analog input signal to a digital output signal.
- NOT 회로, 잡음이 많은 회로에서 사용. 슈미트 트리거 회로 표시 = 잡음 제거
- 외부에서 선을 끌어서 Not 회로를 사용할때 사용
- 지연이 생기면서 안정적으로 신호 전달

## 구형파 회로
https://cafe.naver.com/eljet/15
- 아두이노 R4 는 capacitor 대신 크리스탈 16Mhz main oscillator crystal 사용

### Capacitor (콘덴서)  and Harmonics
- capacitors can't filter harmonics, so 구형파 회로 which is less sensitive to noise is needed

https://blog.naver.com/qaws221/222505091188
https://youtu.be/PAnMobqj4KU?si=yuS8jT-RXR-hsIWm
https://www.linkedin.com/pulse/impact-harmonic-over-capacitor-bank-srinivasan-m
https://www.electricalvolt.com/effects-of-harmonics-on-capacitors-interaction-of-harmonics-with-capacitors/

## Caution with short circuiting Arduino board through digital pins