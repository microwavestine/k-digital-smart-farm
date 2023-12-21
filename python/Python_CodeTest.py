# -*- coding: cp949 -*- 
# 1. ���ڿ� �ٲٱ�
a = "a:b:c:d"
a_result = ",".join(a.split(":"))
print("#1 answer is " + a_result)

# 2. ��ųʸ� �� �����ϱ�
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

# 3. ����Ʈ���� + �� concat �ϱ� vs extend �� �ϱ�
"""
a = [1,2]
id(a) <- find address of array
using a += [3,4] allocates new memory space and saves concatenated array there, then labels it as "a".

a.extend([3,4])
does not allocate new memory space, just adds the elements into the existing memory address holding the list.

"""

# 4. ����Ʈ ���� ���ϱ�
grades = [20,55,67,82,45,33,90,87,100,25]
grade_over_50_sum = 0
for grade in grades:
    if grade >= 50:
        grade_over_50_sum += grade
        
print("#4 answer is " + str(grade_over_50_sum))

# 5. Fibonnaci �Լ�
## 0, 1, 1, 2, 3, 5, 8, 13 ...
fibonnaci_input = int(input("n �� ���ϱ����� �Ǻ���ġ ������ ����մϴ�: "))
def fib(n):
    if n == 0 : return 0
    if n == 1 : return 1
    return fib(n-2) + fib(n-1)

for i in range(0, fibonnaci_input):
    print(fib(i))


# 6. ������ ���� ���ϱ�
numbers_input = input("���ڵ��� �Է��ϼ��� (,�� ����): ")
numbers_arr = numbers_input.split(",")
numbers_sum = 0
for num in numbers_arr:
    numbers_sum += int(num)

print("#6 answer is " + str(numbers_sum))

# 7. ���� ������
multiplier_input = input("�������� ����� ���ڸ� �Է��ϼ���(2-9): ")
print("#7 answer is: ")
for i in range(1,10):
    print(int(multiplier_input) * i, end=" ")

# 8. ������ �о� �������� �����ϱ�



# 9. ��հ� ���ϱ