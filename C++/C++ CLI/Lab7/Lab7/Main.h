#pragma once

namespace Lab7 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace System::Text::RegularExpressions;

	/// <summary>
	/// Ñâîäêà äëÿ Main
	/// </summary>
	public ref class Main : public System::Windows::Forms::Form
	{
		Form^ child = nullptr;
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
	private: System::Windows::Forms::ToolStripMenuItem^  îòêğûòüToolStripMenuItem;
	private: System::Windows::Forms::OpenFileDialog^  openFileDialog1;

	//private: array<array<System::String ^>^> ^ records;
	private: bool isopenfile;
	public: System::Windows::Forms::DataGridView^  dataGridView1;



	private: System::Windows::Forms::ToolStripMenuItem^  ñîõğàíèòüToolStripMenuItem;
	private: System::Windows::Forms::SaveFileDialog^  saveFileDialog1;
	private: String^ filename;
	private: bool ischanged;

	private: String ^ BaseName;
	private: DataTable ^ Table;
	private: DataSet ^ Set;
	private: System::Windows::Forms::ToolStripMenuItem^  ïîèñêToolStripMenuItem;

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
			this->menuStrip1 = (gcnew System::Windows::Forms::MenuStrip());
			this->ôàéëToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->îòêğûòüToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->ñîõğàíèòüToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->ïîèñêToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->openFileDialog1 = (gcnew System::Windows::Forms::OpenFileDialog());
			this->dataGridView1 = (gcnew System::Windows::Forms::DataGridView());
			this->saveFileDialog1 = (gcnew System::Windows::Forms::SaveFileDialog());
			this->menuStrip1->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridView1))->BeginInit();
			this->SuspendLayout();
			// 
			// menuStrip1
			// 
			this->menuStrip1->Items->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(1) { this->ôàéëToolStripMenuItem });
			this->menuStrip1->Location = System::Drawing::Point(0, 0);
			this->menuStrip1->Name = L"menuStrip1";
			this->menuStrip1->Padding = System::Windows::Forms::Padding(9, 3, 0, 3);
			this->menuStrip1->Size = System::Drawing::Size(610, 25);
			this->menuStrip1->TabIndex = 1;
			this->menuStrip1->Text = L"menuStrip1";
			// 
			// ôàéëToolStripMenuItem
			// 
			this->ôàéëToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(3)
			{
				this->îòêğûòüToolStripMenuItem,
					this->ñîõğàíèòüToolStripMenuItem, this->ïîèñêToolStripMenuItem
			});
			this->ôàéëToolStripMenuItem->Name = L"ôàéëToolStripMenuItem";
			this->ôàéëToolStripMenuItem->Size = System::Drawing::Size(48, 19);
			this->ôàéëToolStripMenuItem->Text = L"Ôàéë";
			// 
			// îòêğûòüToolStripMenuItem
			// 
			this->îòêğûòüToolStripMenuItem->Name = L"îòêğûòüToolStripMenuItem";
			this->îòêğûòüToolStripMenuItem->Size = System::Drawing::Size(132, 22);
			this->îòêğûòüToolStripMenuItem->Text = L"Îòêğûòü";
			this->îòêğûòüToolStripMenuItem->Click += gcnew System::EventHandler(this, &Main::îòêğûòüToolStripMenuItem_Click);
			// 
			// ñîõğàíèòüToolStripMenuItem
			// 
			this->ñîõğàíèòüToolStripMenuItem->Name = L"ñîõğàíèòüToolStripMenuItem";
			this->ñîõğàíèòüToolStripMenuItem->Size = System::Drawing::Size(132, 22);
			this->ñîõğàíèòüToolStripMenuItem->Text = L"Ñîõğàíèòü";
			this->ñîõğàíèòüToolStripMenuItem->Click += gcnew System::EventHandler(this, &Main::ñîõğàíèòüToolStripMenuItem_Click);
			// 
			// ïîèñêToolStripMenuItem
			// 
			this->ïîèñêToolStripMenuItem->Name = L"ïîèñêToolStripMenuItem";
			this->ïîèñêToolStripMenuItem->Size = System::Drawing::Size(132, 22);
			this->ïîèñêToolStripMenuItem->Text = L"Ïîèñê";
			this->ïîèñêToolStripMenuItem->Click += gcnew System::EventHandler(this, &Main::ïîèñêToolStripMenuItem_Click);
			// 
			// openFileDialog1
			// 
			this->openFileDialog1->Filter = L"Xml-ğàçìåòêà | *.xml";
			// 
			// dataGridView1
			// 
			this->dataGridView1->AllowUserToOrderColumns = true;
			this->dataGridView1->AutoSizeColumnsMode = System::Windows::Forms::DataGridViewAutoSizeColumnsMode::ColumnHeader;
			this->dataGridView1->ColumnHeadersHeightSizeMode = System::Windows::Forms::DataGridViewColumnHeadersHeightSizeMode::AutoSize;
			this->dataGridView1->Dock = System::Windows::Forms::DockStyle::Fill;
			this->dataGridView1->Location = System::Drawing::Point(0, 25);
			this->dataGridView1->Margin = System::Windows::Forms::Padding(4, 5, 4, 5);
			this->dataGridView1->Name = L"dataGridView1";
			this->dataGridView1->Size = System::Drawing::Size(610, 206);
			this->dataGridView1->TabIndex = 2;
			this->dataGridView1->CellBeginEdit += gcnew System::Windows::Forms::DataGridViewCellCancelEventHandler(this, &Main::dataGridView1_CellBeginEdit);
			this->dataGridView1->CellEndEdit += gcnew System::Windows::Forms::DataGridViewCellEventHandler(this, &Main::dataGridView1_CellEndEdit);
			this->dataGridView1->CellValueChanged += gcnew System::Windows::Forms::DataGridViewCellEventHandler(this, &Main::dataGridView1_CellValueChanged);
			this->dataGridView1->UserDeletedRow += gcnew System::Windows::Forms::DataGridViewRowEventHandler(this, &Main::dataGridView1_UserDeletedRow);
			// 
			// saveFileDialog1
			// 
			this->saveFileDialog1->Filter = L"Xml-ğàçìåòêà | *.xml";
			// 
			// Main
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(9, 20);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(610, 231);
			this->Controls->Add(this->dataGridView1);
			this->Controls->Add(this->menuStrip1);
			this->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->MainMenuStrip = this->menuStrip1;
			this->Margin = System::Windows::Forms::Padding(4, 5, 4, 5);
			this->Name = L"Main";
			this->Text = L"Ğåäàêòîğ ñòğóêòóğèğîâàííîé èíôîğìàöèè";
			this->FormClosing += gcnew System::Windows::Forms::FormClosingEventHandler(this, &Main::Main_FormClosing);
			this->Load += gcnew System::EventHandler(this, &Main::Main_Load);
			this->menuStrip1->ResumeLayout(false);
			this->menuStrip1->PerformLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridView1))->EndInit();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: Void loadFile(String ^ Filename, String ^ Filecontents);
	private: System::Void îòêğûòüToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e);
 
private: System::Void dataGridView1_CellValueChanged(System::Object^  sender, System::Windows::Forms::DataGridViewCellEventArgs^  e);
private: System::Void Main_Load(System::Object^  sender, System::EventArgs^  e);

private: System::Void ñîõğàíèòüToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e);
private: System::Void dataGridView1_CellBeginEdit(System::Object^  sender, System::Windows::Forms::DataGridViewCellCancelEventArgs^  e);
private: System::Void dataGridView1_CellEndEdit(System::Object^  sender, System::Windows::Forms::DataGridViewCellEventArgs^  e);
private: System::Void Main_FormClosing(System::Object^  sender, System::Windows::Forms::FormClosingEventArgs^  e);
private: System::Void dataGridView1_UserDeletedRow(System::Object^  sender, System::Windows::Forms::DataGridViewRowEventArgs^  e);

private: System::Void ïîèñêToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e);
public: Void clear_child();
};
}
