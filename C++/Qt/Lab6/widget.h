#ifndef WIDGET_H
#define WIDGET_H

#include <QWidget>
#include <QValidator>
#include <QStringListModel>
#include <QtGui>
#include <QListView>
#include <QMessageBox>
#include "ipdelegate.h"




namespace Ui {
class Widget;
}

class Widget : public QWidget
{
    Q_OBJECT

public:
    explicit Widget(QWidget *parent = nullptr);
    ~Widget();

private slots:
    void on_AddButton_clicked();

    void on_EditButton_clicked();

    void on_DeleteButton_clicked();

    void on_SortButton_clicked();

    void on_FindButton_clicked();

    void checkUniqueItem(QWidget* editor);
signals:
    void tryToWriteItem(bool on);

private:
    Ui::Widget *ui;
    QStringListModel* Model;
    inline bool isUnique(QString &text, QAbstractItemView* view);
};

#endif // WIDGET_H
