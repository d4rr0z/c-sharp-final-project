   M S B A M L   `   `   `  ����I  EGUIPrzychodnia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GUIPrzychodniaGUIPrzychodnia  5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U<clr-namespace:System.Windows.Media;assembly=PresentationCoreSystem.Windows.Media 5   	       GUIPrzychodnia.MainWindow   5   	   \ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:GUIPrzychodnia     5   	   Nmedia<clr-namespace:System.Windows.Media;assembly=PresentationCore     5   	     � Title$  Panel Logowania��5	      $	��310��6)   $	��480��66   
������� � 
ResizeMode$ NoResize=�6U    � WindowStyle$
 None=�6k    � WindowStartupLocation$ CenterScreen=�6~   .��5
      � $	��480��6    � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $	��280 �6   .+�5   
   �� $��Center=�6   $	��310��61   $��Center=�6>   $	��200��6Y   ���	#FFE5B55C6e   �� 5   
   -   5        $��X��5      $��Right=�64   $	��Top=�6P   $��1��6~   $��Arial Rounded MT Bold)�6�   $
��Bold"�6�   $��22��6�   $��23��6�   ���	#FF020202��6h   Z� ��6�   Z� 6�   �� 5   
   $��1��6   $��Panel logowania��6    $
��Left=�6:   $	��Top=�6U   $��	46,35,0,0q�6m   $��Arial Rounded MT Bold)�6�   $��20(�6�   �� 5   
   $��1��6   $��Nazwa użytkownika:��6    $
��Left=�6=   $	��Top=�6X   $��	15,90,0,0q�6p   $��22��6�   $��99��6�   $��Tahoma)�6�   $��10(�6�   �� 5   
   $��1��6   $��Hasło:��6    $
��Left=�61   $	��Top=�6L   $��
15,138,0,0q�6d   $��20��6x   $��37��6�   $��Tahoma)�6�   $��10(�6�   �� 5   
   -   5         ��Name$ txtUsername��5      $��1��6'   $
��Left=�67   $	��Top=�6R    �� TextWrapping$
 Wrap=�6j   $��
40,112,0,0q�6~   $	��207��6�   $��23��6�   $��14(�6�   G� 5   
   -   5         G�Name$ PasswordBox��5      $��1��6+   $	��208��6;   $
��Left=�6G   $	��Top=�6b   $��
40,158,0,0q�6z   $��22��6�   �� 5   
   -   5        $ txtPassword��5      $��1��6'   $	��208��67   $
��Left=�6C   $	��Top=�6^   $��
40,158,0,0q�6v   $��22��6�   $y�	Collapsed=�6�    �� 
IsReadOnly$
 True��6�   �� 5   
   -   5        	 ��Name$	 revealModeCheckBox��5      $��1��6/   $��Pokaż hasło��6?   $��Right=�6U   $	��Top=�6q   $��
0,185,33,0q�6�   $��Tahoma)�6�   $��11(�6�   $��80��6�   $��15��6�   5   (   �� 5   
   -   5        
 ��Name$
 LogIn��5      $��Zaloguj��67   $��1��6J   $	��Top=�6Z   $��Center=�6r   $��	0,224,0,0q�6�   $	��128��6�   
����������	#FF08526B$��Arial Rounded MT Bold)�6�   $��24��6�   $
��Bold"�6  ��6  Z� �� 5   
   $��/Images/Medic_logo.png��6   $��Center=�60   $	��Top=�6M   $	��115��6e   $	��113��6r   $��0,35,0,0q�6~   �� 5   
   $��/Images/Account.png��6   $��1��6.   $	��Top=�6>   $
��Left=�6V    � Cursor$ AppStarting��6q   $��22��6�   $��26��6�   $��
15,112,0,0q�6�   �� 5   
   $��/Images/Lock.png��6   $��1��6+   $	��Top=�6;   $
��Left=�6S   $ AppStarting��6n   $��22��6�   $��26��6�   $��
15,158,0,0q�6�   5       5!      