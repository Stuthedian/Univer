#pragma once

namespace Lab {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace System::Drawing::Drawing2D;

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
	private: System::Windows::Forms::ListBox^  listBox3;
	private: System::Windows::Forms::ListBox^  listBox2;
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::ListBox^  listBox1;
	private: System::Windows::Forms::Panel^  Paintpanel;
	private: System::Windows::Forms::ColorDialog^  colorDialog1;
	private: System::Windows::Forms::Panel^  Colorpanel;

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
			this->Colorpanel = (gcnew System::Windows::Forms::Panel());
			this->listBox3 = (gcnew System::Windows::Forms::ListBox());
			this->listBox2 = (gcnew System::Windows::Forms::ListBox());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->listBox1 = (gcnew System::Windows::Forms::ListBox());
			this->Paintpanel = (gcnew System::Windows::Forms::Panel());
			this->colorDialog1 = (gcnew System::Windows::Forms::ColorDialog());
			this->panel1->SuspendLayout();
			this->SuspendLayout();
			// 
			// panel1
			// 
			this->panel1->BackColor = System::Drawing::SystemColors::ControlLight;
			this->panel1->Controls->Add(this->Colorpanel);
			this->panel1->Controls->Add(this->listBox3);
			this->panel1->Controls->Add(this->listBox2);
			this->panel1->Controls->Add(this->label1);
			this->panel1->Controls->Add(this->listBox1);
			this->panel1->Dock = System::Windows::Forms::DockStyle::Left;
			this->panel1->Location = System::Drawing::Point(0, 0);
			this->panel1->Name = L"panel1";
			this->panel1->Size = System::Drawing::Size(127, 337);
			this->panel1->TabIndex = 0;
			// 
			// Colorpanel
			// 
			this->Colorpanel->BorderStyle = System::Windows::Forms::BorderStyle::Fixed3D;
			this->Colorpanel->Location = System::Drawing::Point(100, 267);
			this->Colorpanel->Name = L"Colorpanel";
			this->Colorpanel->Size = System::Drawing::Size(23, 19);
			this->Colorpanel->TabIndex = 4;
			this->Colorpanel->MouseClick += gcnew System::Windows::Forms::MouseEventHandler(this, &Main::Colorpanel_MouseClick);
			// 
			// listBox3
			// 
			this->listBox3->FormattingEnabled = true;
			this->listBox3->Location = System::Drawing::Point(3, 192);
			this->listBox3->Name = L"listBox3";
			this->listBox3->Size = System::Drawing::Size(120, 69);
			this->listBox3->TabIndex = 3;
			this->listBox3->Click += gcnew System::EventHandler(this, &Main::listBox2_Click);
			// 
			// listBox2
			// 
			this->listBox2->FormattingEnabled = true;
			this->listBox2->Location = System::Drawing::Point(3, 117);
			this->listBox2->Name = L"listBox2";
			this->listBox2->Size = System::Drawing::Size(120, 69);
			this->listBox2->TabIndex = 2;
			this->listBox2->Click += gcnew System::EventHandler(this, &Main::listBox2_Click);
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(3, 264);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(35, 13);
			this->label1->TabIndex = 1;
			this->label1->Text = L"label1";
			// 
			// listBox1
			// 
			this->listBox1->FormattingEnabled = true;
			this->listBox1->Location = System::Drawing::Point(3, 3);
			this->listBox1->Name = L"listBox1";
			this->listBox1->Size = System::Drawing::Size(120, 108);
			this->listBox1->TabIndex = 0;
			// 
			// Paintpanel
			// 
			this->Paintpanel->AutoSize = true;
			this->Paintpanel->BackColor = System::Drawing::Color::White;
			this->Paintpanel->Dock = System::Windows::Forms::DockStyle::Fill;
			this->Paintpanel->Location = System::Drawing::Point(127, 0);
			this->Paintpanel->Name = L"Paintpanel";
			this->Paintpanel->Size = System::Drawing::Size(335, 337);
			this->Paintpanel->TabIndex = 1;
			this->Paintpanel->MouseDown += gcnew System::Windows::Forms::MouseEventHandler(this, &Main::Paintpanel_MouseDown);
			this->Paintpanel->MouseMove += gcnew System::Windows::Forms::MouseEventHandler(this, &Main::Paintpanel_MouseMove);
			this->Paintpanel->MouseUp += gcnew System::Windows::Forms::MouseEventHandler(this, &Main::Paintpanel_MouseUp);
			// 
			// colorDialog1
			// 
			this->colorDialog1->FullOpen = true;
			// 
			// Main
			// 
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::None;
			this->ClientSize = System::Drawing::Size(462, 337);
			this->Controls->Add(this->Paintpanel);
			this->Controls->Add(this->panel1);
			this->Name = L"Main";
			this->Text = L"Main";
			this->Load += gcnew System::EventHandler(this, &Main::Main_Load);
			this->panel1->ResumeLayout(false);
			this->panel1->PerformLayout();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: int x1, y1, x2, y2, c1, c2;
	private: bool is_painting;
	private: GraphicsPath^ mousePath;
	private: Point p;
	private: System::String ^ putLabel(System::Void) {
		String ^s;
		s = "(" + x1 + "," + y1 + ")\r\n(" + x2 + "," + y2 + ")\r\n" +
			"(" + listBox2->Items[listBox2->SelectedIndex]->ToString() + "," +
			listBox3->Items[listBox3->SelectedIndex]->ToString() + ")";
		label1->Text = s;
		return s;
	}
	
