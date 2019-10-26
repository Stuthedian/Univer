#pragma once

namespace Lab2 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Ñâîäêà äëÿ Main
	/// </summary>
	public ref class Main : public System::Windows::Forms::Form
	{
	public:
		Main(void)
		{
			InitializeComponent();
			//
			//TODO: äîáàâüòå êîä êîíñòğóêòîğà
			//
		}

	protected:
		/// <summary>
		/// Îñâîáîäèòü âñå èñïîëüçóåìûå ğåñóğñû.
		/// </summary>
		~Main()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::MenuStrip^  menuStrip1;
	private: System::Windows::Forms::ToolStripMenuItem^  ôàéëToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  ñîçäàòüToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  îòêğûòüÔàéëToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  âûõîäToolStripMenuItem;
	private: System::Windows::Forms::OpenFileDialog^  openFileDialog1;
	private: System::Windows::Forms::ToolStripSeparator^  toolStripMenuItem1;
	private: System::Windows::Forms::ToolStripTextBox^  toolStripTextBox1;
	private: System::Windows::Forms::ToolStripSeparator^  toolStripMenuItem2;
	private: int Formcount;
	protected:

	private:
		/// <summary>
		/// Îáÿçàòåëüíàÿ ïåğåìåííàÿ êîíñòğóêòîğà.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Òğåáóåìûé ìåòîä äëÿ ïîääåğæêè êîíñòğóêòîğà — íå èçìåíÿéòå 
		/// ñîäåğæèìîå ıòîãî ìåòîäà ñ ïîìîùüş ğåäàêòîğà êîäà.
		/// </summary>
		void InitializeComponent(void)
		{
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(Main::typeid));
			this->menuStrip1 = (gcnew System::Windows::Forms::MenuStrip());
			this->ôàéëToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->ñîçäàòüToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->îòêğûòüÔàéëToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->toolStripMenuItem1 = (gcnew System::Windows::Forms::ToolStripSeparator());
			this->toolStripTextBox1 = (gcnew System::Windows::Forms::ToolStripTextBox());
			this->toolStripMenuItem2 = (gcnew System::Windows::Forms::ToolStripSeparator());
			this->âûõîäToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->openFileDialog1 = (gcnew System::Windows::Forms::OpenFileDialog());
			this->menuStrip1->SuspendLayout();
			this->SuspendLayout();
			// 
			// menuStrip1
			// 
			this->menuStrip1->Items->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(1) { this->ôàéëToolStripMenuItem });
			this->menuStrip1->Location = System::Drawing::Point(0, 0);
			this->menuStrip1->Name = L"menuStrip1";
			this->menuStrip1->Size = System::Drawing::Size(284, 24);
			this->menuStrip1->TabIndex = 0;
			this->menuStrip1->Text = L"menuStrip1";
			// 
			// ôàéëToolStripMenuItem
			// 
			this->ôàéëToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(6)
			{
				this->ñîçäàòüToolStripMenuItem,
					this->îòêğûòüÔàéëToolStripMenuItem, this->toolStripMenuItem1, this->toolStripTextBox1, this->toolStripMenuItem2, this->âûõîäToolStripMenuItem
			});
			this->ôàéëToolStripMenuItem->Name = L"ôàéëToolStripMenuItem";
			this->ôàéëToolStripMenuItem->Size = System::Drawing::Size(48, 20);
			this->ôàéëToolStripMenuItem->Text = L"Ôàéë";
			// 
			// ñîçäàòüToolStripMenuItem
			// 
			this->ñîçäàòüToolStripMenuItem->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"ñîçäàòüToolStripMenuItem.Image")));
			this->ñîçäàòüToolStripMenuItem->Name = L"ñîçäàòüToolStripMenuItem";
			this->ñîçäàòüToolStripMenuItem->Size = System::Drawing::Size(160, 22);
			this->ñîçäàòüToolStripMenuItem->Text = L"Ñîçäàòü";
			this->ñîçäàòüToolStripMenuItem->Click += gcnew System::EventHandler(this, &Main::ñîçäàòüToolStripMenuItem_Click);
			// 
			// îòêğûòüÔàéëToolStripMenuItem
			// 
			this->îòêğûòüÔàéëToolStripMenuItem->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"îòêğûòüÔàéëToolStripMenuItem.Image")));
			this->îòêğûòüÔàéëToolStripMenuItem->Name = L"îòêğûòüÔàéëToolStripMenuItem";
			this->îòêğûòüÔàéëToolStripMenuItem->Size = System::Drawing::Size(160, 22);
			this->îòêğûòüÔàéëToolStripMenuItem->Text = L"Îòêğûòü";
			this->îòêğûòüÔàéëToolStripMenuItem->Click += gcnew System::EventHandler(this, &Main::îòêğûòüÔàéëToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this->toolStripMenuItem1->Name = L"toolStripMenuItem1";
			this->toolStripMenuItem1->Size = System::Drawing::Size(157, 6);
			// 
			// toolStripTextBox1
			// 
			this->toolStripTextBox1->Name = L"toolStripTextBox1";
			this->toolStripTextBox1->Size = System::Drawing::Size(100, 23);
			// 
			// toolStripMenuItem2
			// 
			this->toolStripMenuItem2->Name = L"toolStripMenuItem2";
			this->toolStripMenuItem2->Size = System::Drawing::Size(157, 6);
			// 
			// âûõîäToolStripMenuItem
			// 
			this->âûõîäToolStripMenuItem->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"âûõîäToolStripMenuItem.Image")));
			this->âûõîäToolStripMenuItem->Name = L"âûõîäToolStripMenuItem";
			this->âûõîäToolStripMenuItem->Size = System::Drawing::Size(160, 22);
			this->âûõîäToolStripMenuItem->Text = L"Âûõîä";
			this->âûõîäToolStripMenuItem->Click += gcnew System::EventHandler(this, &Main::âûõîäToolStripMenuItem_Click);
			// 
			// openFileDialog1
			// 
			this->openFileDialog1->Filter = L"Òåêñòîâûå ôàéëû|*.txt";
			// 
			// Main
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(284, 261);
			this->Controls->Add(this->menuStrip1);
			this->MainMenuStrip = this->menuStrip1;
			this->Name = L"Main";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"Main";
			this->FormClosing += gcnew System::Windows::Forms::FormClosingEventHandler(this, &Main::Main_FormClosing);
			this->Load += gcnew System::EventHandler(this, &Main::Main_Load);
			this->menuStrip1->ResumeLayout(false);
			this->menuStrip1->PerformLayout();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
private: System::Void âûõîäToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e);
private: System::Void ñîçäàòüToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e);
private: System::Void îòêğûòüÔàéëToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e);
private: System::Void Editfile(System::String ^ Filename, System::String ^ Filecontents);
private: System::Void Main_Load(System::Object^  sender, System::EventArgs^  e);
public: System::Void Dec();
private: System::Void Main_FormClosing(System::Object^  sender, System::Windows::Forms::FormClosingEventArgs^  e);
};


}
