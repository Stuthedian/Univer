#include <QCoreApplication>
#include <QtCore>
#include <iostream>

void foo1()
{
    QQueue<int> Queue1, Queue2;
    Queue1 << 1 << 2 << 45 << 78 << 90;
    Queue2 << 3 << 2 << 8 << 78 << 22;
    qDebug() << Queue1;
    qDebug() << Queue2;
    qDebug() << Queue1.toSet().intersect(Queue2.toSet());
}

void foo2()
{
    int x;
    QStack<int>  St, St1, St2;
    St << 12 << 67 << 34 << 28 << 321 << 55;
    std::cout << "Enter a number\n";
    std::cin  >> x;
    qDebug() << St;
    qSort(St);
    int i = 0;
    for(;i < St.count();i++)
    {
        if(St[i] < x)
            St1.push_back(St[i]);
        else break;
    }
    for(;i < St.count();i++)
    {
        St2.push_back(St[i]);
    }
    qDebug() << St1;
    qDebug() << St2;
}

int main(int argc, char *argv[])
{
    //foo1();
    //foo2();
    return 0;
}


