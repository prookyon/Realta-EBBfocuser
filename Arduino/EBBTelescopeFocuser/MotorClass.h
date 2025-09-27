#include <EEPROM.h>
#include <TMCStepper.h>
#include "EEPROM_locations.h"

#define D_STEP_PIN PD0
#define D_UART_PIN PA15
#define D_ENABLE_PIN PD2
#define D_HEATER_PIN PB13


class Motor: public TMC2209Stepper
{
   public:
      Motor(Stream * SerialPort, float RS, uint8_t addr);
      void Halt();
      void SetMoveTarget(long Position);
      bool Move();
      void setHeaterPWM(byte HeaterValue);
      void engageMotor(bool Engage);
      byte CurrentHeaterValue;
      bool IsMoving;
      bool IsEngaged;
      long CurrentPosition;
      long MoveTarget;
      bool move_direction;
      int current;
      int steps;
	  long PulseLength;
};

Motor::Motor(Stream * SerialPort, float RS, uint8_t addr): TMC2209Stepper(SerialPort,  RS, addr) 
{
}



void Motor::Halt()
{
     IsMoving = false;
     EEPROM.put(EEPROM_OFFSET_POSITION, CurrentPosition);
}

void Motor::SetMoveTarget(long Position)
{
  if(CurrentPosition != Position)
  {
     IsMoving = true;
     MoveTarget = Position;
  }
}

bool Motor::Move()
{
          long difference;
          bool new_direction;
          difference = MoveTarget - CurrentPosition;

          if(!IsEngaged)
          {
            engageMotor(true);
          }
          
          if(difference == 0)
          {
            Halt();
            return false;
          }
          else
          {
            if(difference > 0)
            {
              new_direction = true;
              CurrentPosition = CurrentPosition + 1;
            }
            else
            {
              new_direction = false;
              CurrentPosition = CurrentPosition - 1;
            }

            if(new_direction != move_direction)
            {
              move_direction = new_direction;
              shaft(move_direction);   
            }
            
            digitalWrite(D_STEP_PIN, HIGH); // Raise voltage on this pin to VCC or 3.3v
            delayMicroseconds(PulseLength); // wait
            digitalWrite(D_STEP_PIN, LOW);
            delayMicroseconds(PulseLength); // wait

            return true;
            
          }
}

void Motor::setHeaterPWM(byte HeaterValue)
{
  analogWrite(D_HEATER_PIN, HeaterValue);
  CurrentHeaterValue = HeaterValue;
}

void Motor::engageMotor(bool Engage)
{
  IsEngaged = Engage;
  if(Engage)
  {
  digitalWrite(D_ENABLE_PIN, LOW);
  }
  else
  {
  digitalWrite(D_ENABLE_PIN, HIGH);
  }
}
