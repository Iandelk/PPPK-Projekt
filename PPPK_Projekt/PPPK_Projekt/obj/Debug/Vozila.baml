   M S B A M L   `   `   `  ����G  CPPPK_Projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PPPK_ProjektPPPK_Projekt  5   	       PPPK_Projekt.Vozila   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:PPPK_Projekt     5   	   Z VGu.Wpf.NumericInput, Version=0.5.3.0, Culture=neutral, PublicKeyToken=e6e2e1b32408e0fd'numerichttp://gu.se/NumericInput  5   	     � Title$  Vozila��5	   	   $	��450��6   $	��800��6%    � 	Resources 5
          AlternatingListViewItemStyle �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%�   &	        �� 5   
   " ��65    5      P� 5       �@��AlternationIndex$ 1��6C   . �5      ��  � ��
 �����6H   5      5      5      .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5   
   �� $ Vertical=�6   .+�5      �� -   5        	 ��Name$	 
txt_Naslov��5   -   $��Dodaj Vozilo:��6   $��25(�6A   $��5q�6O   $
��Bold"�6Z   6n   �� 5      $ 
Horizontal=�6   $��5 20 5 5q�62   .+�5      �� $��17(�6   $
��Bold"�6*   $��Marka:��6<   $	��120��6J   6Y   �� 5      -   5        
 ��Name$
 tb_Marka��5   &   $	��140��6   6:   5      �� 5      $ 
Horizontal=�6   $��5 5 5 5q�62   .+�5      �� $��17(�6   $
��Bold"�6*   $
��Tip:��6<   $	��120��6H   6W   �� 5       -   5        $
 tb_Tip��5    &   $	��140��6   68   5!      �� 5"      $ 
Horizontal=�6   $��5 5 5 5q�62   .+�5#      �� $��17(�6   $
��Bold"�6*   $��Godina:��6<   $	��120��6K   6Z   *  $Gu.Wpf.NumericInput.SpinnerDecorator  5$         Child. 5%         Gu.Wpf.NumericInput.IntBox  -   5          Name$ 	tb_Godina��5%   N   $
��2019��6!   �  }Gu.Wpf.NumericInput.NumericBox`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   AllowSpinners . $	��115��6B      MinValue$
 1900X�6a   6s   5&      5'      �� 5(      $ 
Horizontal=�6   $��5 5 5 5q�62   .+�5)      �� $��17(�6   $
��Bold"�6*   $��Kilometraža:��6<   $	��120��6P   6_     5*      . 5+        -   5        $ tb_Kilometraza��5+   ]    .    	Increment$
 1000��66      Value$ 0X�6G   $	��115��6Q   6w   5,      5-      �� 5/      $ 
Horizontal=�6   $��Right=�62   $��5 5 5 5q�6N   .+�50      �� -   5         ��Name$ 
btn_Spremi��50      $��50��6-   $��25��68   $��5q�6D   $��Spremi��6O   6{   �� 51      -   5        $ 
btn_Obrisi��51      $��50��6-   $��25��68   $��Obriši��6D   6p   53      54      �� 56   
   $ Vertical=�6   .+�57      �� -   5        $��listView_Vozila��58   2    �� SelectionMode$ Single=�57      $��Disabled=�6[   $
��Auto=�6�   #��[  6�    �� AlternationCount$ 2��6  $
��Left=�6  $	��350��66  $��	10,10,0,0q�6E  $	��Top=�58   
   $	��490��6$    �� View 5:      �� 5;      -	   5        gridView_Vozila��.P�5?      �� $��Marka��6)    �� Width$	 120��5@       �� DisplayMemberBinding 5?   :   �� *Marka+5@      �� 5B      $	��Tip��6)   $	 120��5C       5B   8   �� *Tip+5C      �� 5E      $��Godina��6)   $	 130��5F       5E   ;   �� *Godina+5F      �� 5H      $��Početni Kilometri��6)   $	 120��5I       5H   F   �� *PocetniKilometri+5I      5K      5N      �� 5P      -
   5        $ 	DodajNovo��5P   H   $��90��6   $��35��6    $��Right=�6,   $��Dodaj Vozilo..��6s   $��5 10 5 5q�6�   5R      5T      5U      5V      