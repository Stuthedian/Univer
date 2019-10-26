#pragma once

namespace Lab4 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// ������ ��� Main
	/// </summary>
	public ref class Main : public System::Windows::Forms::Form
	{
	public:
		Main(void)
		{
			InitializeComponent();
			//
			//TODO: �������� ��� ������������
			//
		}

	protected:
		/// <summary>
		/// ���������� ��� ������������ �������.
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
 private: System::Windows::Forms::PictureBox^  pictureBox1;
	private: System::Windows::Forms::MenuStrip^  menuStrip1;
	private: System::Windows::Forms::ToolStripMenuItem^  ����ToolStripMenuItem;

	private: System::Windows::Forms::ToolStripMenuItem^  �������ToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  ���������ToolStripMenuItem;
	private: System::Windows::Forms::OpenFileDialog^  openFileDialog1;
			 Graphics^ g;
	private: System::Windows::Forms::ToolStripMenuItem^  ������ToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  �������ToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  �������������XToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  ���������������ToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  ����������ToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  ��������������ToolStripMenuItem;
	private: System::Windows::Forms::ColorDialog^  colorDialog1;
	private: System::Windows::Forms::SaveFileDialog^  saveFileDialog1;



	private:
		/// <summary>
		/// ������������ ���������� ������������.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// ��������� ����� ��� ��������� ������������ � �� ��������� 
		/// ���������� ����� ������ � ������� ��������� ����.
		/// </summary>
		void InitializeComponent(void)
		{
			this->panel1 = (gcnew System::Windows::Forms::Panel());
			this->pictureBox1 = (gcnew System::Windows::Forms::PictureBox());
			this->menuStrip1 = (gcnew System::Windows::Forms::MenuStrip());
			this->����ToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->�������ToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->���������ToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->������ToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->�������ToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->�������������XToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->��������������ToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->���������������ToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->����������ToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->openFileDialog1 = (gcnew System::Windows::Forms::OpenFileDialog());
			this->colorDialog1 = (gcnew System::Windows::Forms::ColorDialog());
			this->saveFileDialog1 = (gcnew System::Windows::Forms::SaveFileDialog());
			this->panel1->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->BeginInit();
			this->menuStrip1->SuspendLayout();
			this->SuspendLayout();
			// 
			// panel1
			// 
			this->panel1->AutoScroll = true;
			this->panel1->AutoSizeMode = System::Windows::Forms::AutoSizeMode::GrowAndShrink;
			this->panel1->Controls->Add(this->pictureBox1);
			this->panel1->Controls->Add(this->menuStrip1);
			this->panel1->Dock = System::Windows::Forms::DockStyle::Fill;
			this->panel1->Location = System::Drawing::Point(0, 0);
			this->panel1->Name = L"panel1";
			this->panel1->Size = System::Drawing::Size(507, 383);
			this->panel1->TabIndex = 0;
			// 
			// pictureBox1
			// 
			this->pictureBox1->Location = System::Drawing::Point(0, 24);
			this->pictureBox1->Name = L"pictureBox1";
			this->pictureBox1->Size = System::Drawing::Size(507, 359);
			this->pictureBox1->SizeMode = System::Windows::Forms::PictureBoxSizeMode::AutoSize;
			this->pictureBox1->TabIndex = 0;
			this->pictureBox1->TabStop = false;
			// 
			// menuStrip1
			// 
			this->menuStrip1->Items->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(2)
			{
				this->����ToolStripMenuItem,
					this->������ToolStripMenuItem
			});
			this->menuStrip1->Location = System::Drawing::Point(0, 0);
			this->menuStrip1->Name = L"menuStrip1";
			this->menuStrip1->Size = System::Drawing::Size(507, 24);
			this->menuStrip1->TabIndex = 1;
			this->menuStrip1->Text = L"menuStrip1";
			// 
			// ����ToolStripMenuItem
			// 
			this->����ToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(2)
			{
				this->�������ToolStripMenuItem,
					this->���������ToolStripMenuItem
			});
			this->����ToolStripMenuItem->Name = L"����ToolStripMenuItem";
			this->����ToolStripMenuItem->Size = System::Drawing::Size(48, 20);
			this->����ToolStripMenuItem->Text = L"����";
			// 
			// �������ToolStripMenuItem
			// 
			this->�������ToolStripMenuItem->Name = L"�������ToolStripMenuItem";
			this->�������ToolStripMenuItem->Size = System::Drawing::Size(132, 22);
			this->�������ToolStripMenuItem->Text = L"�������";
			this->�������ToolStripMenuItem->Click += gcnew System::EventHandler(this, &Main::�������ToolStripMenuItem_Click);
			// 
			// ���������ToolStripMenuItem
			// 
			this->���������ToolStripMenuItem->Name = L"���������ToolStripMenuItem";
			this->���������ToolStripMenuItem->Size = System::Drawing::Size(132, 22);
			this->���������ToolStripMenuItem->Text = L"���������";
			this->���������ToolStripMenuItem->Click += gcnew System::EventHandler(this, &Main::���������ToolStripMenuItem_Click);
			// 
			// ������ToolStripMenuItem
			// 
			this->������ToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(3)
			{
				this->�������ToolStripMenuItem,
					this->���������������ToolStripMenuItem, this->����������ToolStripMenuItem
			});
			this->������ToolStripMenuItem->Name = L"������ToolStripMenuItem";
			this->������ToolStripMenuItem->Size = System::Drawing::Size(59, 20);
			this->������ToolStripMenuItem->Text = L"������";
			// 
			// �������ToolStripMenuItem
			// 
			this->�������ToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(2)
			{
				this->�������������XToolStripMenuItem,
					this->��������������ToolStripMenuItem
			});
			this->�������ToolStripMenuItem->Name = L"�������ToolStripMenuItem";
			this->�������ToolStripMenuItem->Size = System::Drawing::Size(179, 22);
			this->�������ToolStripMenuItem->Text = L"���������";
			// 
			// �������������XToolStripMenuItem
			// 
			this->�������������XToolStripMenuItem->Name = L"�������������XToolStripMenuItem";
			this->�������������XToolStripMenuItem->Size = System::Drawing::Size(174, 22);
			this->�������������XToolStripMenuItem->Text = L"�������� �� ��� X";
			this->�������������XToolStripMenuItem->Click += gcnew System::EventHandler(this, &Main::�������������XToolStripMenuItem_Click);
			// 
			// ��������������ToolStripMenuItem
			// 
			this->��������������ToolStripMenuItem->Name = L"��������������ToolStripMenuItem";
			this->��������������ToolStripMenuItem->Size = System::Drawing::Size(174, 22);
			this->��������������ToolStripMenuItem->Text = L"�������� �� ��� Y";
			this->��������������ToolStripMenuItem->Click += gcnew System::EventHandler(this, &Main::��������������ToolStripMenuItem_Click);
			// 
			// ���������������ToolStripMenuItem
			// 
			this->���������������ToolStripMenuItem->Name = L"���������������ToolStripMenuItem";
			this->���������������ToolStripMenuItem->Size = System::Drawing::Size(179, 22);
			this->���������������ToolStripMenuItem->Text = L"���������������";
			this->���������������ToolStripMenuItem->Click += gcnew System::EventHandler(this, &Main::���������������ToolStripMenuItem_Click);
			// 
			// ����������ToolStripMenuItem
			// 
			this->����������ToolStripMenuItem->Name = L"����������ToolStripMenuItem";
			this->����������ToolStripMenuItem->Size = System::Drawing::Size(179, 22);
			this->����������ToolStripMenuItem->Text = L"����������";
			this->����������ToolStripMenuItem->Click += gcnew System::EventHandler(this, &Main::����������ToolStripMenuItem_Click);
			// 
			// openFileDialog1
			// 
			this->openFileDialog1->Filter = L"��� �����|*.*|������� BMP|*.bmp|������� JPEG|*.jpg|������� PNG|*.png";
			// 
			// colorDialog1
			// 
			this->colorDialog1->FullOpen = true;
			// 
			// saveFileDialog1
			// 
			this->saveFileDialog1->Filter = L"������� BMP|*.bmp|������� JPEG|*.jpg|������� PNG|*.png";
			// 
			// Main
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->AutoScroll = true;
			this->ClientSize = System::Drawing::Size(507, 383);
			this->Controls->Add(this->panel1);
			this->MainMenuStrip = this->menuStrip1;
			this->Name = L"Main";
			this->Text = L"Main";
			this->Load += gcnew System::EventHandler(this, &Main::Main_Load);
			this->panel1->ResumeLayout(false);
			this->panel1->PerformLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->EndInit();
			this->menuStrip1->ResumeLayout(false);
			this->menuStrip1->PerformLayout();
			this->ResumeLayout(false);

		}
