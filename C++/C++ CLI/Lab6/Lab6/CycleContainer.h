#pragma once
using namespace System::Drawing;
public ref class CycleContainer
{
private:
	array<Image^>^ container;
	unsigned int current_index;
public:
	CycleContainer(int size)
	{
		container = gcnew array<Image^>(size);
		current_index = 0;
	}
	~CycleContainer()
	{
		for (size_t i = 0; i < container->Length; i++)
		{
			delete container[i];
		}
		delete container;
	}
	Image^% operator[](unsigned int index)
	{
		return container[index];
	}
	Image^ get_next()
	{
		if (current_index >= container->Length)
		{
			current_index = 0;
		}
		return container[current_index++];
	}
};