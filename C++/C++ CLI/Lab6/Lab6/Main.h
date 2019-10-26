#pragma once
#include "CycleContainer.h"

namespace Lab6 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace System::Drawing::Drawing2D;

	/// <summary>
	/// —водка дл€ Main
	/// </summary>
	public ref class Main : public System::Windows::Forms::Form
	{
		
		array<CycleContainer^>^ villain_array;
		Random^ rnd;
		const int delay_barrier = 3000;
		const int delay_missiles = 2000;
		int millisec_barrier = 0;
		int millisec_missiles = delay_missiles;
		bool sec_delay = true;
	private: System::Windows::Forms::Timer^  timer1;
	private: System::Windows::Forms::PictureBox^  SpaceshipBox;
	private: System::Windows::Forms::PictureBox^  BarrierBox;
	private: System::Windows::Forms::PictureBox^  OutMissileBox;
	private: System::Windows::Forms::PictureBox^  OutMissileBox2;
	private: System::Windows::Forms::Panel^  Villainpanel;
	private: System::Windows::Forms::PictureBox^  pictureBox13;
	private: System::Windows::Forms::PictureBox^  pictureBox14;
	private: System::Windows::Forms::PictureBox^  pictureBox15;
	private: System::Windows::Forms::PictureBox^  pictureBox16;
	private: System::Windows::Forms::PictureBox^  pictureBox17;
	private: System::Windows::Forms::PictureBox^  pictureBox18;
	private: System::Windows::Forms::PictureBox^  pictureBox7;
	private: System::Windows::Forms::PictureBox^  pictureBox8;
	private: System::Windows::Forms::PictureBox^  pictureBox9;
	private: System::Windows::Forms::PictureBox^  pictureBox10;
	private: System::Windows::Forms::PictureBox^  pictureBox11;
	private: System::Windows::Forms::PictureBox^  pictureBox12;
	private: System::Windows::Forms::PictureBox^  pictureBox5;
	private: System::Windows::Forms::PictureBox^  pictureBox6;
	private: System::Windows::Forms::PictureBox^  pictureBox3;
	private: System::Windows::Forms::PictureBox^  pictureBox4;
	private: System::Windows::Forms::PictureBox^  pictureBox2;

	private: System::Windows::Forms::PictureBox^  pictureBox1;

		#pragma region Windows Form Designer generated code
		public:
			Main(void)
			{
				InitializeComponent();
			}

		protected:
			/// <summary>
			/// ќсвободить все используемые ресурсы.
			/// </summary>
			~Main()
			{
				if (components)
				{
					delete components;
				}
			}
	private: System::ComponentModel::IContainer^  components;
	protected:

		protected:


		private:
			/// <summary>
			/// ќб€зательна€ переменна€ конструктора.
			/// </summary>


		/// <summary>
		/// “ребуемый метод дл€ поддержки конструктора Ч не измен€йте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		void InitializeComponent(void)
		{
			this->components = (gcnew System::ComponentModel::Container());
			this->pictureBox1 = (gcnew System::Windows::Forms::PictureBox());
			this->timer1 = (gcnew System::Windows::Forms::Timer(this->components));
			this->SpaceshipBox = (gcnew System::Windows::Forms::PictureBox());
			this->BarrierBox = (gcnew System::Windows::Forms::PictureBox());
			this->OutMissileBox = (gcnew System::Windows::Forms::PictureBox());
			this->OutMissileBox2 = (gcnew System::Windows::Forms::PictureBox());
			this->Villainpanel = (gcnew System::Windows::Forms::Panel());
			this->pictureBox2 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox3 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox4 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox5 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox6 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox7 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox8 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox9 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox10 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox11 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox12 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox13 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox14 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox15 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox16 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox17 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox18 = (gcnew System::Windows::Forms::PictureBox());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->SpaceshipBox))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->BarrierBox))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->OutMissileBox))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->OutMissileBox2))->BeginInit();
			this->Villainpanel->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox2))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox3))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox4))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox5))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox6))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox7))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox8))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox9))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox10))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox11))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox12))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox13))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox14))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox15))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox16))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox17))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox18))->BeginInit();
			this->SuspendLayout();
			// 
			// pictureBox1
			// 
			this->pictureBox1->Location = System::Drawing::Point(12, 12);
			this->pictureBox1->Name = L"pictureBox1";
			this->pictureBox1->Size = System::Drawing::Size(90, 67);
			this->pictureBox1->TabIndex = 0;
			this->pictureBox1->TabStop = false;
			// 
			// timer1
			// 
			this->timer1->Tick += gcnew System::EventHandler(this, &Main::timer1_Tick);
			// 
			// SpaceshipBox
			// 
			this->SpaceshipBox->Location = System::Drawing::Point(258, 327);
			this->SpaceshipBox->Name = L"SpaceshipBox";
			this->SpaceshipBox->Size = System::Drawing::Size(100, 65);
			this->SpaceshipBox->TabIndex = 1;
			this->SpaceshipBox->TabStop = false;
			// 
			// BarrierBox
			// 
			this->BarrierBox->BackColor = System::Drawing::Color::Silver;
			this->BarrierBox->Location = System::Drawing::Point(404, 285);
			this->BarrierBox->Name = L"BarrierBox";
			this->BarrierBox->Size = System::Drawing::Size(22, 130);
			this->BarrierBox->TabIndex = 2;
			this->BarrierBox->TabStop = false;
			// 
			// OutMissileBox
			// 
			this->OutMissileBox->Location = System::Drawing::Point(44, 319);
			this->OutMissileBox->Name = L"OutMissileBox";
			this->OutMissileBox->Size = System::Drawing::Size(52, 73);
			this->OutMissileBox->TabIndex = 3;
			this->OutMissileBox->TabStop = false;
			// 
			// OutMissileBox2
			// 
			this->OutMissileBox2->Location = System::Drawing::Point(102, 319);
			this->OutMissileBox2->Name = L"OutMissileBox2";
			this->OutMissileBox2->Size = System::Drawing::Size(52, 73);
			this->OutMissileBox2->TabIndex = 4;
			this->OutMissileBox2->TabStop = false;
			// 
			// Villainpanel
			// 
			this->Villainpanel->Controls->Add(this->pictureBox13);
			this->Villainpanel->Controls->Add(this->pictureBox14);
			this->Villainpanel->Controls->Add(this->pictureBox15);
			this->Villainpanel->Controls->Add(this->pictureBox16);
			this->Villainpanel->Controls->Add(this->pictureBox17);
			this->Villainpanel->Controls->Add(this->pictureBox18);
			this->Villainpanel->Controls->Add(this->pictureBox7);
			this->Villainpanel->Controls->Add(this->pictureBox8);
			this->Villainpanel->Controls->Add(this->pictureBox9);
			this->Villainpanel->Controls->Add(this->pictureBox10);
			this->Villainpanel->Controls->Add(this->pictureBox11);
			this->Villainpanel->Controls->Add(this->pictureBox12);
			this->Villainpanel->Controls->Add(this->pictureBox5);
			this->Villainpanel->Controls->Add(this->pictureBox6);
			this->Villainpanel->Controls->Add(this->pictureBox3);
			this->Villainpanel->Controls->Add(this->pictureBox4);
			this->Villainpanel->Controls->Add(this->pictureBox2);
			this->Villainpanel->Controls->Add(this->pictureBox1);
			this->Villainpanel->Dock = System::Windows::Forms::DockStyle::Top;
			this->Villainpanel->Location = System::Drawing::Point(0, 0);
			this->Villainpanel->Name = L"Villainpanel";
			this->Villainpanel->Size = System::Drawing::Size(597, 257);
			this->Villainpanel->TabIndex = 5;
			// 
			// pictureBox2
			// 
			this->pictureBox2->Location = System::Drawing::Point(108, 12);
			this->pictureBox2->Name = L"pictureBox2";
			this->pictureBox2->Size = System::Drawing::Size(90, 67);
			this->pictureBox2->TabIndex = 1;
			this->pictureBox2->TabStop = false;
			// 
			// pictureBox3
			// 
			this->pictureBox3->Location = System::Drawing::Point(300, 12);
			this->pictureBox3->Name = L"pictureBox3";
			this->pictureBox3->Size = System::Drawing::Size(90, 67);
			this->pictureBox3->TabIndex = 3;
			this->pictureBox3->TabStop = false;
			// 
			// pictureBox4
			// 
			this->pictureBox4->Location = System::Drawing::Point(204, 12);
			this->pictureBox4->Name = L"pictureBox4";
			this->pictureBox4->Size = System::Drawing::Size(90, 67);
			this->pictureBox4->TabIndex = 2;
			this->pictureBox4->TabStop = false;
			// 
			// pictureBox5
			// 
			this->pictureBox5->Location = System::Drawing::Point(492, 12);
			this->pictureBox5->Name = L"pictureBox5";
			this->pictureBox5->Size = System::Drawing::Size(90, 67);
			this->pictureBox5->TabIndex = 5;
			this->pictureBox5->TabStop = false;
			// 
			// pictureBox6
			// 
			this->pictureBox6->Location = System::Drawing::Point(396, 12);
			this->pictureBox6->Name = L"pictureBox6";
			this->pictureBox6->Size = System::Drawing::Size(90, 67);
			this->pictureBox6->TabIndex = 4;
			this->pictureBox6->TabStop = false;
			// 
			// pictureBox7
			// 
			this->pictureBox7->Location = System::Drawing::Point(492, 85);
			this->pictureBox7->Name = L"pictureBox7";
			this->pictureBox7->Size = System::Drawing::Size(90, 67);
			this->pictureBox7->TabIndex = 11;
			this->pictureBox7->TabStop = false;
			// 
			// pictureBox8
			// 
			this->pictureBox8->Location = System::Drawing::Point(396, 85);
			this->pictureBox8->Name = L"pictureBox8";
			this->pictureBox8->Size = System::Drawing::Size(90, 67);
			this->pictureBox8->TabIndex = 10;
			this->pictureBox8->TabStop = false;
			// 
			// pictureBox9
			// 
			this->pictureBox9->Location = System::Drawing::Point(300, 85);
			this->pictureBox9->Name = L"pictureBox9";
			this->pictureBox9->Size = System::Drawing::Size(90, 67);
			this->pictureBox9->TabIndex = 9;
			this->pictureBox9->TabStop = false;
			// 
			// pictureBox10
			// 
			this->pictureBox10->Location = System::Drawing::Point(204, 85);
			this->pictureBox10->Name = L"pictureBox10";
			this->pictureBox10->Size = System::Drawing::Size(90, 67);
			this->pictureBox10->TabIndex = 8;
			this->pictureBox10->TabStop = false;
			// 
			// pictureBox11
			// 
			this->pictureBox11->Location = System::Drawing::Point(108, 85);
			this->pictureBox11->Name = L"pictureBox11";
			this->pictureBox11->Size = System::Drawing::Size(90, 67);
			this->pictureBox11->TabIndex = 7;
			this->pictureBox11->TabStop = false;
			// 
			// pictureBox12
			// 
			this->pictureBox12->Location = System::Drawing::Point(12, 85);
			this->pictureBox12->Name = L"pictureBox12";
			this->pictureBox12->Size = System::Drawing::Size(90, 67);
			this->pictureBox12->TabIndex = 6;
			this->pictureBox12->TabStop = false;
			// 
			// pictureBox13
			// 
			this->pictureBox13->Location = System::Drawing::Point(492, 158);
			this->pictureBox13->Name = L"pictureBox13";
			this->pictureBox13->Size = System::Drawing::Size(90, 67);
			this->pictureBox13->TabIndex = 17;
			this->pictureBox13->TabStop = false;
			// 
			// pictureBox14
			// 
			this->pictureBox14->Location = System::Drawing::Point(396, 158);
			this->pictureBox14->Name = L"pictureBox14";
			this->pictureBox14->Size = System::Drawing::Size(90, 67);
			this->pictureBox14->TabIndex = 16;
			this->pictureBox14->TabStop = false;
			// 
			// pictureBox15
			// 
			this->pictureBox15->Location = System::Drawing::Point(300, 158);
			this->pictureBox15->Name = L"pictureBox15";
			this->pictureBox15->Size = System::Drawing::Size(90, 67);
			this->pictureBox15->TabIndex = 15;
			this->pictureBox15->TabStop = false;
			// 
			// pictureBox16
			// 
			this->pictureBox16->Location = System::Drawing::Point(204, 158);
			this->pictureBox16->Name = L"pictureBox16";
			this->pictureBox16->Size = System::Drawing::Size(90, 67);
			this->pictureBox16->TabIndex = 14;
			this->pictureBox16->TabStop = false;
			// 
			// pictureBox17
			// 
			this->pictureBox17->Location = System::Drawing::Point(108, 158);
			this->pictureBox17->Name = L"pictureBox17";
			this->pictureBox17->Size = System::Drawing::Size(90, 67);
			this->pictureBox17->TabIndex = 13;
			this->pictureBox17->TabStop = false;
			// 
			// pictureBox18
			// 
			this->pictureBox18->Location = System::Drawing::Point(12, 158);
			this->pictureBox18->Name = L"pictureBox18";
			this->pictureBox18->Size = System::Drawing::Size(90, 67);
			this->pictureBox18->TabIndex = 12;
			this->pictureBox18->TabStop = false;
			// 
			// Main
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::Color::Black;
			this->ClientSize = System::Drawing::Size(597, 427);
			this->Controls->Add(this->OutMissileBox2);
			this->Controls->Add(this->OutMissileBox);
			this->Controls->Add(this->Villainpanel);
			this->Controls->Add(this->BarrierBox);
			this->Controls->Add(this->SpaceshipBox);
			this->MaximumSize = System::Drawing::Size(613, 466);
			this->MinimumSize = System::Drawing::Size(613, 466);
			this->Name = L"Main";
			this->Text = L"Main";
			this->Load += gcnew System::EventHandler(this, &Main::Main_Load);
			this->KeyDown += gcnew System::Windows::Forms::KeyEventHandler(this, &Main::Main_KeyDown);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->SpaceshipBox))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->BarrierBox))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->OutMissileBox))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->OutMissileBox2))->EndInit();
			this->Villainpanel->ResumeLayout(false);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox2))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox3))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox4))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox5))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox6))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox7))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox8))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox9))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox10))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox11))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox12))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox13))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox14))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox15))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox16))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox17))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox18))->EndInit();
			this->ResumeLayout(false);

		}
		#pragma endregion
		private: System::Void Main_Load(System::Object^  sender, System::EventArgs^  e)
		{
			rnd = gcnew Random();
			villain_array = gcnew array<CycleContainer^>(Villainpanel->Controls->Count);
			for (size_t i = 0; i < Villainpanel->Controls->Count; i++)
			{
				villain_array[i] = gcnew CycleContainer(2);
				for (size_t j = 1; j <= 2; j++)
				{
					villain_array[i][j-1] = Image::FromFile(Application::StartupPath 
						+ "\\Images\\villain_" + j + ".png");
				}
				((PictureBox^)Villainpanel->Controls[i])->Image = villain_array[i]->get_next();
				((PictureBox^)Villainpanel->Controls[i])->SizeMode = PictureBoxSizeMode::AutoSize;
			}
			
			
			//HatchBrush^ br = gcnew HatchBrush(HatchStyle::BackwardDiagonal, Color::Red, Color::White);
			//BarrierBox->CreateGraphics()->FillPolygon(br, 
			//	gcnew array<Point>{BarrierBox->Location, BarrierBox->Location+BarrierBox->Width});
			//BarrierBox->CreateGraphics()->FillRegion(br,pictureBox1->Region);
			BarrierBox->Visible = false;
			OutMissileBox->Visible = false;
			OutMissileBox->Image = Image::FromFile(Application::StartupPath 
				+ "\\Images\\outgoing_missile.png");
			OutMissileBox2->Visible = false;
			OutMissileBox2->Image = Image::FromFile(Application::StartupPath 
				+ "\\Images\\outgoing_missile.png");
			/*pictureBox1->Image = villain_array->get_next();*/
			SpaceshipBox->Image = Image::FromFile(Application::StartupPath 
				+ "\\Images\\spaceship.png");
			//pictureBox1->SizeMode = PictureBoxSizeMode::AutoSize;
			SpaceshipBox->SizeMode = PictureBoxSizeMode::AutoSize;
			OutMissileBox->SizeMode = PictureBoxSizeMode::AutoSize;
			OutMissileBox2->SizeMode = PictureBoxSizeMode::AutoSize;
			timer1->Interval = 250;
			timer1->Enabled = true;
		}

		private: System::Void timer1_Tick(System::Object^  sender, System::EventArgs^  e)
		{
			//pictureBox1->Image = villain_array->get_next();
			if (OutMissileBox->Visible || OutMissileBox2->Visible)
			{
				for (size_t i = 0; i < Villainpanel->Controls->Count; i++)
				{
					if (OutMissileBox->Visible && Villainpanel->Controls[i]->Visible)
					{
						if ((OutMissileBox->Location.X >= ((PictureBox^)Villainpanel->Controls[i])->Bounds.Left
							&& OutMissileBox->Location.X <= ((PictureBox^)Villainpanel->Controls[i])->Bounds.Right
							&& OutMissileBox->Location.Y >= ((PictureBox^)Villainpanel->Controls[i])->Bounds.Top
							&& OutMissileBox->Location.Y <= ((PictureBox^)Villainpanel->Controls[i])->Bounds.Bottom) 
							|| 
							(OutMissileBox->Location.X + OutMissileBox->Width >= ((PictureBox^)Villainpanel->Controls[i])->Bounds.Left
								&& OutMissileBox->Location.X + OutMissileBox->Width <= ((PictureBox^)Villainpanel->Controls[i])->Bounds.Right
								&& OutMissileBox->Location.Y >= ((PictureBox^)Villainpanel->Controls[i])->Bounds.Top
								&& OutMissileBox->Location.Y <= ((PictureBox^)Villainpanel->Controls[i])->Bounds.Bottom))
						{
							Villainpanel->Controls[i]->Visible = false;
							OutMissileBox->Visible = false;
						}
					}
					if (OutMissileBox2->Visible && Villainpanel->Controls[i]->Visible)
					{
						if ((OutMissileBox2->Location.X >= ((PictureBox^)Villainpanel->Controls[i])->Bounds.Left
							&& OutMissileBox2->Location.X <= ((PictureBox^)Villainpanel->Controls[i])->Bounds.Right
							&& OutMissileBox2->Location.Y >= ((PictureBox^)Villainpanel->Controls[i])->Bounds.Top
							&& OutMissileBox2->Location.Y <= ((PictureBox^)Villainpanel->Controls[i])->Bounds.Bottom) 
							|| 
							(OutMissileBox2->Location.X + OutMissileBox2->Width >= ((PictureBox^)Villainpanel->Controls[i])->Bounds.Left
								&& OutMissileBox2->Location.X + OutMissileBox2->Width <= ((PictureBox^)Villainpanel->Controls[i])->Bounds.Right
								&& OutMissileBox2->Location.Y >= ((PictureBox^)Villainpanel->Controls[i])->Bounds.Top
								&& OutMissileBox2->Location.Y <= ((PictureBox^)Villainpanel->Controls[i])->Bounds.Bottom))
						{
							Villainpanel->Controls[i]->Visible = false;
							OutMissileBox2->Visible = false;
						}
					}
				}
			}
			for (size_t i = 0; i < Villainpanel->Controls->Count; i++)
			{
				((PictureBox^)Villainpanel->Controls[i])->Image = villain_array[i]->get_next();
			}
			if (!sec_delay)
			{
				//millisec += timer1->Interval;
				if(millisec_barrier >= delay_barrier/3)
					sec_delay = true;
			}
			if (BarrierBox->Visible && millisec_barrier >= delay_barrier)
			{
				BarrierBox->Visible = false;
				millisec_barrier = 0;
				sec_delay = false;
			}
			else if (sec_delay && !rnd->Next(0, 2) && !BarrierBox->Visible)
			{
				BarrierBox->Visible = true;
				BarrierBox->Left = (rnd->Next(0,1)
					?rnd->Next(0, SpaceshipBox->Location.X - BarrierBox->Width - 5)
					:rnd->Next(SpaceshipBox->Location.X + SpaceshipBox->Width + 5, ClientSize.Width - BarrierBox->Width));;
			}
			millisec_barrier += timer1->Interval;
			if (OutMissileBox->Visible)
			{
				if(OutMissileBox->Bottom <= 0)
					OutMissileBox->Visible = false;
				else
					OutMissileBox->Top -= 10;
			}
			if (OutMissileBox2->Visible)
			{
				if(OutMissileBox2->Bottom <= 0)
					OutMissileBox2->Visible = false;
				else
					OutMissileBox2->Top -= 10;
			}
			millisec_missiles += timer1->Interval;
				
		}

		private: System::Void Main_KeyDown(System::Object^  sender, System::Windows::Forms::KeyEventArgs^  e)
		{
			switch (e->KeyCode)
			{
				case Keys::Left:
				{
					if (SpaceshipBox->Left > 0 + 5)
					{
						if(BarrierBox->Visible) 
							if(SpaceshipBox->Left > BarrierBox->Right + 5 
							|| SpaceshipBox->Right < BarrierBox->Left + 5)
								SpaceshipBox->Left -= 5;
							else 0;
						else SpaceshipBox->Left -= 5;
					}
						
				}break;
				case Keys::Right:
				{
					if (SpaceshipBox->Right < ClientSize.Width - 5)
					{
						if(BarrierBox->Visible) 
							if(SpaceshipBox->Right < BarrierBox->Left - 5 
							|| SpaceshipBox->Left > BarrierBox->Right + 5)
								SpaceshipBox->Left += 5;
							else 0;
						else SpaceshipBox->Left += 5;
					}
				}break;
				case Keys::Up:
				{
					if(SpaceshipBox->Top > (ClientSize.Height / 4)*3)
						SpaceshipBox->Top -= 5;
				}break;
				case Keys::Down:
				{
					if(SpaceshipBox->Bottom < ClientSize.Height - 5)
						SpaceshipBox->Top += 5;
				}break;
				case Keys::Space:
				{
					//if (millisec_missiles == 0)
					if(!OutMissileBox->Visible && millisec_missiles >= delay_missiles)
					{
						OutMissileBox->Left = SpaceshipBox->Left + SpaceshipBox->Width/2 - OutMissileBox->Width/2;
						OutMissileBox->Top = SpaceshipBox->Top - OutMissileBox->Height - 5;
						OutMissileBox->Visible = true;
						millisec_missiles = 0;
					}
					else if (!OutMissileBox2->Visible && millisec_missiles >= delay_missiles)
					{
						OutMissileBox2->Left = SpaceshipBox->Left + SpaceshipBox->Width/2 - OutMissileBox->Width/2;
						OutMissileBox2->Top = SpaceshipBox->Top - OutMissileBox->Height - 5;
						OutMissileBox2->Visible = true;
						millisec_missiles = 0;
					}
				}
				default:
					break;
			}
		}
