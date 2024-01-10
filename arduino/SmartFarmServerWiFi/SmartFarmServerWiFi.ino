/*
  WiFi Web Server LED Blink

  A simple web server that lets you blink an LED via the web.
  This sketch will print the IP address of your WiFi module (once connected)
  to the Serial Monitor. From there, you can open that address in a web browser
  to turn on and off the LED_BUILTIN.

  If the IP address of your board is yourAddress:
  http://yourAddress/H turns the LED on
  http://yourAddress/L turns it off

  This example is written for a network using WPA encryption. For
  WEP or WPA, change the WiFi.begin() call accordingly.

  Circuit:
  * Board with NINA module (Arduino MKR WiFi 1010, MKR VIDOR 4000 and Uno WiFi Rev.2)
  * LED attached to pin 9

  created 25 Nov 2012
  by Tom Igoe

  Find the full UNO R4 WiFi Network documentation here:
  https://docs.arduino.cc/tutorials/uno-r4-wifi/wifi-examples#simple-webserver
 */

#include "WiFiS3.h"

#include "arduino_secrets.h"
///////please enter your sensitive data in the Secret tab/arduino_secrets.h
char ssid[] = SECRET_SSID;        // your network SSID (name)
char pass[] = SECRET_PASS;    // your network password (use for WPA, or use as key for WEP)

struct LED_TIME
{
  int StartHour;
  int StartMinute;
  int EndHour;
  int EndMinute;
};

WiFiClient *g_client = NULL;
WiFiServer MonitorServer(800);
WiFiServer SettingServer(900);

struct SEED_DATA
{
  float Temperature;
  int Humidity;
  float CO2;
  int TimeCount;
  LED_TIME *LEDTime;
};

struct MONITOR_DATA
{
  SEED_DATA BasicData;
  bool LEDLight;
  bool Heater;
  bool HumidityDevice;  // 가습기
  bool FAN1;            // 내부공기 배출팬
  bool FAN2;            // 외부공기 유입팬
  bool FAN3;            // 순환팬
};

SEED_DATA SetData;
MONITOR_DATA MonitorData;

int keyIndex = 0;                 // your network key index number (needed only for WEP)
int led =  LED_BUILTIN;
int status = WL_IDLE_STATUS;
// WiFiServer server(80);

void setup() {
  pinMode(led, OUTPUT);      // set the LED pin mode
  digitalWrite(led, LOW);

  Serial.begin(9600);      // initialize serial communication

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

  // attempt to connect to WiFi network:
  while (status != WL_CONNECTED) {
    Serial.print("Attempting to connect to Network named: ");
    Serial.println(ssid);                   // print the network name (SSID);

    // Connect to WPA/WPA2 network. Change this line if using open or WEP network:
    status = WiFi.begin(ssid, pass);
    // wait 10 seconds for connection:
    delay(10000);
  }
  // server.begin();                        // start the web server on port 80
  MonitorServer.begin();
  SettingServer.begin();
  printWifiStatus();                        // you're connected now, so print out the status
  defaultSet();
}

void loop() {
  // WiFiClient client = server.available();   // listen for incoming clients
  int loopCnt = 0;
  String request;

  WiFiClient MonitorClient = MonitorServer.available();  // 대기하지 않고 넘어감

  if (MonitorClient)
  {
	  digitalWrite(LED_BUILTIN, HIGH);

	  if (MonitorClient.connected()) // the client's connected
	  {
		  MonitorClient.println(MonitorData.BasicData.Temperature);
		  MonitorClient.println(MonitorData.BasicData.Humidity);
		  MonitorClient.println(MonitorData.BasicData.CO2);
		  MonitorClient.println(MonitorData.LEDLight ? 1 : 0);
		  MonitorClient.println(MonitorData.Heater ? 1 : 0);
		  MonitorClient.println(MonitorData.HumidityDevice ? 1 : 0);
		  MonitorClient.println(MonitorData.FAN1 ? 1 : 0);
		  MonitorClient.println(MonitorData.FAN2 ? 1 : 0);
		  MonitorClient.println(MonitorData.FAN3 ? 1 : 0);
	  }

    MonitorClient.stop();
    Serial.println("MonitorClient disconnected");
    digitalWrite(LED_BUILTIN, LOW);
  }

  WiFiClient SettingClient = SettingServer.available();

  if (SettingClient)
  {
	  digitalWrite(LED_BUILTIN, HIGH);

	  if(SettingClient.connected())
	  {
		  while(!SettingClient.available()) // 데이터가 들어오기 까지 기다린다
		  {
			  delay(1);
		  }

		  request = SettingClient.readStringUntil('\r');
		  SetData.Temperature = request.toFloat();
		  request = SettingClient.readStringUntil('\r');
		  SetData.Humidity = request.toInt();
		  request = SettingClient.readStringUntil('\r');
		  SetData.CO2 = request.toFloat();
		  request = SettingClient.readStringUntil('\r');
		  SetData.TimeCount = request.toInt();

		  SetData.LEDTime = new LED_TIME[SetData.TimeCount];
		//
		//  for(int i = 0; i < SetData.TimeCount; ++i)
		//  {
        //    request = SettingClient.readStringUntil('\r');
		//    SetData.LEDTime[i].StartHour = request.toInt();
		//
		//	request = SettingClient.readStringUntil('\r');
		//    SetData.LEDTime[i].StartMinute = request.toInt();
		//
		//	request = SettingClient.readStringUntil('\r');
		//    SetData.LEDTime[i].EndHour = request.toInt();
		//
		//	request = SettingClient.readStringUntil('\r');
		//    SetData.LEDTime[i].EndMinute = request.toInt();
		//  }
		//
		  Serial.print("Temp:");     Serial.println(SetData.Temperature);
		  Serial.print("Humidity:"); Serial.println(SetData.Humidity);
		  Serial.print("CO2:");      Serial.println(SetData.CO2);
      Serial.print("TimeCount:");      Serial.println(SetData.TimeCount);
		//
		//  for(int i = 0; i < SetData.TimeCount; ++i)
		//  {
		//	Serial.print("s1:");     Serial.println(SetData.LEDTime[i].StartHour);
		//	Serial.print("s2:");     Serial.println(SetData.LEDTime[i].StartMinute);
		//	Serial.print("s3:");     Serial.println(SetData.LEDTime[i].EndHour);
		//	Serial.print("s4:");     Serial.println(SetData.LEDTime[i].EndMinute);
		//  }
	  }

	  delete[] SetData.LEDTime;
	  SettingClient.stop();
	  Serial.println("SettingClient disconnected");
	  digitalWrite(LED_BUILTIN, LOW);
  }
} // end loop

void defaultSet() {
  MonitorData.BasicData.Temperature = 27.0;
  MonitorData.BasicData.Humidity = 70;
  MonitorData.BasicData.CO2 = 0.01;
  MonitorData.LEDLight = true;
  MonitorData.Heater = true;
  MonitorData.HumidityDevice = true;
  MonitorData.FAN1 = true;
  MonitorData.FAN2 = true;
  MonitorData.FAN3 = true;
}

void printWifiStatus() {
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
  // print where to go in a browser:
  Serial.print("To see this page in action, open a browser to http://");
  Serial.println(ip);
}
