# -*- coding: cp949 -*- 
# 1. 문자열 바꾸기
a = "a:b:c:d"
a_result = ",".join(a.split(":"))
print("#1 answer is " + a_result)

# 2. 딕셔너리 값 추출하기
"""
.get method returns None if the key doesn't exist. dict['C'] would throw error.
use .get('somekey', 'default value') to return default value when there's no key.
"""
"""
https://stackoverflow.com/questions/8957750/what-are-dictionary-view-objects
Explains why .keys, .values, .items methods returning dictionary view objects in Python 3 is more efficient than
returning lists.
"""

dict = {'A':90, 'B':80}
dict.get('C', 70) 
print("#2 answer is")
print(dict)

# 3. 리스트에서 + 로 concat 하기 vs extend 로 하기
"""
a = [1,2]
id(a) <- find address of array
using a += [3,4] allocates new memory space and saves concatenated array there, then labels it as "a".

a.extend([3,4])
does not allocate new memory space, just adds the elements into the existing memory address holding the list.

"""

# 4. 리스트 총합 구하기
grades = [20,55,67,82,45,33,90,87,100,25]
grade_over_50_sum = 0
for grade in grades:
    if grade >= 50:
        grade_over_50_sum += grade
        
print("#4 answer is " + str(grade_over_50_sum))

# 5. Fibonnaci 함수
## 0, 1, 1, 2, 3, 5, 8, 13 ...
fibonnaci_input = int(input("n 항 이하까지의 피보나치 수열을 출력합니다: "))
def fib(n):
    if n == 0 : return 0
    if n == 1 : return 1
    return fib(n-2) + fib(n-1)

for i in range(0, fibonnaci_input):
    print(fib(i))


# 6. 숫자의 총합 구하기
numbers_input = input("숫자들을 입력하세요 (,로 나눔): ")
numbers_arr = numbers_input.split(",")
numbers_sum = 0
for num in numbers_arr:
    numbers_sum += int(num)

print("#6 answer is " + str(numbers_sum))

# 7. 한줄 구구단
multiplier_input = input("구구단을 출력할 숫자를 입력하세요(2-9): ")
print("#7 answer is: ")
for i in range(1,10):
    print(int(multiplier_input) * i, end=" ")

# 8. 파일을 읽어 역순으로 저장하기



# 9. 평균값 구하기