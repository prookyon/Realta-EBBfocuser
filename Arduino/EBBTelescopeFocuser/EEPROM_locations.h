#pragma once
#define EEPROM_OFFSET_FIRSTRUN 0 // byte, value of 6 means it has been run before
#define EEPROM_OFFSET_POSITION 1 // long, current position of the focuser
#define EEPROM_OFFSET_CURRENT 10 // int, motor current in mA
#define EEPROM_OFFSET_MICROSTEPS 20 // int, micro steps setting of the motor driver
#define EEPROM_OFFSET_PULSELENGTH 30 // long, pulse length in microseconds