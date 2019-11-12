//======================================================authorship
//CC-BY Michael Osthege (2013)
//======================================================
//includes
#include "SoftwareSerial.h"
//constants
const int TX_BT = 10;
const int RX_BT = 11;
const unsigned long periodicMessageFrequency = 500;//Frequency for periodic messages [milliseconds]
unsigned long time = 0;
//
const int ledRed = 7;
const int ledGreen = 6;
//workforce
SoftwareSerial btSerial(TX_BT, RX_BT);
//conversion helpers
String cmd;
//======================================================
//======================================================
//======================================================
//lifecycle
void setup()
{
	pinMode(ledRed, OUTPUT);//set up LED output
	pinMode(ledGreen, OUTPUT);

	Serial.begin(9600);
	Serial.println("Serial initialized");

	btSerial.begin(9600);
	Serial.println("Bluetooth initialized");
}
void loop()
{
	readBluetooth();
	unsigned long currentTime = millis();
	if ((currentTime - time) > periodicMessageFrequency)
	{
		sendPeriodicMessages();
		time = currentTime;
	}
}
//inbound
void processMessage(char* command)
{
	Serial.print("< ");
	Serial.println(command);
	cmd = (String)command;
	if (cmd == "TURN_ON_RED")
	{
		digitalWrite(ledRed, HIGH);
		sendMessage("RED_ON");
	}
	else if (cmd == "TURN_OFF_RED")
	{
		digitalWrite(ledRed, LOW);
		sendMessage("RED_OFF");
	}
	else if (cmd == "TURN_ON_GREEN")
	{
		digitalWrite(ledGreen, HIGH);
		sendMessage("GREEN_ON");
	}
	else if (cmd == "TURN_OFF_GREEN")
	{
		digitalWrite(ledGreen, LOW);
		sendMessage("GREEN_OFF");
	}
	else
        {
          Serial.print("unknown command: ");
          Serial.println(command);
        }
}
//outbound
void sendMessage(char* message)
{
	Serial.print("> ");
	Serial.println(message);
	int messageLen = strlen(message);
	if (messageLen < 256)
	{
		btSerial.write(messageLen);
		btSerial.print(message);
	}
}
void sendPeriodicMessages()
{
	int value1 = analogRead(A0);
	char value2[8] = "";
	char value3[16] = "";
	itoa(value1, value2, 10);
	strcat(value3, "A0=");
	strcat(value3, value2);
	sendMessage(value3);
}
//connection handling
void readBluetooth()
{
	while (btSerial.available())
	{
		int commandSize = (int) btSerial.read();
		char command[commandSize];
		int commandPos = 0;
		while (commandPos < commandSize)
		{
			if (btSerial.available())
			{
				command[commandPos] = (char) btSerial.read();
				commandPos++;
			}
		}
		command[commandPos] = 0;
		processMessage(command);
	}
}
