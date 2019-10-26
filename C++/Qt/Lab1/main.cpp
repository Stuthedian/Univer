#include <QCoreApplication>
#include "stack.h"
#include <iostream>
#include <string>
int main(int argc, char *argv[])
{
    /*QCoreApplication a(argc, argv);
    return a.exec();*/
    int n;
    bool loop = true;
    std::string command;

    std::cout << "Make Stack\n";
    std::cin >> n;
    Stack st(n);
    while(loop)
    {
        std::cin >> command;
        if(command == "quit")   loop = false;
        else if(command == "print")
        {
            st.print();
        }
        else if(command == "push")
        {
            std::cout << "Enter a number\n";
            std::cin >> n;
            st.push(n);
        }
        else if(command == "pop")
        {
            st.pop();
        }
        else std::cout << "Unknown command\n";
    }
    std::cout << "Press enter to quit\n";
    return 0;
}
