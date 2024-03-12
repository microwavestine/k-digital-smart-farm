# Pi vs STM32
- Both 32bit Arm
- differs in hardware capability and software eco system
- STM32 = microcontroller ARM Cortex-M
- Pi = MPU ARM Cortex-A aka SoC w/ microprocessor has MMU
## 32bit Arm
- those that can run linux
  - MMU (allow virtual memory)
  - 256M+ RAM
  - 512M+ Flash
  - easier to develop on, has more capable system in networking and graphics
  - requires DRAM, which is external rather than on chip SRAM -> power hungry
  - Linux is not OS optimized for realtime
- those that can't run linux
  - no MMU
  - RAM and Flash in KB


# ESP32 vs STM32
https://medium.com/@khantalha7367/esp32-vs-stm32f103c8t6-d8c2cd6e377b