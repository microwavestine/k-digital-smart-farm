#include <Wire.h>

void setup() {
  pinMode(LED_BUILTIN, OUTPUT);
  Wire.begin(8);                // join I2C bus with address #8
  Wire.onReceive(receiveEvent); // register event
  Serial.begin(9600);           // start serial for output
}

void loop() {
  delay(100);
}

// function that executes whenever data is received from master
// this function is registered as an event, see setup()
void receiveEvent(int howMany) { 
  while (Wire.available()) { // loop through all but the last
    char c = Wire.read(); // receive byte as a character  
  }
  if(c == 0)  
     digitalWrite(LED_BUILTIN, LOW);
  else 
     digitalWrite(LED_BUILTIN, HIGH);  
}
​
[출처] i2c 0 1 번갈아 보내기 (IT메카닉스) | 작성자 eljet