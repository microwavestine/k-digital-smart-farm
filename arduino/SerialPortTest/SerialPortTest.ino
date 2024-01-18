void setup() {
  //Initialize serial and wait for port to open:
  Serial.begin(9600);
  // pinMode(13, OUTPUT);
  while (!Serial) {
    ;  // wait for serial port to connect. Needed for native USB port only
  }
}

void loop() {

  Serial.println("Hello World");
  delay(3000);
  // prints value unaltered, i.e. the raw binary version of the byte.
  // The Serial Monitor interprets all bytes as ASCII, so 33, the first number,
  // will show up as '!'
  // if(Serial.available()) {
  //   recv = Serial.read();
  //   if(recv == 33) {
  //     digitalWrite(13, LOW);
  //   }
  //   else {
  //     digitalWrite(13, HIGH);
  //   }
  //   }
  }
