#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = nullptr);
    ~MainWindow();

private slots:
    void on_action_triggered();

    void on_actioncos_x_triggered();

    void on_actionx_3_triggered();

private:
    Ui::MainWindow *ui;
    const int size = 360;
    QVector <double> x,y;
};

#endif // MAINWINDOW_H
