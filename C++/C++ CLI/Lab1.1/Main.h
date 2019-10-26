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
	private: System::Windows::Forms::TextBox^  textBox1;
	private: System::Windows::Forms::Label^  SignLabel;
	private: System::Windows::Forms::Label^  OperandLabel;
	private: System::Windows::Forms::Button^  Mulbutton;
	private: System::Windows::Forms::Button^  Equalbutton;
	private: System::Windows::Forms::Button^  Clearbutton;
	private: System::Windows::Forms::Button^  Addbutton;
	private: System::Windows::Forms::Button^  Divbutton;
	private: System::Windows::Forms::Button^  Subbutton;
	private: System::Windows::Forms::MenuStrip^  menuStrip1;
	private: System::Windows::Forms::ToolStripMenuItem^  файлToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  выйтиToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  правкаToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  копироватьToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  вставитьToolStripMenuItem;
	private: System::Windows::Forms::ToolStripSeparator^  toolStripMenuItem1;
	private: System::Windows::Forms::ToolStripMenuItem^  очиститьToolStripMenuItem;
	private: System::Windows::Forms::Button^  CelstoFahrbutton;
	private: System::Windows::Forms::Button^  FahrtoCelsbutton;
	private: System::Windows::Forms::ToolStripMenuItem^  вычислитьToolStripMenuItem;
	private: System::Windows::Forms::ContextMenuStrip^  contextMenuStrip1;
	private: System::Windows::Forms::ToolStripMenuItem^  копироватьToolStripMenuItem1;
	private: System::Windows::Forms::ToolStripMenuItem^  вставитьToolStripMenuItem1;
	private: System::Windows::Forms::ToolStripSeparator^  toolStripMenuItem2;
	private: System::Windows::Forms::ToolStripMenuItem^  вычислитьToolStripMenuItem1;
	private: System::Windows::Forms::ToolStripMenuItem^  очиститьToolStripMenuItem1;
	private: System::Windows::Forms::ToolStripSeparator^  toolStripMenuItem3;
	private: System::Windows::Forms::ToolStripMenuItem^  выйтиToolStripMenuItem1;


	private: System::ComponentModel::IContainer^  components;

	protected:

	private:
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>


