#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    x.resize(size);
    y.resize(size);
    ui->centralWidget->addGraph();
    ui->centralWidget->xAxis->setLabel("Ось x");
    ui->centralWidget->xAxis->setRange(0,size); //1
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_action_triggered()
{
         for (int i=0; i<size; i++) {
          x[i] = i;
          y[i] = sin(qDegreesToRadians(x[i]));
         }
         ui->centralWidget->graph(0)->setData(x,y);
         ui->centralWidget->yAxis->setLabel("sin(x)");
         ui->centralWidget->yAxis->setRange(-1,1);
         //4. Показать всё это:
         ui->centralWidget->replot();
}

int GetNod(int ch,int zn) { //Найти НОД
 return (ch ? GetNod(zn%ch,ch) : zn);
 }

QString ClipFraction (int ch,int zn) { //Сократить, если есть НОД>1
 int nod = GetNod(ch,zn);
 if (nod>1) { ch/=nod; zn/=nod; }
 QString result;
 if (ch==0) result.setNum(0);
 else if (ch==zn) result.setNum(1);
 else if (zn==1) result.setNum(ch);
 else result = QString("%1/%2").arg(ch).arg(zn);
 return result;
}


void MainWindow::on_actioncos_x_triggered()
{
    for (int i=0; i<size; i++) {
     x[i] = i;
     y[i] = cos(qDegreesToRadians(x[i]));
    }
    ui->centralWidget->graph(0)->setData(x,y);
    ui->centralWidget->yAxis->setLabel("cos(x)");
    ui->centralWidget->yAxis->setRange(-1,1);
    ui->centralWidget->replot();
}

void MainWindow::on_actionx_3_triggered()
{
    ui->centralWidget->xAxis->setRange(0,10);
    for (int i=0; i<size; i++) {
     x[i] = i;
     y[i] = x[i]*x[i]*x[i];
    }

    ui->centralWidget->graph(0)->setData(x,y);
    ui->centralWidget->yAxis->setLabel("x^3");
    ui->centralWidget->yAxis->setRange(0,100);
    ui->centralWidget->replot();
}
