# -*- coding: cp949 -*- 
# 1. ���ڿ� �ٲٱ� (needs review)
a = "a:b:c:d"
a_result = ",".join(a.split(":"))
print("#1 answer is " + a_result)

# 2. ��ųʸ� �� �����ϱ�(needs review)
dict = {'A':90, 'B':80}
dict.get('C', 70)
print("#2 answer is")
print(dict)


# 4. ����Ʈ ���� ���ϱ�
grades = [20,55,67,82,45,33,90,87,100,25]
grade_over_50_sum = 0
for grade in grades:
    if grade >= 50:
        grade_over_50_sum += grade
        
print("#4 answer is " + str(grade_over_50_sum))

# 5. Fibonnaci �Լ�


# 6. ������ ���� ���ϱ�
numbers_input = input("���ڵ��� �Է��ϼ��� (,�� ����): ")
numbers_arr = numbers_input.split(",")
numbers_sum = 0;
for num in numbers_arr:
    numbers_sum += int(num)

print("#6 answer is " + str(numbers_sum))

#7 ���� ������
multiplier_input = input("�������� ����� ���ڸ� �Է��ϼ���(2-9): ")
print("#7 answer is: ")
for i in range(1,10):
    print(int(multiplier_input) * i, end=" ")