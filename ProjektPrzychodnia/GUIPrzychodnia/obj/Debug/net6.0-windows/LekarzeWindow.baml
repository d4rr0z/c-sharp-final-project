   M S B A M L   `   `   `  ����I  EGUIPrzychodnia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GUIPrzychodniaGUIPrzychodnia  5   	   "    GUIPrzychodnia.LekarzeWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:GUIPrzychodnia     5   	     � Title$  Przychodnia��5      $	��600��6$   $
��1100��61    � WindowStyle$
 None=�6>    � WindowStartupLocation$ CenterScreen=�6Q    � 
ResizeMode$ NoResize=�6v   .��5	      � ���	#FFD6D6D6 � ColumnDefinitions 5
   
   �� 5      $	��225 �6   �� 5      $	��875 �6   .+�5   
   �� $
��Left=�6   $��20��6/   $	��Top=�6<   $
��1100��6T   ���	#FF08526B$��2��6r   �� 5   
   $��
Medic-stop��6   $
��Left=�6&   $	��Top=�6A   $��10,4,0,0q�6Y   $��Arial Rounded MT Bold)�6k   
�������6�   �� 5   
   -   5        $��X��5      $��Right=�64   $	��Top=�6P   $��1��6~   $��Arial Rounded MT Bold)�6�   $
��Bold"�6�   $��22��6�   $��23��6�   
���������6h   Z� ��6�   Z� 6�   �� 5   
   $��Center=�6   $	��580��61   $	��Top=�6>   $	��225��6V   ���	#FFE5B55C$��0,20,0,0q�6s   �� 5   
   -   5         ��Name$ 
bt_Pacient��5      $��Pacjenci��6?   $��Center=�6R   $	��Top=�6o   $��	0,262,0,0q�6�   $��Arial Rounded MT Bold)�6�   $��18(�6�   $	��225��6�   $��38��6�   ��6�   Z� ��6�   Z� �� 5   
   -   5        $ bt_Appointments��5      $��Wizyty��6I   $��Center=�6Z   $	��Top=�6w   $��	0,300,0,0q�6�   $��Arial Rounded MT Bold)�6�   $��18(�6�   $	��225��6�   $��38��6�   
���   ���6�   Z� ��6  Z� 6  �� 5   
   -   5        $ 
bt_Doctors��5      $��Lekarze��6?   $��Center=�6Q   $	��Top=�6n   $��	0,338,0,0q�6�   $��Arial Rounded MT Bold)�6�   $��18(�6�   $	��225��6�   $��38��6�   
���   ���6�   Z� ��6�   Z� 6  �� 5   
   -   5        $ 
bt_LoggOut��5      $��Wyloguj��6?   $��Center=�6Q   $	��Top=�6n   $��	0,543,0,0q�6�   $��Arial Rounded MT Bold)�6�   $��18(�6�   $	��225��6�   $��38��6�   ��6�   Z� ��6�   Z� �� 5   
   $��/Images/Doctor.png��6   $��22,343,163,224q�6,   �� 5   
   $$��/Images/icons8-calendar-50.png��6   $��22,303,163,264q�68   �� 5   
   $��/Images/Edit.png��6   $��22,264,163,305q�6*   �� 5   
   $��/Images/Medic_logo.png��6   $��Center=�60   $	��Top=�6M   $	��100��6e   $	��100��6r   $��0,37,0,0q�6~   �� 5   
   $��/Images/Login.png��6   $��23,546,162,22q�6+   �� 5    
   $��Center=�6   $��76��61   $	��225��6=   $	��Top=�6I   ���	#FFE3A636$��	0,158,0,0q�6r   �� 5!   
   $��/Images/User.png��6   $��2,165,143,373q�6*   �� 5"   
   $��Witaj!��6   $
��Left=�6!   $	��Top=�6<   $��
78,170,0,0q�6T   $��Tahoma)�6h   $��13(�6|   �� 5#   
   -   5         ��Name$ NameUser��5#      $�� ��6"   $
��Left=�6.   $	��Top=�6I   $��
78,196,0,0q�6a   $��Tahoma)�6u   $��13(�6�   $	��137��6�   �� 5&   
   $��Center=�6   $	��216��61   $��1��6>   $	��Top=�6N   $	��835��6f   ���	#FFFAFAFA$��0,37,0,0q�6�   ���	#FF8181816�   �� 5'   
   $��Lista lekarzy:��6   $
��Left=�6)   $	��Top=�6D   $��1��6\   $��Arial Rounded MT Bold)�6l   $��25(�6�   $��	35,46,0,0q�6�   $	��218��6�   �� 5(   
   -   5         ��Name$ 
lstLekarze��5(       �� SelectionMode$ Single=�6V   $��1��6m   $��	35,85,0,0q�6}   $
��Left=�6�   $	��Top=�6�   $	��145��6�   $	��443��6�   	 �� View	 5)      �� 5*      .P�5+      �� $��ID��6%   
 �� Width$
 60��6\    �� DisplayMemberBinding 61   �� *	IdLekarza+6\   �� 5,      $��Imię��6%   $	
 100��6Y    63   �� *Imie+6Y   �� 5-      $��Nazwisko��6%   $	
 140��6a    67   �� *
Nazwisko+6a   �� 5.      $��Specjalizacja��6%   $	
 130��6k    6<   �� *Specjalizacja+6k   5/      51      �� 53   
   -   5         ��Name$ ComboBoxSpecialization��53      $��1��64   $
��Left=�6D   $	��Top=�6_   $	��320��6w   $��505,116,0,0q�6�   $��28��6�   6�   �� 54   
   $��Wybierz specjalizacje:��6   $��1��63   $
��Left=�6C   $	��Top=�6^   $��
505,85,0,0q�6v   $	��175��6�   �� 55   
   -	   5        $ 
btn_Search��55      $��Wyszukaj��6>   $
��Left=�6Q   $	��Top=�6l   $��1��6�   $��625,206,0,0q�6�   $��Arial Rounded MT Bold)�6�   $��80��6�   $��28��6�   
���   ����	#FF08526B
�������6  �� 56   
   -
   5         ��Name$ 	txtSearch��56      $
��Left=�6&   $	��Top=�6A   $��1��6Y   $��505,176,0,0q�6i   $��Tahoma)�6~   $��13(�6�   $	��321��6�   $��23��6�   
���   �6�   �� 57   
   $��Wyszukaj lekarza:��6   $��1��6.   $
��Left=�6>   $	��Top=�6Y   $��505,145,0,0q�6q   $	��175��6�   �� 59   
   $��Center=�6   $	��300��61   $��1��6>   $	��Top=�6N   $	��835��6f   ���	#FFFAFAFA$��	0,281,0,0q�6�   ���	#FF8181816�   �� 5:   
   $��Profil��6   $
��Left=�6!   $	��Top=�6<   $��1��6T   $��Arial Rounded MT Bold)�6d   $��25(�6�   $��
35,290,0,0q�6�   $	��218��6�   �� 5;   
   -   5         ��Name$ imageDoctor��5;      $��Uniform=�6%   $	��183��67   $	��155��6D   $��1��6P   $
��Left=�6`   $	��Top=�6{   $��
52,343,0,0q�6�   �� 5<   
   -   5        $ 
NameDoctor��5<      $�� ��6$   $��1��60   $
��Left=�6@   $	��Top=�6[   $��224,343,0,0q�6s   $	��175��6�   $��20(�6�   $��Tahoma)�6�   $
��Bold"�6�   �� 5=   
   -   5        $ NameSpecialization��5=      $�� ��6,   $��1��68   $
��Left=�6H   $	��Top=�6c   $��224,377,0,0q�6{   $	��175��6�   $��Tahoma)�6�   $��17(�6�   �� 5>   
   -   5        $ NameTelephone��5>      $�� ��6'   $��1��63   $
��Left=�6C   $	��Top=�6^   $��224,413,0,0q�6v   $	��175��6�   $��Tahoma)�6�   $��15(�6�   �� 5?   
   -   5        $ lstWizyt��5?      $ Single=�6%   $��1��6<   $��498,303,0,0q�6L   $
��Left=�6a   $	��Top=�6|   $	��259��6�   $	��334��6�   	 5@      �� 5A      .P�5B      �� $��ID��6%   $
 60��6[    61   �� *
IdWizyty+6[   �� 5C      $��Pacjent��6%   $	
 120��66    �� CellTemplate 5D      �� 5E      .R�5F   "   �� �� 5G      �6"   �� *Pacjent.Imie+ �� 5H      $� ��6"    �� 5I      �6"   �� *Pacjent.Nazwisko+5J   #   5K      5M      �� 5N      $��Termin��6%   $	
 140��6]    65   �� *Termin+6]   5O      5Q      5R      5S      