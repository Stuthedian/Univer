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
#include <QMenu>
#include <QClipboard>
#include <QApplication>
#include <QMimeData>



class Calculator : public QWidget
{
    Q_OBJECT
private:
    QLabel *displaystring;
   QStack <QString> stack;
   QMenu* m_pmnu;
protected:
   virtual void keyPressEvent(QKeyEvent *event);
   virtual void mousePressEvent (QMouseEvent *);
public:
    explicit Calculator(QWidget *parent = 0);
   QPushButton* createButton (const QString& str);
      void calculate ();
signals:

public slots:
      void slotButtonClicked ();
      void slotActivated(QAction* pAction);
};

#endif // CALCULATOR_H
