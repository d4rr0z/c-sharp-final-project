   M S B A M L   `   `   `  ����I  EGUIPrzychodnia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GUIPrzychodniaGUIPrzychodnia  5   	   #    GUIPrzychodnia.PacjenciWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:GUIPrzychodnia     5   	     � Title$  Przychodnia��5      $	��600��6%   $
��1100��62    � WindowStyle$
 None=�6?    � WindowStartupLocation$ CenterScreen=�6R    � 
ResizeMode$ NoResize=�6w   .��5	      � ���	#FFD6D6D6 � ColumnDefinitions 5   
   �� 5      $	��225 �6   �� 5      $	��875 �6   .+�5   
   �� $
��Left=�6   $��20��6/   $	��Top=�6<   $
��1100��6T   ���	#FF08526B$��2��6r   �� 5   
   $��
Medic-stop��6   $
��Left=�6&   $	��Top=�6A   $��10,4,0,0q�6Y   $��Arial Rounded MT Bold)�6k   
�������6�   �� 5   
   -   5        $��X��5      $��Right=�64   $	��Top=�6P   $��1��6~   $��Arial Rounded MT Bold)�6�   $
��Bold"�6�   $��22��6�   $��23��6�   
���������6h   Z� ��6�   Z� 6�   �� 5   
   $��Center=�6   $	��580��61   $	��Top=�6>   $	��225��6V   ���	#FFE5B55C$��0,20,0,0q�6s   �� 5   
   -   5         ��Name$ 
bt_LoggOut��5      $��Wyloguj��6?   $��Center=�6Q   $	��Top=�6n   $��	0,543,0,0q�6�   $��Arial Rounded MT Bold)�6�   $��18(�6�   $	��225��6�   $��38��6�   ��6�   Z� ��6�   Z� �� 5   
   -   5        $ 
bt_Pacient��5      $��Pacjenci��6?   $��Center=�6R   $	��Top=�6o   $��	0,262,0,0q�6�   $��Arial Rounded MT Bold)�6�   $��18(�6�   $	��225��6�   $��38��6�   ��6�   Z� ��6�   Z� �� 5   
   -   5        $ bt_Appointments��5      $��Wizyty��6I   $��Center=�6Z   $	��Top=�6w   $��	0,300,0,0q�6�   $��Arial Rounded MT Bold)�6�   $��18(�6�   $	��225��6�   $��38��6�   
���   ���6�   Z� ��6  Z� 6  �� 5   
   -   5        $ 
bt_Doctors��5      $��Lekarze��6?   $��Center=�6Q   $	��Top=�6n   $��	0,338,0,0q�6�   $��Arial Rounded MT Bold)�6�   $��18(�6�   $	��225��6�   $��38��6�   
���   ���6�   Z� ��6�   Z� 6  �� 5   
   $��/Images/Doctor.png��6   $��22,343,163,224q�6,   �� 5   
   $$��/Images/icons8-calendar-50.png��6   $��22,303,163,264q�68   �� 5   
   $��/Images/Edit.png��6   $��22,264,163,305q�6*   �� 5   
   $��/Images/Login.png��6   $��23,546,162,22q�6+   �� 5   
   $��/Images/Medic_logo.png��6   $��Center=�60   $	��Top=�6M   $	��100��6e   $	��100��6r   $��0,37,0,0q�6~   �� 5!   
   $��Center=�6   $��76��61   $	��225��6=   $	��Top=�6I   ���	#FFE3A636$��	0,158,0,0q�6r   �� 5"   
   $��/Images/User.png��6   $��2,165,143,373q�6*   �� 5#   
   $��Witaj!��6   $
��Left=�6!   $	��Top=�6<   $��
78,170,0,0q�6T   $��Tahoma)�6h   $��13(�6|   �� 5$   
   -   5         ��Name$ NameAndSurname��5$      $�� ��6(   $
��Left=�64   $	��Top=�6O   $��
78,196,0,0q�6g   $��Tahoma)�6{   $��13(�6�   $	��137��6�   �� 5'   
   $��Center=�6   $	��363��61   $��1��6>   $	��Top=�6N   $	��835��6f   ���	#FFFAFAFA$��0,37,0,0q�6�   ���	#FF8181816�   �� 5(   
   $��Lista pacjentów:��6   $
��Left=�6+   $	��Top=�6F   $��1��6^   $��Arial Rounded MT Bold)�6n   $��25(�6�   $��	35,46,0,0q�6�   $	��218��6�   �� 5)   
   -   5        $��lstPacjenci��5)       �� SelectionMode$ Single=�6V   $��1��6m   $��0,85,0,0q�6}   $��Center=�6�   $	��Top=�6�   $	��240��6�   $	��808��6�    �� View 5*      �� 5+      .P�5,      �� $��ID��6%   	 �� Width$	 70��6]   
 �� DisplayMemberBinding
 61   �� *
IdPacjenta+6]   �� 5-      $��Imię��6%   $		 100��6Y   
 63   �� *Imie+6Y   �� 5.      $��Nazwisko��6%   $		 170��6a   
 67   �� *
Nazwisko+6a   �� 5/      $��Data Urodzenia��6%   $		 100��6�   
 6=   �� *DataUrodzenia+ �� StringFormat$ {0:dd-MM-yyyy}��6�   �� 50      $��Pesel��6%   $		 110��6[   
 64   �� *Pesel+6[   �� 51      $��Telefon��6%   $		 110��6e   
 66   �� *NumerTelefonu+6e   �� 52      $��Płeć��6%   $	 30��6Y   
 63   �� *Plec+6Y   �� 53      $��Miasto��6%   $		 110��6]   
 65   �� *Miasto+6]   54      56      �� 57   
   -   5        $ 
btn_Search��57      $��Wyszukaj��6>   $
��Left=�6Q   $	��Top=�6l   $��1��6�   $��
35,325,0,0q�6�   $��Arial Rounded MT Bold)�6�   $	��109��6�   $��22��6�   
���   ����	#FF08526B
�������6  �� 58   
   -	   5         ��Name$ 	txtSearch��58      $
��Left=�6&   $	��Top=�6A   $��1��6Y   $��143,325,0,0q�6i   $��Tahoma)�6~   $��13(�6�   $	��698��6�   $��22��6�   
���   �6�   �� 5:   
   $��Center=�6   $	��174��61   $��1��6>   $	��Top=�6N   $	��835��6f   ���	#FFFAFAFA$��	0,416,0,0q�6�   ���	#FF8181816�   �� 5;   
   $��Imie:��6   $
��Left=�6    $	��Top=�6;   $��1��6S   $��131,439,0,0q�6c   $��Tahoma)�6x   $��13(�6�   �� 5<   
   -
   5        $ txtName��5<       �� TextWrapping$
 Wrap=�6#   $
��Left=�68   $	��Top=�6S   $��1��6k   $��176,443,0,0q�6{   $��Tahoma)�6�   $��13(�6�   $	��129��6�   �� 5=   
   $��	Nazwisko:��6   $
��Left=�6$   $	��Top=�6?   $��1��6W   $��103,470,0,0q�6g   $��Tahoma)�6|   $��13(�6�   �� 5>   
   -   5        $ 
txtSurname��5>      $
 Wrap=�6&   $
��Left=�6;   $	��Top=�6V   $��1��6n   $��176,473,0,0q�6~   $��Tahoma)�6�   $��13(�6�   $	��129��6�   �� 5?   
   $��Pesel:��6   $
��Left=�6!   $	��Top=�6<   $��1��6T   $��127,499,0,0q�6d   $��Tahoma)�6y   $��13(�6�   �� 5@   
   -   5        $ txtPesel��5@      $
 Wrap=�6$   $
��Left=�69   $	��Top=�6T   $��1��6l   $��176,503,0,0q�6|   $��Tahoma)�6�   $��13(�6�   $	��129��6�   �� 5A   
   $��Data urodzenia:��6   $
��Left=�6*   $	��Top=�6E   $��1��6]   $��331,439,0,0q�6m   $��Tahoma)�6�   $��13(�6�   �� 5B   
   -   5        $ txtDateOfBirth��5B      $
 Wrap=�6*   $
��Left=�6?   $	��Top=�6Z   $��1��6r   $��437,443,0,0q�6�   $��Tahoma)�6�   $��13(�6�   $	��130��6�   �� 5C   
   $��Płeć:��6   $
��Left=�6    $	��Top=�6;   $��1��6S   $��133,530,0,0q�6c   $��Tahoma)�6x   $��13(�6�   �� 5D   
   $��Telefon:��6   $
��Left=�6#   $	��Top=�6>   $��1��6V   $��375,470,0,0q�6f   $��Tahoma)�6{   $��13(�6�   �� 5E   
   -   5        $ txtTelephone��5E      $
 Wrap=�6(   $
��Left=�6=   $	��Top=�6X   $��1��6p   $��437,473,0,0q�6�   $��Tahoma)�6�   $��13(�6�   $	��130��6�   �� 5F   
   -   5         ��Name$ comboGender��5F      $
��Left=�6(   $	��Top=�6C   $��1��6[   $��176,534,0,0q�6k   $��Tahoma)�6�   $��13(�6�   $	��129��6�   .@�5G      �� -   5         ��Name$ M��5G      $��Mężczyzna��6&    �� 
IsSelected$
 True��6:   �� 5H      -   5        $ K��5H      $��Kobieta��6&   5I      �� 5J   
   $��Miasto:��6   $
��Left=�6"   $	��Top=�6=   $��1��6U   $��381,499,0,0q�6e   $��Tahoma)�6z   $��13(�6�   �� 5K   
   -   5        $ txtCity��5K      $
 Wrap=�6#   $
��Left=�68   $	��Top=�6S   $��1��6k   $��438,503,0,0q�6{   $��Tahoma)�6�   $��13(�6�   $	��130��6�   �� 5M   
   -   5        $ btn_Add��5M      $��Dodaj��68   $
��Left=�6H   $	��Top=�6c   $��1��6{   $��670,437,0,0q�6�   $��Arial Rounded MT Bold)�6�   $��15(�6�   $	��119��6�   $��36��6�   ���	#FF08526B
���������6�   Z� 6  �� 5N   
   -   5        $ 
btn_Update��5N      $��Zaktualizuj��6>   $
��Left=�6T   $	��Top=�6o   $��1��6�   $��670,488,0,0q�6�   $��Arial Rounded MT Bold)�6�   $��15(�6�   $	��120��6�   $��36��6�   ���	#FF08526B
���������6�   Z� 6#  �� 5O   
   -   5        $ 
btn_Delate��5O      $��Usuń��6?   $
��Left=�6N   $	��Top=�6i   $��1��6�   $��127,357,0,0q�6�   $��Arial Rounded MT Bold)�6�   $��15(�6�   $	��173��6�   $��36��6�   ���	#FF08526B
���������6�   Z� 6  �� 5P   
   -   5        $ 	btn_Clear��5P      $��	Wyczyść��6<   $
��Left=�6N   $	��Top=�6i   $��1��6�   $��670,538,0,0q�6�   $��Arial Rounded MT Bold)�6�   $��15(�6�   $	��120��6�   $��36��6�   ���	#FF08526B
���������6�   Z� 6  �� 5Q   
   -   5        $ btn_Sort��5Q      $��Sortuj po Nazwisku��6;   $
��Left=�6X   $	��Top=�6s   $��1��6�   $��367,357,0,0q�6�   $��Arial Rounded MT Bold)�6�   $��15(�6�   $	��173��6�   $��36��6�   ���	#FF08526B
������� J� RenderTransformOrigin$ 	0.462,0.5&�6:  ��6�   Z� 6:  �� 5R   
   -   5        $ btn_Sort_Id��5R      $��Sortuj po ID��6A   $
��Left=�6X   $	��Top=�6s   $��1��6�   $��592,357,0,0q�6�   $��Arial Rounded MT Bold)�6�   $��15(�6�   $	��173��6�   $��36��6�   ���	#FF08526B
���������6�   Z� 6'  5S      5T      