#pragma endregion
 private: System::Void Main_Load(System::Object^  sender, System::EventArgs^  e) {
	���������ToolStripMenuItem->Enabled = false;
}
private: System::Void �������ToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e) 
{
	openFileDialog1->ShowDialog();
	if (openFileDialog1->FileName == "") return;
	Image ^ img;
	try {
		img = Image::FromFile(openFileDialog1->FileName);
	}
	catch (Exception^ e) {
		System::Windows::Forms::MessageBox::Show(e->Message + "\n�� ������� ������� ����", "������",
			MessageBoxButtons::OK, MessageBoxIcon::Exclamation);
		openFileDialog1->FileName = "";
		return;
	}
	this->ClientSize = System::Drawing::Size(img->Width, img->Height);
	pictureBox1->Image = img;
	���������ToolStripMenuItem->Enabled = true;
}
private: System::Void ���������ToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e) {
	saveFileDialog1->ShowDialog();
	if (saveFileDialog1->FileName == "") return;
	try
	{
		pictureBox1->Image->Save(saveFileDialog1->FileName);
	}
	catch (Exception^ e) {
		System::Windows::Forms::MessageBox::Show(e->Message + "\n�� ������� ������� ����", "������",
			MessageBoxButtons::OK, MessageBoxIcon::Exclamation);
		saveFileDialog1->FileName = "";
		return;
	}
	
}
private: System::Void �������������XToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e) {
	Bitmap^ bitmap1 = gcnew Bitmap(pictureBox1->Image);
	if (bitmap1 != nullptr) {
		bitmap1->RotateFlip(RotateFlipType::Rotate180FlipX);
		pictureBox1->Image = bitmap1;
	}
}
private: System::Void ��������������ToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e) {
	Bitmap^ bitmap1 = gcnew Bitmap(pictureBox1->Image);
	if (bitmap1 != nullptr) {
		bitmap1->RotateFlip(RotateFlipType::Rotate180FlipY);
		pictureBox1->Image = bitmap1;
	}

}

private: System::Void ���������������ToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e) {
	Bitmap^ bitmap1 = gcnew Bitmap(pictureBox1->Image); 
	Graphics ^ Gr1 = Graphics::FromImage(bitmap1); 
	Bitmap^ bitmap2 = gcnew Bitmap(bitmap1->Width / 2, bitmap1->Height / 2, Gr1);
	Graphics ^ Gr2 = Graphics::FromImage(bitmap2); 
	Rectangle compressionRectangle = Rectangle(0, 0, bitmap1->Width / 2, bitmap1->Height / 2);
	Gr2->DrawImage(bitmap1, compressionRectangle);
	Pen ^ MyPen = gcnew Pen(Color::FromArgb(0, 0, 0, 0));
	
	Gr2->DrawRectangle(MyPen, 0, 0, bitmap2->Width - 1, bitmap2->Height - 1);
	
	pictureBox1->Image = bitmap2; 
	this->ClientSize = bitmap2->Size;
}
private: System::Void ����������ToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e) {
	Bitmap^ bitmap1 = gcnew Bitmap(pictureBox1->Image);
	Bitmap ^bitmap2 = gcnew Bitmap(bitmap1->Width, bitmap1->Height);
	Graphics ^ g = Graphics::FromImage(bitmap2);
	using namespace System::Drawing::Imaging;
	colorDialog1->ShowDialog();
	float red =  colorDialog1->Color.R/255.0f;
	float green = colorDialog1->Color.G / 255.0f;
	float blue = colorDialog1->Color.B / 255.0f;
	float alpha = colorDialog1->Color.A / 255.0f;
	array <array <float> ^> ^Map = {
		{ 1, 0, 0, 0, 0 },
		{ 0, 1, 0, 0, 0 },
		{ 0, 0, 1, 0, 0 },
		{ 0, 0, 0, 1, 0 },
		{ red, green, blue, alpha*0.5f, 1 }

	};
	ColorMatrix ^ GrayscaleMatrix = gcnew ColorMatrix(Map);
	ImageAttributes ^ attributes = gcnew ImageAttributes();
	attributes->SetColorMatrix(GrayscaleMatrix);
	Rectangle rect = Rectangle(0, 0, bitmap1->Width, bitmap1->Height);
	g->DrawImage(bitmap1, rect, 0, 0, bitmap1->Width,
		bitmap1->Height, GraphicsUnit::Pixel, attributes);
	delete g;
	pictureBox1->Image = bitmap2;
}
};
}
