int sensorPin = A0;
double sensorValue = 0;
int key = 0; // key 변수 선언

void setup() {
  Serial.begin(9600);
  pinMode(13, OUTPUT);  // LED 1을 출력으로 설정
  pinMode(12, OUTPUT);  // LED 2을 출력으로 설정
  pinMode(11, OUTPUT);  // LED 3을 출력으로 설정
  pinMode(10, OUTPUT);  // LED 4을 출력으로 설정
}

void loop() {
  sensorValue = analogRead(sensorPin);
  sensorValue = sensorValue / (1024.0 / 5.0);
  key = get_key(sensorValue);

  switch (key) {
    case 10:
      digitalWrite(13, LOW); // LED 1 켜기
      digitalWrite(12, LOW);
      digitalWrite(11, LOW);
      digitalWrite(10, HIGH);
      Serial.println("1");
      break;
    case 11:
      digitalWrite(13, LOW);
      digitalWrite(12, LOW); // LED 2 켜기
      digitalWrite(11, HIGH);
      digitalWrite(10, LOW);
      Serial.println("2");
      break;
    case 12:
      digitalWrite(13, LOW);
      digitalWrite(12, HIGH);
      digitalWrite(11, LOW); // LED 3 켜기
      digitalWrite(10, LOW);
      Serial.println("3");
      break;
    case 13:
      digitalWrite(13, HIGH);
      digitalWrite(12, LOW);
      digitalWrite(11, LOW);
      digitalWrite(10, LOW); // LED 4 켜기
      Serial.println("4");
      break;
    default:
      digitalWrite(13, LOW);
      digitalWrite(12, LOW);
      digitalWrite(11, LOW);
      digitalWrite(10, LOW);
      break;
  }
  delay(1000); // LED 상태를 표시하고 1초 대기
}

int get_key(double input)
{
  if(input < 0.4) return 0;
  if(input < 1.4) return 10;
  if(input < 2.6) return 11;
  if(input < 3.9) return 12;
  if(input < 5.2) return 13;

  return 0; // 기본값 반환
}