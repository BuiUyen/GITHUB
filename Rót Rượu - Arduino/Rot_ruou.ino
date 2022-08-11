#include <Wire.h>
#include <LiquidCrystal_I2C.h> //SDA -> A4 and SCL -> A5.
LiquidCrystal_I2C lcd = LiquidCrystal_I2C(0x27, 20, 4);

int button_muc_ruou = 9; //nút bấm mức rượu
int button_menu = 10; // nút chọn menu
int button_bomruou = 11; // nút bơm rượu
int button_mau = 8; // nút bơm rượu chén mẫu

int buzzer = 7; //còi báo 7
int motor2pin2 = 6;
int motor2pin1 = 5;
int enB = 4;
int cam_bien = 3;

long startTime = 0;
long thoi_gian= 0;
int muc_ruou = 1;
int menu  = 0;
int trangthai = 0;  //trạng thái có chén rượu hay không?
String string_muc_ruou = "25%";
int giatri; //giá trị điều chỉnh tốc độ máy bơm
int bamxung;
int trangthai_bom = 0;
long so_chen = 0;

void setup()
{
  Serial. begin (9600);
  pinMode(button_muc_ruou, INPUT);
  pinMode(cam_bien, INPUT);
  pinMode(motor2pin1, OUTPUT);
  pinMode(motor2pin2, OUTPUT);
  lcd.init();
  lcd.backlight();
}

void loop()
{
  Serial.println("bat dau");
  giatri = analogRead (A1);
  bamxung = map(giatri,0,1023,0,255);
  Serial.println (bamxung);
  if(menu==0)
  {
    lcd.setCursor(2, 0);
    lcd.print("ROT RUOU TU DONG");
    lcd.setCursor(4, 2); 
    lcd.print("BUI HUU UYEN");
    }  
  
 if (digitalRead(button_muc_ruou) == HIGH && menu == 1)
  {
    tone(buzzer, 2000);delay(150);noTone(buzzer);
    switch (muc_ruou)
    {
      case 3:
      muc_ruou = 2;
      string_muc_ruou = "50% ";
      break;
      case 4:
      muc_ruou = 3;
      string_muc_ruou = "75% ";
      break;
      case 2:
      muc_ruou = 1;
      string_muc_ruou = "25% ";
      break;      
     }
     menu_1();
  }
 
 if (digitalRead(button_bomruou) == HIGH && menu == 1)
  {
    tone(buzzer, 2000);delay(150);noTone(buzzer);
    switch (muc_ruou)
    {
      case 1:
      muc_ruou = 2;
      string_muc_ruou = "50% ";
      break;
      case 2:
      muc_ruou = 3;
      string_muc_ruou = "75% ";
      break;
      case 3:
      muc_ruou = 4;
      string_muc_ruou = "100%";
      break;
      }
      menu_1();
  }

  
 if(menu == 1)  // --------------------------------------------------------------------------menu 1
{
  if(trangthai_bom == 0)
 {
  if (digitalRead(cam_bien) == LOW)
  {
    delay(500);
    if (digitalRead(cam_bien) == LOW  && trangthai == 0) // rót rượu
    {
      tone(buzzer, 1000);delay(100);noTone(buzzer);
      
      startTime = millis();
      trangthai_bom = 1;
      bom_ruou();
      }
    }
  }  
  else
  {
    if(digitalRead(cam_bien) == HIGH)
    {
      tat_bom();
      trangthai_bom = 0;
      for(int i = 0; i <= 3; i++)
      {
        tone(buzzer, 2000);delay(50); noTone(buzzer);delay(50);        
      }
    }
    else
    {
      int i = millis() - startTime;
      if( i < (thoi_gian*muc_ruou)/4)
      {
        bom_ruou();
      }
      else
      {
        trangthai_bom = 0;
        tat_bom();
        tone(buzzer, 3000);delay(50);tone(buzzer, 4000);delay(50);tone(buzzer, 5000);delay(50);noTone(buzzer);
        trangthai = 1;
        so_chen++;
        menu_1();
      }
    }
  }
  
  if (digitalRead(cam_bien) == HIGH && trangthai == 1) // lấy chén rượu đã rót
  {
  delay(300);
  trangthai = 0;
  }
}

  if(menu == 2)  // --------------------------------------------------------------------------menu 2
{
  if(digitalRead(button_bomruou)== true)// ấn nút bơm
  {
    if(digitalRead(cam_bien) == HIGH)
    {
      tat_bom();      
      for(int i = 0; i <= 3; i++)
      {
        tone(buzzer, 2000);delay(50); noTone(buzzer);delay(50);        
      }
    }
    else
    {
      bom_ruou();
    }    
  }
  else
  {
    tat_bom();
  }
}

 if(menu == 3) // --------------------------------------------------------------------------menu 3
{
  if(digitalRead(button_mau)== true)
  {
    if(digitalRead(cam_bien) == HIGH)
    {
      tat_bom();
      startTime == 0;
      for(int i = 0; i <= 3; i++)
      {
        tone(buzzer, 2000);delay(50); noTone(buzzer);delay(50);        
      }
    }
    else
    {
      if(startTime == 0)
      {
        startTime = millis();
      }
      thoi_gian = millis() - startTime;
      bom_ruou();
      lcd.setCursor(13, 3);lcd.print("      ");
      lcd.setCursor(13, 3);lcd.print(thoi_gian);
    }
  }
  else
  {
    menu_3();
    tat_bom();
    startTime = 0;
  }
}
// ------------------------------------------------------------------------------------------ ấn nút menu
int buttonMenu = digitalRead(button_menu);    //Đọc trạng thái button menu
if (buttonMenu == HIGH)
  {
    tone(buzzer, 3000);
    delay(100);
    noTone(buzzer);    
    if (buttonMenu == HIGH)
    {
      lcd.clear();
      switch(menu)
      {
        case 0:
        menu = 1;        
        menu_1();
        delay(100);
        break;
        
        case 1:
        menu = 2;        
        menu_2();
        delay(100);
        break;
        
        case 2:
        menu = 3;
        menu_3();
        delay(100);
        break;

        case 3:
        menu = 1;        
        menu_1();
        delay(100);
        break;
      }
    }
  }
  Serial.println("ket thuc");
}
          
