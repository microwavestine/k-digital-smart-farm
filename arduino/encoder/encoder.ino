int CLK = 2;
int DT = 3;
int count = 0;
int currentCLK;
int previousCLK;
int rotation_check = 0;

void setup() {
  pinMode(CLK,INPUT);
  pinMode(DT,INPUT); 
  Serial.begin(9600);
  previousCLK = digitalRead(CLK);
}

void loop() {
  currentCLK = digitalRead(CLK);
  if(currentCLK != previousCLK) 
  {
    if(digitalRead(DT) != currentCLK)
      count++;
      rotation_check = 1;          
    else
      count--;
      rotation_check = 0;
    Serial.print(" count = ");
    Serial.println(count);
  }  
  previousCLK = currentCLK;
}