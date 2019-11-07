#include<Servo.h>
Servo base;

void setup() 
{
  base.attach(8);

  Serial.begin(9600);  
}

void loop()
{
      int val=Serial.parseInt();
      if(val!=0)
      {
        base.write(val);
      }
}

