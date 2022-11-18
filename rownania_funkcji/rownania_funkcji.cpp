#include <iostream>

using namespace std;

int function(float a, float b, float c, int f, int check);

int main()
{
    float a, b, c, f, check_char;
    cout << "Podaj liczby: \na: ";
    cin >> a;
    if(a == 0){a = 1;}
    cout << "\nb: ";
    cin >> b;
    cout << "\nc: ";
    cin >> c;
    cout << "\nfunckja jest rownaniem(1) czy nierownoscia(2)?";
    cin >> f;
    if (f == 2) {
        cout << "\n 1. wieksze 2. mniejsze 3. wieksze lub rowne 4. mniejsze lub rowne";
        cin >> check_char;
        function(a, b, c, f, check_char);
    }else{
        function(a, b, c, f, NULL);
    }
    
}

int function(float a, float b, float c, int f, int check) {
    float x1, x2;
    int delta = (b * b) - 4 * a * c;
    if (delta < 0) {
        cout << "SPRZECZNE - Brak rozwiazania";
        return 0;
    }
    else if (delta == 0) {
        cout << a * 2 << " " << b * -1;
        x1 = (b * -1) / (2 * a);
        cout << "roziwazania rowniania to " << x1;
        return 0;
    }
    else if (delta > 0) {
        x1 = ((b * -1) - sqrt(delta)) / (2 * a);
        x2 = ((b * -1) + sqrt(delta)) / (2 * a);
    }
    if (delta > 0 && f == 1) {
        cout << "roziwazania rowniania to " << x1 << ", " << x2;
        return 0;
    }
    else if (delta > 0 && f == 2) {
        if (a > 0 && (check == 1 || check == 3)) {
            if(x1 > x2){
                if (check == 1) {
                    cout << "(-nieskonczonosc;" << x2 << ")  (" << x1 << ";nieskonczonosc)";
                }
                else if (check == 3) {
                    cout << "(-nieskonczonosc;" << x2 << ")  <" << x1 << ";nieskonczonosc)";
                }
            }
            else if (x1 < x2) {
                if (check == 1) {
                    cout << "(-nieskonczonosc;" << x1 << ")  (" << x2 << ";nieskonczonosc)";
                }
                else if (check == 3) {
                    cout << "(-nieskonczonosc;" << x1 << ")  <" << x2 << ";nieskonczonosc)";
                }
            }
            return 0;
        }
        else if (a < 0 && (check == 1 || check == 3)) {
            if (x1 > x2) {
                if (check == 1) {
                    cout << "(" << x2 << ";" << x1 << ")";
                }
                else if (check == 3) {
                    cout << "<" << x2 << ";" << x1 << ">";
                }
            }
            if (x1 < x2) {
                if (check == 1) {
                    cout << "(" << x1 << ";" << x2 << ")";
                }
                else if (check == 3) {
                    cout << "<" << x1 << ";" << x2 << ">";
                }
            }
            return 0;
        }
        else if (a > 0 && (check == 2 || check == 4)) {
            if (x1 > x2) {
                if (check == 2) {
                    cout << "(" << x2 << ";" << x1 << ")";
                }
                else if (check == 4) {
                    cout << "<" << x2 << ";" << x1 << ">";
                }
            }
            if (x1 < x2) {
                if (check == 2) {
                    cout << "(" << x1 << ";" << x2 << ")";
                }
                else if (check == 4) {
                    cout << "<" << x1 << ";" << x2 << ">";
                }
            }
            return 0;
        }
        else if (a < 0 && (check == 2 || check == 4)) {
            if (x1 > x2) {
                if (check == 2) {
                    cout << "(-nieskonczonosc;" << x2 << ")  (" << x1 << ";nieskonczonosc)";
                }
                else if (check == 4) {
                    cout << "(-nieskonczonosc;" << x2 << ")  <" << x1 << ";nieskonczonosc)";
                }
            }
            else if (x1 < x2) {
                if (check == 2) {
                    cout << "(-nieskonczonosc;" << x1 << ")  (" << x2 << ";nieskonczonosc)";
                }
                else if (check == 4) {
                    cout << "(-nieskonczonosc;" << x1 << ")  <" << x2 << ";nieskonczonosc)";
                }
            }
            return 0;
        }
    }
}
