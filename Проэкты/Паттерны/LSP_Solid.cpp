#include<iostream>
#include<list>
#include<string>

using namespace std;

class Bird
{
    string color;
    string habitation;
public:
    Bird(const string & c, const string&h)
    {
        color = c;
        habitation = h;
    }
    const string &getColor() const
    {
        return color;
    }

    void setColor(const string &color)
    {
        this->color = color;
    }

    const string &getHabitation() const
    {
        return habitation;
    }

    void setHabitation(const string &habitation)
    {
        this->habitation = habitation;
    }

};
class FlyingBird:public Bird
{
public:
    FlyingBird(const string & c, const string&h):Bird(c,h)
    {
    }
    virtual void flying()
    {
        cout<<"Bird is flying"<<endl;
    }
};

class Pigeon:public FlyingBird
{
public:
    Pigeon():FlyingBird("Dirty","Cities"){}
    void flying()override
    {
        cout<<"Pigeon is flying bad"<<endl;
    }
};
class Hummingbird:public FlyingBird
{
public:
    Hummingbird():FlyingBird("Green-Gray","South America"){}
    void flying()override
    {
        cout<<"Hummingbird is flying backward"<<endl;
    }
};
class Penguin:public Bird
{
public:
    Penguin():Bird("Black","Antarctica"){}

};
int main()
{
    srand(time(0));
    list<FlyingBird*> birds;
    for (int i = 0; i <10 ; ++i)
    {
        switch(rand()%3)
        {
            case 0:
                birds.push_back(new FlyingBird("SomeColor","SomePlace"));
                break;
            case 1:
                birds.push_back(new Pigeon());
                break;
            case 2:
                birds.push_back(new Hummingbird);
                break;

        }
    }
    for(auto i : birds)
    {
           i->flying();
       
    }
    for(auto i : birds)
    {
        delete i;
    }

}