#pragma region Windows Form Designer generated code
		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		void InitializeComponent(void)
		{
   this->components = (gcnew System::ComponentModel::Container());
   this->textBox1 = (gcnew System::Windows::Forms::TextBox());
   this->SignLabel = (gcnew System::Windows::Forms::Label());
   this->OperandLabel = (gcnew System::Windows::Forms::Label());
   this->Mulbutton = (gcnew System::Windows::Forms::Button());
   this->Equalbutton = (gcnew System::Windows::Forms::Button());
   this->Clearbutton = (gcnew System::Windows::Forms::Button());
   this->Addbutton = (gcnew System::Windows::Forms::Button());
   this->Divbutton = (gcnew System::Windows::Forms::Button());
   this->Subbutton = (gcnew System::Windows::Forms::Button());
   this->menuStrip1 = (gcnew System::Windows::Forms::MenuStrip());
   this->файлToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
   this->выйтиToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
   this->правкаToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
   this->копироватьToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
   this->вставитьToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
   this->toolStripMenuItem1 = (gcnew System::Windows::Forms::ToolStripSeparator());
   this->вычислитьToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
   this->очиститьToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
   this->CelstoFahrbutton = (gcnew System::Windows::Forms::Button());
   this->FahrtoCelsbutton = (gcnew System::Windows::Forms::Button());
   this->contextMenuStrip1 = (gcnew System::Windows::Forms::ContextMenuStrip(this->components));
   this->копироватьToolStripMenuItem1 = (gcnew System::Windows::Forms::ToolStripMenuItem());
   this->вставитьToolStripMenuItem1 = (gcnew System::Windows::Forms::ToolStripMenuItem());
   this->toolStripMenuItem2 = (gcnew System::Windows::Forms::ToolStripSeparator());
   this->вычислитьToolStripMenuItem1 = (gcnew System::Windows::Forms::ToolStripMenuItem());
   this->очиститьToolStripMenuItem1 = (gcnew System::Windows::Forms::ToolStripMenuItem());
   this->toolStripMenuItem3 = (gcnew System::Windows::Forms::ToolStripSeparator());
   this->выйтиToolStripMenuItem1 = (gcnew System::Windows::Forms::ToolStripMenuItem());
   this->menuStrip1->SuspendLayout();
   this->contextMenuStrip1->SuspendLayout();
   this->SuspendLayout();
   // 
   // textBox1
   // 
   this->textBox1->BackColor = System::Drawing::SystemColors::Control;
   this->textBox1->Cursor = System::Windows::Forms::Cursors::IBeam;
   this->textBox1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
    static_cast<System::Byte>(204)));
   this->textBox1->Location = System::Drawing::Point(15, 49);
   this->textBox1->Name = L"textBox1";
   this->textBox1->Size = System::Drawing::Size(114, 26);
   this->textBox1->TabIndex = 0;
   this->textBox1->TextAlign = System::Windows::Forms::HorizontalAlignment::Right;
   // 
   // SignLabel
   // 
   this->SignLabel->AutoSize = true;
   this->SignLabel->Location = System::Drawing::Point(63, 33);
   this->SignLabel->Name = L"SignLabel";
   this->SignLabel->Size = System::Drawing::Size(28, 13);
   this->SignLabel->TabIndex = 1;
   this->SignLabel->Text = L"Sign";
   // 
   // OperandLabel
   // 
   this->OperandLabel->AutoSize = true;
   this->OperandLabel->Location = System::Drawing::Point(12, 33);
   this->OperandLabel->Name = L"OperandLabel";
   this->OperandLabel->Size = System::Drawing::Size(48, 13);
   this->OperandLabel->TabIndex = 2;
   this->OperandLabel->Text = L"Operand";
   this->OperandLabel->TextAlign = System::Drawing::ContentAlignment::TopRight;
   // 
   // Mulbutton
   // 
   this->Mulbutton->BackColor = System::Drawing::SystemColors::Control;
   this->Mulbutton->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
    static_cast<System::Byte>(204)));
   this->Mulbutton->Location = System::Drawing::Point(97, 113);
   this->Mulbutton->Name = L"Mulbutton";
   this->Mulbutton->Size = System::Drawing::Size(35, 35);
   this->Mulbutton->TabIndex = 3;
   this->Mulbutton->Text = L"*";
   this->Mulbutton->UseVisualStyleBackColor = true;
   this->Mulbutton->Click += gcnew System::EventHandler(this, &Main::Mulbutton_Click);
   // 
   // Equalbutton
   // 
   this->Equalbutton->BackColor = System::Drawing::SystemColors::Control;
   this->Equalbutton->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
    static_cast<System::Byte>(204)));
   this->Equalbutton->Location = System::Drawing::Point(56, 154);
   this->Equalbutton->Name = L"Equalbutton";
   this->Equalbutton->Size = System::Drawing::Size(35, 35);
   this->Equalbutton->TabIndex = 4;
   this->Equalbutton->Text = L"=";
   this->Equalbutton->UseVisualStyleBackColor = true;
   this->Equalbutton->Click += gcnew System::EventHandler(this, &Main::Equalbutton_Click);
   // 
   // Clearbutton
   // 
   this->Clearbutton->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
    static_cast<System::Byte>(204)));
   this->Clearbutton->Location = System::Drawing::Point(97, 154);
   this->Clearbutton->Name = L"Clearbutton";
   this->Clearbutton->Size = System::Drawing::Size(35, 35);
   this->Clearbutton->TabIndex = 5;
   this->Clearbutton->Text = L"C";
   this->Clearbutton->UseVisualStyleBackColor = true;
   this->Clearbutton->Click += gcnew System::EventHandler(this, &Main::Clearbutton_Click);
   // 
   // Addbutton
   // 
   this->Addbutton->BackColor = System::Drawing::SystemColors::Control;
   this->Addbutton->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
    static_cast<System::Byte>(204)));
   this->Addbutton->Location = System::Drawing::Point(12, 113);
   this->Addbutton->Name = L"Addbutton";
   this->Addbutton->Size = System::Drawing::Size(35, 35);
   this->Addbutton->TabIndex = 6;
   this->Addbutton->Text = L"+";
   this->Addbutton->UseVisualStyleBackColor = true;
   this->Addbutton->Click += gcnew System::EventHandler(this, &Main::Addbutton_Click);
   // 
   // Divbutton
   // 
   this->Divbutton->BackColor = System::Drawing::SystemColors::Control;
   this->Divbutton->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
    static_cast<System::Byte>(204)));
   this->Divbutton->Location = System::Drawing::Point(138, 113);
   this->Divbutton->Name = L"Divbutton";
   this->Divbutton->Size = System::Drawing::Size(35, 35);
   this->Divbutton->TabIndex = 7;
   this->Divbutton->Text = L"/";
   this->Divbutton->UseVisualStyleBackColor = true;
   this->Divbutton->Click += gcnew System::EventHandler(this, &Main::Divbutton_Click);
   // 
   // Subbutton
   // 
   this->Subbutton->BackColor = System::Drawing::SystemColors::Control;
   this->Subbutton->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
    static_cast<System::Byte>(204)));
   this->Subbutton->Location = System::Drawing::Point(56, 113);
   this->Subbutton->Name = L"Subbutton";
   this->Subbutton->Size = System::Drawing::Size(35, 35);
   this->Subbutton->TabIndex = 8;
   this->Subbutton->Text = L"-";
   this->Subbutton->UseVisualStyleBackColor = true;
   this->Subbutton->Click += gcnew System::EventHandler(this, &Main::Subbutton_Click);
   // 
   // menuStrip1
   // 
   this->menuStrip1->Items->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(2) {
    this->файлToolStripMenuItem,
     this->правкаToolStripMenuItem
   });
   this->menuStrip1->Location = System::Drawing::Point(0, 0);
   this->menuStrip1->Name = L"menuStrip1";
   this->menuStrip1->Size = System::Drawing::Size(284, 24);
   this->menuStrip1->TabIndex = 9;
   this->menuStrip1->Text = L"menuStrip1";
   // 
   // файлToolStripMenuItem
   // 
   this->файлToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(1) { this->выйтиToolStripMenuItem });
   this->файлToolStripMenuItem->Name = L"файлToolStripMenuItem";
   this->файлToolStripMenuItem->Size = System::Drawing::Size(48, 20);
   this->файлToolStripMenuItem->Text = L"Файл";
   // 
   // выйтиToolStripMenuItem
   // 
   this->выйтиToolStripMenuItem->Name = L"выйтиToolStripMenuItem";
   this->выйтиToolStripMenuItem->Size = System::Drawing::Size(152, 22);
   this->выйтиToolStripMenuItem->Text = L"Выйти";
   this->выйтиToolStripMenuItem->Click += gcnew System::EventHandler(this, &Main::выйтиToolStripMenuItem_Click);
   // 
   // правкаToolStripMenuItem
   // 
   this->правкаToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(5) {
    this->копироватьToolStripMenuItem,
     this->вставитьToolStripMenuItem, this->toolStripMenuItem1, this->вычислитьToolStripMenuItem, this->очиститьToolStripMenuItem
   });
   this->правкаToolStripMenuItem->Name = L"правкаToolStripMenuItem";
   this->правкаToolStripMenuItem->Size = System::Drawing::Size(59, 20);
   this->правкаToolStripMenuItem->Text = L"Правка";
   // 
   // копироватьToolStripMenuItem
   // 
   this->копироватьToolStripMenuItem->Name = L"копироватьToolStripMenuItem";
   this->копироватьToolStripMenuItem->Size = System::Drawing::Size(152, 22);
   this->копироватьToolStripMenuItem->Text = L"Копировать";
   this->копироватьToolStripMenuItem->Click += gcnew System::EventHandler(this, &Main::копироватьToolStripMenuItem_Click);
   // 
   // вставитьToolStripMenuItem
   // 
   this->вставитьToolStripMenuItem->Name = L"вставитьToolStripMenuItem";
   this->вставитьToolStripMenuItem->Size = System::Drawing::Size(152, 22);
   this->вставитьToolStripMenuItem->Text = L"Вставить";
   this->вставитьToolStripMenuItem->Click += gcnew System::EventHandler(this, &Main::вставитьToolStripMenuItem_Click);
   // 
   // toolStripMenuItem1
   // 
   this->toolStripMenuItem1->Name = L"toolStripMenuItem1";
   this->toolStripMenuItem1->Size = System::Drawing::Size(149, 6);
   // 
   // вычислитьToolStripMenuItem
   // 
   this->вычислитьToolStripMenuItem->Name = L"вычислитьToolStripMenuItem";
   this->вычислитьToolStripMenuItem->Size = System::Drawing::Size(152, 22);
   this->вычислитьToolStripMenuItem->Text = L"Вычислить";
   this->вычислитьToolStripMenuItem->Click += gcnew System::EventHandler(this, &Main::вычислитьToolStripMenuItem_Click);
   // 
   // очиститьToolStripMenuItem
   // 
   this->очиститьToolStripMenuItem->Name = L"очиститьToolStripMenuItem";
   this->очиститьToolStripMenuItem->Size = System::Drawing::Size(152, 22);
   this->очиститьToolStripMenuItem->Text = L"Очистить";
   this->очиститьToolStripMenuItem->Click += gcnew System::EventHandler(this, &Main::очиститьToolStripMenuItem_Click);
   // 
   // CelstoFahrbutton
   // 
   this->CelstoFahrbutton->BackColor = System::Drawing::SystemColors::Control;
   this->CelstoFahrbutton->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 15.75F, System::Drawing::FontStyle::Regular,
    System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(204)));
   this->CelstoFahrbutton->Location = System::Drawing::Point(12, 196);
   this->CelstoFahrbutton->Name = L"CelstoFahrbutton";
   this->CelstoFahrbutton->Size = System::Drawing::Size(86, 35);
   this->CelstoFahrbutton->TabIndex = 10;
   this->CelstoFahrbutton->Text = L"C°→F°";
   this->CelstoFahrbutton->UseVisualStyleBackColor = true;
   this->CelstoFahrbutton->Click += gcnew System::EventHandler(this, &Main::CelstoFahrbutton_Click);
   // 
   // FahrtoCelsbutton
   // 
   this->FahrtoCelsbutton->BackColor = System::Drawing::SystemColors::Control;
   this->FahrtoCelsbutton->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 15.75F, System::Drawing::FontStyle::Regular,
    System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(204)));
   this->FahrtoCelsbutton->Location = System::Drawing::Point(104, 196);
   this->FahrtoCelsbutton->Name = L"FahrtoCelsbutton";
   this->FahrtoCelsbutton->Size = System::Drawing::Size(86, 35);
   this->FahrtoCelsbutton->TabIndex = 11;
   this->FahrtoCelsbutton->Text = L"F°→C°";
   this->FahrtoCelsbutton->UseVisualStyleBackColor = true;
   this->FahrtoCelsbutton->Click += gcnew System::EventHandler(this, &Main::FahrtoCelsbutton_Click);
   // 
   // contextMenuStrip1
   // 
   this->contextMenuStrip1->Items->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(7) {
    this->копироватьToolStripMenuItem1,
     this->вставитьToolStripMenuItem1, this->toolStripMenuItem2, this->вычислитьToolStripMenuItem1, this->очиститьToolStripMenuItem1,
     this->toolStripMenuItem3, this->выйтиToolStripMenuItem1
   });
   this->contextMenuStrip1->Name = L"contextMenuStrip1";
   this->contextMenuStrip1->ShowImageMargin = false;
   this->contextMenuStrip1->Size = System::Drawing::Size(128, 148);
   this->contextMenuStrip1->Opening += gcnew System::ComponentModel::CancelEventHandler(this, &Main::contextMenuStrip1_Opening);
   // 
   // копироватьToolStripMenuItem1
   // 
   this->копироватьToolStripMenuItem1->Name = L"копироватьToolStripMenuItem1";
   this->копироватьToolStripMenuItem1->Size = System::Drawing::Size(127, 22);
   this->копироватьToolStripMenuItem1->Text = L"Копировать";
   this->копироватьToolStripMenuItem1->Click += gcnew System::EventHandler(this, &Main::копироватьToolStripMenuItem1_Click);
   // 
   // вставитьToolStripMenuItem1
   // 
   this->вставитьToolStripMenuItem1->Name = L"вставитьToolStripMenuItem1";
   this->вставитьToolStripMenuItem1->Size = System::Drawing::Size(127, 22);
   this->вставитьToolStripMenuItem1->Text = L"Вставить";
   this->вставитьToolStripMenuItem1->Click += gcnew System::EventHandler(this, &Main::вставитьToolStripMenuItem1_Click);
   // 
   // toolStripMenuItem2
   // 
   this->toolStripMenuItem2->Name = L"toolStripMenuItem2";
   this->toolStripMenuItem2->Size = System::Drawing::Size(124, 6);
   // 
   // вычислитьToolStripMenuItem1
   // 
   this->вычислитьToolStripMenuItem1->Name = L"вычислитьToolStripMenuItem1";
   this->вычислитьToolStripMenuItem1->Size = System::Drawing::Size(127, 22);
   this->вычислитьToolStripMenuItem1->Text = L"Вычислить";
   this->вычислитьToolStripMenuItem1->Click += gcnew System::EventHandler(this, &Main::вычислитьToolStripMenuItem1_Click);
   // 
   // очиститьToolStripMenuItem1
   // 
   this->очиститьToolStripMenuItem1->Name = L"очиститьToolStripMenuItem1";
   this->очиститьToolStripMenuItem1->Size = System::Drawing::Size(127, 22);
   this->очиститьToolStripMenuItem1->Text = L"Очистить";
   this->очиститьToolStripMenuItem1->Click += gcnew System::EventHandler(this, &Main::очиститьToolStripMenuItem1_Click);
   // 
   // toolStripMenuItem3
   // 
   this->toolStripMenuItem3->Name = L"toolStripMenuItem3";
   this->toolStripMenuItem3->Size = System::Drawing::Size(124, 6);
   // 
   // выйтиToolStripMenuItem1
   // 
   this->выйтиToolStripMenuItem1->Name = L"выйтиToolStripMenuItem1";
   this->выйтиToolStripMenuItem1->Size = System::Drawing::Size(127, 22);
   this->выйтиToolStripMenuItem1->Text = L"Выйти";
   this->выйтиToolStripMenuItem1->Click += gcnew System::EventHandler(this, &Main::выйтиToolStripMenuItem1_Click);
   // 
   // Main
   // 
   this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
   this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
   this->ClientSize = System::Drawing::Size(284, 261);
   this->ContextMenuStrip = this->contextMenuStrip1;
   this->Controls->Add(this->FahrtoCelsbutton);
   this->Controls->Add(this->CelstoFahrbutton);
   this->Controls->Add(this->Subbutton);
   this->Controls->Add(this->Divbutton);
   this->Controls->Add(this->Addbutton);
   this->Controls->Add(this->Clearbutton);
   this->Controls->Add(this->Equalbutton);
   this->Controls->Add(this->Mulbutton);
   this->Controls->Add(this->OperandLabel);
   this->Controls->Add(this->SignLabel);
   this->Controls->Add(this->textBox1);
   this->Controls->Add(this->menuStrip1);
   this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedSingle;
   this->MainMenuStrip = this->menuStrip1;
   this->MaximizeBox = false;
   this->Name = L"Main";
   this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
   this->Text = L"Calc";
   this->Load += gcnew System::EventHandler(this, &Main::Main_Load);
   this->menuStrip1->ResumeLayout(false);
   this->menuStrip1->PerformLayout();
   this->contextMenuStrip1->ResumeLayout(false);
   this->ResumeLayout(false);
   this->PerformLayout();

  }
