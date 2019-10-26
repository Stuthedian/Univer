#pragma once
#include "parser.h"
#include "TabForm.h"

namespace Lab4_3 {

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
	private: System::Windows::Forms::Button^  Tabbutton;
	private: System::Windows::Forms::Button^  Okbutton;
	private: System::Windows::Forms::Label^  label4;
	private: System::Windows::Forms::Label^  label3;
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::TextBox^  dX;
	private: System::Windows::Forms::TextBox^  EndX;
	private: System::Windows::Forms::TextBox^  StartX;
	private: System::Windows::Forms::TextBox^  FuncBox;
	private: System::Windows::Forms::DataVisualization::Charting::Chart^  chart1;

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
			System::Windows::Forms::DataVisualization::Charting::ChartArea^  chartArea1 = (gcnew System::Windows::Forms::DataVisualization::Charting::ChartArea());
			System::Windows::Forms::DataVisualization::Charting::Legend^  legend1 = (gcnew System::Windows::Forms::DataVisualization::Charting::Legend());
			System::Windows::Forms::DataVisualization::Charting::Series^  series1 = (gcnew System::Windows::Forms::DataVisualization::Charting::Series());
			this->panel1 = (gcnew System::Windows::Forms::Panel());
			this->Tabbutton = (gcnew System::Windows::Forms::Button());
			this->Okbutton = (gcnew System::Windows::Forms::Button());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->dX = (gcnew System::Windows::Forms::TextBox());
			this->EndX = (gcnew System::Windows::Forms::TextBox());
			this->StartX = (gcnew System::Windows::Forms::TextBox());
			this->FuncBox = (gcnew System::Windows::Forms::TextBox());
			this->chart1 = (gcnew System::Windows::Forms::DataVisualization::Charting::Chart());
			this->panel1->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->chart1))->BeginInit();
			this->SuspendLayout();
			// 
			// panel1
			// 
			this->panel1->Controls->Add(this->Tabbutton);
			this->panel1->Controls->Add(this->Okbutton);
			this->panel1->Controls->Add(this->label4);
			this->panel1->Controls->Add(this->label3);
			this->panel1->Controls->Add(this->label2);
			this->panel1->Controls->Add(this->label1);
			this->panel1->Controls->Add(this->dX);
			this->panel1->Controls->Add(this->EndX);
			this->panel1->Controls->Add(this->StartX);
			this->panel1->Controls->Add(this->FuncBox);
			this->panel1->Dock = System::Windows::Forms::DockStyle::Top;
			this->panel1->Location = System::Drawing::Point(0, 0);
			this->panel1->Name = L"panel1";
			this->panel1->Size = System::Drawing::Size(624, 79);
			this->panel1->TabIndex = 0;
			// 
			// Tabbutton
			// 
			this->Tabbutton->Location = System::Drawing::Point(429, 38);
			this->Tabbutton->Name = L"Tabbutton";
			this->Tabbutton->Size = System::Drawing::Size(88, 23);
			this->Tabbutton->TabIndex = 9;
			this->Tabbutton->Text = L"Табулировать";
			this->Tabbutton->UseVisualStyleBackColor = true;
			this->Tabbutton->Click += gcnew System::EventHandler(this, &Main::Tabbutton_Click);
			// 
			// Okbutton
			// 
			this->Okbutton->Location = System::Drawing::Point(429, 9);
			this->Okbutton->Name = L"Okbutton";
			this->Okbutton->Size = System::Drawing::Size(88, 23);
			this->Okbutton->TabIndex = 8;
			this->Okbutton->Text = L"Построить";
			this->Okbutton->UseVisualStyleBackColor = true;
			this->Okbutton->Click += gcnew System::EventHandler(this, &Main::Okbutton_Click);
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->Location = System::Drawing::Point(323, 6);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(27, 13);
			this->label4->TabIndex = 7;
			this->label4->Text = L"Шаг";
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Location = System::Drawing::Point(256, 6);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(22, 13);
			this->label3->TabIndex = 6;
			this->label3->Text = L"До";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(188, 6);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(20, 13);
			this->label2->TabIndex = 5;
			this->label2->Text = L"От";
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(50, 9);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(53, 13);
			this->label1->TabIndex = 4;
			this->label1->Text = L"Функция";
			// 
			// dX
			// 
			this->dX->Location = System::Drawing::Point(305, 22);
			this->dX->MaxLength = 10;
			this->dX->Name = L"dX";
			this->dX->Size = System::Drawing::Size(63, 20);
			this->dX->TabIndex = 3;
			this->dX->Text = L"1";
			// 
			// EndX
			// 
			this->EndX->Location = System::Drawing::Point(236, 22);
			this->EndX->MaxLength = 10;
			this->EndX->Name = L"EndX";
			this->EndX->Size = System::Drawing::Size(63, 20);
			this->EndX->TabIndex = 2;
			this->EndX->Text = L"3,14";
			// 
			// StartX
			// 
			this->StartX->Location = System::Drawing::Point(167, 22);
			this->StartX->MaxLength = 10;
			this->StartX->Name = L"StartX";
			this->StartX->Size = System::Drawing::Size(63, 20);
			this->StartX->TabIndex = 1;
			this->StartX->Text = L"0";
			// 
			// FuncBox
			// 
			this->FuncBox->Location = System::Drawing::Point(12, 22);
			this->FuncBox->Name = L"FuncBox";
			this->FuncBox->Size = System::Drawing::Size(129, 20);
			this->FuncBox->TabIndex = 0;
			this->FuncBox->Text = L"sin(x)";
			// 
			// chart1
			// 
			chartArea1->Name = L"ChartArea1";
			this->chart1->ChartAreas->Add(chartArea1);
			this->chart1->Dock = System::Windows::Forms::DockStyle::Fill;
			legend1->Name = L"Legend1";
			this->chart1->Legends->Add(legend1);
			this->chart1->Location = System::Drawing::Point(0, 79);
			this->chart1->Name = L"chart1";
			series1->ChartArea = L"ChartArea1";
			series1->Legend = L"Legend1";
			series1->Name = L"Series1";
			this->chart1->Series->Add(series1);
			this->chart1->Size = System::Drawing::Size(624, 282);
			this->chart1->TabIndex = 1;
			this->chart1->Text = L"chart1";
			// 
			// Main
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(624, 361);
			this->Controls->Add(this->chart1);
			this->Controls->Add(this->panel1);
			this->MinimumSize = System::Drawing::Size(640, 400);
			this->Name = L"Main";
			this->Text = L"Main";
			this->Load += gcnew System::EventHandler(this, &Main::Main_Load);
			this->panel1->ResumeLayout(false);
			this->panel1->PerformLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->chart1))->EndInit();
			this->ResumeLayout(false);

		}
