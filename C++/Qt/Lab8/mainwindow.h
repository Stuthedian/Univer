#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QFileDialog>
#include <QPainter>
#include <QMouseEvent>
#include <QPixmap>
#include <QMessageBox>

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = nullptr);
    ~MainWindow();
protected:
void paintEvent(QPaintEvent *);
void mousePressEvent( QMouseEvent * event );

private slots:
void on_action_triggered();

void on_action_2_triggered();

void on_action_3_triggered();

void on_action_4_triggered();

private:
    Ui::MainWindow *ui;
    QPainter painter;
     QImage img;
     enum mouseaction{None, Click, Paint} m_act;
     int x1, y1, x2, y2;
};

#endif // MAINWINDOW_H
