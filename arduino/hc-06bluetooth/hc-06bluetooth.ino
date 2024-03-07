#include <SoftwareSerial.h>

// Note any pin can be used for TX, but only the following pins
// can be used for RX:
// D0, D1, D2, D3, D8, D14, D15, A1, A2, A3, A4, A5

SoftwareSerial SoftSerial(6, 7); // Tx, Rx

void setup() {
    Serial.begin(9600);

    while (!Serial) {
    }

    if (!SoftSerial.begin(9600)) {
        Serial.println("Failed to init soft serial");
        while (1);
    }
    Serial.println(SoftSerial);
}

void loop() { // run over and over
 if (SoftSerial.available()) {       
    Serial.write(SoftSerial.read());
  }
  if (Serial.available()) {         
    SoftSerial.write(Serial.read());
  }
}