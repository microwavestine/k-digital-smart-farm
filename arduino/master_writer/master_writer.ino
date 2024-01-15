#include <Wire.h>
boolean toggle_state = false;
void setup() {
  Wire.begin(); // join I2C bus (address optional for master)
}

void loop() {
  Wire.beginTransmission(8); // transmit to device #8
  Wire.write(toggle_state);              // sends one byte
  Wire.endTransmission();    // stop transmitting
  toggle_state = !toggle_state; 
  delay(1000);
}