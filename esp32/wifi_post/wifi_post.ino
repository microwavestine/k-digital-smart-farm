// name 같은 것끼리 change
// LED1 : <input type=radio name=led1 value=0 checked>OFF <input type=radio name=led1 value=1>ON<BR>\
// LED2 : <input type=radio name=led2 value=0 checked>OFF <input type=radio name=led2 value=1>ON<BR>\

#include <WiFi.h>
#include <WiFiClient.h>
#include <WebServer.h>
#include <ESPmDNS.h>



const char* ssid     = "iptimeSmart";
const char* password = "12345678";
const int led = 13;
bool value = true;
WebServer server(80);

void handleRoot() {
  String postForms = "<html>\ 
    <head>\
      <meta charset=\"UTF-8\">\ 
      <title> ESP32 Web Server Post 방식</title>\
      <style>\ 
       body {background-color:#cccccc; font-family: Arial; Color:#000088;}\ 
      </style>\
    </head>\
    <body>\
      <h1> ESP32 Web Server Post 방식 제어</h1><br>\
            LED state = ##led##\
      <form method=\":post\" action=\"/jhk\">\
        <br> 0 = led Off, 1 = led On<br>\  
        <input type=\"text\" name=\"led\" value=\"\"><br>\ 
        <input type=\"text\" name=\"led1\" value=\"\"><br>\ 
        <input type=\"submit\" value=\"Submit\">\ 
      </form>\             
    </body>\
  </html>";


  bool myled = digitalRead(led);



  Serial.println("   myled=   " + String(myled));



  if(myled)
  {
    Serial.println("my led 1");
    postForms.replace("##led##","ON"); // 전역을 지역으로 바꿔야 한다 
    server.send(200, "text/html", postForms);
  }

  else
  {
    Serial.println("my led 0");
    postForms.replace("##led##","OFF"); // 전역을 지역으로 바꿔야 한다
    server.send(200, "text/html", postForms);
  }
  // 200 : OK 응답코드  
  server.send(200, "text/plain", postForms);
}



void jhkfunc() {
  // server.args() ; 변수 갯수
  // server.argName : 변수이름
  // server.arg : 값
  for(int i = 0; i < server.args() ; ++i)
  {
      Serial.println(String( server.argName(i) + " " + server.arg(i)));
      if(server.argName(i) == "led")
      {
          if(server.arg(i) == "0")
          {
              digitalWrite(led,LOW);
              value = false; 
          }

          else if(server.arg(i) == "1")
          {
              digitalWrite(led,HIGH);
              value = true;
          }
      }     
  }
    //                                               0초 후에 

  String res = "<meta http-equiv=\"refresh\" content=\"0; url=http://"+WiFi.localIP().toString() +"\">";
  server.send(200, "text/html", res);
}



void ledON() {
   digitalWrite(led, 1);
  // 200 : OK 응답코드  
  server.send(200, "text/plain", "ledON!");
  value = true; 
  Serial.println("   value ledON=   " + String(value));
}

void ledOFF()  {
  digitalWrite(led, 0);
  // 200 : OK 응답코드  
  server.send(200, "text/plain", "ledOFF!");
   value = false; 
  Serial.println("   value ledOFF=   " + String(value));
}



void handleNotFound() {
  digitalWrite(led, 1);
  String message = "File Not Found\n\n";
  message += "URI: ";
  message += server.uri();
  message += "\nMethod: ";
  message += (server.method() == HTTP_GET) ? "GET" : "POST";
  message += "\nArguments: ";
  message += server.args();
  message += "\n";
  for (uint8_t i = 0; i < server.args(); i++) {
    message += " " + server.argName(i) + ": " + server.arg(i) + "\n";
  }
  // 404 : Page not found
  server.send(404, "text/plain", message);
  digitalWrite(led, 0);
}



void setup(void) {
  pinMode(led, OUTPUT);
  digitalWrite(led, 0);
  Serial.begin(115200);
  WiFi.mode(WIFI_STA);
  WiFi.begin(ssid, password);
  Serial.println("");
  // Wait for connection
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }

  Serial.println("");
  Serial.print("Connected to ");
  Serial.println(ssid);
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());

  if (MDNS.begin("esp32")) {
    Serial.println("MDNS responder started");
  }
  // 클라이언트가  루트디렉토리 를 입력했을때 handleRoot 에서 처리

  //
  server.on("/", handleRoot);  
  server.on("/L", ledOFF);
  server.on("/H", ledON);
  server.on("/jhk", jhkfunc);
  server.on("/inline", []() {
    server.send(200, "text/plain", "this works as well");
  });

  server.onNotFound(handleNotFound);
  server.begin();
  Serial.println("HTTP server started");
}


void loop(void) {
  server.handleClient();
  delay(2);//allow the cpu to switch to other tasks
}