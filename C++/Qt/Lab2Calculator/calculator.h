#ifndef CALCULATOR_H
#define CALCULATOR_H

#include <QWidget>
 #include <QStack>
 #include <QLabel>
 #include <QPushButton>
 #include <QGridLayout>
#include <QtMath>
#include <QKeyEvent>
#include <Qt>



class Calculator : public QWidget
{
    Q_OBJECT
private:
    QLabel *displaystring;
   QStack <QString> stack;
protected:
   virtual void keyPressEvent(QKeyEvent *event);
public:
    explicit Calculator(QWidget *parent = 0);
   QPushButton* createButton (const QString& str);
      void calculate ();
signals:

public slots:
      void slotButtonClicked ();
};

#endif // CALCULATOR_H