void menu_1()
{  
  //lcd.setCursor(2, 0);
  //lcd.print("Rot ruou tu dong");
  lcd.setCursor(2, 0);
  lcd.print("Che do ");
  lcd.setCursor(9, 0);
  lcd.print(muc_ruou);
  lcd.setCursor(10, 0);
  lcd.print(":");
  lcd.setCursor(12, 0);
  lcd.print(string_muc_ruou);

  lcd.setCursor(2, 2);
  lcd.print("So chen: ");
  lcd.setCursor(11, 2);
  lcd.print(so_chen);
}

void menu_2()
{  
  lcd.setCursor(2, 0);
  lcd.print("Rot ruou tu dong");
  lcd.setCursor(8, 1); 
  lcd.print("---");
  lcd.setCursor(4, 2); 
  lcd.print("Che do bom:");
  lcd.setCursor(6, 3); 
  lcd.print("Nhan giu");  
}

void menu_3()
{  
  lcd.setCursor(1, 0);
  lcd.print("Cai dat thoi gian:");
  lcd.setCursor(8, 1); 
  lcd.print("---");
  lcd.setCursor(2, 2);
  lcd.print("Rot chen lam mau");
  lcd.setCursor(2, 3);
  lcd.print("Thoi gian: ");
  lcd.setCursor(13, 3);
  lcd.print(thoi_gian);
}

void bom_ruou()
{
  digitalWrite(motor2pin1, HIGH);
  digitalWrite(motor2pin2, LOW);
  analogWrite(enB, bamxung);
}
void tat_bom()
{
  digitalWrite(motor2pin1, LOW);
  digitalWrite(motor2pin2, LOW);
  analogWrite(enB, bamxung);
}
