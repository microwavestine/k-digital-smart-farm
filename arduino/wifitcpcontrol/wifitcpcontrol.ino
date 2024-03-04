#include "WiFiS3.h"

#define SECRET_SSID "iptimeSmart"
#define SECRET_PASS "12345678"

///////please enter your sensitive data in the Secret tab/arduino_secrets.h
// #include "arduino_secrets.h" 

char ssid[] = SECRET_SSID;        // your network SSID (name)
char pass[] = SECRET_PASS;    // your network password (use for WPA, or use as key for WEP)
int keyIndex = 0;            // your network key index number (needed only for WEP)

int status = WL_IDLE_STATUS;
// if you don't want to use DNS (and reduce your sketch size)
// use the numeric IP instead of the name for the server:

const char* host = "192.168.0.31";
const uint16_t port = 7000;


IPAddress server(192,168,0,31);  // numeric IP for Google (no DNS)
//char server[] = "www.google.com";    // name address for Google (using DNS)
// Initialize the Ethernet client library
// with the IP address and port of the server
// that you want to connect to (port 80 is default for HTTP):
uint32_t received_data_num = 0;
WiFiClient client;

const int LED1 = 13; 
const int LED2 = 12; 
const int MOTOR1 = 11;

String  WORK;
String  KEY;
String  VALUE;
String  HOUSE_NAME = "1234A001";
bool    isTrue;  
String  str = "1234A001 MOTOR LED2=ON" ;
/* -------------------------------------------------------------------------- */
void setup() {
/* -------------------------------------------------------------------------- */  
  //Initialize serial and wait for port to open:
  Serial.begin(9600); 
  while (!Serial) {
    ; // wait for serial port to connect. Needed for native USB port only
  }
  
  pinMode(LED1, OUTPUT);
  pinMode(LED2, OUTPUT);
  pinMode(MOTOR1, OUTPUT);
  
  // check for the WiFi module:
  if (WiFi.status() == WL_NO_MODULE) {
    Serial.println("Communication with WiFi module failed!");
    // don't continue
    while (true);
  }  
  String fv = WiFi.firmwareVersion();
  if (fv < WIFI_FIRMWARE_LATEST_VERSION) {
    Serial.println("Please upgrade the firmware");
  }
//  
  // attempt to connect to WiFi network:
  while (status != WL_CONNECTED) {
    Serial.print("Attempting to connect to SSID: ");
    Serial.println(ssid);
    // Connect to WPA/WPA2 network. Change this line if using open or WEP network:
    status = WiFi.begin(ssid, pass);
     
    // wait 10 seconds for connection:
    delay(10000);
  }  
  printWifiStatus();
}
/* just wrap the received data up to 80 columns in the serial print*/
/* -------------------------------------------------------------------------- */
void read_response() {
/* -------------------------------------------------------------------------- */  
   while (client.available()) {
    /* actual data reception */
    char c = client.read();
    /* print data to serial port */
    Serial.print(c);
    /* wrap data to 80 columns*/
    received_data_num++;
    if(received_data_num > 80) { 
      received_data_num = 0;
      Serial.println();
    }
  }   
}

void read_responseNew() {
/* -------------------------------------------------------------------------- */  
  //스트링으로 하면 스트링 문자 끝이 들어올때 까지 가다림 
  while (client.available()) {
    String read_line = client.readStringUntil('\r'); 
    client.readStringUntil('\n');  // Skip new line as well
    client.flush();	
    Serial.println(read_line);  
	
    isTrue = parsing(read_line);
    
    if(isTrue)
    {  
      if (WORK.equals("LED"))
      {
        ledFunc();
      }
      else if (WORK.equals("MOTOR"))
      {
        motorFunc();
      }  
	  } 
  }    
}

/* -------------------------------------------------------------------------- */
void loop() {
/* -------------------------------------------------------------------------- */  
  // 1234A001 LED LED1=ON+LED2=ON     
  // 1234A001 MORTOR  MORTOR1=ON


  Serial.print("connecting to ");
  Serial.print(host);
  Serial.print(':');
  Serial.println(port);
  
  if (!client.connect(host, port)) {
    Serial.println("connection failed");
    Serial.println("wait 5 sec...");
    delay(5000);
    return;
  } 
  
  // 접속 성공적으로 되었다 
    // This will send the request to the server
  client.println("hello from Arduino R4 Wifi"); 

  // 연결이 될동안에 진행 
  unsigned long dt = millis(); 
  while(client.connected()) 
  {
    // 일정한 시간 간격으로 메세지 전송 
    if((millis() -dt) > 1000)
    {
      dt = millis();
      client.println("Hi");
    }   
    read_responseNew();         
  }  

  client.stop(); 
  delay(1000);
}

/* -------------------------------------------------------------------------- */
void printWifiStatus() {
/* -------------------------------------------------------------------------- */  
  // print the SSID of the network you're attached to:
  Serial.print("SSID: ");
  Serial.println(WiFi.SSID());

  // print your board's IP address:
  IPAddress ip = WiFi.localIP();
  Serial.print("IP Address: ");
  Serial.println(ip);

  // print the received signal strength:
  long rssi = WiFi.RSSI();
  Serial.print("signal strength (RSSI):");
  Serial.print(rssi);
  Serial.println(" dBm");  
}

void ledFunc()
{
  Serial.println(" ==== led func ===== ");
  if (KEY.equals("LED1"))
  {   

      if (VALUE.equals("ON"))
      {
         digitalWrite(LED1, HIGH);         
      } 
      else if(VALUE.equals("OFF"))
      {
        digitalWrite(LED1, LOW);
      }
  }
  else if (KEY.equals("LED2"))
  {
      if (VALUE.equals("ON"))
      {
         digitalWrite(LED2, HIGH);         
      } 
      else if(VALUE.equals("OFF"))
      {
        digitalWrite(LED2, LOW);
      }      
  }
}

void motorFunc()
{   
  Serial.println(" ==== Motro func ===== ");
  Serial.println(KEY);
  Serial.println(VALUE);  
}

bool parsing(String str)
{
  String element[3] = {"","",""};
  String suBelement[2] = {"",""};

  int first = 0;               
  int second = 0;
  int length = 0;

  first = str.indexOf(" ");                // 첫 번째 콤마 위치
  second = str.indexOf(" ",first+1);       // 두 번째 콤마 위치
  length = str.length();                   // 문자열 길이

  element[0] = str.substring(0, first);        // 첫 번째 토큰 
  element[1] = str.substring(first+1, second); // 두 번째 토큰 
  element[2] = str.substring(second+1,length); // 세 번째 토큰
 
  if(first  < 1) return false;
  if(second < 1) return false; 

  if (!element[0].equals(HOUSE_NAME)) return false;

  WORK = element[1];

  first = 0; 
  length = 0;

  first  = element[2].indexOf("=");            
  length = element[2].length(); 

  if(first  < 1) return false;

  suBelement[0] = element[2].substring(0, first);        // 첫 번째 토큰 
  suBelement[1] = element[2].substring(first+1, length); // 두 번째 토큰 
  
  KEY = suBelement[0];
  VALUE = suBelement[1];

  Serial.println(element[0]);
  Serial.println(element[1]);
  Serial.println(element[2]); 
  return true;
}