#pragma endregion
	private: bool Parse (String ^s, double &a)	{
		bool A = Double::TryParse(s,System::Globalization::NumberStyles::Number,
			System::Globalization::NumberFormatInfo::CurrentInfo,a);
		return A;
	}
	private: bool Check (String ^Str,double x1) {
		TParser *parser = new TParser();
		try {
			double x=x1;
			Str=Str->Replace("x",x.ToString());
			char *p = (char*) (Runtime::InteropServices::Marshal::StringToHGlobalAnsi (Str)).ToPointer ();
			parser->Compile(p);
			parser->Evaluate();
			return true;      
		}
		catch (...) {
			return false;
		}
	}
	private: void Go (String ^S,double x1, double x2, double dX) {
		TParser *parser = new TParser();
		using namespace System::Windows::Forms::DataVisualization::Charting;
		using namespace System::Collections::Generic; 
		using namespace System::Drawing::Drawing2D;
		using namespace System::Drawing;
		using namespace Runtime::InteropServices;
		Dictionary <double, double>^ f1 = gcnew Dictionary<double, double>();
		String ^ Str;
		double x;
		char *p;
		chart1->Series[0]->ChartType = SeriesChartType::Line;
		chart1->Series[0]->MarkerStyle = MarkerStyle::Circle;
		ArrayList^ points = gcnew ArrayList();
		System::Globalization::NumberFormatInfo ^ nfi = gcnew System::Globalization::NumberFormatInfo();
		nfi->NumberDecimalSeparator = "."; //для C++ нужна "принудительная" точка разделителем целой и дробной части
		try {
			for (x=x1; x<=x2; x+=dX) {
				Str=S->Replace("x",x.ToString(nfi));
				p = (char*) (Marshal::StringToHGlobalAnsi(Str)).ToPointer();
				parser->Compile(p);
				parser->Evaluate();
				f1->Add(x, parser->GetResult()); 
			}
		}
		catch(TError error) {
			System::String ^ str1 = gcnew System::String (error.error);
			System::String ^ str2 = gcnew System::String (error.pos.ToString());
			MessageBox::Show ("Ошибка " + str1 +  " в позиции строки разбора " + str2+" для x = "+x,
				"Ошибка парсера",MessageBoxButtons::OK);
			//return;
		}
		chart1->Series[0]->LegendText = S;
		chart1->Series[0]->Color = System::Drawing::Color::Green;
		chart1->Series[0]->BorderWidth = 2;
		chart1->Series[0]->Points->DataBindXY(f1->Keys, f1->Values);
	}

	private: System::Void Okbutton_Click(System::Object^  sender, System::EventArgs^  e)
	{
		double start, end, step; 
		String ^ s = FuncBox->Text;
		this->chart1->Visible=false;
		
		if (Parse(StartX->Text,start)==false 
			|| Parse(EndX->Text,end)==false || Parse(dX->Text,step)==false) {
			MessageBox::Show ("Введите числовые значения x1,x2,dx","Ошибка",MessageBoxButtons::OK);
			return;
		}
		if (start>end || start+step>end) {
			MessageBox::Show ("Введите x1<x1+dX<x2","Ошибка",MessageBoxButtons::OK);
			return;
		}
		this->chart1->Visible=true;
		if (!Check (s,start)) {
			MessageBox::Show ("Введите верную функцию, не могу взять значение от 1-го аргумента",
				"Ошибка",MessageBoxButtons::OK);
			return;
		}
		Go (s, start, end, step);
	}
	private: System::Void Tabbutton_Click(System::Object^  sender, System::EventArgs^  e)
	{
		TabForm^ T2 = gcnew TabForm();
		using namespace System::Windows::Forms::DataVisualization::Charting;
		for each (DataPoint ^p in chart1->Series[0]->Points) { 
			T2->Do (p->XValue, p->YValues[0]);
		}
		T2->Show();
	}
	private: System::Void Main_Load(System::Object^  sender, System::EventArgs^  e)
	{
		chart1->Visible = false;
	}
};
}
