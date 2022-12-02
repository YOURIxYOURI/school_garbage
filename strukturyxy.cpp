#include <iostream>
#include <cmath>

using namespace std;

struct punkt{
    double x,y;
};

struct wielobok{
    unsigned int n;
    punkt* tab = nullptr;
};

void wczytaj(punkt &p);
void wczytaj(wielobok &wb);
void wypisz(const punkt &p);
void wypisz(const wielobok &wb);
double bok(punkt &p1, punkt &p2);
double obwod(wielobok &wb);


int main() {
    wielobok wb;
    
    wczytaj(wb);
    
    wypisz(wb);
    
    cout << "\nobwod figury to " << obwod(wb);
    
    // wielobok* ptr = new wielobok;
    
    // wczytaj(*ptr);
    
    // wypisz(*ptr);
    
    // delete [] ptr->tab; 
    // delete ptr;
    delete [] wb.tab; 
    return 0;
}

void wczytaj(punkt &p){
    cout << "\npodaj X punktu ";
    cin >> p.x;
    cout << "\npodaj Y punktu ";
    cin >> p.y;
}

void wczytaj(wielobok &wb){
    cout << "\npodaj liczbe punktów ";
    cin >> wb.n;
    wb.tab = new punkt [wb.n];
    for(int i = 0;i < wb.n;i++){
        wczytaj(wb.tab[i]);
    }
}

void wypisz(const punkt &p) {
    cout << "\n(" << p.x << "," << p.y << ")";
}

void wypisz(const wielobok &wb){
    for(int i = 0;i < wb.n;i++){
        wypisz(wb.tab[i]);
    }
}

double bok(punkt &p1, punkt &p2) {
    double bok = sqrt(pow(p2.x - p1.x,2)+pow(p2.y-p1.y,2));
    return bok;
}

double obwod(wielobok &wb){
    double ob = 0;
    for(int i = 0;i < wb.n;i++){
        if(i != wb.n-1)
            ob += bok(wb.tab[i+1], wb.tab[i]);
        else
            ob += bok(wb.tab[i], wb.tab[0]);
    }
    return ob;
}





