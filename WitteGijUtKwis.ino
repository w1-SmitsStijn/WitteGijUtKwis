int knopA = 5;
int knopB = 4;
int knopC = 3;
int knopD = 2;

int toestandknopA = 0;
int toestandknopB = 0;
int toestandknopC = 0;
int toestandknopD = 0;

int ledGoed = 13;
int ledFout = 12;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  
  pinMode(knopA, INPUT);
  pinMode(knopB, INPUT);
  pinMode(knopC, INPUT);
  pinMode(knopD, INPUT);
  
  pinMode(ledGoed, OUTPUT);
  pinMode(ledFout, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  toestandknopA = digitalRead(knopA);
  toestandknopB = digitalRead(knopB);
  toestandknopC = digitalRead(knopC);
  toestandknopD = digitalRead(knopD);

  if (toestandknopA == HIGH) {    
    Serial.println('A');
    char antwoord = Serial.read();
    if (antwoord == 'A') {
      digitalWrite(ledGoed, HIGH);
    }

    else {
      digitalWrite(ledFout, HIGH);
    }
    delay(1000);
  }

  else if(toestandknopB == HIGH) {    
    Serial.println("B");
    delay(1000);
  }
  
  else if (toestandknopC == HIGH) {    
    Serial.println("C");
    delay(1000);
  }
  
  else if (toestandknopD == HIGH) {    
    Serial.println("D");
    delay(1000);
  }
}
