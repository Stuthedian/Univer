#pragma once
#include "Main.h"

namespace Lab2 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Сводка для Editor
	/// </summary>
	public ref class Editor : public System::Windows::Forms::Form
	{
	public:
		Editor(Main^ parent)
		{
			InitializeComponent();
			parentMain = parent;
		}

	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~Editor()
		{
			if (components)
			{
				delete components;
			}
		}
	public: System::Windows::Forms::TextBox^  textBox1;
	protected:
	private: System::Windows::Forms::ToolStrip^  toolStrip1;
	private: System::Windows::Forms::ToolStripButton^  toolStripOpenButton;
	private: System::Windows::Forms::ToolStripButton^  toolStripSaveButton;
	private: System::Windows::Forms::OpenFileDialog^  openFileDialog1;
	private: System::Windows::Forms::SaveFileDialog^  saveFileDialog1;
	private: Main^ parentMain;
	public: System::String ^ Filename;
	public: System::String ^ Filecontents;
			 
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
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(Editor::typeid));
			this->textBox1 = (gcnew System::Windows::Forms::TextBox());
			this->toolStrip1 = (gcnew System::Windows::Forms::ToolStrip());
			this->toolStripOpenButton = (gcnew System::Windows::Forms::ToolStripButton());
			this->toolStripSaveButton = (gcnew System::Windows::Forms::ToolStripButton());
			this->openFileDialog1 = (gcnew System::Windows::Forms::OpenFileDialog());
			this->saveFileDialog1 = (gcnew System::Windows::Forms::SaveFileDialog());
			this->toolStrip1->SuspendLayout();
			this->SuspendLayout();
			// 
			// textBox1
			// 
			this->textBox1->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->textBox1->Font = (gcnew System::Drawing::Font(L"Consolas", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->textBox1->Location = System::Drawing::Point(0, 28);
			this->textBox1->Multiline = true;
			this->textBox1->Name = L"textBox1";
			this->textBox1->ScrollBars = System::Windows::Forms::ScrollBars::Vertical;
			this->textBox1->Size = System::Drawing::Size(419, 326);
			this->textBox1->TabIndex = 0;
			this->textBox1->TabStop = false;
			// 
			// toolStrip1
			// 
			this->toolStrip1->Items->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(2)
			{
				this->toolStripOpenButton,
					this->toolStripSaveButton
			});
			this->toolStrip1->Location = System::Drawing::Point(0, 0);
			this->toolStrip1->Name = L"toolStrip1";
			this->toolStrip1->Size = System::Drawing::Size(419, 25);
			this->toolStrip1->TabIndex = 1;
			this->toolStrip1->Text = L"toolStrip1";
			// 
			// toolStripOpenButton
			// 
			this->toolStripOpenButton->DisplayStyle = System::Windows::Forms::ToolStripItemDisplayStyle::Image;
			this->toolStripOpenButton->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"toolStripOpenButton.Image")));
			this->toolStripOpenButton->ImageTransparentColor = System::Drawing::Color::Magenta;
			this->toolStripOpenButton->Name = L"toolStripOpenButton";
			this->toolStripOpenButton->Size = System::Drawing::Size(23, 22);
			this->toolStripOpenButton->Text = L"Открыть";
			this->toolStripOpenButton->Click += gcnew System::EventHandler(this, &Editor::toolStripOpenButton_Click);
			// 
			// toolStripSaveButton
			// 
			this->toolStripSaveButton->DisplayStyle = System::Windows::Forms::ToolStripItemDisplayStyle::Image;
			this->toolStripSaveButton->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"toolStripSaveButton.Image")));
			this->toolStripSaveButton->ImageTransparentColor = System::Drawing::Color::Magenta;
			this->toolStripSaveButton->Name = L"toolStripSaveButton";
			this->toolStripSaveButton->Size = System::Drawing::Size(23, 22);
			this->toolStripSaveButton->Text = L"Сохранить";
			this->toolStripSaveButton->Click += gcnew System::EventHandler(this, &Editor::toolStripSaveButton_Click);
			// 
			// openFileDialog1
			// 
			this->openFileDialog1->Filter = L"Текстовые файлы|*.txt";
			// 
			// Editor
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(419, 354);
			this->Controls->Add(this->toolStrip1);
			this->Controls->Add(this->textBox1);
			this->Name = L"Editor";
			this->Text = L"Editor";
			this->FormClosed += gcnew System::Windows::Forms::FormClosedEventHandler(this, &Editor::Editor_FormClosed);
			this->toolStrip1->ResumeLayout(false);
			this->toolStrip1->PerformLayout();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void writefile();
	private: System::Void toolStripOpenButton_Click(System::Object^  sender, System::EventArgs^  e);
	private: System::Void toolStripSaveButton_Click(System::Object^  sender, System::EventArgs^  e);
private: System::Void Editor_FormClosed(System::Object^  sender, System::Windows::Forms::FormClosedEventArgs^  e);
};
}
