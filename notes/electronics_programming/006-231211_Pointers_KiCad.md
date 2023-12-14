# 006-231211 Pointers, KiCad Installation

# Installations
- KiCAD
	- for drawing circuit diagrams
	- 파일 => 회로도 설정 => 전기규칙 => 위반사항 심각도 => 입력핀이 출력핀에 의해 구동 되지 않음 (무시체크)
	- https://docs.kicad.org/7.0/en/getting_started_in_kicad/getting_started_in_kicad.html

# C programming

- `*(&a) = 100` is the same as `a = 100`
- printf `%lf` to show floating points
  - `%0.3f` to third decimal point


```
	// 3 objects, 10 characters(bytes) each
	char city[3][10] = {
		"Seoul", "Jeju", "Incheon"
	};
	
	char* ptcity[3];
	
	ptcity[0] = city[0];
	ptcity[1] = city[1];
	ptcity[2] = city[2];
	
	printf("%s\n", ptcity[0]); // Seoul
	printf("%s\n", ptcity[1]); // Jeju
	printf("%s\n", ptcity[2]); // Incheon

```

```
void swap(int *A, int *B) {

		int tmp;
		tmp = *A; // save the data of A to temporary space;
		*A = *B; // save data of B to A's dataspace;
		*B = tmp; // save the original A's data to B's dataspace

}

int main(int argc, char *argv[])
{
	int a = 20;
	int b= 50;
	swap(&a,&b);
	printf("%d   %d", a,b);
}

```

```
int main(int argc, char *argv[])
{
	int num = 20;
	int* pnum = &num; // * means pointer variable that saves address
	int** ppnum = &pnum; // ** means pointer variable that saves the address of another pointer variable
    // & means "get the address of that variable"

	// **ppnum == 20
	// *ppnum == &num
	// &ppnum == address of ppnum
	// ppnum == &pnum
}

```

# Electronics

- 산업용 보통 24V DC 사용. 가끔 48V도 사용.

```
diode in circuit diagram looks like
anode                  cathode (the "-" part of led diode; short leg)
            xx     x
            xxx    x
            x xxx  x
            x   xx x
 xxxxxxxxxxxx    xxxxxxxxxxxxx
            x    xxx
            x  xxx x
            x xx   x
            xx     x
```
used ascii flow to generate ascii diagram



