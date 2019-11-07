
#include <iostream>
#include <cmath>
#include <math.h>
#include <ccomplex>
#include <complex>
#include <stdio.h>
#include <stdlib.h>
void calculate();
namespace pi{


	double const pi = 3.1415926535897932384626433832795; 


}
namespace e{

double const e = 2.718;


}
using namespace std;


int main(){
	char nth;
	char exit;
	char nthroot;
	char controls;
	char colors;
	char coptions;
	char optional;
	char settings;
	char options;
	char formulas;
	char choose;
	char YN1;
	char YN2;
	char YN3;
	char YN4;
	char YN5;
	char Converter_Settings;
	double num1,num2;
	double sum = 0;
	char DOR;

	
	cout << "Do you want to see the options or start doing calculations" << endl << "Press S for settings,for the calculations press C"<< endl;
	cin >> optional;
	switch (optional)
	{
	case 83:
		cout << "Press C for colors" << endl;
		cout << "Press S for settings " << endl;
		cin >> settings;
		switch (settings)
		{
		case 67:
color:

			cout << "Pick your color you want!"<< endl << "1)White & Black(original)" <<endl<< "2)Blue & Yellow" << endl << "3)Red & Yellow" <<endl<< "4)Red & Blue" << endl;
			cin >> colors;
			switch (colors)
			{
			case 49:
				system("COLOR 07");
				cout << "Do you like this color" << endl;
				cin >> YN1;
				switch (YN1)
			    {
			        case 78:
			         goto color;
				     break;
			        case 89:
				     goto begin;
				     break;
				default:
					cout << "Does not compute!!!" << endl;
					break;
				}
				break;
			case 50:
				system("COLOR 16");
				cout << "Do you like this color" << endl;
				cin >> YN2;
				switch (YN2)
				{
				case 78:
					goto color;
					break;
				case 89:
					goto begin;
					break;
				default:
					cout << "Does not compute!!!" << endl;
					break;
				}
				break;
			case 51:
				system("COLOR 46");
				cout << "Do you like this color " << endl;
				cin >> YN3;
				switch (YN3)
				{
				case 78:
					goto color;
					break;
				case 89:
					goto begin;
					break;
				default:
					cout << "Does not compute!!!" << endl;
					break;
				}
				break;
			case 52:
				system("COLOR 41");
				cout << "Do you like this color " << endl;
				cin >> YN4;
				switch (YN4)
				{
				case 78:
					goto color;
					break;
				case 89:
					goto begin;
					break;
				default:
					cout << "Does not compute!!!" << endl;
					break;
				}
				break;
			case 53:
				system("COLOR 70");
				cout << "Do you like this color" << endl;
				cin >> YN5;
				switch (YN5)
			    {
			     case 78:
			      goto color;
				  break;
			    case 89:
				 goto begin;
				 break;
				default:
					cout << "Does not compute!!!" << endl;
					break;
				}
			default:
				cout << "Does not compute!!!" << endl;
				break;
			}
			break;
		case 83:
			cout << "Press + for addition" << endl << "Press * for multiplication" << endl << "Press - for subtraction" << endl << "Press / for division" << endl << "Press Q(must be uppercase) for square root" 
				<< endl << "Press S(must be uppercase) for squared" << endl << "Press I(must be uppercase) for sin" << endl << "Press O(must be uppercase) for cos " << endl << "Press T(must be uppercase) for tan"
				<< endl << "Press U(must be uppercase) for sinh" << endl << "Press V(must be uppercase) for cosh" << endl << "Press W(must be uppercase) for tanh" << endl << "Press A(must be uppercase)for atan"
				<< endl << "Press B(must be uppercase) for asin"<< endl << "Press D(must be uppercase) for acos" << endl << "Press L(must be uppercase) for log(Logarithm function) " << endl
				<< "Press K(must be uppercase) for the cubic answer of a number" << endl << "Press N(must be uppercase)for exp" << endl << "Press J(must e uppercase) for te cubic root"<<endl << "Press Y(must be uppercase) for the fourth" << 
				endl << "Press Z(must be uppercase) for the fourth root " <<endl<<"Press R(must be uppercase) for the nthroot"<< endl<< "Press F(must be uppercase) for floor" << endl << "Press H(must be uppercase) for the nth of a number" << endl
				<< "Press h(must be lowercase) for the hypotenuse" << endl <<"Press l(must be lowercase) for log10" << endl << "Press f(must be lowercase) for fmod" << endl << "Press p(must be lowercase) for pow" << endl
				<< "Press % for the converter "<< endl << "Press a (must be lowercase) for absolute value "<< endl;
		 

			goto begin;
			break;
		default:
			cout << "Does not compute!!!" << endl;
			break;
		}
		break;
		case 67:
			goto begin;
			break;
	default:
		cout << "Does not compute!!!" << endl;
		break;
	}
		
	
	
	if(optional = 67){
	
	
begin:

	if (options = 67){ 
	do
	{

		cout << "Enter a x value" << flush;
	    cin >> num1;
	    cout << "Enter a y value" << flush;
	    cin >> num2;

		cout << "Choose your operator" << endl << "1)+,-,*,/;" << endl << "2)sqr,sqrt,cubic,cbrt,fourth,frrt,nthroot,nth,absolute"<< endl << "3)sin,cos,tan,hypot" << endl << "4)sinh,cosh,tanh" << endl <<"5)asin,acos,atan"<<endl<<"6)log,log10"<<endl<< "7)exp,floor,fmod" << endl << "8)Constants" << endl << "9)Formulas" << endl << "10)Converter" << endl;
		cin >> choose;
		switch (choose)
		{
		case 43:
			{
			sum = num1 + num2;
			cout << num1  << "+" << num2 << "=" << sum << endl;
			}
			break;
		case 45:
			{
			
				sum = num1 - num2;
				cout << num1 << "-" << num2 << "=" << sum << endl;


			}
			break;
		

		case 42:
			{
			
				sum = num1 * num2;
				cout << num1 << "*" << num2 << "=" << sum << endl;

			}
			break;
		case 47:
			{
			
				if(num2 == 0){
				
					cout << "Invalid" << endl;
				
				}
				else{
				
					sum = num1 / num2;
					cout << num1 << "/" << num2 << "=" << sum  << endl;

				}

			}
			break;
		case 83:
			sum= num1 * num1;
			cout << num1    << "  on squared is  " <<   sum << endl;
			break;
		case 97:
			sum = abs(num1);
			cout << "The absolute value is "<< sum << endl;
			break;
		case 81:
			sum = sqrt(num1);
			cout << "The squared root of   " << num1 << "   is equal to  " << sum << endl;
			break;
		case 113:
			sum = sqrt(num1);
			cout << "The squared root of   " << num1 << "   is equal to  " << sum << endl;
			break;
		case 115:
			sum= num1 * num1;
			cout << num1    << "  on squared is  " <<   sum << endl;
			break;
		case 84:
			sum = tan(num1);
			cout << "The tangent of  " << num1 << "  is  " << sum << endl;
			break;
		case 79:
			sum = cos(num1);
			cout << "The cosine of " << num1 << "  is  " << sum << endl;
			break;
		case 73:
			sum = sin(num1);
			cout << "The sine of " << num1 << "  is  " << sum << endl;
		case 56:
			cout <<"The value of PI is   " << pi::pi << endl << "The value of Euler's constant is  " << e::e << endl; 
			break;
		case 85:
			sum = sinh(num1);
			cout << "The sinh of  " << num1 << "  is   " << sum << endl;
			break;
		case 86:
			sum = cosh(num1);
			cout << "The cosh of   " << num1 << "  is  "<< sum << endl;
			break;
		case 87:
			sum = tanh(num1);
			cout << "The tanh of  " << num1 << "   is  " << sum << endl;
			break;
		case 65:
			sum = atan(num1);
			cout << "The atan of  " << num1 << "   is    " << sum << endl;
			break;
		case 66:
			sum = asin(num1);
			cout << "The asin of  " << num1 << "  is  " <<sum << endl;
			break;
		case 68:
			sum = acos(num1);
			cout << "The acos of " << num1 << "  is  " << sum << endl;
			break;
		case 76:
			sum = log(num1);
			cout << "The log of " << num1 << "  is  " << sum << endl;
			break;
		case 75:
			sum = num1 * num1 * num1;
			cout << "The result is " << sum << endl;
			break;
		case 78:
			sum = exp(num1);
			cout << "The exp of " << num1 << "   is     " << sum << endl;
			break;
		case 74:
			sum = pow(num1, 1/3.);
			cout << "The cubic root of " << num1 << " is  " << sum << endl;
			break;
		case 89:
			sum = num1 * num1 * num1 * num1;
			cout << "The answer is " << sum << endl;
			break;
		case 112:
			sum = pow(num1,num2);
			cout << "The answer is "<< sum << endl;
			break;
		case 90:
			sum = pow(num1, 1/4.);
			cout << "The answer is " << sum << endl;
			break;
		
		case 82:
			cout << "Choose what number you want to place n (you can only choose from 5 to 9)" << endl;
			cin >> nthroot;
			switch (nthroot)
			{
			case 53:
				sum = pow(num1, 1/5.);
				cout << "The result is " << sum << endl;
				break;
			case 54:
				sum = pow(num1, 1/6.);
				cout << "The result is " << sum << endl;
				break;
			case 55:
				sum = pow(num1, 1/7.);
				cout << "The result is " << sum << endl;
				break;
			case 56:
				sum = pow(num1, 1/8.);
				cout << "The result is " << sum << endl;
				break;
			case 57:
				sum = pow(num1, 1/9.);
				cout << "The result is " << sum << endl;
				break;
			default:
				goto not;
				break;
			}
		case 70:
			sum = floor(num1);
			cout << "The result is " << sum << endl;
			break;
		case 72:
			cout << "Choose which number to place in n(from 5 to 9)" << endl;
			cin >> nth;
			switch (nth)
			{
			case 53:
				sum = num1*num1*num1*num1*num1;
				cout << "The result is " << sum << endl;
				break;
			case 54:
				sum = num1*num1*num1*num1*num1*num1;
				cout << "The result is "<< sum << endl;
				break;
			case 55:
				sum = num1*num1*num1*num1*num1*num1*num1;
				cout << "The result is "<< sum << endl;
				break;
			case 56:
				sum = num1*num1*num1*num1*num1*num1*num1*num1;
				cout << "The result is "<< sum <<endl;
				break;
			case 57:
				sum = num1*num1*num1*num1*num1*num1*num1*num1*num1;
				cout << "The result is "<< sum << endl;
				break;
			default:
				cout << "Does not compute"<< endl;
				break;
			}
		case 104:
			sum = hypot(num1,num2);
			cout << "The hypotenuse is " << sum << endl;
			break;
		case 108:
			sum = log10(num1);
			cout << "The base 10 logartihm is " << sum << endl;
			break;
		case 102:
			sum = fmod(num1,num2);
			cout << "The the fmod of " << num1 << "  is  " << sum << endl;
			break;
		case 57:
			cout << "Choose which formulas do you want to see"<<endl<<"1)Basic"<<endl<<"2)Trig functions" << endl;
			cin >> formulas;
			switch (formulas)
			{
			case 66:
				cout << "1)a+b=c" << endl << "2)c-b=a" << endl << "3)a*b=c" << endl << "4)c/b=a" << endl;
				break;
			case 67:
				cout << "1)sin a = oppsite/hypotenuse"<< endl << "2)cos a = addjecent/hypotenuse" << endl << "3)tan a = oppsite/addjecent" << endl << "Memory trick:SOH CAH TOA" << endl;
				break;
			default:
				cout << "Does not compute"<< endl;
				break;
			}
			break;
		case 37:
			cout << "See how the converter works(Press uppercase H) or go to the converter (Press uppercase C)" << endl;
			cin >> Converter_Settings;
			switch (Converter_Settings)
			{
			case 67:
				goto converter;
				break;
				case 72:
					cout << "First it will ask you:Should I convert from Degrees or Radians" << endl << "To convert to Degrees press uppercase D" << endl << "To convert to Radians press uppercase R" << endl;
					goto converter;
					break;
			default:
				cout << "Does not compute!!!" << endl; 
				break;
			}
converter:
			cout << "Should I convert from Degrees or Radians" << endl;
			cin >> DOR;
			switch (DOR)
			{
			case 68:

				sum = num1 * (pi::pi /180);
				cout << "The result is "<< sum << endl;
				break;
			case 82:
				sum = pi::pi/num1 * (180/pi::pi);
				cout << "The result is " << sum << endl;
				break;
			default:
				cout << "Does not compute" << endl;
				break;
			
			}
			break;
		default:
not:
			cout << "Operator does not exist" << endl; 

			break;
		}
EorC:
		cout << "Do you want to exit or do more calculations" << endl;
		cin >> exit;
		switch (exit)
		{
		case 67:
			goto begin;
			break;
		case 69:
			goto exit;
			break;
		default:
			cout << "Does not compute" << endl;
			goto EorC;
			break;
		}

	} while ((choose != '+') && (choose != '-') && (choose != '*') && (choose = '/') );
 }
exit:

	system("pause");
	cin.get();
	return 0;
}
}
