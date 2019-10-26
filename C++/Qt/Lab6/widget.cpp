#include "widget.h"
#include "ui_widget.h"

Widget::Widget(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::Widget)
{
    ui->setupUi(this);
    IpDelegate *myDelegate = new IpDelegate(this);
    Model = new QStringListModel(this);
    ui->listView->setModel(Model);
    ui->listView->setItemDelegate(myDelegate);
    connect(myDelegate, SIGNAL(closeEditor(QWidget*)), this, SLOT(checkUniqueItem(QWidget*)));
     //связываем сигнал закрытия редактора со слотом проверки
    connect(this, SIGNAL(tryToWriteItem(bool)), myDelegate, SLOT(setUnique(bool)));
     //для передачи в делегат булевой переменной
}

Widget::~Widget()
{
    delete ui;
}

void Widget::on_AddButton_clicked()
{
    int row = Model->rowCount(); // в числовую переменную заносим общее количество строк
    Model->insertRows(row, 1); // добавляем строки, количеством 1 шт.
    QModelIndex index = Model->index(row); // создаем ссылку на элемент модели
    ui->listView->setCurrentIndex(index); // передаем этот индекс ListView
    ui->listView->edit(index); // переводим курсор на указанную позицию для ожидания ввода данных
}

void Widget::on_EditButton_clicked()
{
    QModelIndex index = ui->listView->currentIndex();
     ui->listView->edit(index);
}

void Widget::on_DeleteButton_clicked()
{
    QModelIndex index = ui->listView->currentIndex();
    Model->removeRow(index.row());
    ui->listView->setCurrentIndex(index.row() != Model->rowCount() ?
      index : Model->index(index.row()-1));
}

void Widget::on_SortButton_clicked()
{
    Model->sort(0);
}

void Widget::on_FindButton_clicked()
{
    QMessageBox msgBox;
    QString str = "Найдены совпадения:\n";
    int a = str.count();
    QStringListModel* model = static_cast<QStringListModel*>(ui->listView->model());
    if(ui->lineEdit->text().trimmed() == "") return;
    for (int i=0; i<model->rowCount(); i++) {
     if (model->data(model->index(i), Qt::DisplayRole).toString().contains(ui->lineEdit->text()))
     {
        str += model->data(model->index(i), Qt::DisplayRole).toString() + '\n';
     }
    }
    if(str.count() == a)
        str = "Совпадений не найдено!";
    msgBox.setWindowTitle("Поиск");
    msgBox.setText(str);
    msgBox.exec();
}

bool Widget::isUnique(QString &text, QAbstractItemView *view) {
 //метод, проверяющий уникальность элемента
 int item = view->currentIndex().row();
 QStringListModel* model = static_cast<QStringListModel*>(view->model());
 for (int i=0; i<model->rowCount(); i++) {
  if (i != item)
   if (model->data(model->index(i), Qt::DisplayRole).toString() == text)
    return false;
 }
 return true;
}


void Widget::checkUniqueItem(QWidget *editor) {
 //qDebug() << "CLOSE EDITOR";
 QString text = static_cast<QLineEdit*>(editor)->text();
 emit tryToWriteItem(isUnique(text, ui->listView));
  //сигнал делегату, isUnique(text, catView) - результат проверки
}
