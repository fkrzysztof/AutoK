   M S B A M L   `   `   `  ����D  @MVVMFirma, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:MVVMFirma.ViewsMVVMFirma.Views  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5           MVVMFirma.Views.AdresyView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:MVVMFirma.Views     5      9System&clr-namespace:System;assembly=mscorlib     5        � 	Resources  5       �� Source�� 5   
   $ MainWindowResources.xaml?�6   %    .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��0��6!    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $
��auto �6#    5      �� 5      $
��auto �6    .+�5!      �� $��0��6   $��0��6%   $F��@/MVVMFirma;component/Content/Grafika/business-cards-database.png��62      imageStyleTop#��[  6|   �� 5"      $��1��6   $��0��6%   $��Książka Adresowa��63     LabelBig#��[ 6N   5$      c� 5(   
   $��1��6   .@�5)      d� $��Dodaj��6     ToolbarButtonStyle#��[ 5*      d� 5+      $��Usuń��6   #��[ 5,      d� 5-      $��Edytuj��6   #��[ 5.      5/      9� 51   
   $��2��6   $��Filtr aktywny��6      Expander10Up#��[ 67   .��52      � 
������� 53      �� 54      �� 55      �� 56      �� 57      �� 58      �� 59       5<      �� 5=      �� 5>      $
��auto �6'   �� 5?      $	��100 �6'   �� 5@      $	��100 �6'   �� 5A      $	��100 �6'   �� 5B      $��50 �6'   �� 5C      �� 5D      �� 5E      .+�5H      �� $��0��6   $��0��6%   $��Rodzaj kontaktu��5I        LabelNormal#��[ 5J      �� 5K      $��0��6   $��2��6(   $��3��68     ComboBoxStyle#��[ 5L      .@�5M      �� $��Wybierz��6#   �� 5N      $��Dostawcy��6#   �� 5O      $��Klienci��6#   �� 5P      $��
Pracownicy��6#   5Q      �� 5V      $��1��6   $��0��6(   $
��Imie��68     CheckBoxStyle#��[ 5W      �� 5Z      $��1��6   $��2��6'     TextBoxStyle#��[ 5[      �� 5\      $��1��6   $��3��6%   $��	Nazwisko:��65   #��[ 5]      �� 5^      $��1��6   $��4��6'     ListBoxStyle#��[ 5_      �� 5g      $��2��6   $��0��6(   $��Nazwa Firmy:��5h      #��[ 5i      �� 5l      $��2��6   $��2��6'   $��2��67   #��[ 5m      �� 5s      $��3��6   $��0��6(   $��Lokalizacja:��5t      #��[ 5u      �� 5x      $��3��6   $��2��6'   $��2��67   #��[ 5y      �� 5      $��4��6   $��0��6(   $��Data utworzenia:��68   #��[ 5�      (  "System.Windows.Controls.DatePicker  5�      $��4��6   $��2��6*   $��2��6:    	 DatePickerStyle#��[	 5�      5�      5�      &   System.Windows.Controls.DataGrid  5�   
   $��3��6    
 DataGrid#��[
 6       AutoGenerateColumns .  ��5�   /   �� *KontrahenciList+   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$
 Imie��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Imie+  5�      $ Nazwisko��6%    67   �� *
Nazwisko+  5�      $ Firma��6%    64   �� *Nazwa+  5�      $ 	Telefon 1��6%    68   �� *
Telefon1+  5�      $ 	Telefon 2��6%    68   �� *
Telefon2+  5�      $ Email 1��6%    66   �� *Email1+  5�      $ Email 2��6%    66   �� *Email2+5�      5�      5�      