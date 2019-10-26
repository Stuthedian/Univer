#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    m_act = mouseaction::None;
    x1 = y1 = x2 = y2 = -1;
}

MainWindow::~MainWindow()
{
    delete ui;
}
void MainWindow::paintEvent(QPaintEvent *event) {
    painter.begin(this);
    painter.setPen(QPen(Qt::red,Qt::SolidLine));
    painter.setBrush(QBrush(Qt::green,Qt::SolidPattern));
    if(!img.isNull())
    {
        //QImage img(width(),height(),QImage::Format_RGB32);
        painter.drawImage(0,0,img.scaled(width(), height()));
    }
    if(x1 != -1 && x2 != -1)
    {
        painter.drawRect(x1, y1, x2-x1, y2-y1);
        //if(m_act == mouseaction::Paint) m_act = mouseaction::None;
    }
    painter.end();
}

void MainWindow::mousePressEvent( QMouseEvent * event )
{
    switch (m_act) {
    case mouseaction::Click:
    {
        if(event->button() == Qt::LeftButton)
        {
           //QColor clr = QColor::fromRgb(QPixmap::grabWidget(this).toImage().pixel(event->x(), event->y()));
           QColor clr = QColor::fromRgb(QWidget::grab().toImage().pixel(event->x(), event->y()));
           QMessageBox msgBox;
           msgBox.setText(QString("Red: ")+ QString::number(clr.red())
                          + " Green: " +QString::number(clr.green())
                          + " Blue: " + QString::number(clr.blue()));
           msgBox.exec();
        }
        m_act = mouseaction::None;
    }break;
    case mouseaction::Paint:
    {
        if(x1 == -1)
        {
            x1 = event->x();
            y1 = event->y();
            //x2 = y2 = -1;
        }
        else if(x2 == -1)
        {
            x2 = event->x();
            y2 = event->y();
            this->repaint();
        }

    }break;
    default: break;
    }

}

void MainWindow::on_action_triggered()
{
    //QFileDialog dialog(this);
    //dialog.exec();

    //img.load("D:\\Users\\dnevalniy\\Documents\\шеш\\zWfS46EcwwI.jpg");

    QString fileName = QFileDialog::getOpenFileName(this,
      tr("Открыть изображение"), "D:\\Users\\dnevalniy\\Documents\\шеш", tr("Image Files (*.png *.jpg *.bmp)"));
    img.load(fileName);
this->repaint();
}

void MainWindow::on_action_2_triggered()
{
    x1 = y1 = x2 = y2 = -1;
    m_act = mouseaction::Paint;
}

void MainWindow::on_action_3_triggered()
{
    m_act = mouseaction::Click;
}

void MainWindow::on_action_4_triggered()
{
    QString fileName = QFileDialog::getSaveFileName(this,
           tr("Сохранить изображение"), "",
           tr("Image Files (*.png *.jpg *.bmp)"));
    QWidget::grab().toImage().save(fileName);
}
