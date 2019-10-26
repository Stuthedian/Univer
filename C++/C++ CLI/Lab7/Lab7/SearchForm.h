#pragma once
#include "Main.h"
namespace Lab7 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Сводка для SearchForm
	/// </summary>
	public ref class SearchForm : public System::Windows::Forms::Form
	{
		Main^ parent;
	public:
		SearchForm(Main^ parent)
		{
			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
			this->parent = parent;
		}

	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~SearchForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::ComboBox^  comboBox1;
	private: System::Windows::Forms::TextBox^  textBox1;
	private: System::Windows::Forms::Button^  button1;
	private: System::Windows::Forms::DataGridView^  dataGridView1;
	protected:

	protected:

	private:
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		void InitializeComponent(void)
		{
			this->comboBox1 = (gcnew System::Windows::Forms::ComboBox());
			this->textBox1 = (gcnew System::Windows::Forms::TextBox());
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->dataGridView1 = (gcnew System::Windows::Forms::DataGridView());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridView1))->BeginInit();
			this->SuspendLayout();
			// 
			// comboBox1
			// 
			this->comboBox1->DropDownStyle = System::Windows::Forms::ComboBoxStyle::DropDownList;
			this->comboBox1->FormattingEnabled = true;
			this->comboBox1->Location = System::Drawing::Point(18, 18);
			this->comboBox1->Margin = System::Windows::Forms::Padding(4, 5, 4, 5);
			this->comboBox1->Name = L"comboBox1";
			this->comboBox1->Size = System::Drawing::Size(180, 28);
			this->comboBox1->TabIndex = 0;
			this->comboBox1->SelectedIndexChanged += gcnew System::EventHandler(this, &SearchForm::comboBox1_SelectedIndexChanged);
			// 
			// textBox1
			// 
			this->textBox1->Location = System::Drawing::Point(205, 20);
			this->textBox1->Name = L"textBox1";
			this->textBox1->Size = System::Drawing::Size(180, 26);
			this->textBox1->TabIndex = 1;
			// 
			// button1
			// 
			this->button1->Location = System::Drawing::Point(258, 52);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(85, 27);
			this->button1->TabIndex = 2;
			this->button1->Text = L"Найти";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &SearchForm::button1_Click);
			// 
			// dataGridView1
			// 
			this->dataGridView1->AllowUserToAddRows = false;
			this->dataGridView1->AllowUserToDeleteRows = false;
			this->dataGridView1->ColumnHeadersHeightSizeMode = System::Windows::Forms::DataGridViewColumnHeadersHeightSizeMode::AutoSize;
			this->dataGridView1->Location = System::Drawing::Point(18, 97);
			this->dataGridView1->Name = L"dataGridView1";
			this->dataGridView1->ReadOnly = true;
			this->dataGridView1->Size = System::Drawing::Size(584, 150);
			this->dataGridView1->TabIndex = 3;
			// 
			// SearchForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(9, 20);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(651, 258);
			this->Controls->Add(this->dataGridView1);
			this->Controls->Add(this->button1);
			this->Controls->Add(this->textBox1);
			this->Controls->Add(this->comboBox1);
			this->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->Margin = System::Windows::Forms::Padding(4, 5, 4, 5);
			this->Name = L"SearchForm";
			this->Text = L"SearchForm";
			this->FormClosed += gcnew System::Windows::Forms::FormClosedEventHandler(this, &SearchForm::SearchForm_FormClosed);
			this->Load += gcnew System::EventHandler(this, &SearchForm::SearchForm_Load);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridView1))->EndInit();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void SearchForm_Load(System::Object^  sender, System::EventArgs^  e)
	{
		for (size_t i = 0; i < parent->dataGridView1->ColumnCount; i++)
		{
			if(i != 0)
				comboBox1->Items->Add(parent->dataGridView1->Columns[i]->HeaderText);
			dataGridView1->Columns->Add(parent->dataGridView1->Columns[i]->HeaderText,
				parent->dataGridView1->Columns[i]->HeaderText);
		}
		comboBox1->SelectedIndex = 0;
	}
	private: System::Void comboBox1_SelectedIndexChanged(System::Object^  sender, System::EventArgs^  e)
	{
		textBox1->Clear();
		textBox1->BackColor = SystemColors::Window;
	}
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e)
	{
		dataGridView1->Rows->Clear();
		if (textBox1->Text->Trim()->Length != 0)
		{
			int b;
			if (comboBox1->SelectedIndex == 3 && !Int32::TryParse(textBox1->Text, b))
			{
				textBox1->BackColor = Color::Red;
				return;
			}
			else
			{
				textBox1->BackColor = SystemColors::Window;
			}
			for (size_t i = 0; 
				i < parent->dataGridView1->RowCount-1; i++)
			{
				if (parent->dataGridView1->Rows[i]
				->Cells[comboBox1->SelectedIndex+1]->Value->ToString()->Contains(textBox1->Text->Trim()))
				{
					dataGridView1->Rows->Add(gcnew array<String^>(5)
					{parent->dataGridView1->Rows[i]->Cells[0]->Value->ToString(),
						parent->dataGridView1->Rows[i]->Cells[1]->Value->ToString(),
						parent->dataGridView1->Rows[i]->Cells[2]->Value->ToString(),
						parent->dataGridView1->Rows[i]->Cells[3]->Value->ToString(),
						parent->dataGridView1->Rows[i]->Cells[4]->Value->ToString()});
				}
			}
		}
	}
	private: System::Void SearchForm_FormClosed(System::Object^  sender, System::Windows::Forms::FormClosedEventArgs^  e)
	{
		parent->clear_child();
	}
};
}
