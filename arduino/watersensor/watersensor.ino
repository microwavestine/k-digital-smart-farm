float temperature;  
int Pin = A0;
const int cnt = 20;
void setup()  
{
    Serial.begin(9600);
}

void loop()  
{  
  temperature = 0; 
  for(int i = 0; i < cnt; ++i)
	{
		temperature += analogRead(Pin);
		delay(50);
	}
	Serial.println(temperature/(float)cnt);
}