//		//private: void MoveImg(Point point) 
//		//{
//		//	/*if (imgPoint.X > point.X) imgPoint.X--;
//		//	if (imgPoint.X < point.X) imgPoint.X++;
//		//	if (imgPoint.Y > point.Y) imgPoint.Y--;
//		//	if (imgPoint.Y < point.Y) imgPoint.Y++;*/
//		//}
//
//		/*private: System::Void Main_Paint(System::Object^  sender, System::Windows::Forms::PaintEventArgs^  e)
//		{
//
//		}
//
//		private: System::Void Main_MouseDown(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e)
//		{
//
//		}
//*/
//		/*private: System::Void Main_MouseMove(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e)
//		{
//
//		}*/
//		/*private: System::Void pictureBox1_MouseDown(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e)
//		{
//			i_mouse = true;
//		}
//		private: System::Void pictureBox1_MouseUp(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e)
//		{
//			i_mouse = false;
//		}
//		private: System::Void pictureBox1_MouseMove(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e)
//		{
//			int mouseX = e->Location.X;
//			int mouseY = e->Location.Y;
//			if (i_mouse && (Math::Abs(mouseX - pozx) >= 5 || Math::Abs(mouseY - pozy) >= 5)) {
//				pictureBox1->Left += mouseX - pictureBox1->Width / 2;
//				pictureBox1->Top += mouseY - pictureBox1->Height/ 2;
//				pozx = mouseX; pozy = mouseY;
//			}
//
//		}*/
	};
}
