void setup() {
  for(int i=2; i< 10; i++) {
    pinMode(i, OUTPUT); // A ~ G
  }
  digitalWrite(9, HIGH); // the "."
  pinMode(A0,OUTPUT); // ones digit
  pinMode(A1,OUTPUT); // tens digit
}

void loop() {
  digitalWrite(A0,HIGH);
  digitalWrite(A1,LOW);
  writeNumber(0);
  delay(1000);
  writeNumber(1);
  delay(1000);
  writeNumber(2);
  delay(1000);
  digitalWrite(A0,LOW);
  digitalWrite(A1,HIGH);
  writeNumber(0);
  delay(1000);
  writeNumber(1);
  delay(1000);
  writeNumber(2);
  delay(1000);
}

void writeNumber(int num) {
  switch (num) {
    case 0:
      digitalWrite(8, LOW); // G
      digitalWrite(2, HIGH); // A
      digitalWrite(3, HIGH); // B
      digitalWrite(4, HIGH); // C
      digitalWrite(5, HIGH); // D
      digitalWrite(6, HIGH); // E
      digitalWrite(7, HIGH); // F
      break;
    case 1:
      digitalWrite(2, LOW); // A
      digitalWrite(5, LOW); // D
      digitalWrite(8, LOW); // G
      digitalWrite(6, LOW); // E
      digitalWrite(7, LOW); // F
      digitalWrite(3, HIGH); // B
      digitalWrite(4, HIGH); // C
      break;
    case 2:
      digitalWrite(4, LOW); // C
      digitalWrite(7, LOW); // F
      digitalWrite(2, HIGH); // A
      digitalWrite(3, HIGH); // B
      digitalWrite(8, HIGH); // G
      digitalWrite(5, HIGH); // D
      digitalWrite(6, HIGH); // E
      break;

  }
}
