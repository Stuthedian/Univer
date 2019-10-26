#include "stack.h"
#include <iostream>

Stack::Stack(int size): size(size)
{
   numbers = new int[this->size];
   curr_size = 0;
   std::cout << "Stack created\n";
}
Stack::~Stack()
{
    delete[] numbers;
}

void Stack::push(int number)
{
    if(curr_size >= size)
    {
        std::cout << "Can not push. Stack is full\n";
        return;
    }
    numbers[curr_size] = number;
    curr_size++;
    std::cout << "Pushed number " << number <<" \n";
}

void Stack::pop()
{
    if(curr_size <= 0)
    {
        std::cout << "Can not pop. Stack is empty\n";
        return;
    }
    std::cout << "Poped number " << numbers[--curr_size] <<" \n";
    return;
}

void Stack::print()
{
    if(curr_size <= 0)
        std::cout << "Stack is empty\n";
    else
    {
        for(int i = 0; i < curr_size; i++)
        {
            std::cout << "Stack[" << i << "]\t" << numbers[i] << '\n';
        }
    }
}