	private: System::Void Main_Load(System::Object^  sender, System::EventArgs^  e)
	{
		is_painting = false;
		mousePath = gcnew GraphicsPath();
		p.X = -1; 
		p.Y = -1;
		Colorpanel->BackColor = colorDialog1->Color;
		listBox1->Items->AddRange(gcnew array<Object^> {"Окружность",
			"Отрезок", "Прямоугольник", "Сектор",
			"Текст", "Эллипс", "Закрашенный сектор", "Треугольник (случайно)",
			"Карандаш", "Дуга"});
		listBox1->SelectedIndex = 0;
		Font = gcnew System::Drawing::Font("Times New Roman", 14.F);
		x1=50; y1=50; x2=150; y2=150; c1=0; c2=45;
		for (int i = 0; i < 360/45 + 1; i++)
		{
			listBox2->Items->Add(i*45);
			listBox3->Items->Add(i*45);
		}
		listBox2->SelectedIndex = 0;
		listBox3->SelectedIndex = 1;
		putLabel();
	}
	private: System::Void listBox2_Click(System::Object^  sender, System::EventArgs^  e)
	{
		//Назначено также на событие Click для списка listBox3
		if (sender->Equals((Object ^)this->listBox2)) c1 = 
			Convert::ToInt16(listBox2->Items[listBox2->SelectedIndex]->ToString());
		else c2 = Convert::ToInt16(listBox3->Items[listBox3->SelectedIndex]->ToString());
		putLabel();
	}
	private: System::Void Paintpanel_MouseDown(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e)
	{
		x1=e->X; y1=e->Y;
		putLabel();
		mousePath->AddLine(Point(e->X, e->Y), Point(e->X, e->Y));
		is_painting = true;
	}
	private: System::Void Paintpanel_MouseUp(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e)
	{
		x2 = e->X; y2 = e->Y;
		putLabel();
		is_painting = false;
		//Graphics ^ MyGraphics = this->CreateGraphics();
		Graphics ^ MyGraphics = Paintpanel->CreateGraphics();
		Pen ^ MyPen = gcnew Pen(colorDialog1->Color);  // Создание пера для рисования фигур
		SolidBrush ^ MyBrush = gcnew SolidBrush(colorDialog1->Color); // Создание кисти для "закрашивания" фигур
		MyGraphics->Clear(Color::White); // Очистка области рисования 
												  // или MyGraphics->Clear(Color::FromName("Control"));
												  // или MyGraphics->Clear(ColorTranslator::FromHtml("#EFEBDE"));
		int x = Math::Min(x1,x2); //Обработка сохраненных координат клика и отпускания мыши
		int y = Math::Min(y1,y2);
		int w = Math::Abs(x2-x1+1);
		int h = Math::Abs(y2-y1+1);
		if(!(w && h))
			return;
		switch (listBox1->SelectedIndex) { //Выбор фигуры
			case 0: // - выбрана окружность:
				MyGraphics->DrawEllipse(MyPen, x, y, w, h); break;
			case 1: // - выбран отрезок:
				MyGraphics->DrawLine(MyPen, x1, y1, x2, y2); break;
			case 2: // - выбран прямоугольник:
				MyGraphics->DrawRectangle(MyPen, x, y, w, h); break;
			case 3: // - выбран сектор:
				MyGraphics->DrawPie(MyPen, x, y, w, h, c1, c2); break;
			case 4: // - выбран текст:
				MyGraphics->DrawString(putLabel(), Font, MyBrush, x1, y1); break;
			case 5: // - выбран эллипс:
				MyGraphics->DrawEllipse(MyPen, x, y, w, h); break;
			case 6: // - выбран закрашенный сектор:
				MyGraphics->FillPie(MyBrush, x, y, w, h, c1, c2); break;
			case 7: //треугольник со случайной точкой
				{
					Point p1 = Point(x1, y1);
					Point p2 = Point(x2, y2);
					Random ^r = gcnew Random();
					//Point p3 = Point(r->Next() % this->ClientSize.Width, r->Next()%this->ClientSize.Height);
					Point p3 = Point(r->Next() % Paintpanel->ClientSize.Width, r->Next()%Paintpanel->ClientSize.Height);
					array<Point>^ MyPoints = { p1, p2, p3 };
					MyGraphics->FillPolygon(gcnew SolidBrush(SystemColors::ControlDark), MyPoints);
					this->TransparencyKey = SystemColors::ControlDark; //цвет, который будет выглядеть 
				}
				break;
			case 8:
				MyGraphics->DrawPath(gcnew Pen(colorDialog1->Color), mousePath); 
				p.X = -1; 
				p.Y = -1;
				mousePath = gcnew GraphicsPath();
				break;
			case 9:
				MyGraphics->DrawArc(MyPen, x, y, w, h, c1, c2); break;
		}
	}
	private: System::Void Paintpanel_MouseMove(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e)
	{
		if (is_painting)
		{
			x2 = e->X; y2 = e->Y;
			putLabel();
			Graphics ^ MyGraphics = Paintpanel->CreateGraphics();
			Pen ^ MyPen = gcnew Pen(Color::Gray); 
			MyPen->DashStyle = DashStyle::Dash;
			HatchBrush^ hatchbrush = gcnew HatchBrush(HatchStyle::BackwardDiagonal,	
				Color::Gray, SystemColors::Control);
			//SolidBrush ^ MyBrush = gcnew SolidBrush(Color::Red); // Создание кисти для "закрашивания" фигур
			MyGraphics->Clear(Color::White); // Очистка области рисования 
													  // или MyGraphics->Clear(Color::FromName("Control"));
													  // или MyGraphics->Clear(ColorTranslator::FromHtml("#EFEBDE"));
			int x = Math::Min(x1,x2); //Обработка сохраненных координат клика и отпускания мыши
			int y = Math::Min(y1,y2);
			int w = Math::Abs(x2-x1+1);
			int h = Math::Abs(y2-y1+1);
			if(!(w && h))
				return;
			switch (listBox1->SelectedIndex) { //Выбор фигуры
				case 0: // - выбрана окружность:
					MyGraphics->DrawEllipse(MyPen, x, y, w, h); break;
				case 1: // - выбран отрезок:
					MyGraphics->DrawLine(MyPen, x1, y1, x2, y2); break;
				case 2: // - выбран прямоугольник:
					MyGraphics->DrawRectangle(MyPen, x, y, w, h); break;
				case 3: // - выбран сектор:
					MyGraphics->DrawPie(MyPen, x, y, w, h, c1, c2); break;
				case 4: // - выбран текст:
					MyGraphics->DrawString(putLabel(), Font, hatchbrush, x1, y1); break;
				case 5: // - выбран эллипс:
					MyGraphics->DrawEllipse(MyPen, x, y, w, h); break;
				case 6: // - выбран закрашенный сектор:
					MyGraphics->FillPie(hatchbrush, x, y, w, h, c1, c2); break;
				case 7:
					{//треугольник со случайной точкой
						Point p1 = Point(x1, y1);
						Point p2 = Point(x2, y2);
						Random ^r = gcnew Random();
						//Point p3 = Point(r->Next() % this->ClientSize.Width, r->Next()%this->ClientSize.Height);
						Point p3 = Point(r->Next() % Paintpanel->ClientSize.Width, r->Next()%Paintpanel->ClientSize.Height);
						array<Point>^ MyPoints = { p1, p2, p3 };
						MyGraphics->FillPolygon(gcnew SolidBrush(SystemColors::ControlDark), MyPoints);
						this->TransparencyKey = SystemColors::ControlDark; //цвет, который будет выглядеть 
					}
					break;
				case 8:
					if (p.X == -1 || p.Y == -1) 
					{ 
						p.X = e->X; 
						p.Y = e->Y; 
					}
					else if (p.X != e->X || p.Y != e->Y) 
					{
						mousePath->AddLine(p.X, p.Y, e->X, e->Y);
						p.X = e->X; 
						p.Y = e->Y;
					}
					MyGraphics->DrawPath(MyPen, mousePath);
					break;
				case 9:
					MyGraphics->DrawArc(MyPen, x, y, w, h, c1, c2); break;
			}
		}
	}

	private: System::Void Colorpanel_MouseClick(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e)
	{
		colorDialog1->ShowDialog();
		Colorpanel->BackColor = colorDialog1->Color;
	}
};
}
