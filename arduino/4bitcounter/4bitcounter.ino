
void setup() {
  pinMode(7, OUTPUT);
  pinMode(8, OUTPUT);
  pinMode(9, OUTPUT);
  pinMode(10, OUTPUT);
}

void loop() {
  for(int i = 0; i < 16; ++i) {
    binaryCount(i);
    delay(1000);
  }
}

void binaryCount(int i) {

digitalWrite(10, (i >> 3) & 0x1 ); // same as  i/8%2
digitalWrite(9, (i >> 2) & 0x1); // same as i/4%2
digitalWrite(8, (i >> 1) & 0x1); // same as i/2%2
digitalWrite(7, i & 0x1); // same as i%2
}

// void f(unsigned int x)
// {
//    printf("%u%u%u%u\n",
//           (x>>3)&0x1,
//           (x>>2)&0x1,
//           (x>>1)&0x1,
//           x&0x1);
//    if(x==0xF) return;
//    else f(x+1);
// }

// int main(void)
// {
//     f(0);
// }
// $ ./test
// 0000
// 0001
// 0010
// 0011
// 0100
// 0101
// 0110
// 0111
// 1000
// 1001
// 1010
// 1011
// 1100
// 1101
// 1110
// 1111


