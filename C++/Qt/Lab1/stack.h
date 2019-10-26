#ifndef STACK_H
#define STACK_H


class Stack
{
public:
    Stack(int size);
    ~Stack();
    void push(int number);
    void pop();
    void print();
private:
    int* numbers;
    int curr_size;
    const int size;
};

#endif // STACK_H