#pragma endregion
		Single d1,d2,res;
		enum class Operation
		{
			None, Add, Sub, Mul, Div
		} operation;
	private: 
		System::Void Main_Load(System::Object^  sender, System::EventArgs^  e)
		{
			OperandLabel->Text = "";
			SignLabel->Text = "";
			operation = Operation::None;
		}
	private: 
		bool is_number()
		{ 
			Single d;
			bool Is_Num = Single::TryParse (textBox1->Text,
				System::Globalization::NumberStyles::Number,
				System::Globalization::NumberFormatInfo::CurrentInfo,d);
			textBox1->Focus();
			if (Is_Num == true) 
			{ 
				if (operation == Operation::None) d1=d; else d2=d; 
				return true; 
			}
			return false;
		}

	private: 
		void copy_number (Operation choice)
		{
			this->operation = choice;
			OperandLabel->Text = textBox1->Text;
			SignLabel->Text;
			switch (operation)
			{
				case Operation::None:break;
				case Operation::Add:SignLabel->Text = "+";break;
				case Operation::Sub:SignLabel->Text = "-";break;
				case Operation::Mul:SignLabel->Text = "*";break;
				case Operation::Div:SignLabel->Text = "/";break;
				default:break;
			}
			textBox1->Clear();
		}

	private: 
		System::Void Addbutton_Click(System::Object^  sender, System::EventArgs^  e)
		{
			if (is_number()) 
			{
				copy_number(Operation::Add);
				textBox1->BackColor = System::Drawing::SystemColors::Control;
			}
			else textBox1->BackColor = System::Drawing::Color::LightCoral;
		}
	private: 
		System::Void Subbutton_Click(System::Object^  sender, System::EventArgs^  e)
		{
			if (is_number()) 
			{
				copy_number(Operation::Sub);
				textBox1->BackColor = System::Drawing::SystemColors::Control;
			}
			else textBox1->BackColor = System::Drawing::Color::LightCoral;
		}
	private: 
		System::Void Mulbutton_Click(System::Object^  sender, System::EventArgs^  e)
		{
			if (is_number()) 
			{
				copy_number(Operation::Mul);
				textBox1->BackColor = System::Drawing::SystemColors::Control;
			}
			else textBox1->BackColor = System::Drawing::Color::LightCoral;
		}
	private: 
		System::Void Divbutton_Click(System::Object^  sender, System::EventArgs^  e)
		{
			if (is_number()) 
			{
				copy_number(Operation::Div);
				textBox1->BackColor = System::Drawing::SystemColors::Control;
			}
			else textBox1->BackColor = System::Drawing::Color::LightCoral;
		}
	private: 
		System::Void Equalbutton_Click(System::Object^  sender, System::EventArgs^  e)
		{
			if (operation != Operation::None)
   {
    if (is_number())
    {
     switch (operation)
     {
     case Operation::Add:res = d1 + d2; break;
     case Operation::Sub:res = d1 - d2; break;
     case Operation::Mul:
      try { res = d1*d2; }
      catch (...)
      {
       MessageBox::Show("Переполнение");
       return;
      }break;
     case Operation::Div:
      if (Double::IsInfinity(res = d1 / d2))
      {
       MessageBox::Show("Деление на ноль");
       Clearbutton_Click(sender, e);
       return;
      }
      break;
     }
     OperandLabel->Text += " " + SignLabel->Text + " " + textBox1->Text + " =";
     SignLabel->Text = "";
     operation = Operation::None;
     textBox1->Text = "" + res;
     textBox1->BackColor = System::Drawing::SystemColors::Control;
    }
    else textBox1->BackColor = System::Drawing::Color::LightCoral;
   }
		}
	private: 
		System::Void Clearbutton_Click(System::Object^  sender, System::EventArgs^  e)
		{
			textBox1->Clear(); 
			SignLabel->Text=""; 
			OperandLabel->Text=""; 
			operation = Operation::None;
			textBox1->BackColor = System::Drawing::SystemColors::Control;
		}
	private: 
		System::Void CelstoFahrbutton_Click(System::Object^  sender, System::EventArgs^  e)
		{
			if (is_number()) 
			{
				textBox1->Text = "" + (d1 * 1.8 + 32);
				textBox1->BackColor = System::Drawing::SystemColors::Control;
			}
			else textBox1->BackColor = System::Drawing::Color::LightCoral;
		}
	private: 
		System::Void FahrtoCelsbutton_Click(System::Object^  sender, System::EventArgs^  e)
		{
			if (is_number()) 
			{
				textBox1->Text = "" + ((d1 - 32) / 1.8);
				textBox1->BackColor = System::Drawing::SystemColors::Control;
			}
			else textBox1->BackColor = System::Drawing::Color::LightCoral;
		}

	private: 
		System::Void выйтиToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e)
		{
			Close();
		}
	private: 
		System::Void вычислитьToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e)
		{
			Equalbutton_Click(sender, e);
		}
	private: 
		System::Void очиститьToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e)
		{
			Clearbutton_Click(sender, e);
		}
	private: 
		System::Void копироватьToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e)
		{
			Clipboard::SetText(textBox1->Text);
		}
	private: 
		System::Void вставитьToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e)
		{
			textBox1->Text = Clipboard::GetText();
		}
	private: 
		System::Void копироватьToolStripMenuItem1_Click(System::Object^  sender, System::EventArgs^  e)
		{
			Clipboard::SetText(textBox1->Text);
		}
	private: 
		System::Void вставитьToolStripMenuItem1_Click(System::Object^  sender, System::EventArgs^  e)
		{
			textBox1->Text = Clipboard::GetText();
		}
	private: 
		System::Void вычислитьToolStripMenuItem1_Click(System::Object^  sender, System::EventArgs^  e)
		{
			Equalbutton_Click(sender, e);
		}
	private: 
		System::Void очиститьToolStripMenuItem1_Click(System::Object^  sender, System::EventArgs^  e)
		{
			Clearbutton_Click(sender, e);
		}
	private: 
		System::Void выйтиToolStripMenuItem1_Click(System::Object^  sender, System::EventArgs^  e)
		{
			Close();
		}
private: System::Void contextMenuStrip1_Opening(System::Object^  sender, System::ComponentModel::CancelEventArgs^  e) {
}
};
}
