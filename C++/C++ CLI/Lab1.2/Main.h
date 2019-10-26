#pragma once

namespace Lab11 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Сводка для Main
	/// </summary>
	public ref class Main : public System::Windows::Forms::Form
	{
	public:
		Main(void)
		{
			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
		}

	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~Main()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Panel^  panel1;
	protected:
	private: System::Windows::Forms::Label^  label3;
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Button^  button1;
	private: System::Windows::Forms::NumericUpDown^  Minnumeric;
	private: System::Windows::Forms::NumericUpDown^  Maxnumeric;
	private: System::Windows::Forms::NumericUpDown^  Stepnumeric;
	private: System::Windows::Forms::TextBox^  textBox1;
	private: System::Windows::Forms::ComboBox^  comboBox1;
	private: System::Windows::Forms::Panel^  panel2;

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
			this->panel1 = (gcnew System::Windows::Forms::Panel());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->Minnumeric = (gcnew System::Windows::Forms::NumericUpDown());
			this->Maxnumeric = (gcnew System::Windows::Forms::NumericUpDown());
			this->Stepnumeric = (gcnew System::Windows::Forms::NumericUpDown());
			this->textBox1 = (gcnew System::Windows::Forms::TextBox());
			this->comboBox1 = (gcnew System::Windows::Forms::ComboBox());
			this->panel2 = (gcnew System::Windows::Forms::Panel());
			this->panel1->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->Minnumeric))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->Maxnumeric))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->Stepnumeric))->BeginInit();
			this->panel2->SuspendLayout();
			this->SuspendLayout();
			// 
			// panel1
			// 
			this->panel1->Controls->Add(this->label3);
			this->panel1->Controls->Add(this->label2);
			this->panel1->Controls->Add(this->label1);
			this->panel1->Controls->Add(this->button1);
			this->panel1->Controls->Add(this->Minnumeric);
			this->panel1->Controls->Add(this->Maxnumeric);
			this->panel1->Controls->Add(this->Stepnumeric);
			this->panel1->Dock = System::Windows::Forms::DockStyle::Top;
			this->panel1->Location = System::Drawing::Point(0, 0);
			this->panel1->Name = L"panel1";
			this->panel1->Size = System::Drawing::Size(419, 95);
			this->panel1->TabIndex = 0;
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Location = System::Drawing::Point(179, 30);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(27, 13);
			this->label3->TabIndex = 7;
			this->label3->Text = L"Шаг";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(12, 45);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(22, 13);
			this->label2->TabIndex = 6;
			this->label2->Text = L"До";
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(12, 14);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(20, 13);
			this->label1->TabIndex = 5;
			this->label1->Text = L"От";
			// 
			// button1
			// 
			this->button1->Location = System::Drawing::Point(338, 25);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(75, 23);
			this->button1->TabIndex = 4;
			this->button1->Text = L"Вычислить";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &Main::button1_Click);
			// 
			// Minnumeric
			// 
			this->Minnumeric->Location = System::Drawing::Point(53, 12);
			this->Minnumeric->Name = L"Minnumeric";
			this->Minnumeric->Size = System::Drawing::Size(120, 20);
			this->Minnumeric->TabIndex = 1;
			// 
			// Maxnumeric
			// 
			this->Maxnumeric->Location = System::Drawing::Point(53, 43);
			this->Maxnumeric->Name = L"Maxnumeric";
			this->Maxnumeric->Size = System::Drawing::Size(120, 20);
			this->Maxnumeric->TabIndex = 2;
			// 
			// Stepnumeric
			// 
			this->Stepnumeric->Location = System::Drawing::Point(212, 26);
			this->Stepnumeric->Name = L"Stepnumeric";
			this->Stepnumeric->Size = System::Drawing::Size(120, 20);
			this->Stepnumeric->TabIndex = 3;
			// 
			// textBox1
			// 
			this->textBox1->Location = System::Drawing::Point(0, 95);
			this->textBox1->Multiline = true;
			this->textBox1->Name = L"textBox1";
			this->textBox1->Size = System::Drawing::Size(290, 386);
			this->textBox1->TabIndex = 1;
			// 
			// comboBox1
			// 
			this->comboBox1->DropDownStyle = System::Windows::Forms::ComboBoxStyle::DropDownList;
			this->comboBox1->FormattingEnabled = true;
			this->comboBox1->Items->AddRange(gcnew cli::array< System::Object^  >(3) { L"pi", L"e", L"золотое сечение" });
			this->comboBox1->Location = System::Drawing::Point(5, 6);
			this->comboBox1->Name = L"comboBox1";
			this->comboBox1->Size = System::Drawing::Size(121, 21);
			this->comboBox1->TabIndex = 8;
			// 
			// panel2
			// 
			this->panel2->Controls->Add(this->comboBox1);
			this->panel2->Dock = System::Windows::Forms::DockStyle::Right;
			this->panel2->Location = System::Drawing::Point(290, 95);
			this->panel2->Name = L"panel2";
			this->panel2->Size = System::Drawing::Size(129, 164);
			this->panel2->TabIndex = 2;
			// 
			// Main
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(419, 259);
			this->Controls->Add(this->panel2);
			this->Controls->Add(this->textBox1);
			this->Controls->Add(this->panel1);
			this->Name = L"Main";
			this->Text = L"Main";
			this->Load += gcnew System::EventHandler(this, &Main::Main_Load);
			this->panel1->ResumeLayout(false);
			this->panel1->PerformLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->Minnumeric))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->Maxnumeric))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->Stepnumeric))->EndInit();
			this->panel2->ResumeLayout(false);
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e)
	{
		if ((int)Stepnumeric->Value == 0)
		{
			MessageBox::Show("Некорректное значение шага!");
			return;
		}
		else if ((int)Minnumeric->Value > (int)Maxnumeric->Value)
		{
			MessageBox::Show("Значение поля \"От\" не должно превышать значение поля \"До\"!");
			return;
		}
		double n;
		switch (comboBox1->SelectedIndex)
		{
			case 0:n = Math::PI;  break;
			case 1:n = Math::E; break;
			case 2:n = (1 + Math::Sqrt(5)) / 2; break;
			default:break;
		}
		textBox1->Clear();
		String ^S = gcnew String (' ',100);
		for (int i=(int)Minnumeric->Value;i<=(int)Maxnumeric->Value; i+= (int)Stepnumeric->Value) 
		{
			S = String::Format ("{0,-10} {1,10}",i.ToString(),Math::Round(i*n,3).ToString());
			
			textBox1->AppendText(S + Environment::NewLine);
		}
		delete S;
	}
private: System::Void Main_Load(System::Object^  sender, System::EventArgs^  e)
{
	comboBox1->SelectedIndex = 0;
}
};
}
