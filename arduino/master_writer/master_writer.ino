#include <Wire.h> 
void setup() {
	Wire.begin(8); 
	Wire.onRequest(requestEvent); 
} 
void loop() { 
	delay(100);
} 
void requestEvent() 
{ 
	Wire.write("01B23A456B789A "); // 마스터에게보낼데이터
}
