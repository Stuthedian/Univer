#include "widget.h"
#include "ui_widget.h"

Widget::Widget(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::Widget), Value(0)
{
    ui->setupUi(this);
}

Widget::~Widget()
{
    delete ui;
}

void Widget::slotInc()
{
    emit this->counterChanged(++Value);
    if(Value == 5) emit this->goodbye();
}

/*void Widget::on_pushButton_clicked()
{
    emit this->counterChanged(++Value);
    if(Value == 5) emit this->goodbye();
}*/

void Widget::toggleConnection()
{
    if(ui->pushButton->signalsBlocked())
    {
        ui->pushButton->blockSignals(false);
        ui->pushButton_2->setText("Disconnect");
    }
    else
    {
        ui->pushButton->blockSignals(true);
        ui->pushButton_2->setText("Connect");
    }
}
/*
void Widget::on_pushButton_2_clicked()
{
    if(ui->pushButton->signalsBlocked())
    {
        ui->pushButton->blockSignals(false);
        ui->pushButton_2->setText("Disconnect");
    }
    else
    {
        ui->pushButton->blockSignals(true);
        ui->pushButton_2->setText("Connect");
    }

}*/
