# 003 - C Basics

- 전처리기
	- #include <iostream> 등 파일 윗부분에 있는 부분.
	- 다른 파일에 있는 기능을 사용하기 위함.
- `const double xxx = ` const in C means the value is fixed, unlike in JS where it means the address of the variable is fixed. After const declaration the variable turns read-only.
- Logic operations on numbers i.e 10 | 20 is done bitwise (10, 20 represented in bits). The result is the sum of each bit places' values after logic operation.
	- `&` is AND operation
	- `|` is OR operation
	- `^` is XOR operation
	- `~` is NOT operation

Learning resource: https://developerinsider.co/c-and-cpp-insider/

- `int num[][3]`
	- can ommit sizing row array; can be automatically assigned based on column array size and the size of the data
	- column array size can't be omitted
- `continue` keyword
	- when used inside an if statement within a while loop, it means to stop executing lines below and go back up to beginning of while loop, then continue on with the loop again.

- atoi() turns string into int
	- need `#include <stdlib.h>`
- can escape percentage sign by `%%`
- array is in the format of `int arr[10] = { 1, 2, 3...}`;
- array length is `int arrLength = sizeof(arr) / sizeof(arr[0]);`
- can find memory address by `printf("%p", &arr[0])`
	- an outdated way to express it is `*arr` = `&arr[0]` or `*arr + 1` = `&arr[1]`

## Pointers
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