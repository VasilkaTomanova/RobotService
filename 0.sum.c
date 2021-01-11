/*Декларирайте функция, която събира две числа и връща резултата им:*/

#include <stdio.h>
int returnSumOfTwoDigits(int firstNumber, int secdonNumber);

int main(){
    int a,b,result;
    a = 10;
    b = 32;
    result = returnSumOfTwoDigits(a,b);
    printf("%d",result);
    return 0;
}

int returnSumOfTwoDigits(int firstNumber, int secdonNumber){
    int result = firstNumber + secdonNumber;
    return result;
}