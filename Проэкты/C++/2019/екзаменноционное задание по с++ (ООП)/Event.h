#pragma once
#include<iostream>
#include<string>
#include<list>


class MyDate
{
	int days = 1;
	int get_day_in_year(int year)
	{
		if ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0))
		{
			return 366;
		}
		return 365;
	}
	int get_day_in_month(int m, int y)
	{
		if (m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12)
		{
			return 31;
		}
		else if (m == 4 || m == 6 || m == 9 || m == 11)
		{
			return 30;
		}
		else if (m == 2)
		{
			if (y == 366)
			{
				return 29;
			}
			else if (y == 365)
			{
				return 28;
			}
		}
	}
	int get_day_in_days()
	{
		int ndays = days;
		int n = 1;
		for (int i = days; i > get_day_in_year(n);)
		{
			i -= get_day_in_year(n);
			n++;
			ndays = i;
		}
		int month_ = 1;
		for (int i = ndays; i > get_day_in_month(month_, get_day_in_year(n));)
		{
			i -= get_day_in_month(month_, get_day_in_year(n));
			month_++;
			ndays = i;
		}

		return ndays;
	}
	int get_month_in_days()
	{
		int ndays = days;
		int n = 1;
		for (int i = days; i > get_day_in_year(n);)
		{
			i -= get_day_in_year(n);
			n++;
			ndays = i;
		}
		int month_ = 1;
		for (int i = ndays; i > get_day_in_month(month_, get_day_in_year(n));)
		{
			i -= get_day_in_month(month_, get_day_in_year(n));
			month_++;
			ndays = i;
		}
		return month_;
	}
	int get_year_in_days()
	{
		int n = 1;
		for (int i = days; i > get_day_in_year(n);)
		{
			i -= get_day_in_year(n);
			n++;
		}
		return n;
	}
public:
	MyDate() = default;
	MyDate(int day, int month, int year)
	{
		if (day <= get_day_in_month(month, get_day_in_year(year)) && day > 0 && month > 0 && month <= 12 && year > 0)
		{
			days = 0;
			for (int i = 1; i < year; i++)
			{
				days += get_day_in_year(i);
			}
			for (int i = 1; i < month; i++)
			{
				days += get_day_in_month(i, get_day_in_year(year));
			}
			days += day;
		}
	}


	MyDate operator +(int d)
	{
		days += d;
		return *this;
	}
	int operator -(const MyDate &obj)
	{
		return days - obj.days;
	}
	MyDate operator++(int)
	{
		days += 1;
		return *this;
	}
	MyDate operator--(int)
	{
		days -= 1;
		return *this;
	}
	bool operator <(const MyDate &obj)
	{
		if (days < obj.days)
		{
			return 1;
		}
		return 0;
	}
	bool operator >(const MyDate &obj)
	{
		if (days > obj.days)
		{
			return 1;
		}
		return 0;
	}
	bool operator <=(const MyDate &obj)
	{
		if (days <= obj.days)
		{
			return 1;
		}
		return 0;
	}
	bool operator >=(const MyDate &obj)
	{
		if (days >= obj.days)
		{
			return 1;
		}
		return 0;
	}
	bool operator ==(const MyDate &obj)
	{
		if (days == obj.days)
		{
			return 1;
		}
		return 0;
	}
	bool operator !=(const MyDate &obj)
	{
		if (days != obj.days)
		{
			return 1;
		}
		return 0;
	}

	explicit operator int() const
	{
		return days;
	}

	void show()
	{
		std::cout << get_day() << " : ";
		std::cout << get_month() << " : ";
		std::cout << get_year() << std::endl;
	}
	int get_days()const
	{
		return days;
	}
	int get_day()
	{
		return get_day_in_days();
	}
	int get_year()
	{
		return get_year_in_days();
	}
	int get_month()
	{
		return get_month_in_days();
	}
	void set_days(int day, int month, int year)
	{
		if (day <= get_day_in_month(month, get_day_in_year(year)) && day > 0 && month > 0 && month <= 12 && year > 0)
		{
			days = 0;
			for (int i = 1; i < year; i++)
			{
				days += get_day_in_year(i);
			}
			for (int i = 1; i < month; i++)
			{
				days += get_day_in_month(i, get_day_in_year(year));
			}
			days += day;
		}
	}
};



class Event
{
	std::string text;
public:
	Event();
	Event(const std::string &textt);
	virtual ~Event() = 0;
	const std::string &get_text()const;
	void set_text(const std::string &str);
};

Event::~Event(){ }
Event::Event() { text = "notext"; }
Event::Event(const std::string &textt)
{
	text = textt;
}
const std::string & Event::get_text()const
{
	return text;
}
void Event::set_text(const std::string &str)
{
	text = str;
}



class Reminder :public Event
{
	MyDate data;
public:
	Reminder();
	Reminder(const std::string &str, int d, int m, int y);
	void set_data(int d, int m, int y);
	int get_days()const;
};

Reminder::Reminder(const std::string &str, int d, int m, int y) :Event(str)
{
	data.set_days(d, m, y);
}
Reminder::Reminder() :Event()
{
	data.set_days(1, 1, 1);
}
void Reminder::set_data(int d, int m, int y)
{
	data.set_days(d, m, y);
}
int Reminder::get_days()const
{
	return data.get_days();
}



class Notes :public Event
{
	std::string title;
public:
	Notes();
	Notes(const std::string &str, const std::string &titl);
	void set_title(const std::string &titl);
	const std::string &get_title()const;
};

Notes::Notes() :Event()
{
	title = "notitle";
}
Notes::Notes(const std::string &str, const std::string &titl) : Event(str)
{
	title = titl;
}
void Notes::set_title(const std::string &titl)
{
	title = titl;
}
const std::string &Notes::get_title()const
{
	return title;
}


class list_reminders
{
public:
	std::list<Reminder> lst_rm;
public:
	list_reminders();
	
	
};

list_reminders::list_reminders()
{}




